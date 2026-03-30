using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace books
{
    public partial class FormOrders : Form
    {
        public models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        //private Order selectedOrder;
        public FormOrders(models.User user, bool quest, string currentRole)
        {
            InitializeComponent();

            dataGridViewHistory.AutoGenerateColumns = false;
            dataGridViewHistory.RowHeadersVisible = false;

            dataGridViewHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var colUserBook = new DataGridViewTextBoxColumn();
            colUserBook.Name = "colUserBook";
            colUserBook.FillWeight = 20;
            colUserBook.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colDateOfIssue = new DataGridViewTextBoxColumn();
            colDateOfIssue.Name = "colDateOfIssue";
            colDateOfIssue.FillWeight = 50;
            colDateOfIssue.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colPlannedReturnDate = new DataGridViewTextBoxColumn();
            colPlannedReturnDate.Name = "colPlannedReturnDate";
            colPlannedReturnDate.FillWeight = 50;
            colPlannedReturnDate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colActualReturnDate = new DataGridViewTextBoxColumn();
            colActualReturnDate.Name = "colActualReturnDate";
            colActualReturnDate.FillWeight = 50;
            colActualReturnDate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.FillWeight = 50;
            colStatus.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewHistory.Columns.AddRange(
           [
                colUserBook, 
                colDateOfIssue, 
                colPlannedReturnDate, 
                colActualReturnDate, 
                colStatus
           ]);

            CurrentUser = user;
            IsGuest = quest;

            if (currentRole == "Библиотекарь")
            {
                buttonCreate.Visible = false;
                buttonUpdate.Visible = false;
                panel.Visible = false;
                dataGridViewHistory.Dock = DockStyle.Fill;
            }

            dataGridViewHistory.Columns["colUserBook"].HeaderText = "Данные";
            dataGridViewHistory.Columns["colDateOfIssue"].HeaderText = "Дата выдачи";
            dataGridViewHistory.Columns["colPlannedReturnDate"].HeaderText = "Планируемая дата возвращения";
            dataGridViewHistory.Columns["colActualReturnDate"].HeaderText = "Фактическая дата возврата";
            dataGridViewHistory.Columns["colStatus"].HeaderText = "Статус";

            LoadHistory();
        }
        private void LoadHistory()
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var books = db.BookLoans
                        .Include(i => i.IdStatusNavigation)
                        .Include(i => i.IdBookNavigation)
                        .Include(i => i.IdUserNavigation)
                        .OrderBy(p => p.Id)
                        .ToList();

                    dataGridViewHistory.SuspendLayout();
                    dataGridViewHistory.Rows.Clear();

                    foreach (var book in books)
                    {
                        int rowIndex = dataGridViewHistory.Rows.Add();
                        var row = dataGridViewHistory.Rows[rowIndex];

                        row.Cells["colUserBook"].Value = LoadUserBook(book);
                        row.Cells["colDateOfIssue"].Value = $"{book.DateOfIssue:dd.MM.yyyy}";//LoadDateOfIssue(book.DateOfIssue);
                        row.Cells["colPlannedReturnDate"].Value = $"{book.PlannedReturnDate:dd.MM.yyyy}";
                        row.Cells["colActualReturnDate"].Value = $"{book.ActualReturnDate:dd.MM.yyyy}";
                        row.Cells["colStatus"].Value = $"{book.IdStatusNavigation.StatusName}";

                        // Подсветка просроченных книг (книга выдана более 30 дней назад и еще не возвращена)
                        // Если DateOfIssue не nullable
                        if (book.ActualReturnDate == null && book.DateOfIssue.HasValue)
                        {
                            // Альтернативный способ вычисления разницы дат
                            DateTime currentDate = DateTime.Now.Date;
                            DateTime dateOfIssue = new DateTime(book.DateOfIssue.Value.Year,
                                                               book.DateOfIssue.Value.Month,
                                                               book.DateOfIssue.Value.Day);
                            TimeSpan daysSinceIssue = currentDate - dateOfIssue;
                            if (daysSinceIssue.TotalDays > 30)
                            {
                                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA"); // #D4EDDA
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LoadUserBook(BookLoan bookLoan)
        {
            return $"Читатель: {bookLoan.IdUserNavigation.FullName}" + Environment.NewLine +
                $"Книга: {bookLoan.IdBookNavigation.BookName}";
        }
    }
}
