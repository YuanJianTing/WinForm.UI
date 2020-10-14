using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.UI.Extension
{
    public static class GraphicsExtension
    {
        /// <summary>
        /// 取相反色
        /// </summary>
        /// <param name="Color"></param>
        /// <returns></returns>
        public static Color TakeBackColor(this Color Color)
        {
            int R, G, B = 0;
            R = 255 - Color.R;
            G = 255 - Color.G;
            B = 255 - Color.B;
            Color Result = Color.FromArgb(R, G, B);
            return Result;
        }

        public static SizeF MeasureNoPaddingString(this Graphics g, string vaule, Font font)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            return g.MeasureString(vaule, font, Point.Empty, sf);
        }

        /// <summary>
        /// 绘制居中字符
        /// </summary>
        /// <param name="g"></param>
        /// <param name="vaule"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="rectangle"></param>
        public static void DrawNoPaddingStringMiddleCenter(this Graphics g, string vaule, Font font, Brush brush, Rectangle rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(vaule, font, brush, rectangle, sf);
        }
        public static void DrawNoPaddingStringMiddleCenter(this Graphics g, string vaule, Font font, Brush brush, RectangleF rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(vaule, font, brush, rectangle, sf);
        }

        public static void DrawNoPaddingStringMiddleLeft(this Graphics g, string vaule, Font font, Brush brush, Rectangle rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(vaule, font, brush, rectangle, sf);
        }

        public static void DrawNoPaddingStringTopCenter(this Graphics g, string vaule, Font font, Brush brush, Rectangle rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;
            g.DrawString(vaule, font, brush, rectangle, sf);
        }
        public static void DrawNoPaddingStringTopRight(this Graphics g, string vaule, Font font, Brush brush, Rectangle rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Far;//右
            sf.LineAlignment = StringAlignment.Near;//上
            g.DrawString(vaule, font, brush, rectangle, sf);
        }
        //居中靠右
        public static void DrawNoPaddingStringMiddleRight(this Graphics g, string vaule, Font font, Brush brush, Rectangle rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Far;//右
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(vaule, font, brush, rectangle, sf);
        }
        //左下
        public static void DrawNoPaddingStringBottomLeft(this Graphics g, string vaule, Font font, Brush brush, Rectangle rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Far;
            g.DrawString(vaule, font, brush, rectangle, sf);
        }
        //下居中
        public static void DrawNoPaddingStringBottomCenter(this Graphics g, string vaule, Font font, Brush brush, Rectangle rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Center;//右
            sf.LineAlignment = StringAlignment.Far;
            g.DrawString(vaule, font, brush, rectangle, sf);
        }
        //下居右
        public static void DrawNoPaddingStringBottomRight(this Graphics g, string vaule, Font font, Brush brush, Rectangle rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Far;//右
            sf.LineAlignment = StringAlignment.Far;
            g.DrawString(vaule, font, brush, rectangle, sf);
        }
        public static void DrawNoPaddingStringTopLeft(this Graphics g, string vaule, Font font, Brush brush, Rectangle rectangle)
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            sf.Alignment = StringAlignment.Near;//右
            sf.LineAlignment = StringAlignment.Near;
            g.DrawString(vaule, font, brush, rectangle, sf);
        }

        public static void DrawStretchImageImage(this Graphics g, Bitmap vaule, Rectangle rectangle)
        {
            g.DrawImage(vaule, rectangle, new Rectangle(0, 0, vaule.Width, vaule.Height), GraphicsUnit.Pixel);
        }
    }
}
