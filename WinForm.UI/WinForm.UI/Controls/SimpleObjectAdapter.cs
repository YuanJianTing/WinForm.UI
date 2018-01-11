using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:51:47
    * 说明：
    * ==========================================================
    * */
    public class SimpleObjectAdapter<T> : BaseAdapter<T>
    {
        public Color MouseMoveBackColor { get; set; } = Color.FromArgb(214, 219, 233);
        public Color SelectedBackColor { get; set; } = Color.FromArgb(104, 104, 104);

        public override void GetView(int position, ViewHolder holder, Graphics g)
        {
            FTable owner = this.owner as FTable;
            T obj = items[position];
            holder.UserData = obj;

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
                string value = GetValue(obj, item.BindingData);

                g.DrawString(value, item.Font, sb, MyRect, StringFormat);
                if (owner.CellBorderStyle != CellBorderStyle.None)
                    //竖线
                    g.DrawLine(p, MyRect.X + item.Width, MyRect.Y, MyRect.X + item.Width, MyRect.Y + holder.bounds.Height);
                i++;
            }
            g.DrawLine(p, 0, holder.bounds.Y + holder.bounds.Height, holder.bounds.Width, holder.bounds.Y + holder.bounds.Height);
        }

        private string GetValue(T item, string key)
        {
            try
            {
                Type type = item.GetType();
                if (type.IsClass)
                {
                    PropertyInfo propertyInfo = type.GetProperty(key);
                    object value = propertyInfo.GetValue(item, null);
                    return (value != null) ? value.ToString() : "";
                }
            }
            catch (Exception)
            {
            }
            return "";
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

    }
}
