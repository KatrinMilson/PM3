using MySql.Data.MySqlClient;
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
    public partial class Menu : MetroFramework.Forms.MetroForm
    {
        public Menu()
        {
            InitializeComponent();
            Style = MetroFramework.MetroColorStyle.Blue;
        }

        private void оценкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.l = 1;
            var item = new WorkForm();
            item.Owner = this;
            item.Show();
        }

        private void расписаниеЗанятийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.l = 2;
            var item = new WorkForm();
            item.Owner = this;
            item.Show();
        }

        private void стедентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.l = 3;
            var item = new WorkForm();
            item.Owner = this;
            item.Show();
        }

        private void предметToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.l = 4;
            var item = new WorkForm();
            item.Owner = this;
            item.Show();
        }
    }
}
