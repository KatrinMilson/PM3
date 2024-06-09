using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PM03
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            textBoxPassword.AutoSize = false;
            textBoxConfirmPassword.AutoSize = false;
            textBoxPassword.Size = new Size(textBoxPassword.Size.Width, 50);
            textBoxConfirmPassword.Size = new Size(textBoxConfirmPassword.Size.Width, 50);
        }

        private void textBoxFirstName_Enter(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            if (firstName.ToLower().Trim().Equals("firstname")) {
                textBoxFirstName.Text = "";
                textBoxFirstName.ForeColor = Color.DarkOrange;
            }
        }

        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            if (firstName.ToLower().Trim().Equals("firstname") || firstName.Trim().Equals(""))
            {
                textBoxFirstName.Text = "FirstName";
                textBoxFirstName.ForeColor = Color.SandyBrown;
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;
        }

        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            string firstName = textBoxLastName.Text;
            if (firstName.ToLower().Trim().Equals("lastname") || firstName.Trim().Equals(""))
            {
                textBoxLastName.Text = "LastName";
                textBoxLastName.ForeColor = Color.SandyBrown;
            }
        }

        private void textBoxLastName_Enter(object sender, EventArgs e)
        {
            string firstName = textBoxLastName.Text;
            if (firstName.ToLower().Trim().Equals("lastname"))
            {
                textBoxLastName.Text = "";
                textBoxLastName.ForeColor = Color.DarkOrange;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            string firstName = textBoxEmail.Text;
            if (firstName.ToLower().Trim().Equals("email") || firstName.Trim().Equals(""))
            {
                textBoxEmail.Text = "Email";
                textBoxEmail.ForeColor = Color.SandyBrown;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            string firstName = textBoxEmail.Text;
            if (firstName.ToLower().Trim().Equals("email"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.DarkOrange;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            string firstName = textBoxUsername.Text;
            if (firstName.ToLower().Trim().Equals("username") || firstName.Trim().Equals(""))
            {
                textBoxUsername.Text = "Username";
                textBoxUsername.ForeColor = Color.SandyBrown;
            }
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            string firstName = textBoxUsername.Text;
            if (firstName.ToLower().Trim().Equals("username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.DarkOrange;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            string firstName = textBoxPassword.Text;
            if (firstName.ToLower().Trim().Equals("password") || firstName.Trim().Equals(""))
            {
                textBoxPassword.Text = "Password";
                textBoxPassword.ForeColor = Color.SandyBrown;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            string firstName = textBoxPassword.Text;
            if (firstName.ToLower().Trim().Equals("password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.DarkOrange;
            }
        }

        private void textBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            string firstName = textBoxConfirmPassword.Text;
            if (firstName.ToLower().Trim().Equals("confirm password") || firstName.Trim().Equals(""))
            {
                textBoxConfirmPassword.Text = "Confirm password";
                textBoxConfirmPassword.ForeColor = Color.SandyBrown;
            }
        }

        private void textBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            string firstName = textBoxConfirmPassword.Text;
            if (firstName.ToLower().Trim().Equals("confirm password"))
            {
                textBoxConfirmPassword.Text = "";
                textBoxConfirmPassword.ForeColor = Color.DarkOrange;
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelClose_Enter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.DarkOrange;
        }

        private void labelClose_Leave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            string fName = textBoxFirstName.Text;
            string lName = textBoxLastName.Text;
            string email = textBoxEmail.Text;
            string uName = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            var command =
                new MySqlCommand($"INSERT INTO `users` (`firstName`, `lastName`, `email`, `username`, `password`) VALUES ('{fName}', '{lName}', '{email}', '{uName}', '{password}')",
                db.GetConnection());

            db.openConnection();

            if(checkTextBoxValues())
            {
                MessageBox.Show("Error: You need enter your info first", "Empty data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if(checkUsername())
            {
                MessageBox.Show("User already exist.","Duplicate username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if(!password.Equals(textBoxConfirmPassword.Text))
            {
                MessageBox.Show("Wrogn confirm password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Create", "Account created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error");
            }

            db.closeConnection();
        }

        private bool checkUsername()
        {
            DB db = new DB();

            string username = textBoxUsername.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `users` WHERE `username` = '{username}'", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table.Rows.Count > 0;
        }

        private bool checkTextBoxValues()
        {
            string fName = textBoxFirstName.Text;
            string lName = textBoxLastName.Text;
            string email = textBoxEmail.Text;
            string uName = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            return (fName.Equals("FirstName") || lName.Equals("LastName") || email.Equals("Email") || uName.Equals("Username") || password.Equals("Password"));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginForm().Show();
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
