using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinForm.UI.Controls;

namespace WinForm.UI.Events
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:13:59
    * 说明：
    * ==========================================================
    * */
    public class ItemClickEventArgs : EventArgs
    {
        public ViewHolder ViewHolder;

        public ItemClickEventArgs(ViewHolder item)
        {
            this.ViewHolder = item;
        }
    }
}
