using Microsoft.Office.Interop.Word;
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
using Word = Microsoft.Office.Interop.Word;

namespace PM03.DBForns
{
    public partial class InsertAssessmentForm : MetroFramework.Forms.MetroForm
    {
        private readonly string pathToWord = @"C:\Users\satoa\OneDrive\Рабочий стол\assessment.docx";
        private readonly string pathToWord2 = @"C:\Users\satoa\OneDrive\Рабочий стол\assessment1.docx";
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
                buttonImport.Visible = true;
                LoadString();
            }
        }

        private void LoadString()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=school;");
            connection.Open();

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter($"SELECT * FROM `assesment` WHERE `id` = '{id}';", connection);
            System.Data.DataTable table = new System.Data.DataTable();
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
            System.Data.DataTable table = new System.Data.DataTable();
            mySqlDataAdapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "FIO";
            comboBox1.ValueMember = "id";
            connection.Close();

            MySqlDataAdapter mySqlDataAdapter2 = new MySqlDataAdapter("SELECT * FROM `lesson` WHERE 1;", connection);
            System.Data.DataTable table2 = new System.Data.DataTable();
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
            System.Data.DataTable table = new System.Data.DataTable();
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
            System.Data.DataTable table = new System.Data.DataTable();
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
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);
            connection.Close();
            Close();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            string studentID = comboBox1.SelectedValue.ToString();
            string lessonID = comboBox2.SelectedValue.ToString();
            string Group = textBox1.Text;
            string Description = textBox2.Text;

            var wordmap = new Word.Application();
            wordmap.Visible = false;
            var worddoc = wordmap.Documents.Open(pathToWord);

            ReplaceWord("{date}", date, worddoc);
            ReplaceWord("{studentID}", studentID, worddoc);
            ReplaceWord("{lessonID}", lessonID, worddoc);
            ReplaceWord("{Group}", Group, worddoc);
            ReplaceWord("{Description}", Description, worddoc);

            worddoc.SaveAs2(pathToWord2);
            worddoc.Close();
        }

        private void ReplaceWord(string v, string text, Document worddoc)
        {
            var range = worddoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: v, ReplaceWith: text);
        }
    }
}
