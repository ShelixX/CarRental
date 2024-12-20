using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Runtime.CompilerServices;

namespace CarRental
{
    public partial class CarRental : Form
    {
        // Строка подключения
        static string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB; Initial catalog=CarRental; Integrated Security=True";
        // Подключение к базе данных
        SqlConnection MyConnection = new SqlConnection(connectionString);
        int role; // Переменная для хранения роли пользователя
        int userID; // Переменная для хранения идентификатора пользователя
        int carID; // Переменная для хранения идентификатора выбранного автомобиля

        // Свойства для модульного тестирования
        public int Role { get { return role; } }
        public int UserID { get; }
        public ComboBox ComboBox4 { get { return transmissionTypeComboBox4; } }
        public int TableLayoutPanel3RowCount { get { return carTableLayoutPanel3.RowStyles.Count; } }
        public Image PictureBox1Image { get { return logoPictureBox1.Image; } }
        public TabControl TabControl1 { get { return tabControl1; } }
        public DateTime DateTimePciker1MaxDate { get { return birthDateTimePicker1.MaxDate; } }
   
        // Конструктор формы
        public CarRental()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на кнопку авторизации
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            // Обработчик исключения
            try
            {
                bool loginCheck = false; // Переменная для хранения значения, которое указывает на наличие пользователя с введёнными данными
                string command = "DECLARE @bit bit EXEC @bit = ПроверкаАвторизации @login, @password SELECT @bit"; // Строка запроса
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                // Передача параметров
                cmd.Parameters.AddWithValue("@login", loginTextBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@password", passwordTextBox2.Text.ToString());
                MyConnection.Open(); // Открытие подключения
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) // Чтения возвращаемых результатов из бд
                {
                    loginCheck = (Convert.ToInt32(reader[0]) == 1) ? true : false; // Передача в перменную loginCheck значения true, если пользователь с введёнными данными существует, иначе false 
                }
                MyConnection.Close(); // Закрытие подключения
                if (loginCheck) // Проверка наличия пользователя
                {
                    var mb = MessageBox.Show("Авторизация прошла успешно!", "Авторизация", MessageBoxButtons.OK); // Создание окна с сообщением
                    // Выполнение конструкции при нажатии пользователем кнопки ОК или закрытия окна
                    if (mb == DialogResult.OK)
                    {
                        getUserInfo(loginTextBox1.Text.ToString()); // Получение идентификатора и роли пользователя
                        // Открытие формы администратора если роль администратор
                        if (role == 1)
                        {
                            adminForm();
                        }
                        // Открытие формы сотрудника если роль сотрудник
                        else if (role == 2)
                        {
                            employeeCars();
                        }
                        // Открытие формы клиента если роль клиент
                        else if (role == 3)
                        {
                            clientCars();
                        }
                    }
                }
                // Вывод сообщения в случае ввода некорректных данных
                else
                {
                    var mb = MessageBox.Show("Неверный логин или пароль!", "Авторизация", MessageBoxButtons.OK);
                }
            }
            // Обработка исключения вызванного ошибкой в базе данных
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка во время авторизации.", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Обработчик нажатия кнопки регистрации
        private void roundedButton2_Click(object sender, EventArgs e)
        {
            formClear(tabPage2);
            registrationForm();
        }

        // Открытие формы регистрации
        public void registrationForm()
        {
            try
            {
                tabControl1.SelectTab(tabPage2);
                DateTime dt = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day); // Получение даты с вычетом 18-ти лет
                birthDateTimePicker1.MaxDate = dt; // Запись максимального допустимого значения для выбора даты
                birthDateTimePicker1.Value = dt;
                driveLicenseDateTimePicker2.MaxDate = DateTime.Now;
                driveLicenseDateTimePicker2.Value = DateTime.Now;
                string command = "SELECT Тип FROM Типы_коробки_передач";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    transmissionTypeComboBox1.Items.Add(reader[0].ToString()); // Добавление в выпадающий список значений
                }
                MyConnection.Close();
                transmissionTypeComboBox1.SelectedIndex = 1;
            }
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка во время получения списка типов коробки передач.", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Обработчик изменения текста в textBox для блокировки кнопки в случае невыполнения условий
        private void registrationForm_TextChanged(object sender, EventArgs e)
        {
            if ((middlenameTextBox3.Text.Length > 0) && (phoneNumberMaskedTextBox1.Text.Length == 12) && (numberIDTextBox5.Text.Length == 10) && (secondNameTextBox7.Text.Length > 0) && (nameTextBox8.Text.Length > 0) && (loginTextBox10.Text.Length > 0) && (loginTextBox11.Text.Length > 0))
            {
                registerRoundedButton3.Enabled = true;
            }
            else
            {
                registerRoundedButton3.Enabled = false;
            }
        }

        // Обработчик изменения текста в textBox для блокировки кнопки в случае невыполнения условий
        private void textBoxMainForm_TextChanged(object sender, EventArgs e)
        {
            if ((loginTextBox1.Text.Length > 0) && (passwordTextBox2.Text.Length > 0))
            {
                enterRoundedButton1.Enabled = true;
            }
            else
            {
                enterRoundedButton1.Enabled = false;
            }
        }

        // Очистка элементов формы от значений внутри них
        private void formClear(TabPage tp)
        {
            // Аннулирование идентификатора автомобиля
            if (role == 3)
                carID = 0;
            // Аннулирование идентификатора автомобиля
            if (role == 3)
                carID = 0;
            // Проход по всем элементам страницы
            foreach (Control c in tp.Controls)
            {
                // Очистка текстовых полей
                if (c.GetType() == typeof(TextBox))
                    c.ResetText();
                // Очистка текстовых полей с маской
                else if (c.GetType() == typeof(MaskedTextBox))
                    ((MaskedTextBox)c).ResetText();
                // Очистка выпадающих списков
                else if (c.GetType() == typeof(ComboBox))
                    ((ComboBox)c).Items.Clear();
                // Выбор максмального значения даты для поля с датой
                else if (c.GetType() == typeof(DateTimePicker))
                    ((DateTimePicker)c).Value = ((DateTimePicker)c).MaxDate;
                // Очистка таблиц, кроме таблицы со стажем
                else if ((c.GetType() == typeof(TableLayoutPanel)) && (c.Name != "expirienceTableLayoutPanel1"))
                {
                    for (int i = 0; i < ((TableLayoutPanel)c).ColumnStyles.Count; i++)
                    {
                        for (int j = 1; j < ((TableLayoutPanel)c).RowStyles.Count; j++)
                        {
                            ((TableLayoutPanel)c).Controls.Remove(((TableLayoutPanel)c).GetControlFromPosition(i, j));
                        }
                    }
                }
            }

        }

        // Метод для записи в переменные идентификатор пользователя и его роль
        public void getUserInfo(string login)
        {
            string command = "SELECT Номер_пользователя, Роль FROM Пользователи WHERE Логин = @Логин";
            SqlCommand cmd = new SqlCommand(command, MyConnection);
            cmd.Parameters.AddWithValue("@Логин", login);
            MyConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userID = Convert.ToInt32(reader[0]);
                role = Convert.ToInt32(reader[1]);
            }
            MyConnection.Close();
        }

        // Открытие клиентской формы с автомобилями
        public void clientCars()
        {
            try
            {
                formClear(tabPage3); // Очистка элементов формы
                submitRoundedButton8.Enabled = false;
                rentalStartDateTimePicker3.MinDate = DateTime.Now;
                rentalStartDateTimePicker3.MaxDate = rentalStartDateTimePicker3.MinDate.AddMonths(1);
                rentalStartDateTimePicker3.Value = rentalStartDateTimePicker3.MinDate;
                rentalEndDateTimePicker4.MinDate = DateTime.Now.AddDays(1);
                rentalEndDateTimePicker4.MaxDate = rentalEndDateTimePicker4.MinDate.AddMonths(1);
                rentalEndDateTimePicker4.Value = rentalEndDateTimePicker4.MinDate;
                // Заполнение выпадающих спиской
                string command = "SELECT Марка FROM Марки_автомобилей";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    markFilterComboBox2.Items.Add(reader[0].ToString());
                }
                MyConnection.Close();
                command = "SELECT Тип FROM Типы_автомобилей";
                cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    carTypeFilterComboBox3.Items.Add(reader[0].ToString());
                }
                MyConnection.Close();
                command = "SELECT Тип FROM Типы_коробки_передач";
                cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    transmissionTypeComboBox4.Items.Add(reader[0].ToString());
                }
                MyConnection.Close();
                command = "SELECT Класс FROM Классы_автомобилей";
                cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    carClassComboBox5.Items.Add(reader[0].ToString());
                }
                MyConnection.Close();
                // Заполнение таблицы данными
                command = "SELECT * FROM СписокАвтомобилей";
                cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    clientCarsTableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
                    clientCarsTableLayoutPanel6.RowStyles[0].Height = 50;
                    clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[0].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 0, i);
                    clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[1].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 1, i);
                    clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[2].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 2, i);
                    clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[3].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 3, i);
                    clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[4].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 4, i);
                    clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[5].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 5, i);
                    clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[6].ToString().Substring(0, reader[6].ToString().IndexOf(',')), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 6, i);
                    FlowLayoutPanel panel = new FlowLayoutPanel() { Size = (new Size(110, 80)) };
                    // Запись тега для передачи в обработчик идентификатора автомобиля
                    string tag = reader[0].ToString();
                    RoundedButton choose = new RoundedButton() { Text = "Выбрать", Width = 150, Tag = tag };
                    choose.Click += new System.EventHandler(carChoose_Click);
                    clientCarsTableLayoutPanel6.Controls.Add(choose, 8, i);
                    i++;
                }
                MyConnection.Close();
                // Изменение ширины столбцов
                for (int j = 0; j < clientCarsTableLayoutPanel6.ColumnCount; j++)
                {
                    clientCarsTableLayoutPanel6.Controls[j].Width = 200;
                }
                tabControl1.SelectTab(tabPage3); // Переключение на клиентскую форму с автомобилями
            }
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка. Не удалось загрузить форму.", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Обработчик нажатия на кнопку выбора автомобиля
        private void carChoose_Click(object sender, EventArgs e)
        {
            // Проверка роли
            if (role == 3)
            {
                submitRoundedButton8.Enabled = true; // Выдача доступа к отправке заявки на прокат
                // Сохранение идентификатора выбранного автомобиля в переменную
                string car = ((RoundedButton)sender).Tag as string;
                carID = Convert.ToInt32(car);
            }
        }

        // Открытие формы сотрудника с автомобилями
        private void employeeCars()
        {
            try
            {
                formClear(tabPage5); // Очистка формы
                // Заполнение таблицы данными
                string command = "SELECT * FROM СписокАвтомобилей";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    carTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
                    carTableLayoutPanel2.RowStyles[0].Height = 50;
                    carTableLayoutPanel2.Controls.Add(new Label() { Text = reader[0].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 0, i);
                    carTableLayoutPanel2.Controls.Add(new Label() { Text = reader[1].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 1, i);
                    carTableLayoutPanel2.Controls.Add(new Label() { Text = reader[2].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 2, i);
                    carTableLayoutPanel2.Controls.Add(new Label() { Text = reader[3].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 3, i);
                    carTableLayoutPanel2.Controls.Add(new Label() { Text = reader[4].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 4, i);
                    carTableLayoutPanel2.Controls.Add(new Label() { Text = reader[5].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 5, i);
                    carTableLayoutPanel2.Controls.Add(new Label() { Text = reader[6].ToString().Substring(0, reader[6].ToString().IndexOf(',')), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 6, i);
                    FlowLayoutPanel panel = new FlowLayoutPanel() { Size = (new Size(110, 80)) };
                    // Сохранение тега для передачи данных на редактирование
                    string[] tag = new string[7] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString() };
                    RoundedButton edit = new RoundedButton() { Text = "Изменить", Width = 90, Tag = tag };
                    RoundedButton delete = new RoundedButton() { Text = "Удалить", Width = 90, Tag = $"{reader[0].ToString()}" };
                    edit.Click += new System.EventHandler(carEdit_Click);
                    delete.Click += new System.EventHandler(carDelete_Click);
                    panel.Controls.AddRange(new RoundedButton[] { edit, delete });
                    carTableLayoutPanel2.Controls.Add(panel, 7, i);
                    i++;
                }
                MyConnection.Close();
                for (int j = 0; j < carTableLayoutPanel2.ColumnCount; j++)
                {
                    carTableLayoutPanel2.Controls[j].Width = 200;
                }
                tabControl1.SelectTab(tabPage5);
            }
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка во загрузки формы с автомобилями!", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Обработчик нажатия на кнопку изменения данных автомобиля
        private void carEdit_Click(object sender, EventArgs e)
        {
            // Проверка роли на роль администратора или сотрудника
            if (role == 2 || role == 1)
            {
                string text = "Изменить";
                Car car = new Car(text, (((RoundedButton)sender).Tag) as string[], MyConnection);
                // Открытие формы для изменения данных автомобиля
                car.FormClosed += new FormClosedEventHandler(carClosed_FormClosed);
                car.ShowDialog();
            }
        }

        // Обработчик нажатия на кнопку удаления автомобиля
        private void carDelete_Click(object sender, EventArgs e)
        {
            if (role == 2 || role == 1)
            {
                try
                {
                    var mb = MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo);
                    // Удаление автомобиля в случае нажатия на кнопку Да
                    if (mb == DialogResult.Yes)
                    {
                        string command = "EXEC УдалитьАвто @Номер";
                        SqlCommand cmd = new SqlCommand(command, MyConnection);
                        MyConnection.Open();
                        cmd.Parameters.AddWithValue("@Номер", Convert.ToInt32(((RoundedButton)sender).Tag));
                        cmd.ExecuteNonQuery();
                        MyConnection.Close();
                        if (role == 2)
                            employeeCars();
                        else if (role == 1)
                            cars();
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Произошла ошибка во время удаления автомобиля!", "Ошибка", MessageBoxButtons.OK);
                    MyConnection.Close();
                }
            }
        }

        // Обработчик нажатия на кнопку удаления данных пользователя
        private void userDelete_Click(object sender, EventArgs e)
        {
            if (role == 1)
            {
                try
                {
                    var mb = MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo);
                    if (mb == DialogResult.Yes)
                    {
                        string command = "EXEC УдалитьПользователя @Номер";
                        SqlCommand cmd = new SqlCommand(command, MyConnection);
                        MyConnection.Open();
                        cmd.Parameters.AddWithValue("@Номер", Convert.ToInt32(((RoundedButton)sender).Tag));
                        cmd.ExecuteNonQuery();
                        MyConnection.Close();
                        users();
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Произошла ошибка во время удаления пользователя!", "Ошибка", MessageBoxButtons.OK);
                    MyConnection.Close();
                }
            }
        }

        // Обработчик нажатия на кнопку удаления данных клиента
        private void clientDelete_Click(object sender, EventArgs e)
        {
            if (role == 1)
            {
                try
                {
                    var mb = MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo);
                    if (mb == DialogResult.Yes)
                    {
                        string command = "EXEC УдалитьПользователя @Номер";
                        SqlCommand cmd = new SqlCommand(command, MyConnection);
                        MyConnection.Open();
                        cmd.Parameters.AddWithValue("@Номер", Convert.ToInt32(((RoundedButton)sender).Tag));
                        cmd.ExecuteNonQuery();
                        MyConnection.Close();
                        clients();
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Произошла ошибка во время удаления клиента!", "Ошибка", MessageBoxButtons.OK);
                    MyConnection.Close();
                }  
            }
        }

        // Обработчик вводимых символов в текстовое поле (только кириллица)
        public void textOnly(object sender, KeyPressEventArgs e)
        {
            // Разрешение ввода букв
            if ((e.KeyChar >= 'а' && e.KeyChar <= 'я') || (e.KeyChar >= 'А' && e.KeyChar <= 'Я') || e.KeyChar == 'Ё' || e.KeyChar == 'ё')
            {
                //ничего не делаем, то есть пропускаем этот символ
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

        // Обработчик вводимых символов в текстовое поле (только цифры)
        public void numberOnly(object sender, KeyPressEventArgs e)
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

        // Обработчик вводимых символов в текстовое поле (только текст и цифры)
        public void textAndNumbers(object sender, KeyPressEventArgs e)
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
            // Запрет ввода других символов
            else
            {
                e.Handled = true;
            }
        }

        // Обработчик нажатия на кнопку регистрации в форме для регистрации
        private void roundedButton3_Click(object sender, EventArgs e)
        {
            try
            {
                numberCheck(phoneNumberMaskedTextBox1.Text); // Проверка наличия клиента с введённым номером телефона и выброс исключения в случае успешного нахождения
                // Регистрация пользователя с введёнными данными
                string command = "EXEC КлиентРег @Фамилия, @Имя, @Отчество, @Номер_телефона, @Дата_рождения, @Номер_удостоверения, @Тип_коробки_передач, @Дата_получения_прав, @Логин, @Пароль";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                cmd.Parameters.AddWithValue("@Фамилия", secondNameTextBox7.Text);
                cmd.Parameters.AddWithValue("@Имя", nameTextBox8.Text);
                cmd.Parameters.AddWithValue("@Отчество", middlenameTextBox3.Text);
                cmd.Parameters.AddWithValue("@Номер_телефона", phoneNumberMaskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@Дата_рождения", birthDateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Номер_удостоверения", numberIDTextBox5.Text);
                cmd.Parameters.AddWithValue("@Тип_коробки_передач", transmissionTypeComboBox1.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@Дата_получения_прав", driveLicenseDateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@Логин", loginTextBox10.Text);
                cmd.Parameters.AddWithValue("@Пароль", loginTextBox11.Text);
                cmd.ExecuteNonQuery();
                MyConnection.Close();
                // Сообщение об успешной регистрации и переход на клиентскую форму с автомобилями
                var mb = MessageBox.Show("Регистрация прошла успешно!", "Регистрация", MessageBoxButtons.OK);
                if (mb == DialogResult.OK)
                {
                    getUserInfo(loginTextBox10.Text);
                    clientCars();
                }
            }
            // Обработка исключения при наличии пользователя с введённым логином
            catch (SqlException)
            {
                MessageBox.Show("Данный логин уже используется, попробуйте другой!", "Регистрация", MessageBoxButtons.OK);
                MyConnection.Close();
            }
            // Обработка исключения при наличии клиента с введённым номером телефона
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Регистрация", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Проверка на наличие клиента с введённым номером телефона
        public void numberCheck(string number)
        {
            bool numberCheck = false;
            string command = "DECLARE @bit bit EXEC @bit = ПроверкаНаличияКлиента @number SELECT @bit";
            SqlCommand cmd = new SqlCommand(command, MyConnection);
            cmd.Parameters.AddWithValue("@number", number);
            MyConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                numberCheck = (Convert.ToInt32(reader[0]) == 1) ? true : false;
            }
            MyConnection.Close();
            if (numberCheck)
            {
                throw new Exception("Пользователь с данным номером телефона уже зарегистрирован!");
            }
        }

        // Выход на форму авторизации
        public void exit_Click(object sender, EventArgs e)
        {
            formClear(tabPage1);
            tabControl1.SelectTab(tabPage1);
        }

        // Обработчик нажатия кнопки для открытия клиентской формы с автомобилями
        private void clientCars_Click(object sender, EventArgs e)
        {
            clientCars();
        }

        // Открытие формы с активной заявкой
        private void check_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectTab(tabPage4);
                string command = "SELECT * FROM dbo.ПросмотрЗаявки(@Номер)";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                cmd.Parameters.AddWithValue("@Номер", userID);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                // Вывод данных активной заявки в случае наличия
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        activeApplicationlabel30.Text = $"Автомобиль {reader[0].ToString()} на срок от {reader[1].ToString().Substring(0, 10)} до {reader[2].ToString().Substring(0, 10)}. Статус заявки: {reader[3].ToString()}.";
                    }
                }
                // Сообщение об отсутствии активной заявки
                else
                {
                    activeApplicationlabel30.Text = "У вас нет активных заявок";
                }
                MyConnection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка во время загрузки авктивной заявки!", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Обработчик нажатия кнопки для открытия формы сотрудника с автомобилями
        private void employeeCars_Click(object sender, EventArgs e)
        {
            employeeCars();
        }

        // Обработчик нажатия кнопки для открытия формы сотрудника с заявками на прокат
        private void statusChange_Click(object sender, EventArgs e)
        {
            statusChange();
        }

        // Открытие формы с заявками на прокат сотрудника
        private void statusChange()
        {
            try
            {
                formClear(tabPage6);
                string command = "SELECT * FROM СписокЗаявок";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    applicationsTableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
                    applicationsTableLayoutPanel4.RowStyles[0].Height = 50;
                    applicationsTableLayoutPanel4.Controls.Add(new Label() { Text = reader[0].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 0, i);
                    applicationsTableLayoutPanel4.Controls.Add(new Label() { Text = reader[1].ToString().Substring(0, 10), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 1, i);
                    applicationsTableLayoutPanel4.Controls.Add(new Label() { Text = reader[2].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 2, i);
                    applicationsTableLayoutPanel4.Controls.Add(new Label() { Text = reader[3].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 3, i);
                    applicationsTableLayoutPanel4.Controls.Add(new Label() { Text = reader[4].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 4, i);
                    applicationsTableLayoutPanel4.Controls.Add(new Label() { Text = reader[5].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 5, i);
                    applicationsTableLayoutPanel4.Controls.Add(new Label() { Text = reader[6].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 6, i);
                    applicationsTableLayoutPanel4.Controls.Add(new Label() { Text = reader[7].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 7, i);
                    RoundedButton edit = new RoundedButton() { Text = "Изменить статус", Width = 100, Height = 44, Tag = new string[2] { reader[0].ToString(), reader[7].ToString() } };
                    edit.Click += new System.EventHandler(statusEdit_Click);
                    applicationsTableLayoutPanel4.Controls.Add(edit, 8, i);
                    i++;
                }
                MyConnection.Close();
                if (applicationsTableLayoutPanel4.RowCount > 1)
                {
                    for (int j = 0; j < applicationsTableLayoutPanel4.ColumnCount; j++)
                    {
                        applicationsTableLayoutPanel4.Controls[j].Width = 200;
                    }
                }
                tabControl1.SelectTab(tabPage6);
            }
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка во время загрузки формы с заявками!", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Обработчик нажатия кнопки для изменения статуса заявки
        private void statusEdit_Click(object sender, EventArgs e)
        {
            if (role == 1 || role == 2)
            {
                string[] tag = ((RoundedButton)sender).Tag as string[];
                int ID = Convert.ToInt32(tag[0]);
                StatusEdit se = new StatusEdit(ID, tag[1], MyConnection);
                se.FormClosed += new FormClosedEventHandler(statusEditClosed_FormClosed);
                se.ShowDialog();
            }
        }

        // Обработчик закрытия формы изменения статуса заявки
        private void statusEditClosed_FormClosed(Object sender, FormClosedEventArgs e)
        {
            // Переход на форму сотруднка для изменения статуса заявки 
            if (role == 2)
                statusChange();
            // Переход на форму администратора для изменения статуса заявки 
            else if (role == 1)
                status();
        }

        // Обработчик нажатия кнопки для открытия формы администрации
        private void adminForm_Click(object sender, EventArgs e)
        {
            adminForm();
        }

        // Открытие формы администратора
        private void adminForm()
        {
            formClear(tabPage7);
            tabControl1.SelectTab(tabPage7);
        }

        // Обработчик нажатия кнопки для открытия формы администратора с пользователями
        private void users_Click(object sender, EventArgs e)
        {
            users();
        }

        // Открытие формы администратора с пользователями
        private void users()
        {
            try
            {
                formClear(tabPage11);
                DataGridViewButtonCell b = new DataGridViewButtonCell();
                string command = "SELECT Пользователи.Номер_пользователя, Пользователи.Логин, Роли.Роль FROM Пользователи INNER JOIN Роли ON Пользователи.Роль=Роли.Номер_роли WHERE Пользователи.Роль not in (1)";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    usersTableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
                    usersTableLayoutPanel7.RowStyles[0].Height = 50;
                    usersTableLayoutPanel7.Controls.Add(new Label() { Text = reader[0].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 0, i);
                    usersTableLayoutPanel7.Controls.Add(new Label() { Text = reader[1].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 1, i);
                    usersTableLayoutPanel7.Controls.Add(new Label() { Text = "******", TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 2, i);
                    usersTableLayoutPanel7.Controls.Add(new Label() { Text = reader[2].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 3, i);
                    FlowLayoutPanel panel = new FlowLayoutPanel() { Size = (new Size(110, 80)) };
                    string[] tag = new string[2] { reader[0].ToString(), reader[1].ToString() };
                    RoundedButton edit = new RoundedButton() { Text = "Изменить", Width = 90, Tag = tag };
                    RoundedButton delete = new RoundedButton() { Text = "Удалить", Width = 90, Tag = $"{reader[0].ToString()}" };
                    edit.Click += new System.EventHandler(userEdit_Click);
                    delete.Click += new System.EventHandler(userDelete_Click);
                    panel.Controls.AddRange(new RoundedButton[] { edit, delete });
                    usersTableLayoutPanel7.Controls.Add(panel, 7, i);
                    i++;
                }
                MyConnection.Close();
                for (int j = 0; j < usersTableLayoutPanel7.ColumnCount; j++)
                {
                    usersTableLayoutPanel7.Controls[j].Width = 200;
                }
                tabControl1.SelectTab(tabPage11);
            }
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка во время загрузки формы с пользователями!", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Обработчик нажатия кнопки для добавления сотруднка
        private void employeeAdd_Click(object sender, EventArgs e)
        {
            if (role == 1)
            {
                User user = new User("Добавить",  MyConnection);
                user.FormClosed += new FormClosedEventHandler(userEdit_employeeAdd_FormClosed);
                user.ShowDialog();
            }
        }

        // Обработчик нажатия кнопки для изменения данных пользователя
        private void userEdit_Click(object sender, EventArgs e)
        {
            if (role == 1)
            {
                string[] tag = ((RoundedButton)sender).Tag as string[];
                User user = new User("Изменить", tag, MyConnection);
                user.FormClosed += new FormClosedEventHandler(userEdit_employeeAdd_FormClosed);
                user.ShowDialog();
            }
        }

        // Обработчик закрытия формы изменения данных пользователя
        private void userEdit_employeeAdd_FormClosed(Object sender, FormClosedEventArgs e)
        {
            users();
        }

        // Обработчик нажатия кнопки для открытия формы администратора с автомобилями
        private void cars_Click(object sender, EventArgs e)
        {
            cars();
        }

        // Проверка на соответствие типа коробки передач
        private bool transmissionCheck()
        {
            int id1 = 0;
            int id2 = 0;
            string command = "SELECT Номер_типа_передачи FROM Клиенты WHERE Номер_клиента = @Номер";
            SqlCommand cmd = new SqlCommand(command, MyConnection);
            MyConnection.Open();
            cmd.Parameters.AddWithValue("@Номер", userID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id1 = Convert.ToInt32(reader[0].ToString());
            }
            MyConnection.Close();
            command = "SELECT Тип_коробки_передач FROM Автомобили WHERE Номер_автомобиля = @Номер";
            cmd = new SqlCommand(command, MyConnection);
            MyConnection.Open();
            cmd.Parameters.AddWithValue("@Номер", carID);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id2 = Convert.ToInt32(reader[0].ToString());
            }
            MyConnection.Close();
            // Проверка, является ли может ли водитель взять автомобиль с механической коробкой передач
            if (id1 == 2 && id2 == 1)
                return false;
            else return true;
        }

        // Проверка на соответствие требуемого стажа и стажа клиента
        private bool experienceCheck()
        {
            DateTime dt = new DateTime();
            int carClass = 0;
            string command = "SELECT Дата_получения_прав FROM Клиенты WHERE Номер_клиента = @Номер";
            SqlCommand cmd = new SqlCommand(command, MyConnection);
            MyConnection.Open();
            cmd.Parameters.AddWithValue("@Номер", userID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dt = DateTime.Parse(reader[0].ToString()).AddDays(1);
            }
            MyConnection.Close();
            command = "SELECT Класс_автомобиля FROM Автомобили WHERE Номер_автомобиля = @Номер";
            cmd = new SqlCommand(command, MyConnection);
            MyConnection.Open();
            cmd.Parameters.AddWithValue("@Номер", carID);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                carClass = Convert.ToInt32(reader[0].ToString());
            }
            MyConnection.Close();
            
            TimeSpan timeSpan = DateTime.Now.Date.Subtract(dt.Date);
            DateTime zeroTime = new DateTime(1, 1, 1);
            int years;
            if (timeSpan.TotalDays >= 0)
                years = (zeroTime + timeSpan).Year - 1;
            else years = 0;
            if (years < 5 && carClass == 3)
                return false;
            else if (years < 2 && carClass == 2)
                return false;
            else return true;
        }

        // Обработчик нажатия кнопки для отправки заявки на прокат автомобиля
        private void roundedButton8_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "SELECT * FROM dbo.ПросмотрЗаявки(@Номер)";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                cmd.Parameters.AddWithValue("@Номер", userID);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MyConnection.Close();
                    throw new Exception("У вас уже есть активная заявка.");
                }
                MyConnection.Close();
                if (!transmissionCheck()) throw new Exception("Вы не можете взять автомобиль с механическим типом коробки передач!"); // Выброс исключения в случае несоответвии типа коробки передач
                if (!experienceCheck()) throw new Exception("Вы не можете взять автомобиль с текущим стажем вождения!"); // Выброс исключения в случае отсутствия требуемого стажа
                command = "INSERT INTO Заявки (Дата, Клиент, Номер_телефона, Автомобиль, Начало_аренды, Конец_аренды, Статус)\n" +
                    "VALUES (@Дата, @Клиент, (SELECT Номер_телефона FROM Клиенты WHERE Номер_клиента = @Клиент), @Автомобиль, @Начало_аренды, @Конец_аренды, @Статус)";
                cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                cmd.Parameters.AddWithValue("@Дата", DateTime.Now);
                cmd.Parameters.AddWithValue("@Клиент", userID);
                cmd.Parameters.AddWithValue("@Автомобиль", carID);
                cmd.Parameters.AddWithValue("@Начало_аренды", rentalStartDateTimePicker3.Value);
                cmd.Parameters.AddWithValue("@Конец_аренды", rentalEndDateTimePicker4.Value);
                cmd.Parameters.AddWithValue("@Статус", 1);
                cmd.ExecuteNonQuery();
                MyConnection.Close();
                var mb = MessageBox.Show("Заявка успешно оставлена.", "", MessageBoxButtons.OK);
                if (mb == DialogResult.OK)
                {
                    submitRoundedButton8.Enabled = false;
                    clientCars();
                }
            }
            catch (SqlException)
            {
                var mb = MessageBox.Show("Произошла ошибка. Не удалось оставить заявку.", "Ошибка", MessageBoxButtons.OK);
                if (mb == DialogResult.OK)
                {
                    MyConnection.Close();
                    submitRoundedButton8.Enabled = false;
                    clientCars();
                }
            }
            catch (Exception ex)
            {
                var mb = MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
                if (mb == DialogResult.OK)
                {
                    MyConnection.Close();
                    submitRoundedButton8.Enabled = false;
                    clientCars();
                }
            }
        }

        // Открытие формы администратора с автомобилями
        public void cars()
        {
            try
            {
                formClear(tabPage8);
                string command = "SELECT * FROM СписокАвтомобилей";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    carTableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
                    carTableLayoutPanel3.RowStyles[0].Height = 50;
                    carTableLayoutPanel3.Controls.Add(new Label() { Text = reader[0].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 0, i);
                    carTableLayoutPanel3.Controls.Add(new Label() { Text = reader[1].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 1, i);
                    carTableLayoutPanel3.Controls.Add(new Label() { Text = reader[2].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 2, i);
                    carTableLayoutPanel3.Controls.Add(new Label() { Text = reader[3].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 3, i);
                    carTableLayoutPanel3.Controls.Add(new Label() { Text = reader[4].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 4, i);
                    carTableLayoutPanel3.Controls.Add(new Label() { Text = reader[5].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 5, i);
                    carTableLayoutPanel3.Controls.Add(new Label() { Text = reader[6].ToString().Substring(0, reader[6].ToString().IndexOf(',')), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(150, 75) }, 6, i);
                    FlowLayoutPanel panel = new FlowLayoutPanel() { Size = (new Size(110, 80)) };
                    string[] tag = new string[7] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString() };
                    RoundedButton edit = new RoundedButton() { Text = "Изменить", Width = 90, Tag = tag };
                    RoundedButton delete = new RoundedButton() { Text = "Удалить", Width = 90, Tag = $"{reader[0].ToString()}" };
                    edit.Click += new System.EventHandler(carEdit_Click);
                    delete.Click += new System.EventHandler(carDelete_Click);
                    panel.Controls.AddRange(new RoundedButton[] { edit, delete });
                    carTableLayoutPanel3.Controls.Add(panel, 7, i);
                    i++;
                }
                MyConnection.Close();
                for (int j = 0; j < carTableLayoutPanel3.ColumnCount; j++)
                {
                    carTableLayoutPanel3.Controls[j].Width = 200;
                }
                tabControl1.SelectTab(tabPage8);
            }
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка во время загрузки формы с автомобилями!", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Обработчик нажатия кнопки для открытия формы администратора с заявками на прокат
        private void status_Click(object sender, EventArgs e)
        {
            status();
        }

        // Открытие формы администратора с заявками на прокат
        private void status()
        {
            try
            {
                formClear(tabPage9);
                string command = "SELECT * FROM СписокЗаявок";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    applicationsTableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
                    applicationsTableLayoutPanel5.RowStyles[0].Height = 50;
                    applicationsTableLayoutPanel5.Controls.Add(new Label() { Text = reader[0].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 0, i);
                    applicationsTableLayoutPanel5.Controls.Add(new Label() { Text = reader[1].ToString().Substring(0, 10), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 1, i);
                    applicationsTableLayoutPanel5.Controls.Add(new Label() { Text = reader[2].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 2, i);
                    applicationsTableLayoutPanel5.Controls.Add(new Label() { Text = reader[3].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 3, i);
                    applicationsTableLayoutPanel5.Controls.Add(new Label() { Text = reader[4].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 4, i);
                    applicationsTableLayoutPanel5.Controls.Add(new Label() { Text = reader[5].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 5, i);
                    applicationsTableLayoutPanel5.Controls.Add(new Label() { Text = reader[6].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 6, i);
                    applicationsTableLayoutPanel5.Controls.Add(new Label() { Text = reader[7].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 7, i);
                    RoundedButton edit = new RoundedButton() { Text = "Изменить статус", Width = 100, Height = 44 };
                    edit.Click += new System.EventHandler(statusEdit_Click);
                    applicationsTableLayoutPanel5.Controls.Add(edit, 8, i);
                    i++;
                }
                MyConnection.Close();
                if (applicationsTableLayoutPanel5.RowCount > 1)
                {
                    for (int j = 0; j < applicationsTableLayoutPanel5.ColumnCount; j++)
                    {
                        applicationsTableLayoutPanel5.Controls[j].Width = 200;
                    }
                }
                tabControl1.SelectTab(tabPage9);
            }
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка во время загрузки формы с заявками!", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }
        // Обработчик нажатия кнопки для открытия формы администратора с клиентами
        private void clients_Click(object sender, EventArgs e)
        {
            clients();
        }

        // Открытие формы администратора с клиентами
        private void clients()
        {
            try
            {
                formClear(tabPage10);
                string command = "SELECT Клиенты.Номер_клиента, Клиенты.Фамилия + ' ' + Клиенты.Имя + ' ' + Клиенты.Отчество, Клиенты.Номер_телефона," +
                    " Клиенты.Дата_рождения, Клиенты.Номер_удостоверения, Типы_коробки_передач.Тип, Клиенты.Дата_получения_прав FROM Клиенты INNER JOIN Типы_коробки_передач ON Клиенты.Номер_типа_передачи = Типы_коробки_передач.Номер_типа";
                SqlCommand cmd = new SqlCommand(command, MyConnection);
                MyConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    clientsTableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
                    clientsTableLayoutPanel8.RowStyles[0].Height = 50;
                    clientsTableLayoutPanel8.Controls.Add(new Label() { Text = reader[0].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 0, i);
                    clientsTableLayoutPanel8.Controls.Add(new Label() { Text = reader[1].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 1, i);
                    clientsTableLayoutPanel8.Controls.Add(new Label() { Text = reader[2].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 2, i);
                    clientsTableLayoutPanel8.Controls.Add(new Label() { Text = reader[3].ToString().Substring(0, 10), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 3, i);
                    clientsTableLayoutPanel8.Controls.Add(new Label() { Text = reader[4].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 4, i);
                    clientsTableLayoutPanel8.Controls.Add(new Label() { Text = reader[5].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 5, i);
                    clientsTableLayoutPanel8.Controls.Add(new Label() { Text = reader[6].ToString().Substring(0, 10), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 6, i);
                    FlowLayoutPanel panel = new FlowLayoutPanel() { Size = (new Size(110, 80)) };
                    string[] tag = new string[7] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString() };
                    RoundedButton edit = new RoundedButton() { Text = "Изменить", Width = 90, Tag = tag };
                    RoundedButton delete = new RoundedButton() { Text = "Удалить", Width = 90, Tag = $"{reader[0].ToString()}" };
                    edit.Click += new System.EventHandler(clientEdit_Click);
                    delete.Click += new System.EventHandler(clientDelete_Click);
                    panel.Controls.AddRange(new RoundedButton[] { edit, delete });
                    clientsTableLayoutPanel8.Controls.Add(panel, 7, i);
                    i++;
                }
                MyConnection.Close();
                if (clientsTableLayoutPanel8.RowCount > 1)
                {
                    for (int j = 0; j < clientsTableLayoutPanel8.ColumnCount; j++)
                    {
                        clientsTableLayoutPanel8.Controls[j].Width = 200;
                    }
                }
                tabControl1.SelectTab(tabPage10);
            }
            catch (SqlException)
            {
                MessageBox.Show("Произошла ошибка во время загрузки формы с клиентами!", "Ошибка", MessageBoxButtons.OK);
                MyConnection.Close();
            }
        }

        // Обработчик нажатия кнопки для добавления автомобиля
        private void carAdd_Click(object sender, EventArgs e)
        {
            if (role == 1 || role ==2)
            {
                Car car = new Car("Добавить", MyConnection);
                car.FormClosed += new FormClosedEventHandler(carClosed_FormClosed);
                car.ShowDialog();
            }
        }

        // Обработчик нажатия кнопки для изменения данных клиента
        private void clientEdit_Click(object sender, EventArgs e)
        {
            if (role == 1)
            {
                ClientsEdit clientEdit = new ClientsEdit(((RoundedButton)sender).Tag as string[], MyConnection);
                clientEdit.FormClosed += new FormClosedEventHandler(clientEditClosed_FormClosed);
                clientEdit.ShowDialog();
            }
        }

        // Обработчик закрытия формы для изменения данных клиента
        private void clientEditClosed_FormClosed(Object sender, FormClosedEventArgs e)
        {
            clients();
        }

        // Обработчик закрытия формы для изменения или добавления данных клиента
        private void carClosed_FormClosed(Object sender, FormClosedEventArgs e)
        {
            if (role == 2)
                employeeCars();
            else if (role == 1)
                cars();
        }

        // Обработчик изменение выбора в выпадающем списке
        private void filter_SelectedValueChanged(object sender, EventArgs e)
        {
            carID = 0;
            submitRoundedButton8.Enabled = false;
            foreach (Control c in tabPage3.Controls)
            {
                if ((c.GetType() == typeof(TableLayoutPanel)) && (c.Name != "tableLayoutPanel1"))
                {
                    for (int i = 0; i < ((TableLayoutPanel)c).ColumnStyles.Count; i++)
                    {
                        for (int j = 1; j < ((TableLayoutPanel)c).RowStyles.Count; j++)
                        {
                            ((TableLayoutPanel)c).Controls.Remove(((TableLayoutPanel)c).GetControlFromPosition(i, j));
                        }
                    }
                }
            }
            string command = "SELECT * FROM СписокАвтомобилей";
            SqlCommand cmd = new SqlCommand(command, MyConnection);
            MyConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int k = 1;
            while (reader.Read())
            {
                // Проверка на выбор в выпадающем списке и совпадении значения выпадающего списка с данными автомобиля
                if (markFilterComboBox2.SelectedIndex != -1 && markFilterComboBox2.Text != reader[1].ToString())
                    continue;
                if (carTypeFilterComboBox3.SelectedIndex != -1 && carTypeFilterComboBox3.Text != reader[3].ToString())
                    continue;
                if (transmissionTypeComboBox4.SelectedIndex != -1 && transmissionTypeComboBox4.Text != reader[4].ToString())
                    continue;
                if (carClassComboBox5.SelectedIndex != -1 && carClassComboBox5.Text != reader[5].ToString())
                    continue;
                clientCarsTableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));
                clientCarsTableLayoutPanel6.RowStyles[0].Height = 50;
                clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[0].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 0, k);
                clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[1].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 1, k);
                clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[2].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 2, k);
                clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[3].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 3, k);
                clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[4].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 4, k);
                clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[5].ToString(), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 5, k);
                clientCarsTableLayoutPanel6.Controls.Add(new Label() { Text = reader[6].ToString().Substring(0, reader[6].ToString().IndexOf(',')), TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Size = new Size(200, 75) }, 6, k);
                FlowLayoutPanel panel = new FlowLayoutPanel() { Size = (new Size(110, 80)) };
                string tag = reader[0].ToString();
                RoundedButton choose = new RoundedButton() { Text = "Выбрать", Width = 150, Tag = tag };
                choose.Click += new System.EventHandler(carChoose_Click);
                clientCarsTableLayoutPanel6.Controls.Add(choose, 8, k);
                k++;
            }
            MyConnection.Close();
            if (clientCarsTableLayoutPanel6.RowCount > 1)
            {
                for (int j = 0; j < clientCarsTableLayoutPanel6.ColumnCount; j++)
                {
                    clientCarsTableLayoutPanel6.Controls[j].Width = 200;
                }
            }
        }

        // Обработчик нажатия кнопки для отмены фильтрации списка автомобилей
        public void filterClear_Click(object sender, EventArgs e)
        {
            markFilterComboBox2.SelectedIndex = -1;
            carTypeFilterComboBox3.SelectedIndex = -1;
            transmissionTypeComboBox4.SelectedIndex = -1;
            carClassComboBox5.SelectedIndex = -1;
        }
    }
}