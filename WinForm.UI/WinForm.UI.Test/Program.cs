using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinForm.UI.Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Style style= FormsManager.Style;
            string path = Path.Combine(Application.StartupPath, "logo.ico");
            if (File.Exists(path))
                style.Icon = new Icon(path);
            style.TitleBackColor = Color.FromArgb(27, 123, 210);
            style.MinBoxBackColor = Color.FromArgb(70, Color.White);
            style.MaxBoxBackColor = Color.FromArgb(70, Color.White);

            Application.Run(new Form1());
        }
    }
}
