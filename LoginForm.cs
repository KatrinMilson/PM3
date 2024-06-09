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

namespace PM03
{
    public partial class LoginForm : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=csharp_users_db;");
        public LoginForm()
        {
            InitializeComponent();
            textBoxPassword.AutoSize = false;
            textBoxPassword.Size = new Size(textBoxPassword.Size.Width, 50);
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.DarkRed;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Blue;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            var command = new MySqlCommand($"SELECT * FROM `users` WHERE `username` = @name AND `password` = @pass", db.GetConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Hide();
                new MainForm().Show();
            }
            else
            {
                if(username.Trim().Equals("") || password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter your username or passsword", "Empty username or password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Wrong username or password", "Wrong data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Hide();
            new RegisterForm().Show();
        }

        private void label2_Leave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.DarkOrange;
        }
    }
}
