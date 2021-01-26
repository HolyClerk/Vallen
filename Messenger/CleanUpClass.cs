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
    class CleanUp
    {
        public static int countTries;

        public static void Delete(string dir)
        {
            if (dir.Length > 6)
            {
                // Функция получает файлы из директории которая хранится в переменно, 
                // делит их по типу(* = любой тип) и присваивает к массиву
                string[] fileList = Directory.GetFiles(dir, "*");

                foreach (var f in fileList)
                {
                    File.Delete(f);
                    countTries++;
                }
            }

            else
            {
            }
        }
    }
}
