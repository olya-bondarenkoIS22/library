using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace books
{
    public partial class FormCreateOrUpdateOrders : Form
    {
        public models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        private BookLoan editingBookLoan;
        private bool isEditMode;

        // Конструктор для добавления новой выдачи
        public FormCreateOrUpdateOrders(models.User user, bool quest)
        {
            InitializeComponent();
            CurrentUser = user;
            IsGuest = quest;
            isEditMode = false;
            this.Load += FormCreateOrUpdateOrders_Load;
        }

        // Конструктор для редактирования существующей выдачи
        public FormCreateOrUpdateOrders(models.User user, bool quest, BookLoan bookLoanToEdit)
        {
            InitializeComponent();
            CurrentUser = user;
            IsGuest = quest;
            editingBookLoan = bookLoanToEdit;
            isEditMode = true;
            this.Load += FormCreateOrUpdateOrders_Load;
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация обязательных полей
                if (comboBoxUser.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите читателя.",
                        "Ошибка валидации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxBook.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите книгу.",
                        "Ошибка валидации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxStatus.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите статус.",
                        "Ошибка валидации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                using (var db = new LibraryContext())
                {
                    BookLoan bookLoan;

                    if (isEditMode && editingBookLoan != null)
                    {
                        // Поиск выдачи для редактирования
                        bookLoan = db.BookLoans.Find(editingBookLoan.Id);
                        if (bookLoan == null)
                        {
                            MessageBox.Show("Запись не найдена в базе данных.",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        // Проверка на дубликат (книга уже выдана этому читателю и не возвращена)
                        models.User selectedUser = (models.User)comboBoxUser.SelectedItem;
                        Book selectedBook = (Book)comboBoxBook.SelectedItem;

                        var existingLoan = db.BookLoans
                            .FirstOrDefault(bl => bl.IdUser == selectedUser.Id &&
                                                  bl.IdBook == selectedBook.Id &&
                                                  bl.ActualReturnDate == null);

                        if (existingLoan != null)
                        {
                            MessageBox.Show("Эта книга уже выдана данному читателю и еще не возвращена.",
                                "Ошибка валидации",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        bookLoan = new BookLoan();
                        db.BookLoans.Add(bookLoan);
                    }

                    // Заполнение данных выдачи
                    models.User selectedUserForLoan = (models.User)comboBoxUser.SelectedItem;
                    bookLoan.IdUser = selectedUserForLoan.Id;

                    Book selectedBookForLoan = (Book)comboBoxBook.SelectedItem;
                    bookLoan.IdBook = selectedBookForLoan.Id;

                    // Преобразование DateTime в DateOnly
                    bookLoan.DateOfIssue = DateOnly.FromDateTime(dateTimePickerOfIssue.Value);
                    bookLoan.PlannedReturnDate = DateOnly.FromDateTime(dateTimePickerPlannedReturnDate.Value);

                    // Фактическая дата возврата - берем из DateTimePicker
                    bookLoan.ActualReturnDate = DateOnly.FromDateTime(dateTimePickerActualReturnDate.Value);

                    models.Status selectedStatus = (models.Status)comboBoxStatus.SelectedItem;
                    bookLoan.IdStatus = selectedStatus.Id;

                    db.SaveChanges();

                    string message = isEditMode ? "Запись успешно обновлена!" : "Запись успешно добавлена!";
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
                MessageBox.Show($"Ошибка при сохранении: {ex.InnerException?.Message ?? ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormCreateOrUpdateOrders_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    // Загрузка справочников
                    var users = db.Users.OrderBy(u => u.FullName).ToList();
                    var books = db.Books.OrderBy(b => b.BookName).ToList();
                    var statuses = db.Statuses.OrderBy(s => s.Id).ToList();

                    comboBoxUser.DataSource = users;
                    comboBoxUser.DisplayMember = "FullName";
                    comboBoxUser.ValueMember = "Id";

                    comboBoxBook.DataSource = books;
                    comboBoxBook.DisplayMember = "BookName";
                    comboBoxBook.ValueMember = "Id";

                    comboBoxStatus.DataSource = statuses;
                    comboBoxStatus.DisplayMember = "StatusName";
                    comboBoxStatus.ValueMember = "Id";

                    // Настройка DateTimePicker
                    dateTimePickerOfIssue.Value = DateTime.Now;
                    dateTimePickerPlannedReturnDate.Value = DateTime.Now.AddDays(14);
                    dateTimePickerActualReturnDate.Value = DateTime.Now;

                    if (isEditMode && editingBookLoan != null)
                    {
                        LoadBookLoanData(db);
                        button.Text = "Обновить";
                        this.Text = "Редактирование выдачи";
                    }
                    else
                    {
                        button.Text = "Добавить";
                        this.Text = "Добавление выдачи";
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

        private void LoadBookLoanData(LibraryContext db)
        {
            // Выбор читателя
            if (editingBookLoan.IdUser > 0)
            {
                var user = db.Users.FirstOrDefault(u => u.Id == editingBookLoan.IdUser);
                if (user != null)
                    comboBoxUser.SelectedItem = user;
            }

            // Выбор книги
            if (editingBookLoan.IdBook > 0)
            {
                var book = db.Books.FirstOrDefault(b => b.Id == editingBookLoan.IdBook);
                if (book != null)
                    comboBoxBook.SelectedItem = book;
            }

            // Заполнение дат
            if (editingBookLoan.DateOfIssue.HasValue)
                dateTimePickerOfIssue.Value = editingBookLoan.DateOfIssue.Value.ToDateTime(TimeOnly.MinValue);

            if (editingBookLoan.PlannedReturnDate.HasValue)
                dateTimePickerPlannedReturnDate.Value = editingBookLoan.PlannedReturnDate.Value.ToDateTime(TimeOnly.MinValue);

            // Заполнение фактической даты возврата
            if (editingBookLoan.ActualReturnDate.HasValue)
            {
                dateTimePickerActualReturnDate.Value = editingBookLoan.ActualReturnDate.Value.ToDateTime(TimeOnly.MinValue);
            }

            // Выбор статуса
            if (editingBookLoan.IdStatus > 0)
            {
                var status = db.Statuses.FirstOrDefault(s => s.Id == editingBookLoan.IdStatus);
                if (status != null)
                    comboBoxStatus.SelectedItem = status;
            }
        }
    }
}