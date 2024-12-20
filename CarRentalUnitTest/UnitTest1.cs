using CarRental;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;


namespace CarRentalUnitTest
{
    [TestClass]
    public class CarRentalUnitTest
    {
        // Тест на проверку получения идентификатора пользователя в методе getUserInfo
        [TestMethod]
        public void getUserInfo_UserIdIsNotNull()
        {
            CarRental.CarRental form1 = new CarRental.CarRental();
            form1.getUserInfo("illithid1");
            Assert.IsNotNull(form1.UserID, "Идентификатор пользователя не найден.");
        }

        // Тест на проверку получение корректной роли пользователя в методе getUserInfo
        [TestMethod]
        public void getUserInfo_UserRoleIsClient()
        {
            CarRental.CarRental form1 = new CarRental.CarRental();
            form1.getUserInfo("illithid1");
            Assert.AreEqual(3, form1.Role,  "Пользователь не клиент.");
        }

        // Тест на проверку выброса исключения в случае ввода существущего номер телефона в методе numberCheck
        [TestMethod]
        public void numberCheck_ThrowingAnException()
        {
            try
            {
                CarRental.CarRental form1 = new CarRental.CarRental();
                form1.numberCheck("+79998877766");
                throw new Exception("Пользователя с данным номером телефона нет.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Пользователь с данным номером телефона уже зарегистрирован!", ex.Message, "Исключение не возникло.");
            }
        }

        // Тест на проверку заполнения списка с типами коробки передач
        [TestMethod]
        public void clients_ComboboxCompletion()
        {
            CarRental.CarRental form1 = new CarRental.CarRental();
            form1.clientCars();
            Assert.IsNotNull(form1.ComboBox4.Items, "Список с типами коробки передачи не заполнен.");
        }

        // Тест на проверку очистки фильтрации по типу коробки передач
        [TestMethod]
        public void clients_TransmissionTypeFilterClear()
        {
            CarRental.CarRental form1 = new CarRental.CarRental();
            form1.clientCars();
            form1.ComboBox4.SelectedIndex = 1;
            RoundedButton rb = new RoundedButton();
            rb.Click += new EventHandler(form1.filterClear_Click);
            rb.PerformClick();
            Assert.AreEqual(-1, form1.ComboBox4.SelectedIndex, "Очистка фильтрации по типу коробки передач не выполнена.");
        }


        // Тест на проверку загрузки логотипа на форме
        [TestMethod]
        public void clients_CheckLogoNotNull()
        {
            CarRental.CarRental form1 = new CarRental.CarRental();
            form1.clientCars();
            Assert.IsNotNull(form1.PictureBox1Image, "Логотип отсутствуют на форме.");
        }

        // Тест на проверку заполнения таблицы с автомобилями
        [TestMethod]
        public void cars_CarsTableCompletion()
        {
            CarRental.CarRental form1 = new CarRental.CarRental();
            form1.cars();
            Assert.IsTrue(form1.TableLayoutPanel3RowCount > 1, "Таблица не заполнена данными об автомобилях.");
        }

        // Тест на проверку перехода к форме авторизации после нажатия кнопки
        [TestMethod]
        public void exit_CheckReturnToAuth()
        {
            CarRental.CarRental form1 = new CarRental.CarRental();
            form1.TabControl1.SelectedIndex = 2; 
            RoundedButton rb = new RoundedButton();
            rb.Click += new EventHandler(form1.exit_Click);
            rb.PerformClick();
            Assert.AreEqual(0, form1.TabControl1.SelectedIndex, "Возврат на форму авторизации не выполнен.");
        }

        // Тест на проверку установки максимальной даты
        [TestMethod]
        public void registrationForm_MaxdateOfBirth18YearsAgoCheck()
        {
            CarRental.CarRental form1 = new CarRental.CarRental();
            form1.registrationForm();
            Assert.AreEqual(new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day), form1.DateTimePciker1MaxDate, $"Максимальная дата не {new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day).ToShortDateString()}.");
        }

        // Тест на проверку загрузки элементов формы
        [TestMethod]
        public void form_FormControlsNotNullCheck()
        {
            CarRental.CarRental form1 = new CarRental.CarRental();
            Assert.IsNotNull(form1.Controls, "На форме нет элементов.");
        }
    }
}