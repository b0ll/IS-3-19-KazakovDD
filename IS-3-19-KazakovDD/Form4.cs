using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary;
using MySql.Data.MySqlClient;



namespace IS_3_19_KazakovDD
{
    public partial class Form4 : Form
    { 
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataTable table = new DataTable();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnDB conndb = new ConnDB();
            try
            {
                conndb.ConnMySql().Open();
                string commandStr = "SELECT idStud AS 'ID', fioStud AS 'ФИО', drStud AS 'Дата рождения' FROM t_datetime";
                MyDA.SelectCommand = new MySqlCommand(commandStr, conndb.ConnMySql());
                MyDA.Fill(table);
                bSource.DataSource = table;
                dataGridView1.DataSource = bSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            finally
            {
                MessageBox.Show("Подключение Окончено.");
                conndb.ConnMySql().Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DateTime dr = new DateTime();
                dr = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                MessageBox.Show(DateTime.Today.Subtract(dr.Date).Days.ToString() + " дней с момента рождения.");
            }
            catch
            {
            }
        }
    }
}
