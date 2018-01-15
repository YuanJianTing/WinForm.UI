using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:10:10
    * 说明：
    * ==========================================================
    * */
    public abstract class Adapter
    {

        public abstract int GetCount();

        public abstract void GetView(int position, ViewHolder holder, Graphics g);

        protected Control owner;
        internal Control Owner
        {
            set { this.owner = value; OnBindControl(value); }
        }

        public void notifyDataSetChanged()
        {
            if (owner != null)
                owner.Invalidate();
        }


        protected virtual void OnBindControl(Control Owner)
        {

        }

    }

    public class ViewHolder
    {
        public object UserData;
        public int position;
        public Rectangle bounds;
        public bool isMouseClick = false;
        public bool isMouseMove = false;
        public ViewHolder(Rectangle bounds)
        {
            this.bounds = bounds;
        }
    }
}
