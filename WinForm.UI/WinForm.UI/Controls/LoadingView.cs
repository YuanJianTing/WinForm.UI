using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/18 15:01:52
    * 说明：
    * ==========================================================
    * */
    public class LoadingView : Control
    {
        private Point center = Point.Empty;
        private Dot[] dots = new Dot[6];
        private int DotSize = 10;

        private Timer timer;

        public LoadingView()
        {
            SetStyle(
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.SupportsTransparentBackColor |
               ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();

            timer = new Timer();
            timer.Interval = 5;
            timer.Tick += Timer_Tick;
            base.Size = new Size(200, 200);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(Parent.BackColor);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            ////绘制边框
            Pen pen = new Pen(Color.FromArgb(100, 100, 100));
            Point[] point = new Point[4];
            point[0] = new Point(0, 0);
            point[1] = new Point(Width - 1, 0);
            point[2] = new Point(Width - 1, Height - 1);
            point[3] = new Point(0, Height - 1);
            g.DrawPolygon(pen, point);

            DrawPoint(g, center);

            foreach (Dot item in dots)
            {
                DrawPoint(g, item.Point);
            }

            g.SmoothingMode = SmoothingMode.None;

            //if (Mouse != Point.Empty)
            //    g.DrawString(Mouse.ToString(), this.Font, Brushes.Black, 7, 7);
        }


        /// <summary>  
        /// 对一个坐标点按照一个中心进行旋转  
        /// </summary>  
        /// <param name="center">中心点</param>  
        /// <param name="p1">要旋转的点</param>  
        /// <param name="angle">旋转角度，笛卡尔直角坐标</param>  
        /// <returns></returns>  
        private Point PointRotate(Point center, Point p1, double angle)
        {
            Point tmp = new Point();
            double angleHude = angle * Math.PI / 180;/*角度变成弧度*/
            double x1 = (p1.X - center.X) * Math.Cos(angleHude) + (p1.Y - center.Y) * Math.Sin(angleHude) + center.X;
            double y1 = -(p1.X - center.X) * Math.Sin(angleHude) + (p1.Y - center.Y) * Math.Cos(angleHude) + center.Y;
            tmp.X = (int)x1;
            tmp.Y = (int)y1;
            return tmp;
        }

        /// <summary>  
        ///     根据半径、角度求圆上坐标  
        /// </summary>  
        /// <param name="center">圆心</param>  
        /// <param name="radius">半径</param>  
        /// <param name="angle">角度</param>  
        /// <returns>坐标</returns>  
        public static PointF GetDotLocationByAngle(PointF center, float radius, int angle)
        {
            var x = (float)(center.X + radius * Math.Cos(angle * Math.PI / 180));
            var y = (float)(center.Y + radius * Math.Sin(angle * Math.PI / 180));

            return new PointF(x, y);
        }



        private void DrawPoint(Graphics g, PointF point)
        {
            using (SolidBrush hrush = new SolidBrush(BackColor))
            {
                RectangleF rect = new RectangleF(point, new Size(DotSize, DotSize));
                g.FillEllipse(hrush, rect);
            }
        }


        protected override void OnCreateControl()
        {
            base.OnCreateControl();



            //center = new Point(this.Width / 2 - DotSize / 2, this.Height / 2 - DotSize / 2);
            ////圆点默认位置
            //Point defaultPoint = new Point(this.Width / 2 - DotSize / 2, this.Height - 20);

            //for (int i = 0; i < dots.Length; i++)
            //{
            //    dots[i] = new Dot(defaultPoint);
            //    dots[i].center = center;
            //    dots[i].DueTime = i * 150;
            //}
        }

        private Size oldSize = new Size(200, 200);

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.Size.Width != oldSize.Width)
                base.Size = new Size(this.Width, this.Width);
            else if (this.Size.Height != oldSize.Height)
                base.Size = new Size(this.Height, this.Height);
            oldSize = base.Size;
            center = new Point(this.Width / 2 - DotSize / 2, this.Height / 2 - DotSize / 2);
            //圆点默认位置
            Point defaultPoint = new Point(this.Width / 2 - DotSize / 2, this.Height-20);
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i] = new Dot(defaultPoint);
                dots[i].center = center;
                dots[i].DueTime = i * 150;
            }
        }


        public void Start()
        {
            if (timer.Enabled)
            {
                foreach (Dot item in dots)
                {
                    item.Stop();
                }
                timer.Stop();
                return;
            }
            foreach (Dot item in dots)
            {
                item.Move();
            }
            timer.Start();
        }


    }
}