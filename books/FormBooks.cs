using books.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace books
{
    public partial class FormBooks : Form
    {
        public models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        private string currentUserRole;
        private BookLoan selectedBook;
        public FormBooks(models.User user, bool quest)
        {
            InitializeComponent();
            CurrentUser = user;
            IsGuest = quest;
            labelFullName.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            dataGridViewBook.AutoGenerateColumns = false;
            dataGridViewBook.RowHeadersVisible = false;

            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 20;

            var colInfoBook = new DataGridViewTextBoxColumn();
            colInfoBook.Name = "colInfoBook";
            colInfoBook.FillWeight = 60;
            colInfoBook.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoBook.DefaultCellStyle.Font = new Font("Times New Roman", 16, FontStyle.Regular);
            colInfoBook.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            var colInfoCount = new DataGridViewTextBoxColumn();
            colInfoCount.Name = "colInfoCount";
            colInfoCount.FillWeight = 20;
            colInfoCount.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colInfoCount.DefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            colInfoCount.DefaultCellStyle.Padding = new Padding(5);

            dataGridViewBook.Columns.AddRange(
                colPhoto,
                colInfoBook,
                colInfoCount
            );
            LoadRole();

            if (IsGuest)
            {
                buttonOrders.Visible = false;
                buttonCreate.Visible = false;
                buttonUpdate.Visible = false;
                buttonDelete.Visible = false;
            }
            if (currentUserRole == "Библиотекарь")
            {
                buttonCreate.Visible = false;
                buttonUpdate.Visible = false;
                buttonDelete.Visible = false;
            }
            dataGridViewBook.Columns["colPhoto"].HeaderText = "Изображение";
            dataGridViewBook.Columns["colInfoBook"].HeaderText = "Информация о книге";
            dataGridViewBook.Columns["colInfoCount"].HeaderText = "Всего / Доступно";
            LoadBooks();
        }
        private void LoadRole()
        {
            if (!IsGuest)
            {
                currentUserRole = CurrentUser.IdRoleNavigation.RoleName;
            }
        }

        private void LoadBooks()
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var books = db.Books
                        .Include(p => p.IdAuthorNavigation)
                        .Include(p => p.IdGenreNavigation)
                        .Include(p => p.IdPublisherNavigation)
                        .OrderBy(p => p.Id)
                        .ToList();
                    dataGridViewBook.SuspendLayout();
                    dataGridViewBook.Rows.Clear();

                    foreach (var book in books)
                    {
                        int rowIndex = dataGridViewBook.Rows.Add();
                        var row = dataGridViewBook.Rows[rowIndex];

                        // Сохраняем объект товара в Tag строки для удобства
                        row.Tag = book;
                        row.Cells["colPhoto"].Value = LoadProductImage(book.PhotoUrl);
                        row.Cells["colInfoBook"].Value = FormatBookInfo(book);
                        row.Cells["colInfoCount"].Value = $"{book.Total} / {book.Avaiable}";

                        if (book.Avaiable == 0)
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCCCC");
                        }
                        else if (book.Avaiable == 1 || book.Avaiable == 2)
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                        }

                        //ApplyRowStyles(row, book);
                    }

                    dataGridViewBook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridViewBook.ResumeLayout();

                    dataGridViewBook.ClearSelection();
                    //selectedGood = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string FormatBookInfo(Book book)
        {
            return $"{book.Isbn} | {book.BookName}" + Environment.NewLine +
                $"Автор: {book.IdAuthorNavigation.AuthorName}" + Environment.NewLine +
                $"Жанр: {book.IdGenreNavigation.GenreName}" + Environment.NewLine +
                $"Издатель: {book.IdPublisherNavigation.PublisherName}" + Environment.NewLine +
                $"Год: {book.Year}" + Environment.NewLine +
                $"Количество страниц: {book.Pages}" + Environment.NewLine +
                $"Аннотация: {book.Annotation}";
        }

        private Image LoadProductImage(string photoUrl)
        {
            if (!String.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }

            return Resources.picture;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            if (!IsGuest)
            {
                FormOrders ordersForm = new FormOrders(CurrentUser, IsGuest, currentUserRole);
                ordersForm.ShowDialog();
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
