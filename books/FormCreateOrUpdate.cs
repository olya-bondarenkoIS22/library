using books.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace books
{
    public partial class FormCreateOrUpdate : Form
    {
        public models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        private Book editingBook;
        private bool isEditMode;

        public FormCreateOrUpdate(models.User user, bool quest)
        {
            InitializeComponent();
            CurrentUser = user;
            IsGuest = quest;
            isEditMode = false;
            this.Load += FormCreateOrUpdate_Load;
        }

        public FormCreateOrUpdate(models.User user, bool quest, Book bookToEdit)
        {
            InitializeComponent();
            CurrentUser = user;
            IsGuest = quest;
            editingBook = bookToEdit;
            isEditMode = true;
            this.Load += FormCreateOrUpdate_Load;
        }

        private void buttonCreateOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxISBN.Text) ||
                    string.IsNullOrWhiteSpace(textBoxBookName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxYear.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPages.Text) ||
                    string.IsNullOrWhiteSpace(textBoxTotal.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAvaiable.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAnnotation.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля.",
                        "Ошибка валидации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxAuthor.SelectedItem == null ||
                    comboBoxGenre.SelectedItem == null ||
                    comboBoxPublisher.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите все обязательные значения.",
                        "Ошибка валидации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxYear.Text, out int year) || year <= 0 || year > DateTime.Now.Year)
                {
                    MessageBox.Show("Пожалуйста, введите корректный год (от 1 до текущего года).",
                        "Ошибка валидации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxPages.Text, out int pages) || pages <= 0)
                {
                    MessageBox.Show("Пожалуйста, введите корректное количество страниц (положительное число).",
                        "Ошибка валидации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxTotal.Text, out int total) || total <= 0)
                {
                    MessageBox.Show("Пожалуйста, введите корректное общее количество книг (положительное число).",
                        "Ошибка валидации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxAvaiable.Text, out int available) || available < 0 || available > total)
                {
                    MessageBox.Show($"Пожалуйста, введите корректное количество доступных книг (от 0 до {total}).",
                        "Ошибка валидации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                using (var db = new LibraryContext())
                {
                    Book book;

                    if (isEditMode && editingBook != null)
                    {
                        book = db.Books.Find(editingBook.Id);
                        if (book == null)
                        {
                            MessageBox.Show("Книга не найдена в базе данных.",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        if (db.Books.Any(b => b.Isbn == textBoxISBN.Text))
                        {
                            MessageBox.Show("Книга с таким ISBN уже существует в базе данных.",
                                "Ошибка валидации",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                        book = new Book();
                        db.Books.Add(book);
                    }

                    book.Isbn = textBoxISBN.Text;
                    book.BookName = textBoxBookName.Text;

                    Author selectedAuthor = (Author)comboBoxAuthor.SelectedItem;
                    book.IdAuthor = selectedAuthor.Id;

                    Genre selectedGenre = (Genre)comboBoxGenre.SelectedItem;
                    book.IdGenre = selectedGenre.Id;

                    Publisher selectedPublisher = (Publisher)comboBoxPublisher.SelectedItem;
                    book.IdPublisher = selectedPublisher.Id;

                    book.Year = year;
                    book.Pages = pages;
                    book.Total = total;
                    book.Avaiable = available;
                    book.Annotation = textBoxAnnotation.Text;

                    book.PhotoUrl = null;

                    db.SaveChanges();

                    string message = isEditMode ? "Книга успешно обновлена!" : "Книга успешно добавлена!";
                    MessageBox.Show(message,
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении книги: {ex.InnerException?.Message ?? ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormCreateOrUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var authors = db.Authors.OrderBy(a => a.AuthorName).ToList();
                    var genres = db.Genres.OrderBy(g => g.GenreName).ToList();
                    var publishers = db.Publishers.OrderBy(p => p.PublisherName).ToList();

                    comboBoxAuthor.DataSource = authors;
                    comboBoxAuthor.DisplayMember = "AuthorName";
                    comboBoxAuthor.ValueMember = "Id";

                    comboBoxGenre.DataSource = genres;
                    comboBoxGenre.DisplayMember = "GenreName";
                    comboBoxGenre.ValueMember = "Id";

                    comboBoxPublisher.DataSource = publishers;
                    comboBoxPublisher.DisplayMember = "PublisherName";
                    comboBoxPublisher.ValueMember = "Id";

                    if (isEditMode && editingBook != null)
                    {
                        LoadBookData(db);
                        buttonCreateOrUpdate.Text = "Обновить";
                        this.Text = "Редактирование книги";
                    }
                    else
                    {
                        buttonCreateOrUpdate.Text = "Добавить";
                        this.Text = "Добавление книги";
                        textBoxTotal.Text = "1";
                        textBoxAvaiable.Text = "1";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                    "Ошибка загрузки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadBookData(LibraryContext db)
        {
            textBoxISBN.Text = editingBook.Isbn;
            textBoxBookName.Text = editingBook.BookName;

            if (editingBook.IdAuthor > 0)
            {
                var author = db.Authors.FirstOrDefault(a => a.Id == editingBook.IdAuthor);
                if (author != null)
                    comboBoxAuthor.SelectedItem = author;
            }

            if (editingBook.IdGenre > 0)
            {
                var genre = db.Genres.FirstOrDefault(g => g.Id == editingBook.IdGenre);
                if (genre != null)
                    comboBoxGenre.SelectedItem = genre;
            }

            if (editingBook.IdPublisher > 0)
            {
                var publisher = db.Publishers.FirstOrDefault(p => p.Id == editingBook.IdPublisher);
                if (publisher != null)
                    comboBoxPublisher.SelectedItem = publisher;
            }

            textBoxYear.Text = editingBook.Year.ToString();
            textBoxPages.Text = editingBook.Pages.ToString();
            textBoxTotal.Text = editingBook.Total.ToString();
            textBoxAvaiable.Text = editingBook.Avaiable.ToString();
            textBoxAnnotation.Text = editingBook.Annotation;
        }
    }
}