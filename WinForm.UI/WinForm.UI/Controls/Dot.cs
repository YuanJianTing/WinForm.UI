using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/19 8:49:44
    * 说明：
    * ==========================================================
    * */
    public class Dot
    {
        private PointF point = PointF.Empty;
        private PointF DefaultPoint = PointF.Empty;
        public PointF Point { get { return point; } }

        private double angle = 90;
        /// <summary>
        /// 中心点
        /// </summary>
        public Point center { get; set; }

        private Timer MoveTimer;
        //启动延迟
        private int dueTime = 5;
        public int DueTime { get { return dueTime; } set { dueTime = value; } }
        //执行间隔
        private int period = 30;
        private int MaxSpeed = 30;//最大速度
        public Dot(Point initial)
        {
            DefaultPoint = initial;
            point = initial;//初始位置
        }

        public void Move()
        {
            MoveTimer = new Timer((obj) =>
            {
                if (angle > 360)
                    angle = 0;
                point = PointRotate(center, DefaultPoint, angle);
                angle += 4;
                if (angle > 30 && angle < 290 && period == 1)
                {
                    SubSpeed();
                }
                else if (angle > 290 && angle < 360 && period != 1)
                {
                    AddSpeed();
                }

            }, null, dueTime, period);
        }

        public void Stop()
        {
            MoveTimer.Dispose();
            dueTime = 0;
        }


        public void AddSpeed()
        {
            period = 1;
            MoveTimer.Change(0, period);
        }

        public void SubSpeed()
        {
            period = MaxSpeed;
            MoveTimer.Change(0, period);
        }

        /// <summary>  
        /// 对一个坐标点按照一个中心进行旋转  
        /// </summary>  
        /// <param name="center">中心点</param>  
        /// <param name="p1">要旋转的点</param>  
        /// <param name="angle">旋转角度，笛卡尔直角坐标</param>  
        /// <returns></returns>  
        private PointF PointRotate(PointF center, PointF p1, double angle)
        {
            PointF tmp = new PointF();
            double angleHude = angle * Math.PI / 180;/*角度变成弧度*/
            double x1 = (p1.X - center.X) * Math.Cos(angleHude) + (p1.Y - center.Y) * Math.Sin(angleHude) + center.X;
            double y1 = -(p1.X - center.X) * Math.Sin(angleHude) + (p1.Y - center.Y) * Math.Cos(angleHude) + center.Y;
            //tmp.X = (int)x1;
            //tmp.Y = (int)y1;
            tmp.X = (float)y1;
            tmp.Y = (float)x1;
            return tmp;
        }

    }

}
