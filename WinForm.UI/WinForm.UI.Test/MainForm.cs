using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Forms;

namespace WinForm.UI.Test
{
    public partial class MainForm : BaseForm
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void fButton1_Click(object sender, EventArgs e)
        {
            //Toast.MakeText(this, "呵呵的").Show();
            ListViewForm form = new ListViewForm();
            form.Show();
        }

        private void fButton2_Click(object sender, EventArgs e)
        {
            TableForm form = new TableForm();
            form.Show();
        }
    }
}
