using MySql.Data.MySqlClient;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
            
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        void refresh()
        {
            switch(Properties.Settings.Default.l)
            {
                case 1:
                    MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=; database=PMO3;");
                    connection.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter
                        ();
                    break;
            }
        }
    }
}
