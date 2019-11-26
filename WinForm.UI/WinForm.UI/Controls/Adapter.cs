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
        public event Action OnNotifyDataSetChanged;


        public abstract int GetCount();

        public abstract void GetView(int position, ViewHolder holder, Graphics g);

        public abstract int GetRowHeight(int position);


        protected Control owner;
        internal Control Owner
        {
            set { this.owner = value; OnBindControl(value); }
        }

        public void notifyDataSetChanged()
        {
            if (owner != null)
                owner.Invalidate();
            OnNotifyDataSetChanged?.Invoke();
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
        public Point MouseLocation;

        public List<Rectangle> CellBounds { private set; get; }

        public ViewHolder(Rectangle bounds)
        {
            this.bounds = bounds;
            CellBounds = new List<Rectangle>();
        }
    }
}
