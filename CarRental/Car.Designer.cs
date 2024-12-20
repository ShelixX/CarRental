namespace CarRental
{
    partial class Car
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Car));
            this.label1 = new System.Windows.Forms.Label();
            this.markComboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.modelTextBox1 = new System.Windows.Forms.TextBox();
            this.carTypeComboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.transmissionTypeComboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.carClassComboBox4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.costTextBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.roundedButton1 = new RoundedButton();
            this.backRoundedButton4 = new RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Марка:";
            // 
            // markComboBox1
            // 
            this.markComboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.markComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.markComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.markComboBox1.FormattingEnabled = true;
            this.markComboBox1.Location = new System.Drawing.Point(174, 75);
            this.markComboBox1.Name = "markComboBox1";
            this.markComboBox1.Size = new System.Drawing.Size(166, 26);
            this.markComboBox1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Модель:";
            // 
            // modelTextBox1
            // 
            this.modelTextBox1.Location = new System.Drawing.Point(174, 151);
            this.modelTextBox1.MaxLength = 30;
            this.modelTextBox1.Name = "modelTextBox1";
            this.modelTextBox1.Size = new System.Drawing.Size(166, 27);
            this.modelTextBox1.TabIndex = 14;
            this.modelTextBox1.TextChanged += new System.EventHandler(this.textBoxMainForm_TextChanged);
            this.modelTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAndNumbers);
            // 
            // carTypeComboBox2
            // 
            this.carTypeComboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.carTypeComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carTypeComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.carTypeComboBox2.FormattingEnabled = true;
            this.carTypeComboBox2.Location = new System.Drawing.Point(174, 221);
            this.carTypeComboBox2.Name = "carTypeComboBox2";
            this.carTypeComboBox2.Size = new System.Drawing.Size(166, 26);
            this.carTypeComboBox2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Тип:";
            // 
            // transmissionTypeComboBox3
            // 
            this.transmissionTypeComboBox3.BackColor = System.Drawing.SystemColors.Window;
            this.transmissionTypeComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transmissionTypeComboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.transmissionTypeComboBox3.FormattingEnabled = true;
            this.transmissionTypeComboBox3.Location = new System.Drawing.Point(171, 295);
            this.transmissionTypeComboBox3.Name = "transmissionTypeComboBox3";
            this.transmissionTypeComboBox3.Size = new System.Drawing.Size(166, 26);
            this.transmissionTypeComboBox3.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Тип коробки передач:";
            // 
            // carClassComboBox4
            // 
            this.carClassComboBox4.BackColor = System.Drawing.SystemColors.Window;
            this.carClassComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carClassComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.carClassComboBox4.FormattingEnabled = true;
            this.carClassComboBox4.Location = new System.Drawing.Point(171, 367);
            this.carClassComboBox4.Name = "carClassComboBox4";
            this.carClassComboBox4.Size = new System.Drawing.Size(166, 26);
            this.carClassComboBox4.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Класс автомобиля:";
            // 
            // costTextBox2
            // 
            this.costTextBox2.Location = new System.Drawing.Point(170, 440);
            this.costTextBox2.MaxLength = 6;
            this.costTextBox2.Name = "costTextBox2";
            this.costTextBox2.Size = new System.Drawing.Size(166, 27);
            this.costTextBox2.TabIndex = 22;
            this.costTextBox2.TextChanged += new System.EventHandler(this.textBoxMainForm_TextChanged);
            this.costTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberOnly);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Цена:";
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.Enabled = false;
            this.roundedButton1.Location = new System.Drawing.Point(136, 493);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(236, 81);
            this.roundedButton1.TabIndex = 23;
            this.roundedButton1.Text = "Изменить";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // backRoundedButton4
            // 
            this.backRoundedButton4.BackColor = System.Drawing.Color.White;
            this.backRoundedButton4.Location = new System.Drawing.Point(25, 22);
            this.backRoundedButton4.Name = "backRoundedButton4";
            this.backRoundedButton4.Size = new System.Drawing.Size(121, 31);
            this.backRoundedButton4.TabIndex = 10;
            this.backRoundedButton4.Text = "Назад";
            this.backRoundedButton4.UseVisualStyleBackColor = false;
            this.backRoundedButton4.Click += new System.EventHandler(this.roundedButton4_Click);
            // 
            // Car
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(504, 586);
            this.ControlBox = false;
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.costTextBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.carClassComboBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.transmissionTypeComboBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.carTypeComboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modelTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.markComboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backRoundedButton4);
            this.Font = new System.Drawing.Font("Verdana", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Car";
            this.Text = "Car";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton backRoundedButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox markComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modelTextBox1;
        private System.Windows.Forms.ComboBox carTypeComboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox transmissionTypeComboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox carClassComboBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox costTextBox2;
        private System.Windows.Forms.Label label6;
        private RoundedButton roundedButton1;
    }
}