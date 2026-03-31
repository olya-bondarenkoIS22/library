namespace books
{
    partial class FormCreateOrUpdateOrders
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
            buttonCreateOrUpdate = new Button();
            button = new Button();
            label1 = new Label();
            comboBoxUser = new ComboBox();
            label2 = new Label();
            comboBoxBook = new ComboBox();
            label3 = new Label();
            dateTimePickerOfIssue = new DateTimePicker();
            label4 = new Label();
            dateTimePickerPlannedReturnDate = new DateTimePicker();
            label5 = new Label();
            dateTimePickerActualReturnDate = new DateTimePicker();
            label6 = new Label();
            comboBoxStatus = new ComboBox();
            SuspendLayout();
            // 
            // buttonCreateOrUpdate
            // 
            buttonCreateOrUpdate.BackColor = Color.FromArgb(74, 111, 165);
            buttonCreateOrUpdate.FlatStyle = FlatStyle.Flat;
            buttonCreateOrUpdate.ForeColor = Color.White;
            buttonCreateOrUpdate.Location = new Point(-440, -216);
            buttonCreateOrUpdate.Name = "buttonCreateOrUpdate";
            buttonCreateOrUpdate.Size = new Size(267, 45);
            buttonCreateOrUpdate.TabIndex = 22;
            buttonCreateOrUpdate.Text = "Добавить";
            buttonCreateOrUpdate.UseVisualStyleBackColor = false;
            // 
            // button
            // 
            button.BackColor = Color.FromArgb(74, 111, 165);
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.White;
            button.Location = new Point(62, 418);
            button.Name = "button";
            button.Size = new Size(321, 45);
            button.TabIndex = 23;
            button.Text = "Добавить";
            button.UseVisualStyleBackColor = false;
            button.Click += button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(185, 25);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 24;
            label1.Text = "Читатель:";
            // 
            // comboBoxUser
            // 
            comboBoxUser.FormattingEnabled = true;
            comboBoxUser.Location = new Point(62, 54);
            comboBoxUser.Name = "comboBoxUser";
            comboBoxUser.Size = new Size(321, 28);
            comboBoxUser.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(196, 91);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 26;
            label2.Text = "Книга:";
            // 
            // comboBoxBook
            // 
            comboBoxBook.FormattingEnabled = true;
            comboBoxBook.Location = new Point(62, 120);
            comboBoxBook.Name = "comboBoxBook";
            comboBoxBook.Size = new Size(321, 28);
            comboBoxBook.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(172, 157);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 28;
            label3.Text = "Дата выдачи:";
            // 
            // dateTimePickerOfIssue
            // 
            dateTimePickerOfIssue.Location = new Point(62, 186);
            dateTimePickerOfIssue.Name = "dateTimePickerOfIssue";
            dateTimePickerOfIssue.Size = new Size(321, 27);
            dateTimePickerOfIssue.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 222);
            label4.Name = "label4";
            label4.Size = new Size(241, 20);
            label4.TabIndex = 31;
            label4.Text = "Планируемая дата возвращения:";
            // 
            // dateTimePickerPlannedReturnDate
            // 
            dateTimePickerPlannedReturnDate.Location = new Point(62, 251);
            dateTimePickerPlannedReturnDate.Name = "dateTimePickerPlannedReturnDate";
            dateTimePickerPlannedReturnDate.Size = new Size(321, 27);
            dateTimePickerPlannedReturnDate.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(122, 287);
            label5.Name = "label5";
            label5.Size = new Size(200, 20);
            label5.TabIndex = 33;
            label5.Text = "Фактическая дата возврата:";
            // 
            // dateTimePickerActualReturnDate
            // 
            dateTimePickerActualReturnDate.Location = new Point(62, 316);
            dateTimePickerActualReturnDate.Name = "dateTimePickerActualReturnDate";
            dateTimePickerActualReturnDate.Size = new Size(321, 27);
            dateTimePickerActualReturnDate.TabIndex = 34;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(195, 352);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 35;
            label6.Text = "Статус:";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(62, 381);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(321, 28);
            comboBoxStatus.TabIndex = 36;
            // 
            // FormCreateOrUpdateOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(445, 489);
            Controls.Add(comboBoxStatus);
            Controls.Add(label6);
            Controls.Add(dateTimePickerActualReturnDate);
            Controls.Add(label5);
            Controls.Add(dateTimePickerPlannedReturnDate);
            Controls.Add(label4);
            Controls.Add(dateTimePickerOfIssue);
            Controls.Add(label3);
            Controls.Add(comboBoxBook);
            Controls.Add(label2);
            Controls.Add(comboBoxUser);
            Controls.Add(label1);
            Controls.Add(button);
            Controls.Add(buttonCreateOrUpdate);
            Name = "FormCreateOrUpdateOrders";
            Text = "FormCreateOrUpdateOrders";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCreateOrUpdate;
        private Button button;
        private Label label1;
        private ComboBox comboBoxUser;
        private Label label2;
        private ComboBox comboBoxBook;
        private Label label3;
        private DateTimePicker dateTimePickerOfIssue;
        private Label label4;
        private DateTimePicker dateTimePickerPlannedReturnDate;
        private Label label5;
        private DateTimePicker dateTimePickerActualReturnDate;
        private Label label6;
        private ComboBox comboBoxStatus;
    }
}