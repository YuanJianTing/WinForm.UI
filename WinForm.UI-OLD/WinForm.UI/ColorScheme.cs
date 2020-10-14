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
    * 创建时间：2018/01/15 8:46:54
    * 说明：
    * ==========================================================
    * */
    public static class ColorScheme
    {
        /// <summary>
        /// 取相反色
        /// </summary>
        /// <param name="Color"></param>
        /// <returns></returns>
        public static Color TakeBackColor(this Color Color)
        {
            int R, G, B = 0;
            R = 255 - Color.R;
            G = 255 - Color.G;
            B = 255 - Color.B;
            Color Result = Color.FromArgb(R, G, B);
            return Result;
        }


    }
}
