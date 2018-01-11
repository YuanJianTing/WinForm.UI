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
        private static Builder builder;

        public static Builder Builder
        {
            get
            {
                if (builder == null)
                    builder = new Builder();
                return builder;

            }
            set { builder = value; }
        }


        private FormsManager()
        {
        }

    }
}
