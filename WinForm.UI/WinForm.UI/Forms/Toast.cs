using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm.UI.Forms
{
    public partial class Toast : BaseForm
    {
        private int MaxWidth = 200;

        private Toast(Form form)
        {
            InitializeComponent();
            this.IsShadow = false;
            this.Owner = form;
            Point formPoint = form.Location;
            int x, y = 0;
            x = formPoint.X + form.Width / 2 - this.Width / 2;
            y = formPoint.Y + form.Height / 2 - this.Height / 2;
            this.Location = new Point(x, y);
        }

        public static Toast MakeText(Form form, string message, int time = 3000)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException("message is not null");
            Toast toast = new Toast(form);
            toast.Interval = time;
            toast.Message = message;

            return toast;
        }

        public int Interval { get { return this.timer1.Interval; } set { this.timer1.Interval = value; } }

        public string Message { get { return lblMessage.Text; } set { this.lblMessage.Text = value; SetSize(); } }

        private void SetSize()
        {
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(this.lblMessage.Text, this.lblMessage.Font, MaxWidth);
            if (size.Height > 50)
                this.Height = Convert.ToInt32(size.Height + 10);

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
