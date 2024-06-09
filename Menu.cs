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
            var item = new AssessmentForm();
            item.Owner = this;
            item.Show();
        }

        private void расписаниеЗанятийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.l = 2;
            var item = new ScheduleForm();
            item.Owner = this;
            item.Show();
        }

        private void стедентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.l = 3;
            var item = new StudentForm();
            item.Owner = this;
            item.Show();
        }

        private void предметToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.l = 4;
            var item = new LessonForm();
            item.Owner = this;
            item.Show();
        }
        
        void refresh()
        {
            switch (Properties.Settings.Default.l)
            {
                case 1:
                    MySqlConnection connection = 
                        new MySqlConnection("server=localhost; port=3306; username=root; password=; database=csharp_users_db;");
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
    }
}
