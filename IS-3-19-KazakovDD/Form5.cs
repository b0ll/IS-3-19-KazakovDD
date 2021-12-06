using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MyLibrary;

namespace IS_3_19_KazakovDD
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnDB conndb = new ConnDB();
            if (textBox1.TextLength != 0)
            {
                try
                {
                    conndb.ConnMySql().Open();
                    string commandStr = $"INSERT INTO t_PraktStud (fioStud, datetimeStud) VALUES (@fio,@date)";
                    using (MySqlCommand command = new MySqlCommand(commandStr, conndb.ConnMySql()))
                    {
                        command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = textBox1.Text;
                        command.Parameters.Add("@date", MySqlDbType.DateTime).Value = dateTimePicker1.Text;
                        command.Connection.Open();
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }
                finally
                {
                    MessageBox.Show("Соединение закрыто.");
                    conndb.ConnMySql().Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните ФИО");
            }
        }
    }
}
