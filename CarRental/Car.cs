using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarRental
{
    public partial class Car : Form
    {
        SqlConnection Connection;
        int carID = 0;
        public RoundedButton RoundedButton1 { get; }

        // Конструктор для добавления автомобиля
        public Car(string text, SqlConnection MyConnection)
        {
            InitializeComponent();
            this.Text = text + " автомобиль";
            roundedButton1.Text = text;
            Connection = MyConnection;
            comboBoxCompletion();
        }

        // Конструктор для изменения данных автомобиля
        public Car(string text, string[] data, SqlConnection MyConnection)
        {
            InitializeComponent();
            this.Text = text + " данные автомобиля";
            roundedButton1.Text = text;
            roundedButton1.Enabled = true;
            Connection = MyConnection;
            carID = Convert.ToInt32(data[0]);
            comboBoxCompletion();
            // Заполнение полей текущими данными автомобиля
            markComboBox1.SelectedIndex = markComboBox1.Items.IndexOf($"{data[1]}");
            carTypeComboBox2.SelectedIndex = carTypeComboBox2.Items.IndexOf($"{data[3]}");
            transmissionTypeComboBox3.SelectedIndex = transmissionTypeComboBox3.Items.IndexOf($"{data[4]}");
            carClassComboBox4.SelectedIndex = carClassComboBox4.Items.IndexOf($"{data[5]}");
            modelTextBox1.Text = data[2];
            costTextBox2.Text = data[6].Substring(0, data[6].IndexOf(','));
        }

        private void textBoxMainForm_TextChanged(object sender, EventArgs e)
        {
            if ((modelTextBox1.Text.Length > 0) && (costTextBox2.Text.Length > 2))
            {
                roundedButton1.Enabled = true;
            }
            else
            {
                roundedButton1.Enabled = false;
            }
        }

        // Метод для заполнения выпадающих списков данными
        public void comboBoxCompletion()
        {
            try
            {
                string command = "SELECT Марка FROM Марки_автомобилей";
                SqlCommand cmd = new SqlCommand(command, Connection);
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    markComboBox1.Items.Add(reader[0].ToString());
                }
                Connection.Close();
                markComboBox1.SelectedIndex = 1;
                command = "SELECT Тип FROM Типы_автомобилей";
                cmd = new SqlCommand(command, Connection);
                Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    carTypeComboBox2.Items.Add(reader[0].ToString());
                }
                Connection.Close();
                carTypeComboBox2.SelectedIndex = 1;
                command = "SELECT Тип FROM Типы_коробки_передач";
                cmd = new SqlCommand(command, Connection);
                Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    transmissionTypeComboBox3.Items.Add(reader[0].ToString());
                }
                Connection.Close();
                transmissionTypeComboBox3.SelectedIndex = 1;
                command = "SELECT Класс FROM Классы_автомобилей";
                cmd = new SqlCommand(command, Connection);
                Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    carClassComboBox4.Items.Add(reader[0].ToString());
                }
                Connection.Close();
                carClassComboBox4.SelectedIndex = 1;
            }
            catch (SqlException)
            {
                var mb = MessageBox.Show("Произошла ошибка во время заполнения выпадающих списков данными.", "Ошибка", MessageBoxButtons.OK);
                Connection.Close();
                this.Close();
            }
        }

        // Обработчик нажатия кнопки "Назад" для закрытия формы
        private void roundedButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Обработчик нажатия кнопки для изменения данных автомобиля или добавления нового
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Конструкция для изменения данных автомобиля
                if (roundedButton1.Text == "Изменить")
                {
                    string command = "UPDATE Автомобили\n" +
                    "SET Марка = @Марка, Модель = @Модель, Тип_автомобиля = @Тип_автомобиля, Тип_коробки_передач = @Тип_коробки_передач, Класс_автомобиля = @Класс_автомобиля, Цена = @Цена\n" +
                    "WHERE Номер_автомобиля = @Номер_автомобиля";
                    SqlCommand cmd = new SqlCommand(command, Connection);
                    Connection.Open();
                    cmd.Parameters.AddWithValue("@Марка", markComboBox1.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@Модель", modelTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Тип_автомобиля", carTypeComboBox2.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@Тип_коробки_передач", transmissionTypeComboBox3.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@Класс_автомобиля", carClassComboBox4.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@Цена", costTextBox2.Text);
                    cmd.Parameters.AddWithValue("@Номер_автомобиля", carID);
                    cmd.ExecuteNonQuery();
                    Connection.Close();
                    var mb = MessageBox.Show("Данные изменены!", "Изменение данных", MessageBoxButtons.OK);
                    if (mb == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                // Конструкция для добавления нового автомобиля
                if (roundedButton1.Text == "Добавить")
                {
                    string command = "INSERT INTO Автомобили (Марка, Модель, Тип_автомобиля, Тип_коробки_передач, Класс_автомобиля, Цена) VALUES (@Марка, @Модель, @Тип_автомобиля, @Тип_коробки_передач, @Класс_автомобиля, @Цена)";
                    SqlCommand cmd = new SqlCommand(command, Connection);
                    Connection.Open();
                    cmd.Parameters.AddWithValue("@Марка", markComboBox1.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@Модель", modelTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Тип_автомобиля", carTypeComboBox2.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@Тип_коробки_передач", transmissionTypeComboBox3.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@Класс_автомобиля", carClassComboBox4.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@Цена", costTextBox2.Text);
                    cmd.ExecuteNonQuery();
                    Connection.Close();
                    var mb = MessageBox.Show("Автомобиль добавлен!", "Добавление автомобиля", MessageBoxButtons.OK);
                    if (mb == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            catch (SqlException)
            {
                var mb = MessageBox.Show("Произошла ошибка.", "Ошибка", MessageBoxButtons.OK);
                Connection.Close();
                this.Close();
            }
        }

        private void numberOnly(object sender, KeyPressEventArgs e)
        {
            // Разрешение ввода цифр
            if (char.IsDigit(e.KeyChar))
            {
                // Ничего не делаем, то есть пропускаем этот символ
            }
            // Разрешение кнопки Backspace
            else if (e.KeyChar == (char)Keys.Back)
            {
                // Ничего не делаем, то есть пропускаем этот символ
            }
            // Запрет ввода других символов
            else
            {
                e.Handled = true;
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
            // Разрешение кнопки Space
            else if (e.KeyChar == (char)Keys.Space)
            {
                // Ничего не делаем, то есть пропускаем этот символ
            }
            // Разрешение кнопки Backspace
            else if (e.KeyChar == (char)Keys.Back)
            {
                // Ничего не делаем, то есть пропускаем этот символ
            }
            // Запрет ввода других символов
            else
            {
                e.Handled = true;
            }
        }
    }
}
