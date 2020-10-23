using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI.Controls.Emuns;

namespace WinForm.UI.Controls
{
    public abstract class Adapter<VH> where VH : ViewHolder
    {
        public Control Control { get; internal set; }

        public abstract VH OnCreateViewHolder(Control control,int offset, int position);

        public abstract void OnDrawItem(Graphics g,VH viewHolder, int position);
        public abstract int GetItemCount();


        public virtual int GetItemViewType(int position)
        {
            return 0;
        }



        public void NotifyDataSetChanged()
        {
            Control?.Invalidate();
        }

    }

    public class ViewHolder
    {
        public ViewHolder(Control control, Rectangle Bounds, int position)
        {
            this.Bounds = Bounds;
            this.Position = position;
            this.Control = control;
        }
        public int Position { get; }
        public Rectangle Bounds { get; set; }
        public Control Control { get; }

        public MouseState MouseState { get; set; } = MouseState.None;

    }

}
