﻿using MySql.Data.MySqlClient;
using PM03.DBForns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM03
{
    public partial class WorkForm : MetroFramework.Forms.MetroForm
    {
        public WorkForm()
        {
            InitializeComponent();
            refresh();
        }

        void refresh()
        {
            switch(Properties.Settings.Default.l)
            {
                case 1:
                    MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
                    connection.Open();

                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM `assesment` WHERE 1;", connection);
                    DataTable table = new DataTable();
                    mySqlDataAdapter.Fill(table);
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].Visible = false;
                    connection.Close();
                    break;
                case 2:
                    MySqlConnection connection2 = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
                    connection2.Open();

                    MySqlDataAdapter mySqlDataAdapter2 = new MySqlDataAdapter("SELECT * FROM `schedule` WHERE 1;", connection2);
                    DataTable table2 = new DataTable();
                    mySqlDataAdapter2.Fill(table2);
                    dataGridView1.DataSource = table2;
                    dataGridView1.Columns[0].Visible = false;
                    connection2.Close();
                    break;
                case 3:
                    MySqlConnection connection3 = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
                    connection3.Open();

                    MySqlDataAdapter mySqlDataAdapter3 = new MySqlDataAdapter("SELECT * FROM `student` WHERE 1;", connection3);
                    DataTable table3 = new DataTable();
                    mySqlDataAdapter3.Fill(table3);
                    dataGridView1.DataSource = table3;
                    dataGridView1.Columns[0].Visible = false;
                    connection3.Close();
                    break;
                case 4:
                    MySqlConnection connection4 = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
                    connection4.Open();

                    MySqlDataAdapter mySqlDataAdapter4 = new MySqlDataAdapter("SELECT * FROM `lesson` WHERE 1;", connection4);
                    DataTable table4 = new DataTable();
                    mySqlDataAdapter4.Fill(table4);
                    dataGridView1.DataSource = table4;
                    dataGridView1.Columns[0].Visible = false;
                    connection4.Close();
                    break;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                int id = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
                switch(Properties.Settings.Default.l)
                {
                    case 1:
                        new InsertAssessmentForm(id).Show();
                        break;
                    case 2:
                        new ScheduleForm(id).Show();
                        break;
                    case 3:
                        new StudentForm(id).Show();
                        break;
                    case 4:
                        new InsertLessonForm(id).Show();
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch(Properties.Settings.Default.l)
            {
                case 1:
                    new InsertAssessmentForm(-1).Show();
                    break;
                case 2:
                    new ScheduleForm(-1).Show();
                    break;
                case 3:
                    new StudentForm(-1).Show();
                    break;
                case 4:
                    new InsertLessonForm(-1).Show();
                    break;
            }
        }
    }
}