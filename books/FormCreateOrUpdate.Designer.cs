namespace books
{
    partial class FormCreateOrUpdate
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
            textBoxISBN = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxBookName = new TextBox();
            label3 = new Label();
            comboBoxAuthor = new ComboBox();
            label4 = new Label();
            comboBoxGenre = new ComboBox();
            label5 = new Label();
            comboBoxPublisher = new ComboBox();
            label6 = new Label();
            textBoxYear = new TextBox();
            label7 = new Label();
            textBoxPages = new TextBox();
            label8 = new Label();
            textBoxTotal = new TextBox();
            label9 = new Label();
            textBoxAvaiable = new TextBox();
            label10 = new Label();
            buttonCreateOrUpdate = new Button();
            textBoxAnnotation = new TextBox();
            SuspendLayout();
            // 
            // textBoxISBN
            // 
            textBoxISBN.Location = new Point(125, 45);
            textBoxISBN.Name = "textBoxISBN";
            textBoxISBN.Size = new Size(267, 27);
            textBoxISBN.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 10);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 1;
            label1.Text = "ISBN:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(196, 87);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 2;
            label2.Text = "Название книги:";
            // 
            // textBoxBookName
            // 
            textBoxBookName.Location = new Point(125, 122);
            textBoxBookName.Name = "textBoxBookName";
            textBoxBookName.Size = new Size(267, 27);
            textBoxBookName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(231, 164);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 5;
            label3.Text = "Автор:";
            // 
            // comboBoxAuthor
            // 
            comboBoxAuthor.FormattingEnabled = true;
            comboBoxAuthor.Location = new Point(125, 199);
            comboBoxAuthor.Name = "comboBoxAuthor";
            comboBoxAuthor.Size = new Size(267, 28);
            comboBoxAuthor.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(233, 242);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 7;
            label4.Text = "Жанр:";
            // 
            // comboBoxGenre
            // 
            comboBoxGenre.FormattingEnabled = true;
            comboBoxGenre.Location = new Point(125, 277);
            comboBoxGenre.Name = "comboBoxGenre";
            comboBoxGenre.Size = new Size(267, 28);
            comboBoxGenre.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(220, 320);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 9;
            label5.Text = "Издатель:";
            // 
            // comboBoxPublisher
            // 
            comboBoxPublisher.FormattingEnabled = true;
            comboBoxPublisher.Location = new Point(125, 355);
            comboBoxPublisher.Name = "comboBoxPublisher";
            comboBoxPublisher.Size = new Size(267, 28);
            comboBoxPublisher.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(236, 398);
            label6.Name = "label6";
            label6.Size = new Size(36, 20);
            label6.TabIndex = 11;
            label6.Text = "Год:";
            // 
            // textBoxYear
            // 
            textBoxYear.Location = new Point(125, 433);
            textBoxYear.Name = "textBoxYear";
            textBoxYear.Size = new Size(267, 27);
            textBoxYear.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(181, 475);
            label7.Name = "label7";
            label7.Size = new Size(154, 20);
            label7.TabIndex = 13;
            label7.Text = "Количество страниц:";
            // 
            // textBoxPages
            // 
            textBoxPages.Location = new Point(125, 510);
            textBoxPages.Name = "textBoxPages";
            textBoxPages.Size = new Size(267, 27);
            textBoxPages.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(233, 552);
            label8.Name = "label8";
            label8.Size = new Size(51, 20);
            label8.TabIndex = 15;
            label8.Text = "Всего:";
            // 
            // textBoxTotal
            // 
            textBoxTotal.Location = new Point(125, 587);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.Size = new Size(267, 27);
            textBoxTotal.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(219, 629);
            label9.Name = "label9";
            label9.Size = new Size(78, 20);
            label9.TabIndex = 17;
            label9.Text = "Доступно:";
            // 
            // textBoxAvaiable
            // 
            textBoxAvaiable.Location = new Point(125, 664);
            textBoxAvaiable.Name = "textBoxAvaiable";
            textBoxAvaiable.Size = new Size(267, 27);
            textBoxAvaiable.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(214, 706);
            label10.Name = "label10";
            label10.Size = new Size(89, 20);
            label10.TabIndex = 19;
            label10.Text = "Аннотация:";
            // 
            // buttonCreateOrUpdate
            // 
            buttonCreateOrUpdate.BackColor = Color.FromArgb(74, 111, 165);
            buttonCreateOrUpdate.FlatStyle = FlatStyle.Flat;
            buttonCreateOrUpdate.ForeColor = Color.White;
            buttonCreateOrUpdate.Location = new Point(125, 783);
            buttonCreateOrUpdate.Name = "buttonCreateOrUpdate";
            buttonCreateOrUpdate.Size = new Size(267, 45);
            buttonCreateOrUpdate.TabIndex = 21;
            buttonCreateOrUpdate.Text = "Добавить";
            buttonCreateOrUpdate.UseVisualStyleBackColor = false;
            buttonCreateOrUpdate.Click += buttonCreateOrUpdate_Click;
            // 
            // textBoxAnnotation
            // 
            textBoxAnnotation.Location = new Point(125, 741);
            textBoxAnnotation.Name = "textBoxAnnotation";
            textBoxAnnotation.Size = new Size(267, 27);
            textBoxAnnotation.TabIndex = 22;
            // 
            // FormCreateOrUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(517, 843);
            Controls.Add(textBoxAnnotation);
            Controls.Add(buttonCreateOrUpdate);
            Controls.Add(label10);
            Controls.Add(textBoxAvaiable);
            Controls.Add(label9);
            Controls.Add(textBoxTotal);
            Controls.Add(label8);
            Controls.Add(textBoxPages);
            Controls.Add(label7);
            Controls.Add(textBoxYear);
            Controls.Add(label6);
            Controls.Add(comboBoxPublisher);
            Controls.Add(label5);
            Controls.Add(comboBoxGenre);
            Controls.Add(label4);
            Controls.Add(comboBoxAuthor);
            Controls.Add(label3);
            Controls.Add(textBoxBookName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxISBN);
            Name = "FormCreateOrUpdate";
            Text = "Библиотека";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxISBN;
        private Label label1;
        private Label label2;
        private TextBox textBoxBookName;
        private Label label3;
        private ComboBox comboBoxAuthor;
        private Label label4;
        private ComboBox comboBoxGenre;
        private Label label5;
        private ComboBox comboBoxPublisher;
        private Label label6;
        private TextBox textBoxYear;
        private Label label7;
        private TextBox textBoxPages;
        private Label label8;
        private TextBox textBoxTotal;
        private Label label9;
        private TextBox textBoxAvaiable;
        private Label label10;
        private Button buttonCreateOrUpdate;
        private TextBox textBoxAnnotation;
    }
}