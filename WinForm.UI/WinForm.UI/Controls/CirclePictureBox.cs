using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Utils;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/12 8:37:08
    * 说明：
    * ==========================================================
    * */
    public class CirclePictureBox: PictureBox
    {

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g= pe.Graphics;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = GraphicsPathHelper.CreatePath(rect, 10, RoundStyle.All, true);
            g.SetClip(path);

            //if (Image != null)
            //{
            //    DrowImage(g);
            //}

            base.OnPaint(pe);
        }

        private void DrowImage(Graphics g)
        {
            Rectangle rect = new Rectangle(0,0, Image.Width, Image.Height);
            //GraphicsPath path = GraphicsPathHelper.DrawRoundRect(0,0, this.Width, this.Height,10);
            GraphicsPath path = GraphicsPathHelper.CreatePath(rect,10,RoundStyle.All,true);
            g.SetClip(path);
            g.DrawImage(Image, 0,0);
            //g.DrawImageUnscaledAndClipped(Image, rect);
        }

        public static Image CropToCircle(Image srcImage, Color backGround)
        {
            Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
            Graphics g = Graphics.FromImage(dstImage);
            using (Brush br = new SolidBrush(backGround))
            {
                g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
            }
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, dstImage.Width, dstImage.Height);
            g.SetClip(path);
            g.DrawImage(srcImage, 0, 0);

            return dstImage;
        }

    }
}
