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
    public partial class loginForm : Form
    {
        int timerCount;
        public loginForm()
        {
            InitializeComponent();
        }

        /* 
         * Функции, отвечающие за нажатия различных кнопок интерфейса.
        */
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewPassButton_Click(object sender, EventArgs e)
        {
            // Костыль. Multiline включает написание на несколько строк. Если он включен - пароль отображается.
            if (passwordField.Multiline == false)
            {
                passwordField.Multiline = true;
            }
            else
            {
                passwordField.Multiline = false;
            }

            passwordField.Size = loginField.Size;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // .... открытие главного окна
            authorization();
        }

        private void passwordField_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                authorization();
            }

        }

        /*
         * "Дополнительные" функции.
         * Функция authorization включает таймер и проверяет правильность введенных данных. 
         * Функция timer1_Tick через каждый интервал(в 1 секунду) выполняет инкремент timerCount,
         * при достижении определенного числа очищается один из лейблов.
         */

        private void authorization()
        {
            timer1.Enabled = true;

            if (loginField.Text == "admin" && passwordField.Text == "admin")
            {
                main_form main = new main_form();
                main.Show();

                Hide();
            }
            if (loginField.Text == "admin" && passwordField.Text != "admin")
            {
                warningLabel.Text = "Неверно введен пароль";
            }
            else
            {
                warningLabel.Text = "Такого пользователя не существует.";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCount++;

            if (timerCount >= 6)
            {
                warningLabel.Text = "";
                timerCount = 3;
                timer1.Enabled = false;
            }
        }

        /*
         * Ряд функций, ответственных за движение окна(панелей, если точнее).
         * 
         * Функция mouseDown записывает последние координаты расположения мыши на момент нажатия
         * в lastCoordinate. А mouseMove же, в свою очередь, эти координаты передает 
         * в переменные X Y текущего положения панели.
         */

        Point lastCoordinate;

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastCoordinate = new Point(e.X, e.Y);
        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastCoordinate.X;
                Top += e.Y - lastCoordinate.Y;
            }
        }

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastCoordinate = new Point(e.X, e.Y);
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastCoordinate.X;
                Top += e.Y - lastCoordinate.Y;
            }
        }
    }
}
