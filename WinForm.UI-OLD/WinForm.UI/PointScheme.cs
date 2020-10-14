using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WinForm.UI
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/19 9:30:17
    * 说明：
    * ==========================================================
    * */
    public static class PointScheme
    {
        /// <summary>
        /// 该点到指定点pTarget的距离
        /// </summary>
        /// <param name="point"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double DistanceTo(this PointF point,PointF p)
        {
            return Math.Sqrt((p.X - point.X) * (p.X - point.X) + (p.Y - point.Y) * (p.Y - point.Y));
        }

    }
}
