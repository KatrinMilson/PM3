using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM03.DBForns
{
    public partial class InsertAssessmentForm : MetroFramework.Forms.MetroForm
    {
        private int id;
        public InsertAssessmentForm(int id)
        {
            InitializeComponent();
            this.id = id;
            LoadComboBox();
            if (id < 0)
            {
                button1.Visible = true;
            }
            else
            {
                button2.Visible = true;
                button3.Visible = true;
                LoadString();
            }
        }

        private void LoadString()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter($"SELECT * FROM `assesment` WHERE `id` = '{id}';", connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);
            connection.Close();

            dateTimePicker1.Text = table.Rows[0][1].ToString();
            comboBox1.SelectedValue = table.Rows[0][2];
            comboBox2.SelectedValue = table.Rows[0][3];
            textBox1.Text = table.Rows[0][4].ToString();
            textBox2.Text = table.Rows[0][5].ToString();

        }

        private void LoadComboBox()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM `student` WHERE 1;", connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "FIO";
            comboBox1.ValueMember = "id";
            connection.Close();

            MySqlDataAdapter mySqlDataAdapter2 = new MySqlDataAdapter("SELECT * FROM `lesson` WHERE 1;", connection);
            DataTable table2 = new DataTable();
            mySqlDataAdapter2.Fill(table2);
            comboBox2.DataSource = table2;
            comboBox2.DisplayMember = "Title";
            comboBox2.ValueMember = "id";
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            string date = dateTimePicker1.Value.ToShortDateString();
            MySqlDataAdapter mySqlDataAdapter2 = new MySqlDataAdapter($"INSERT INTO `assesment`(`date`, `studentID`, `lessonID`, `Group`, `Description`) VALUES ('{date}','{comboBox1.SelectedValue}','{comboBox2.SelectedValue}','{textBox1.Text}','{textBox2.Text}')", connection);
            DataTable table = new DataTable();
            mySqlDataAdapter2.Fill(table);
            connection.Close();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            string date = dateTimePicker1.Value.ToShortDateString();
            MySqlDataAdapter adapter =
                new MySqlDataAdapter($"UPDATE `assesment` SET `date`='{date}',`studentID`='{comboBox1.SelectedValue}',`lessonID`='{comboBox2.SelectedValue}',`Group`='{textBox1.Text}',`Description`='{textBox2.Text}' WHERE `id` = '{id}'", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            MySqlDataAdapter adapter =
                new MySqlDataAdapter($"DELETE FROM `assesment` WHERE `id` = '{id}'", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            Close();
        }
    }
}
