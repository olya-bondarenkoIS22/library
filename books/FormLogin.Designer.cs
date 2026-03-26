namespace books
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            textBoxLogin = new TextBox();
            label2 = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            buttonGuest = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(198, 136);
            label1.Name = "label1";
            label1.Size = new Size(70, 22);
            label1.TabIndex = 0;
            label1.Text = "Логин:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(171, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(110, 161);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.PlaceholderText = "Логин";
            textBoxLogin.Size = new Size(246, 27);
            textBoxLogin.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(194, 214);
            label2.Name = "label2";
            label2.Size = new Size(78, 22);
            label2.TabIndex = 3;
            label2.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(110, 239);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Пароль";
            textBoxPassword.Size = new Size(246, 27);
            textBoxPassword.TabIndex = 4;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(74, 111, 165);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(110, 272);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(246, 29);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Войти";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonGuest
            // 
            buttonGuest.BackColor = Color.AliceBlue;
            buttonGuest.FlatStyle = FlatStyle.Flat;
            buttonGuest.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonGuest.ForeColor = Color.FromArgb(74, 111, 165);
            buttonGuest.Location = new Point(110, 307);
            buttonGuest.Name = "buttonGuest";
            buttonGuest.Size = new Size(246, 29);
            buttonGuest.TabIndex = 6;
            buttonGuest.Text = "Войти как гость";
            buttonGuest.UseVisualStyleBackColor = false;
            buttonGuest.Click += buttonGuest_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(466, 358);
            Controls.Add(buttonGuest);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(label2);
            Controls.Add(textBoxLogin);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "FormLogin";
            Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private TextBox textBoxLogin;
        private Label label2;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonGuest;
    }
}
