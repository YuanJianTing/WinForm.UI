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
    * 创建时间：2018/01/11 16:12:04
    * 说明：
    * ==========================================================
    * */
    public class SimpleArrayAdapter : BaseAdapter<string[]>
    {
        public Color MouseMoveBackColor { get; set; } = Color.FromArgb(214, 219, 233);
        public Color SelectedBackColor { get; set; } = Color.FromArgb(104, 104, 104);

        public SimpleArrayAdapter()
        {
        }

        public override void GetView(int position, ViewHolder holder, Graphics g)
        {
            FTable owner = this.owner as FTable;
            string[] array = items[position];
            holder.UserData = array;
            DrawBackColor(g, holder);
            StringFormat StringFormat = StringFormat.GenericDefault;
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
            Pen p = new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)), 1);
            switch (owner.CellBorderStyle)
            {
                case CellBorderStyle.None:
                    break;
                case CellBorderStyle.FixedSingle:
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                case CellBorderStyle.Dot:
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    break;
                default:
                    break;
            }
            int i = 0;
            foreach (TableColumn item in owner.Columns)
            {
                if (!item.Visible)
                    continue;
                Rectangle MyRect = new Rectangle(item.Location.X, holder.bounds.Y, item.Width, holder.bounds.Height);
                SolidBrush sb = new SolidBrush(item.ForeColor);
                switch (item.TextAlign)
                {
                    case HorizontalAlignment.Left:
                        StringFormat.Alignment = StringAlignment.Far;
                        break;
                    case HorizontalAlignment.Right:
                        StringFormat.Alignment = StringAlignment.Near;
                        break;
                }
                string value = (array.Length > i) ? array[i] : "";
                if (!string.IsNullOrEmpty(item.BindingData))
                {
                    int pos = 0;
                    int.TryParse(item.BindingData, out pos);
                    value = (array.Length > pos) ? array[pos] : "";
                }

                g.DrawString(value, item.Font, sb, MyRect, StringFormat);
                if (owner.CellBorderStyle != CellBorderStyle.None)
                    //竖线
                    g.DrawLine(p, MyRect.X + item.Width, MyRect.Y, MyRect.X + item.Width, MyRect.Y + holder.bounds.Height);
                i++;
            }
            g.DrawLine(p, 0, holder.bounds.Y + holder.bounds.Height, holder.bounds.Width, holder.bounds.Y + holder.bounds.Height);
        }

        private void DrawBackColor(Graphics g, ViewHolder holder)
        {
            if (!holder.isMouseMove && !holder.isMouseClick)
                return;
            using (SolidBrush sb = new SolidBrush(SelectedBackColor))
            {
                Rectangle newRec = holder.bounds;
                newRec.Width -= 1;
                newRec.Height -= 1;
                newRec.X += 1;
                newRec.Y += 1;
                if (holder.isMouseMove)
                {
                    sb.Color = MouseMoveBackColor;
                }
                g.FillRectangle(sb, newRec);
            }
        }

        public override int GetRowHeight(int position)
        {
            return 50;
        }
    }
}
