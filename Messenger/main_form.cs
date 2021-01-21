using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger
{
    public partial class main_form : Form
    {
        int workTime;
        public main_form()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void title_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мы все отправимся в Вальгаллу!");
        }

        /*
         * Функции отвечающие за движение окон. Подробно они описаны в log_form.cs
         */

        Point lastCoordinate;

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            lastCoordinate = new Point(e.X, e.Y);
        }

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastCoordinate.X;
                Top += e.Y - lastCoordinate.Y;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeOfWork.Text = (workTime++).ToString() + " сек.";
        }
    }

}
