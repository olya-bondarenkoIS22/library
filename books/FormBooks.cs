using books.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            colPhoto.FillWeight = 25;

            var colInfoBook = new DataGridViewTextBoxColumn();
            colInfoBook.Name = "colInfoBook";
            colInfoBook.FillWeight = 55;
            colInfoBook.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoBook.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            colInfoBook.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            var colInfoCount = new DataGridViewTextBoxColumn();
            colInfoCount.Name = "colInfoCount";
            colInfoCount.FillWeight = 20;
            colInfoCount.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colInfoCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colInfoCount.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            colInfoCount.DefaultCellStyle.Padding = new Padding(5);

            dataGridViewBook.Columns.AddRange(
                colPhoto,
                colInfoBook,
                colInfoCount
            );

            LoadBooks();
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
                        row.Cells["colPhoto"].Value = LoadProductImage(book.AddPhotoUrlToSportingGoods);
                        row.Cells["colInfoProduct"].Value = FormatBookInfo(book);
                        row.Cells["colInfoDiscount"].Value = $"{}%";

                        //ApplyRowStyles(row, book);
                    }

                    dataGridViewBook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridViewBook.ResumeLayout();

                    dataGridViewBook.ClearSelection();
                    //selectedGood = null;
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private object? FormatBookInfo(object product)
        {
            throw new NotImplementedException();
        }

        private Image LoadProductImage(string photoUrl)
        {
            if (!String.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }

            return Resources.picture;
        }
    }
}
