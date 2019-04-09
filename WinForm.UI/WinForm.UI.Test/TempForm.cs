using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm.UI.Test
{
    public partial class TempForm : Form
    {
        public TempForm()
        {
            InitializeComponent();
        }
        private int days;

        private void TempForm_Load(object sender, EventArgs e)
        {
             days = System.Threading.Thread.CurrentThread.CurrentUICulture.Calendar.GetDaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rectangle = new Rectangle(25, 25, this.Width- 50, this.Height- 50);
            Graphics g = e.Graphics;
            Region region = new Region(rectangle);
            g.Clip = region;

            g.DrawRectangle(new Pen(Brushes.Black,1), new Rectangle(rectangle.X, rectangle.Y, rectangle.Width-1, rectangle.Height-10));




        }



    }
}
