using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.UI.Controls
{
    public class SimpleArrayAdapter: BaseAdapter<string[]>
    {
        private int x, y;


        public Color MouseMoveBackColor { get; set; } = Color.FromArgb(214, 219, 233);
        public Color SelectedBackColor { get; set; } = Color.FromArgb(104, 104, 104);
        public int ItemHeight { get; set; } = 50;


        public override ViewHolder OnCreateViewHolder(Control control, int offset, int position)
        {
            ViewHolder viewHolder = GetViewHolder(position);
            y = position * ItemHeight;
            if (viewHolder == null)
            {
                viewHolder = new ViewHolder(control, new Rectangle(x, y + offset, control.Width, ItemHeight), position);
                CacheViewHolder(viewHolder);//缓存 ViewHolder
            }
            else
            {
                viewHolder.Bounds = new Rectangle(x, y + offset, control.Width, ItemHeight);
            }
            return viewHolder;
        }

        public override void OnDrawItem(Graphics g, ViewHolder viewHolder, int position)
        {
            throw new NotImplementedException();
        }
    }
}
