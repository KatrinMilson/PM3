﻿using MySql.Data.MySqlClient;
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
    public partial class ScheduleForm : MetroFramework.Forms.MetroForm
    {
        int id;
        public ScheduleForm(int id)
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

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter($"SELECT * FROM `schedule` WHERE `id` = '{id}';", connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);
            connection.Close();

            dateTimePicker1.Text = table.Rows[0][1].ToString();
            textBox1.Text = table.Rows[0][2].ToString();
            textBox2.Text = table.Rows[0][3].ToString();
            comboBox1.Text = table.Rows[0][4].ToString();
            textBox3.Text = table.Rows[0][5].ToString();
            textBox4.Text = table.Rows[0][6].ToString();
        }

        private void LoadComboBox()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM `lesson` WHERE 1;", connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "id";
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            MySqlDataAdapter adapter =
                new MySqlDataAdapter($"DELETE FROM `schedule` WHERE `id` = '{id}'", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            string date = dateTimePicker1.Value.ToShortDateString();
            MySqlDataAdapter adapter =
                new MySqlDataAdapter($"UPDATE `schedule` SET `date`='{date}',`Group`='{textBox1.Text}',`Teacher`='{textBox2.Text}',`lessonID`='{comboBox1.SelectedValue}',`time`='{textBox3.Text}',`classroom`='{textBox4.Text}' WHERE `id` = '{id}'", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            string date = dateTimePicker1.Value.ToShortDateString();
            MySqlDataAdapter mySqlDataAdapter2 = new MySqlDataAdapter($"INSERT INTO `schedule`(`date`, `Group`, `Teacher`, `lessonID`, `time`, `classroom`) VALUES ('{date}','{textBox1.Text}','{textBox2.Text}','{comboBox1.SelectedValue}','{textBox3.Text}','{textBox4.Text}')", connection);
            DataTable table = new DataTable();
            mySqlDataAdapter2.Fill(table);
            connection.Close();
            Close();
        }
    }
}
