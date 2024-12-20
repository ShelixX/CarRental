namespace CarRental
{
    partial class User
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
            this.loginTextBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTextBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedButton1 = new RoundedButton();
            this.backRoundedButton4 = new RoundedButton();
            this.SuspendLayout();
            // 
            // loginTextBox1
            // 
            this.loginTextBox1.Location = new System.Drawing.Point(178, 178);
            this.loginTextBox1.MaxLength = 15;
            this.loginTextBox1.Name = "loginTextBox1";
            this.loginTextBox1.Size = new System.Drawing.Size(166, 27);
            this.loginTextBox1.TabIndex = 28;
            this.loginTextBox1.TextChanged += new System.EventHandler(this.textBoxMainForm_TextChanged);
            this.loginTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAndNumbers);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Логин:";
            // 
            // passwordTextBox2
            // 
            this.passwordTextBox2.Location = new System.Drawing.Point(178, 256);
            this.passwordTextBox2.MaxLength = 20;
            this.passwordTextBox2.Name = "passwordTextBox2";
            this.passwordTextBox2.PasswordChar = '*';
            this.passwordTextBox2.Size = new System.Drawing.Size(166, 27);
            this.passwordTextBox2.TabIndex = 39;
            this.passwordTextBox2.UseSystemPasswordChar = true;
            this.passwordTextBox2.TextChanged += new System.EventHandler(this.textBoxMainForm_TextChanged);
            this.passwordTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAndNumbers);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Пароль:";
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.Enabled = false;
            this.roundedButton1.Location = new System.Drawing.Point(141, 330);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(236, 81);
            this.roundedButton1.TabIndex = 37;
            this.roundedButton1.Text = "Изменить";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // backRoundedButton4
            // 
            this.backRoundedButton4.BackColor = System.Drawing.Color.White;
            this.backRoundedButton4.Location = new System.Drawing.Point(29, 23);
            this.backRoundedButton4.Name = "backRoundedButton4";
            this.backRoundedButton4.Size = new System.Drawing.Size(121, 31);
            this.backRoundedButton4.TabIndex = 24;
            this.backRoundedButton4.Text = "Назад";
            this.backRoundedButton4.UseVisualStyleBackColor = false;
            this.backRoundedButton4.Click += new System.EventHandler(this.roundedButton4_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(504, 586);
            this.ControlBox = false;
            this.Controls.Add(this.passwordTextBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.loginTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backRoundedButton4);
            this.Font = new System.Drawing.Font("Verdana", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "User";
            this.Text = "Employeecs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton roundedButton1;
        private System.Windows.Forms.TextBox loginTextBox1;
        private System.Windows.Forms.Label label2;
        private RoundedButton backRoundedButton4;
        private System.Windows.Forms.TextBox passwordTextBox2;
        private System.Windows.Forms.Label label1;
    }
}