using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinForm.UI
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 15:45:35
    * 说明：
    * ==========================================================
    * */
    public class FormsManager
    {
        private static Style style;

        public static Style Style
        {
            get
            {
                if (style == null)
                    style = new Style();
                return style;

            }
            set { style = value; }
        }


        private FormsManager()
        {
        }

    }
}
