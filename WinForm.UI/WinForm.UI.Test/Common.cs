using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WinForm.UI.Test
{
    /****************************************************************
	*   作者：yuanj
	*   CLR版本：4.0.30319.42000
	*   创建时间：2018/01/18 19:51:11
	*   2018
	*   描述说明：
	*
	*   修改历史：
	*
	*
	*****************************************************************/
    public static class Common
    {
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
    }
}
