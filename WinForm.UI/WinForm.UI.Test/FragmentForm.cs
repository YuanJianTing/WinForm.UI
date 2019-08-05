using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm.UI.Test
{
    public partial class FragmentForm : Form
    {
        public FragmentForm()
        {
            InitializeComponent();
            verticalScroll1.Owner = this;
            userFragment1.Controls.Add(this.richTextBox1);
        }

        private void FragmentForm_Load(object sender, EventArgs e)
        {
            verticalScroll1.VirtualHeight = 700;
        }
    }
}
