using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CarRental
{
    public partial class ClientsEdit : Form
    {
        SqlConnection Connection;
        int clientID;

        public ClientsEdit(string[] data, SqlConnection MyConnection)
        {
            InitializeComponent();
            DateTime dt = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
            birthDateTimePicker1.MaxDate = dt;
            driveLicenseDateTimePicker2.MaxDate = DateTime.Now;
            Connection = MyConnection;
            clientID = Convert.ToInt32(data[0]);
            string[] fio = data[1].Split(' ');
            // Заполнение полей текущими данными клиента
            secondnameTextBox1.Text = fio[0];
            firstnameTextBox3.Text = fio[1];
            middlenameTextBox4.Text = fio[2];
            phoneNumberMaskedTextBox1.Text = data[2].Substring(1,11);
            birthDateTimePicker1.Value = DateTime.Parse(data[3].Substring(0, 10));
            numberIDTextBox2.Text = data[4];
            comboBoxCompletion();
            transmissionTypeComboBox4.SelectedIndex = transmissionTypeComboBox4.Items.IndexOf(data[5]);
            driveLicenseDateTimePicker2.Value = DateTime.Parse(data[6].Substring(0, 10));
        }
        
        // Метод для заполнения выпадающего списка данными
        private void comboBoxCompletion()
        {
            try
            {
                string command = "SELECT Тип FROM Типы_коробки_передач";
                SqlCommand cmd = new SqlCommand(command, Connection);
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    transmissionTypeComboBox4.Items.Add(reader[0].ToString());
                }
                Connection.Close();
            }
            catch (SqlException)
            {
                var mb = MessageBox.Show("Произошла ошибка во время заполнения выпадающих списков данными.", "Ошибка", MessageBoxButtons.OK);
                Connection.Close();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((secondnameTextBox1.Text.Length > 0) && (numberIDTextBox2.Text.Length == 10) && (firstnameTextBox3.Text.Length > 0) && (middlenameTextBox4.Text.Length > 0) && (phoneNumberMaskedTextBox1.Text.Length == 12))
            {
                editRoundedButton1.Enabled = true;
            }
            else
            {
                editRoundedButton1.Enabled = false;
            }
        }

        // Обработчик нажатия кнопки для изменения данных пользователя
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            try {
                string command = "UPDATE Клиенты\n" +
                "SET Фамилия = @Фамилия, Имя = @Имя, Отчество = @Отчество, Номер_телефона = @Номер_телефона, Дата_рождения = @Дата_рождения, Номер_удостоверения = @Номер_удостоверения, Номер_типа_передачи = @Номер_типа_передачи, Дата_получения_прав = @Дата_получения_прав\n" +
                "WHERE Номер_клиента = @Номер_клиента";
                SqlCommand cmd = new SqlCommand(command, Connection);
                Connection.Open();
                cmd.Parameters.AddWithValue("@Фамилия", secondnameTextBox1.Text);
                cmd.Parameters.AddWithValue("@Имя", firstnameTextBox3.Text);
                cmd.Parameters.AddWithValue("@Отчество", middlenameTextBox4.Text);
                cmd.Parameters.AddWithValue("@Номер_телефона", phoneNumberMaskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@Дата_рождения", birthDateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Номер_удостоверения", numberIDTextBox2.Text);
                cmd.Parameters.AddWithValue("@Номер_типа_передачи", transmissionTypeComboBox4.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@Дата_получения_прав", birthDateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Номер_клиента", clientID);
                cmd.ExecuteNonQuery();
                Connection.Close();
                var mb = MessageBox.Show("Данные изменены!", "Изменение данных", MessageBoxButtons.OK);
                if (mb == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (SqlException)
            {
                var mb = MessageBox.Show("Произошла ошибка во время изменения данных клиента.", "Ошибка", MessageBoxButtons.OK);
                Connection.Close();
                this.Close();
            }
        }

        // Обработчик нажатия кнопки "Назад" для закрытия формы
        private void roundedButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textOnly(object sender, KeyPressEventArgs e)
        {
            //разрешение ввода букв
            if ((e.KeyChar >= 'а' && e.KeyChar <= 'я') || (e.KeyChar >= 'А' && e.KeyChar <= 'Я') || e.KeyChar == 'Ё' || e.KeyChar == 'ё')
            {
                //ничего не делаем, то есть пропускаем этот символ
            }
            //разрешение кнопки Backspace
            else if (e.KeyChar == (char)Keys.Back)
            {
                //ничего не делаем, то есть пропускаем этот символ
            }
            //запрет вввода других символов
            else
            {
                e.Handled = true;
            }
        }

        private void numberOnly(object sender, KeyPressEventArgs e)
        {
            //разрешение ввода цифр
            if (char.IsDigit(e.KeyChar))
            {
                //ничего не делаем, то есть пропускаем этот символ
            }
            //разрешение кнопки Backspace
            else if (e.KeyChar == (char)Keys.Back)
            {
                //ничего не делаем, то есть пропускаем этот символ
            }
            //запрет вввода других символов
            else
            {
                e.Handled = true;
            }
        }
    }
}
