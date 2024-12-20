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
    public partial class StatusEdit : Form
    {
        int id;
        SqlConnection Connection;
        public StatusEdit(int id, string status, SqlConnection MyConnection)
        {
            InitializeComponent();
            Connection = MyConnection;
            this.id = id;
            if (status == "Ожидает обработки") // Выдача доступа к кнопкам в случае статуса заявки "Ожидает обработки"
            {
                confirmRoundedButton1.Enabled = true;
                rejectRoundedButton2.Enabled = true;
                completeRoundedButton3.Enabled = false;
            }
            else if (status == "Заявка принята") // Выдача доступа к кнопкам в случае статуса заявки "Заявка принята"
            {
                confirmRoundedButton1.Enabled = false;
                rejectRoundedButton2.Enabled = true;
                completeRoundedButton3.Enabled = true;
            }
            else // Выдача доступа к кнопкам в остальных случаях
            {
                confirmRoundedButton1.Enabled = false;
                rejectRoundedButton2.Enabled = false;
                completeRoundedButton3.Enabled = false;
            }
        }

        // Изменение статуса заявки на "Заявка принята"
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "UPDATE Заявки\n" +
                "SET Статус = @Статус\n" +
                "WHERE Номер_заявки = @Номер_заявки";
                SqlCommand cmd = new SqlCommand(command, Connection);
                Connection.Open();
                cmd.Parameters.AddWithValue("@Статус", 2);
                cmd.Parameters.AddWithValue("@Номер_заявки", id);
                cmd.ExecuteNonQuery();
                Connection.Close();
                var mb = MessageBox.Show("Статус изменён!", "Изменение статуса", MessageBoxButtons.OK);
                if (mb == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (SqlException)
            {
                var mb = MessageBox.Show("Произошла ошибка во время изменения статуса", "Ошибка", MessageBoxButtons.OK);
                Connection.Close();
            }
        }

        // Изменение статуса заявки на "Заявка отклонена"
        private void roundedButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "UPDATE Заявки\n" +
                "SET Статус = @Статус\n" +
                "WHERE Номер_заявки = @Номер_заявки";
                SqlCommand cmd = new SqlCommand(command, Connection);
                Connection.Open();
                cmd.Parameters.AddWithValue("@Статус", 3);
                cmd.Parameters.AddWithValue("@Номер_заявки", id);
                cmd.ExecuteNonQuery();
                Connection.Close();
                var mb = MessageBox.Show("Статус изменён!", "Изменение статуса", MessageBoxButtons.OK);
                if (mb == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (SqlException)
            {
                var mb = MessageBox.Show("Произошла ошибка во время изменения статуса", "Ошибка", MessageBoxButtons.OK);
                Connection.Close();
            }
        }

        // Изменение статуса заявки на "Завершено"
        private void roundedButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "UPDATE Заявки\n" +
                "SET Статус = @Статус\n" +
                "WHERE Номер_заявки = @Номер_заявки";
                SqlCommand cmd = new SqlCommand(command, Connection);
                Connection.Open();
                cmd.Parameters.AddWithValue("@Статус", 4);
                cmd.Parameters.AddWithValue("@Номер_заявки", id);
                cmd.ExecuteNonQuery();
                Connection.Close();
                var mb = MessageBox.Show("Статус изменён!", "Изменение статуса", MessageBoxButtons.OK);
                if (mb == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (SqlException)
            {
                var mb = MessageBox.Show("Произошла ошибка во время изменения статуса", "Ошибка", MessageBoxButtons.OK);
                Connection.Close();
            }
        }

        // Обработчик нажатия кнопки "Назад" для закрытия формы
        private void roundedButton4_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие формы
        }
    }
}
