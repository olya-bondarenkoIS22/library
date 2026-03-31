namespace books
{
    partial class FormBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonCreate = new Button();
            buttonOrders = new Button();
            labelFullName = new Label();
            buttonLogout = new Button();
            panelSearchFilter = new Panel();
            labelRecordsCount = new Label();
            buttonResetFilters = new Button();
            comboBoxPublisherFilter = new ComboBox();
            comboBoxSort = new ComboBox();
            textBoxSearch = new TextBox();
            labelSearch = new Label();
            labelSort = new Label();
            labelFilter = new Label();
            dataGridViewBook = new DataGridView();
            panel1.SuspendLayout();
            panelSearchFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBook).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(buttonDelete);
            panel1.Controls.Add(buttonUpdate);
            panel1.Controls.Add(buttonCreate);
            panel1.Controls.Add(buttonOrders);
            panel1.Controls.Add(labelFullName);
            panel1.Controls.Add(buttonLogout);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1137, 58);
            panel1.TabIndex = 0;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(74, 111, 165);
            buttonDelete.Dock = DockStyle.Left;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(406, 0);
            buttonDelete.Margin = new Padding(15, 3, 3, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(129, 58);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Удалить книгу";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.FromArgb(74, 111, 165);
            buttonUpdate.Dock = DockStyle.Left;
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Location = new Point(258, 0);
            buttonUpdate.Margin = new Padding(15, 3, 3, 3);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(148, 58);
            buttonUpdate.TabIndex = 4;
            buttonUpdate.Text = "Редактировать книгу";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonCreate
            // 
            buttonCreate.BackColor = Color.FromArgb(74, 111, 165);
            buttonCreate.Dock = DockStyle.Left;
            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.ForeColor = Color.White;
            buttonCreate.Location = new Point(129, 0);
            buttonCreate.Margin = new Padding(15, 3, 3, 3);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(129, 58);
            buttonCreate.TabIndex = 3;
            buttonCreate.Text = "Добавить книгу";
            buttonCreate.UseVisualStyleBackColor = false;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // buttonOrders
            // 
            buttonOrders.BackColor = Color.FromArgb(74, 111, 165);
            buttonOrders.Dock = DockStyle.Left;
            buttonOrders.FlatStyle = FlatStyle.Flat;
            buttonOrders.ForeColor = Color.White;
            buttonOrders.Location = new Point(0, 0);
            buttonOrders.Name = "buttonOrders";
            buttonOrders.Size = new Size(129, 58);
            buttonOrders.TabIndex = 2;
            buttonOrders.Text = "Посмотреть \r\nзаказы книг";
            buttonOrders.UseVisualStyleBackColor = false;
            buttonOrders.Click += buttonOrders_Click;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Dock = DockStyle.Right;
            labelFullName.ForeColor = Color.FromArgb(74, 111, 165);
            labelFullName.Location = new Point(908, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(60, 22);
            labelFullName.TabIndex = 1;
            labelFullName.Text = "label1";
            labelFullName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.FromArgb(74, 111, 165);
            buttonLogout.Dock = DockStyle.Right;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(968, 0);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(169, 58);
            buttonLogout.TabIndex = 0;
            buttonLogout.Text = "Выход";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // panelSearchFilter
            // 
            panelSearchFilter.BackColor = Color.FromArgb(240, 248, 255);
            panelSearchFilter.Controls.Add(labelRecordsCount);
            panelSearchFilter.Controls.Add(buttonResetFilters);
            panelSearchFilter.Controls.Add(comboBoxPublisherFilter);
            panelSearchFilter.Controls.Add(comboBoxSort);
            panelSearchFilter.Controls.Add(textBoxSearch);
            panelSearchFilter.Controls.Add(labelSearch);
            panelSearchFilter.Controls.Add(labelSort);
            panelSearchFilter.Controls.Add(labelFilter);
            panelSearchFilter.Dock = DockStyle.Top;
            panelSearchFilter.Location = new Point(0, 58);
            panelSearchFilter.Name = "panelSearchFilter";
            panelSearchFilter.Size = new Size(1137, 79);
            panelSearchFilter.TabIndex = 2;
            panelSearchFilter.Visible = false;
            // 
            // labelRecordsCount
            // 
            labelRecordsCount.AutoSize = true;
            labelRecordsCount.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            labelRecordsCount.ForeColor = Color.Gray;
            labelRecordsCount.Location = new Point(12, 48);
            labelRecordsCount.Name = "labelRecordsCount";
            labelRecordsCount.Size = new Size(0, 19);
            labelRecordsCount.TabIndex = 7;
            // 
            // buttonResetFilters
            // 
            buttonResetFilters.BackColor = Color.FromArgb(74, 111, 165);
            buttonResetFilters.FlatStyle = FlatStyle.Flat;
            buttonResetFilters.ForeColor = Color.White;
            buttonResetFilters.Location = new Point(959, 13);
            buttonResetFilters.Name = "buttonResetFilters";
            buttonResetFilters.Size = new Size(100, 32);
            buttonResetFilters.TabIndex = 6;
            buttonResetFilters.Text = "Сброс";
            buttonResetFilters.UseVisualStyleBackColor = false;
            // 
            // comboBoxPublisherFilter
            // 
            comboBoxPublisherFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPublisherFilter.FormattingEnabled = true;
            comboBoxPublisherFilter.Location = new Point(753, 15);
            comboBoxPublisherFilter.Name = "comboBoxPublisherFilter";
            comboBoxPublisherFilter.Size = new Size(200, 30);
            comboBoxPublisherFilter.TabIndex = 5;
            // 
            // comboBoxSort
            // 
            comboBoxSort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Location = new Point(417, 15);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new Size(220, 30);
            comboBoxSort.TabIndex = 3;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(88, 15);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(200, 30);
            textBoxSearch.TabIndex = 1;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(12, 20);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(70, 22);
            labelSearch.TabIndex = 0;
            labelSearch.Text = "Поиск:";
            // 
            // labelSort
            // 
            labelSort.AutoSize = true;
            labelSort.Location = new Point(294, 20);
            labelSort.Name = "labelSort";
            labelSort.Size = new Size(117, 22);
            labelSort.TabIndex = 2;
            labelSort.Text = "Сортировка:";
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(654, 20);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(93, 22);
            labelFilter.TabIndex = 4;
            labelFilter.Text = "Издатель:";
            // 
            // dataGridViewBook
            // 
            dataGridViewBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewBook.BackgroundColor = Color.White;
            dataGridViewBook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBook.Dock = DockStyle.Fill;
            dataGridViewBook.Location = new Point(0, 137);
            dataGridViewBook.Name = "dataGridViewBook";
            dataGridViewBook.RowHeadersWidth = 51;
            dataGridViewBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBook.Size = new Size(1137, 540);
            dataGridViewBook.TabIndex = 1;
            // 
            // FormBooks
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1137, 677);
            Controls.Add(dataGridViewBook);
            Controls.Add(panelSearchFilter);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormBooks";
            Text = "Библиотека";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelSearchFilter.ResumeLayout(false);
            panelSearchFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBook).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelFullName;
        private Button buttonLogout;
        private Button buttonOrders;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonCreate;
        private DataGridView dataGridViewBook;
        private Panel panelSearchFilter;
        private Label labelRecordsCount;
        private Button buttonResetFilters;
        private ComboBox comboBoxPublisherFilter;
        private ComboBox comboBoxSort;
        private TextBox textBoxSearch;
        private Label labelSearch;
        private Label labelSort;
        private Label labelFilter;
    }
}