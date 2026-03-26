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
            buttonLogout = new Button();
            label1 = new Label();
            buttonOrders = new Button();
            buttonCreate = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(buttonDelete);
            panel1.Controls.Add(buttonUpdate);
            panel1.Controls.Add(buttonCreate);
            panel1.Controls.Add(buttonOrders);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonLogout);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1041, 79);
            panel1.TabIndex = 0;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.FromArgb(74, 111, 165);
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(860, 34);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(169, 37);
            buttonLogout.TabIndex = 0;
            buttonLogout.Text = "Выход";
            buttonLogout.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(74, 111, 165);
            label1.Location = new Point(969, 9);
            label1.Name = "label1";
            label1.Size = new Size(60, 22);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonOrders
            // 
            buttonOrders.BackColor = Color.FromArgb(74, 111, 165);
            buttonOrders.FlatStyle = FlatStyle.Flat;
            buttonOrders.ForeColor = Color.White;
            buttonOrders.Location = new Point(12, 7);
            buttonOrders.Name = "buttonOrders";
            buttonOrders.Size = new Size(129, 64);
            buttonOrders.TabIndex = 2;
            buttonOrders.Text = "Посмотреть \r\nзаказы книг";
            buttonOrders.UseVisualStyleBackColor = false;
            // 
            // buttonCreate
            // 
            buttonCreate.BackColor = Color.FromArgb(74, 111, 165);
            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.ForeColor = Color.White;
            buttonCreate.Location = new Point(147, 7);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(129, 64);
            buttonCreate.TabIndex = 3;
            buttonCreate.Text = "Добавить книгу";
            buttonCreate.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.FromArgb(74, 111, 165);
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.ForeColor = Color.White;
            buttonUpdate.Location = new Point(282, 7);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(148, 64);
            buttonUpdate.TabIndex = 4;
            buttonUpdate.Text = "Редактировать книгу";
            buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(74, 111, 165);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(436, 7);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(129, 64);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Удалить книгу";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1041, 598);
            dataGridView1.TabIndex = 1;
            // 
            // FormBooks
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1041, 677);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormBooks";
            Text = "FormBooks";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button buttonLogout;
        private Button buttonOrders;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonCreate;
        private DataGridView dataGridView1;
    }
}