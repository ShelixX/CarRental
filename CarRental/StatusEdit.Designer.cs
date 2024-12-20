namespace CarRental
{
    partial class StatusEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusEdit));
            this.backRoundedButton4 = new RoundedButton();
            this.completeRoundedButton3 = new RoundedButton();
            this.rejectRoundedButton2 = new RoundedButton();
            this.confirmRoundedButton1 = new RoundedButton();
            this.SuspendLayout();
            // 
            // backRoundedButton4
            // 
            this.backRoundedButton4.BackColor = System.Drawing.Color.White;
            this.backRoundedButton4.Location = new System.Drawing.Point(25, 22);
            this.backRoundedButton4.Name = "backRoundedButton4";
            this.backRoundedButton4.Size = new System.Drawing.Size(121, 31);
            this.backRoundedButton4.TabIndex = 9;
            this.backRoundedButton4.Text = "Назад";
            this.backRoundedButton4.UseVisualStyleBackColor = false;
            this.backRoundedButton4.Click += new System.EventHandler(this.roundedButton4_Click);
            // 
            // completeRoundedButton3
            // 
            this.completeRoundedButton3.BackColor = System.Drawing.Color.White;
            this.completeRoundedButton3.Enabled = false;
            this.completeRoundedButton3.Location = new System.Drawing.Point(133, 352);
            this.completeRoundedButton3.Name = "completeRoundedButton3";
            this.completeRoundedButton3.Size = new System.Drawing.Size(246, 74);
            this.completeRoundedButton3.TabIndex = 8;
            this.completeRoundedButton3.Text = "Завершить";
            this.completeRoundedButton3.UseVisualStyleBackColor = false;
            this.completeRoundedButton3.Click += new System.EventHandler(this.roundedButton3_Click);
            // 
            // rejectRoundedButton2
            // 
            this.rejectRoundedButton2.BackColor = System.Drawing.Color.White;
            this.rejectRoundedButton2.Enabled = false;
            this.rejectRoundedButton2.Location = new System.Drawing.Point(133, 228);
            this.rejectRoundedButton2.Name = "rejectRoundedButton2";
            this.rejectRoundedButton2.Size = new System.Drawing.Size(246, 74);
            this.rejectRoundedButton2.TabIndex = 7;
            this.rejectRoundedButton2.Text = "Отклонить";
            this.rejectRoundedButton2.UseVisualStyleBackColor = false;
            this.rejectRoundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // confirmRoundedButton1
            // 
            this.confirmRoundedButton1.BackColor = System.Drawing.Color.White;
            this.confirmRoundedButton1.Enabled = false;
            this.confirmRoundedButton1.Location = new System.Drawing.Point(133, 105);
            this.confirmRoundedButton1.Name = "confirmRoundedButton1";
            this.confirmRoundedButton1.Size = new System.Drawing.Size(246, 74);
            this.confirmRoundedButton1.TabIndex = 6;
            this.confirmRoundedButton1.Text = "Принять";
            this.confirmRoundedButton1.UseVisualStyleBackColor = false;
            this.confirmRoundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // StatusEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(504, 586);
            this.ControlBox = false;
            this.Controls.Add(this.backRoundedButton4);
            this.Controls.Add(this.completeRoundedButton3);
            this.Controls.Add(this.rejectRoundedButton2);
            this.Controls.Add(this.confirmRoundedButton1);
            this.Font = new System.Drawing.Font("Verdana", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatusEdit";
            this.Text = "Изменение статуса";
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton confirmRoundedButton1;
        private RoundedButton rejectRoundedButton2;
        private RoundedButton completeRoundedButton3;
        private RoundedButton backRoundedButton4;
    }
}