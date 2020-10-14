using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinForm.UI.Controls;

namespace WinForm.UI.Events
{
    public class CellClickEventArgs: EventArgs
    {
        public ViewHolder ViewHolder;
        public int CellIndex;

        public CellClickEventArgs(ViewHolder item,int cellIndex)
        {
            this.CellIndex = cellIndex;
            this.ViewHolder = item;
        }
    }
}
