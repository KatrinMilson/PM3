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
    public partial class StudentForm : MetroFramework.Forms.MetroForm
    {
        int id;
        public StudentForm(int id)
        {
            InitializeComponent();

            this.id = id;
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

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter($"SELECT * FROM `student` WHERE `id` = '{id}';", connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);
            connection.Close();

            textBox1.Text = table.Rows[0][1].ToString();
            textBox2.Text = table.Rows[0][2].ToString();
            textBox3.Text = table.Rows[0][3].ToString();
            textBox4.Text = table.Rows[0][4].ToString();
            textBox5.Text = table.Rows[0][5].ToString();
            textBox6.Text = table.Rows[0][6].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            MySqlDataAdapter adapter =
                new MySqlDataAdapter($"UPDATE `student` SET `FIO`='{textBox1.Text}',`Phone`='{textBox2.Text}',`Email`='{textBox3.Text}',`Address`='{textBox4.Text}',`Group`='{textBox5.Text}',`AvetageScore`='{textBox6.Text}' WHERE `id` = '{id}'", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            MySqlDataAdapter adapter =
                new MySqlDataAdapter($"DELETE FROM `student` WHERE `id` = '{id}'", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            MySqlDataAdapter adapter =
                new MySqlDataAdapter($"INSERT INTO `student`(`FIO`, `Phone`, `Email`, `Address`, `Group`, `AvetageScore`) VALUES ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}')", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            Close();
        }
    }
}
