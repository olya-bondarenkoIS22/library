using books.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private Book selectedBook;

        private string searchText = "";
        private string sortOrder = "asc"; 
        private int? selectedPublisherId = null;

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

            if (IsGuest || currentUserRole == "Библиотекарь")
            {
                buttonOrders.Visible = !IsGuest; 
                buttonCreate.Visible = false;
                buttonUpdate.Visible = false;
                buttonDelete.Visible = false;
                panelSearchFilter.Visible = false; 
            }

            if (currentUserRole == "Администратор")
            {
                buttonOrders.Visible = true;
                buttonCreate.Visible = true;
                buttonUpdate.Visible = true;
                buttonDelete.Visible = true;
                panelSearchFilter.Visible = true; 
                InitializeSearchFilter();
            }

            dataGridViewBook.Columns["colPhoto"].HeaderText = "Изображение";
            dataGridViewBook.Columns["colInfoBook"].HeaderText = "Информация о книге";
            dataGridViewBook.Columns["colInfoCount"].HeaderText = "Всего / Доступно";
            ConfigureDgvProducts();
            LoadBooks();
        }

        private void InitializeSearchFilter()
        {
            using (var db = new LibraryContext())
            {
                var publishers = db.Publishers.OrderBy(p => p.PublisherName).ToList();

                var publisherList = new List<models.Publisher> { new models.Publisher { Id = 0, PublisherName = "Все издатели" } };
                publisherList.AddRange(publishers);

                comboBoxPublisherFilter.DataSource = publisherList;
                comboBoxPublisherFilter.DisplayMember = "PublisherName";
                comboBoxPublisherFilter.ValueMember = "Id";

                comboBoxPublisherFilter.SelectedIndex = 0;
            }

            comboBoxSort.Items.Clear();
            comboBoxSort.Items.Add("По возрастанию (по количеству)");
            comboBoxSort.Items.Add("По убыванию (по количеству)");
            comboBoxSort.SelectedIndex = 0;

            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            comboBoxSort.SelectedIndexChanged += comboBoxSort_SelectedIndexChanged;
            comboBoxPublisherFilter.SelectedIndexChanged += comboBoxPublisherFilter_SelectedIndexChanged;
            if (buttonResetFilters != null)
                buttonResetFilters.Click += buttonResetFilters_Click;
        }

        private void LoadRole()
        {
            if (!IsGuest)
            {
                currentUserRole = CurrentUser.IdRoleNavigation.RoleName;
            }
            else
            {
                currentUserRole = "Гость";
            }
        }

        private void LoadBooks()
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var query = db.Books
                        .Include(p => p.IdAuthorNavigation)
                        .Include(p => p.IdGenreNavigation)
                        .Include(p => p.IdPublisherNavigation)
                        .AsQueryable();

                    if (currentUserRole == "Администратор" && selectedPublisherId.HasValue && selectedPublisherId.Value > 0)
                    {
                        query = query.Where(p => p.IdPublisher == selectedPublisherId.Value);
                    }

                    if (currentUserRole == "Администратор" && !string.IsNullOrWhiteSpace(searchText))
                    {
                        query = query.Where(p =>
                            p.Isbn.Contains(searchText) ||
                            p.BookName.Contains(searchText) ||
                            p.IdAuthorNavigation.AuthorName.Contains(searchText) ||
                            p.IdGenreNavigation.GenreName.Contains(searchText) ||
                            p.IdPublisherNavigation.PublisherName.Contains(searchText) ||
                            p.Annotation.Contains(searchText) ||
                            p.Year.ToString().Contains(searchText) ||
                            p.Pages.ToString().Contains(searchText)
                        );
                    }

                    if (currentUserRole == "Администратор")
                    {
                        if (sortOrder == "asc")
                        {
                            query = query.OrderBy(p => p.Avaiable);
                        }
                        else
                        {
                            query = query.OrderByDescending(p => p.Avaiable);
                        }
                    }
                    else
                    {
                        query = query.OrderBy(p => p.Id);
                    }

                    var books = query.ToList();

                    dataGridViewBook.SuspendLayout();
                    dataGridViewBook.Rows.Clear();

                    foreach (var book in books)
                    {
                        int rowIndex = dataGridViewBook.Rows.Add();
                        var row = dataGridViewBook.Rows[rowIndex];

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
                    }

                    dataGridViewBook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridViewBook.ResumeLayout();

                    dataGridViewBook.ClearSelection();
                    selectedBook = null;

                    if (currentUserRole == "Администратор" && labelRecordsCount != null)
                    {
                        labelRecordsCount.Text = $"Найдено записей: {books.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            searchText = textBoxSearch.Text;
            LoadBooks();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort.SelectedIndex == 0)
            {
                sortOrder = "asc";
            }
            else
            {
                sortOrder = "desc";
            }
            LoadBooks();
        }

        private void comboBoxPublisherFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPublisherFilter.SelectedItem is models.Publisher selectedPublisher)
            {
                if (selectedPublisher.Id == 0)
                {
                    selectedPublisherId = null;
                }
                else
                {
                    selectedPublisherId = selectedPublisher.Id;
                }
                LoadBooks();
            }
        }

        private void buttonResetFilters_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            comboBoxSort.SelectedIndex = 0;
            comboBoxPublisherFilter.SelectedIndex = 0;
        }

        private void ConfigureDgvProducts()
        {
            dataGridViewBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBook.MultiSelect = false;

            dataGridViewBook.SelectionChanged += DgvProducts_SelectionChanged;
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBook.SelectedRows.Count > 0)
            {
                selectedBook = dataGridViewBook.SelectedRows[0].Tag as Book;
            }
            else
            {
                selectedBook = null;
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
            if (currentUserRole == "Администратор")
            {
                FormCreateOrUpdate createForm = new FormCreateOrUpdate(CurrentUser, IsGuest);
                createForm.ShowDialog();
                LoadBooks();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (currentUserRole == "Администратор" && selectedBook != null)
            {
                FormCreateOrUpdate editForm = new FormCreateOrUpdate(CurrentUser, IsGuest, selectedBook);
                editForm.ShowDialog();
                LoadBooks();
            }
            else if (selectedBook == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу для редактирования.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentUserRole != "Администратор")
            {
                MessageBox.Show("Только администратор может удалять книги.",
                    "Доступ запрещен",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (selectedBook == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу для удаления.",
                    "Книга не выбрана",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить книгу \"{selectedBook.BookName}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var db = new LibraryContext())
                {
                    var book = db.Books.Find(selectedBook.Id);

                    if (book == null)
                    {
                        MessageBox.Show("Книга не найдена в базе данных.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    db.Books.Remove(book);
                    db.SaveChanges();
                }

                MessageBox.Show("Книга успешно удалена.",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении книги: {ex.InnerException?.Message ?? ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}