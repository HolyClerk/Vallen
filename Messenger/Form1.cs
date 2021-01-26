using System;
using System.IO;
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
    public partial class DialogForm1 : Form
    {
        public static string checkBoxDownload = "1";
        public static string checkBoxTrashBin = "1";
        public static string checkBoxCache = "1";

        public DialogForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] checkBoxCollection = new[] { checkBoxTrashBin, checkBoxDownload, checkBoxCache };

            foreach (var item in checkBoxCollection)
            {
                CleanUp.Delete(item); // Посылает переменную как аргумент к функции Delete
            }

            string messageDialog = "Файлов в колличестве: " + CleanUp.countTries.ToString() + " было удалено";
            MessageBox.Show(messageDialog);
        }

        // При изменении чекбокса каждой переменной задается ссылка
        private void checkBox1_CheckedChanged(object sender, EventArgs e) // Корзина
        {
            if (checkBox1.Checked == true)
                checkBoxTrashBin = @"C:\Users\Admin\Desktop\d\11";
            else
                checkBoxTrashBin = "1";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) // Загрузки
        {
            if (checkBox2.Checked == true)
                checkBoxDownload = @"C:\Users\Admin\Desktop\d\33";
            else
                checkBoxDownload = "1";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) // Кэш
        {
            if (checkBox3.Checked == true)
                checkBoxCache = @"C:\Users\Admin\Desktop\d\asdasd";
            else
                checkBoxCache = "1";
        }
    }
}
