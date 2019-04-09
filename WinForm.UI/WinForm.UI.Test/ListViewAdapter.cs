using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Animations;
using WinForm.UI.Controls;
using WinForm.UI.Test.Entity;
using WinForm.UI.Test.Properties;

namespace WinForm.UI.Test
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:31:43
    * 说明：
    * ==========================================================
    * */
    public class ListViewAdapter : BaseAdapter<Contart>
    {

        private Font font;
        private Color SubItemSelectColor = Color.FromArgb(50, Color.White);
        private Color ItemMouseOnColor = Color.FromArgb(50, Color.White);
        private Color SubItemBackColor = Color.Transparent;
        private Font LastFont;

        public ListViewAdapter()
        {
            font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            LastFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        }
        private Point ff ;
        protected override void OnBindControl(Control Owner)
        {
            base.OnBindControl(Owner);
        }

        /// <summary>
        /// 绘制列表子项的头像
        /// </summary>
        /// <param name="g">绘图表面</param>
        /// <param name="subItem">要绘制头像的子项</param>
        /// <param name="rectSubItem">该子项的区域</param>
        private void DrawHeadImage(Graphics g, Contart subItem, Rectangle rectSubItem)
        {
            Image HeadImage = Resources.default_head;
            //if (string.IsNullOrWhiteSpace(subItem.HeadUrl))                 //如果头像位空 用默认资源给定的头像
            //    HeadImage = global::formSkin.Properties.Resources.default_head;

            int x = 10;
            int y = rectSubItem.Bottom - (rectSubItem.Height / 2 + 20);
            Rectangle rec = new Rectangle(x, y, 40, 40);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(HeadImage, rec, new Rectangle(0, 0, HeadImage.Width, HeadImage.Height), GraphicsUnit.Pixel);

        }

        public override void GetView(int position, ViewHolder holder, Graphics g)
        {
            Contart bean = GetItem(position) as Contart;
            holder.UserData = bean;
            Color c = SubItemBackColor;
            if (holder.isMouseClick)
            {        //判断改子项是否被选中
                c = SubItemSelectColor;
            }
            else if (holder.isMouseMove)
            {
                c = ItemMouseOnColor;
            }
            else
                c = SubItemBackColor;

            using (SolidBrush b = new SolidBrush(c))
            {
                g.FillRectangle(b, holder.bounds);
            }

            DrawHeadImage(g, bean, holder.bounds);

            int x = 10 + 50;
            int y = holder.bounds.Bottom - (holder.bounds.Height / 2 + 10);
            if (!string.IsNullOrWhiteSpace(bean.LastMessage))
                y = holder.bounds.Top + 12;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                g.DrawString(bean.NickName, font, brush, new PointF(x, y));
            }

            if (!string.IsNullOrWhiteSpace(bean.LastMessage))
            {
                y += 24;
                using (Brush brush = new SolidBrush(Color.FromArgb(153, 153, 153)))
                {
                    g.DrawString(bean.LastMessage, LastFont, brush, new PointF(x, y));
                }
            }

            if (bean.LastMessageTime != null)
            {
                string time = ((DateTime)bean.LastMessageTime).ToString("HH:mm");
                x = holder.bounds.Width - 60;
                y = holder.bounds.Bottom - (holder.bounds.Height / 2 + 15);
                using (Brush brush = new SolidBrush(Color.FromArgb(153, 153, 153)))
                {
                    g.DrawString(time, LastFont, brush, new PointF(x, y));
                }
            }


        }

        public override int GetRowHeight(int position)
        {
            return 65;
        }
    }
}
