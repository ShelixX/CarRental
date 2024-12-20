namespace CarRental
{
    partial class ClientsEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsEdit));
            this.numberIDTextBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.secondnameTextBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstnameTextBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.middlenameTextBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.birthDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.transmissionTypeComboBox4 = new System.Windows.Forms.ComboBox();
            this.driveLicenseDateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.editRoundedButton1 = new RoundedButton();
            this.backRoundedButton4 = new RoundedButton();
            this.phoneNumberMaskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // numberIDTextBox2
            // 
            this.numberIDTextBox2.Location = new System.Drawing.Point(166, 419);
            this.numberIDTextBox2.MaxLength = 10;
            this.numberIDTextBox2.Name = "numberIDTextBox2";
            this.numberIDTextBox2.Size = new System.Drawing.Size(189, 27);
            this.numberIDTextBox2.TabIndex = 36;
            this.numberIDTextBox2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.numberIDTextBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberOnly);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Номер удостоверения:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 33;
            this.label5.Text = "Дата рождения:";
            // 
            // secondnameTextBox1
            // 
            this.secondnameTextBox1.Location = new System.Drawing.Point(169, 43);
            this.secondnameTextBox1.MaxLength = 20;
            this.secondnameTextBox1.Name = "secondnameTextBox1";
            this.secondnameTextBox1.Size = new System.Drawing.Size(186, 27);
            this.secondnameTextBox1.TabIndex = 28;
            this.secondnameTextBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.secondnameTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textOnly);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Фамилия:";
            // 
            // firstnameTextBox3
            // 
            this.firstnameTextBox3.Location = new System.Drawing.Point(166, 116);
            this.firstnameTextBox3.MaxLength = 20;
            this.firstnameTextBox3.Name = "firstnameTextBox3";
            this.firstnameTextBox3.Size = new System.Drawing.Size(189, 27);
            this.firstnameTextBox3.TabIndex = 39;
            this.firstnameTextBox3.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.firstnameTextBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textOnly);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Имя:";
            // 
            // middlenameTextBox4
            // 
            this.middlenameTextBox4.Location = new System.Drawing.Point(165, 191);
            this.middlenameTextBox4.MaxLength = 20;
            this.middlenameTextBox4.Name = "middlenameTextBox4";
            this.middlenameTextBox4.Size = new System.Drawing.Size(190, 27);
            this.middlenameTextBox4.TabIndex = 41;
            this.middlenameTextBox4.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.middlenameTextBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textOnly);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Отчество:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "Номер телефона:";
            // 
            // birthDateTimePicker1
            // 
            this.birthDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthDateTimePicker1.Location = new System.Drawing.Point(165, 344);
            this.birthDateTimePicker1.MinDate = new System.DateTime(1918, 1, 1, 0, 0, 0, 0);
            this.birthDateTimePicker1.Name = "birthDateTimePicker1";
            this.birthDateTimePicker1.Size = new System.Drawing.Size(190, 27);
            this.birthDateTimePicker1.TabIndex = 44;
            // 
            // transmissionTypeComboBox4
            // 
            this.transmissionTypeComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transmissionTypeComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.transmissionTypeComboBox4.FormattingEnabled = true;
            this.transmissionTypeComboBox4.Location = new System.Drawing.Point(48, 494);
            this.transmissionTypeComboBox4.Name = "transmissionTypeComboBox4";
            this.transmissionTypeComboBox4.Size = new System.Drawing.Size(190, 26);
            this.transmissionTypeComboBox4.TabIndex = 45;
            // 
            // driveLicenseDateTimePicker2
            // 
            this.driveLicenseDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.driveLicenseDateTimePicker2.Location = new System.Drawing.Point(275, 494);
            this.driveLicenseDateTimePicker2.MinDate = new System.DateTime(1936, 1, 1, 0, 0, 0, 0);
            this.driveLicenseDateTimePicker2.Name = "driveLicenseDateTimePicker2";
            this.driveLicenseDateTimePicker2.Size = new System.Drawing.Size(190, 27);
            this.driveLicenseDateTimePicker2.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 460);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 18);
            this.label7.TabIndex = 47;
            this.label7.Text = "Тип коробки передач:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 18);
            this.label8.TabIndex = 48;
            this.label8.Text = "Дата получения прав:";
            // 
            // editRoundedButton1
            // 
            this.editRoundedButton1.BackColor = System.Drawing.Color.White;
            this.editRoundedButton1.Location = new System.Drawing.Point(144, 554);
            this.editRoundedButton1.Name = "editRoundedButton1";
            this.editRoundedButton1.Size = new System.Drawing.Size(236, 81);
            this.editRoundedButton1.TabIndex = 37;
            this.editRoundedButton1.Text = "Изменить";
            this.editRoundedButton1.UseVisualStyleBackColor = false;
            this.editRoundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // backRoundedButton4
            // 
            this.backRoundedButton4.BackColor = System.Drawing.Color.White;
            this.backRoundedButton4.Location = new System.Drawing.Point(20, 22);
            this.backRoundedButton4.Name = "backRoundedButton4";
            this.backRoundedButton4.Size = new System.Drawing.Size(121, 31);
            this.backRoundedButton4.TabIndex = 24;
            this.backRoundedButton4.Text = "Назад";
            this.backRoundedButton4.UseVisualStyleBackColor = false;
            this.backRoundedButton4.Click += new System.EventHandler(this.roundedButton4_Click);
            // 
            // phoneNumberMaskedTextBox1
            // 
            this.phoneNumberMaskedTextBox1.Location = new System.Drawing.Point(165, 271);
            this.phoneNumberMaskedTextBox1.Mask = "+70000000000";
            this.phoneNumberMaskedTextBox1.Name = "phoneNumberMaskedTextBox1";
            this.phoneNumberMaskedTextBox1.Size = new System.Drawing.Size(190, 27);
            this.phoneNumberMaskedTextBox1.TabIndex = 51;
            // 
            // ClientsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(504, 660);
            this.ControlBox = false;
            this.Controls.Add(this.phoneNumberMaskedTextBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.driveLicenseDateTimePicker2);
            this.Controls.Add(this.transmissionTypeComboBox4);
            this.Controls.Add(this.birthDateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.middlenameTextBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.firstnameTextBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editRoundedButton1);
            this.Controls.Add(this.numberIDTextBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.secondnameTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backRoundedButton4);
            this.Font = new System.Drawing.Font("Verdana", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientsEdit";
            this.Text = "Изменение данных клиента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton editRoundedButton1;
        private System.Windows.Forms.TextBox numberIDTextBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox secondnameTextBox1;
        private System.Windows.Forms.Label label2;
        private RoundedButton backRoundedButton4;
        private System.Windows.Forms.TextBox firstnameTextBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox middlenameTextBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker birthDateTimePicker1;
        private System.Windows.Forms.ComboBox transmissionTypeComboBox4;
        private System.Windows.Forms.DateTimePicker driveLicenseDateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox phoneNumberMaskedTextBox1;
    }
}