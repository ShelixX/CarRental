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
    public partial class User : Form
    {
        SqlConnection Connection;
        int userID = 0;

        // Конструктор для формы добавления сотрудника
        public User(string text, SqlConnection MyConnection)
        {
            InitializeComponent();
            this.Text = text + " сотрудника"; // Изменение названия формы
            roundedButton1.Text = text; // Изменение названия кнопки
            Connection = MyConnection;
        }

        // Конструктор для формы изменения данных пользователя
        public User(string text, string[] data, SqlConnection MyConnection)
        {
            InitializeComponent();
            this.Text = text + " данные пользователя"; // Изменение названия формы
            roundedButton1.Text = text; // Изменение названия кнопки
            Connection = MyConnection;
            roundedButton1.Tag = data[1];
            userID = Convert.ToInt32(data[0]);
            loginTextBox1.Text = data[1];
        }

        private void textBoxMainForm_TextChanged(object sender, EventArgs e)
        {
            if ((loginTextBox1.Text.Length > 0) && (passwordTextBox2.Text.Length > 0))
            {
                roundedButton1.Enabled = true;
            }
            else
            {
                roundedButton1.Enabled = false;
            }
        }

        // Обработчик нажатия кнопки "Назад" для закрытия формы
        private void roundedButton4_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие формы
        }

        // Обработчик нажатия кнопки добавления сотрудника или изменения данных пользователя
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            bool checkLogin = false;
            string command = "SELECT dbo.ПроверкаНаличияПользователя(@Логин)";
            SqlCommand cmd = new SqlCommand(command, Connection);
            Connection.Open();
            cmd.Parameters.AddWithValue("@Логин", loginTextBox1.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                checkLogin = (Convert.ToInt32(reader[0]) == 1) ? true : false;
            }
            Connection.Close();
            try
            {
                if (roundedButton1.Text == "Изменить")
                {
                    if (checkLogin && loginTextBox1.Text != ((RoundedButton)sender).Tag.ToString())
                        throw new Exception("Пользователь с данным логином уже существует."); // Выброс исключения в случае попытки изменения логина пользователя на уже существующий логин
                    command = "UPDATE Пользователи\n" +
                    "SET Логин = @Логин, Пароль = HASHBYTES('SHA2_256', @Пароль)\n" +
                    "WHERE Номер_пользователя = @Номер_пользователя";
                    cmd = new SqlCommand(command, Connection);
                    Connection.Open();
                    cmd.Parameters.AddWithValue("@Логин", loginTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Пароль", passwordTextBox2.Text);
                    cmd.Parameters.AddWithValue("@Номер_пользователя", userID);
                    cmd.ExecuteNonQuery();
                    Connection.Close();
                    var mb = MessageBox.Show("Данные пользователя изменены!", "Изменение данных пользователя", MessageBoxButtons.OK);
                    if (mb == DialogResult.OK)
                    {
                        this.Close(); // Закрытие формы
                    }
                }
                if (roundedButton1.Text == "Добавить")
                {
                    if (checkLogin)
                        throw new Exception("Пользователь с данным логином уже существует."); // Выброс исключения в случае попытки добавления сотрудника с уже существующим логином
                    command = "INSERT INTO Пользователи (Логин, Пароль, Роль) VALUES (@Логин, HASHBYTES('SHA2_256', @Пароль), @Роль)";
                    cmd = new SqlCommand(command, Connection);
                    Connection.Open();
                    cmd.Parameters.AddWithValue("@Логин", loginTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Пароль", passwordTextBox2.Text);
                    cmd.Parameters.AddWithValue("@Роль", 2);
                    cmd.ExecuteNonQuery();
                    Connection.Close();
                    var mb = MessageBox.Show("Сотрудник добавлен!", "Добавление сотрудника", MessageBoxButtons.OK);
                    if (mb == DialogResult.OK)
                    {
                        this.Close(); // Закрытие формы
                    }
                }
            }
            catch (SqlException)
            {
                var mb = MessageBox.Show("Произошла ошибка.", "Ошибка", MessageBoxButtons.OK);
                Connection.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                var mb = MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void textAndNumbers(object sender, KeyPressEventArgs e)
        {
            // Разрешение ввода цифр
            if (char.IsDigit(e.KeyChar))
            {
                // Ничего не делаем, то есть пропускаем этот символ
            }
            // Разрешение ввода букв
            else if (Char.IsLetter(e.KeyChar))
            {
                // Ничего не делаем, то есть пропускаем этот символ
            }
            // Разрешение кнопки Backspace
            else if (e.KeyChar == (char)Keys.Back)
            {
                // Ничего не делаем, то есть пропускаем этот символ
            }
            // Запрет вввода других символов
            else
            {
                e.Handled = true;
            }
        }
    }
}
