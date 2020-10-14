using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.UI.Sys
{
    static class RoundRect
    {
        /// <summary>
        /// Generate the path of a rounded rectangle
        /// </summary>
        /// <param name="r">The rectangle to use</param>
        /// <param name="dia">The diameter</param>
        /// <returns>The GraphicsPath which resembles a rounded rectangle</returns>
        public static GraphicsPath GetRoundRectPath(Rectangle r, int dia)
        {
            GraphicsPath pPath = new GraphicsPath();

            // diameter can't exceed width or height
            if (dia > r.Width) dia = r.Width;
            if (dia > r.Height) dia = r.Height;

            // define a corner 
            Rectangle Corner = new Rectangle(r.X, r.Y, dia, dia);

            // begin path
            pPath.Reset();

            // top left
            pPath.AddArc(Corner, 180, 90);

            // tweak needed for radius of 10 (dia of 20)
            if (dia == 20)
            {
                Corner.Width += 1;
                Corner.Height += 1;
                r.Width -= 1; r.Height -= 1;
            }

            // top right
            Corner.X += (r.Width - dia - 1);
            pPath.AddArc(Corner, 270, 90);

            // bottom right
            Corner.Y += (r.Height - dia - 1);
            pPath.AddArc(Corner, 0, 90);

            // bottom left
            Corner.X -= (r.Width - dia - 1);
            pPath.AddArc(Corner, 90, 90);

            // end path
            pPath.CloseFigure();

            return pPath;
        }

        /// <summary>
        /// Draw (outline) a rounded rectangle to a graphics context.
        /// </summary>
        /// <param name="pGraphics">The graphics context</param>
        /// <param name="r">The bounding rectangle</param>
        /// <param name="color">The color of the outline</param>
        /// <param name="radius">The corner radius</param>
        /// <param name="width">The width of the outline</param>
        public static void DrawRoundRect(System.Drawing.Graphics pGraphics, Rectangle r, Color color, int radius, int width)
        {
            int dia = 2 * radius;

            // store old page unit
            GraphicsUnit oldPageUnit = pGraphics.PageUnit;

            // set to pixel mode
            pGraphics.PageUnit = GraphicsUnit.Pixel;

            // define the pen
            Pen pen = new Pen(color, 1);

            // set pen alignment
            pen.Alignment = PenAlignment.Center;

            // get the corner path
            GraphicsPath path = GetRoundRectPath(r, dia);

            // draw the round rect
            pGraphics.DrawPath(pen, path);

            // if width > 1
            for (int i = 1; i < width; i++)
            {
                // left stroke
                r.Inflate(-1, 0);

                // get the path
                path = GetRoundRectPath(r, dia);

                // draw the round rect
                pGraphics.DrawPath(pen, path);

                // up stroke
                r.Inflate(0, -1);

                // get the path
                path = GetRoundRectPath(r, dia);

                // draw the round rect
                pGraphics.DrawPath(pen, path);
            }

            // restore page unit
            pGraphics.PageUnit = oldPageUnit;
        }

        /// <summary>
        /// Fill a rounded rectangle to a graphics context.
        /// </summary>
        /// <param name="pGraphics">The graphics context</param>
        /// <param name="pBrush">The brush to fill the rectangle with</param>
        /// <param name="r">The bounding rectangle</param>
        /// <param name="border">The outline (border) color</param>
        /// <param name="radius">The corner radius</param>
        public static void FillRoundRect(System.Drawing.Graphics pGraphics, Brush pBrush, Rectangle r, Color border, int radius)
        {
            int dia = 2 * radius;

            // store old page unit
            GraphicsUnit oldPageUnit = pGraphics.PageUnit;

            // set to pixel mode
            pGraphics.PageUnit = GraphicsUnit.Pixel;

            // define the pen
            Pen pen = new Pen(border, 1);

            // set pen alignment
            pen.Alignment = PenAlignment.Center;

            // get the corner path
            GraphicsPath path = GetRoundRectPath(r, dia);

            // fill
            pGraphics.FillPath(pBrush, path);

            // draw the border last so it will be on top in case the color is different
            pGraphics.DrawPath(pen, path);

            // restore page unit
            pGraphics.PageUnit = oldPageUnit;
        }
    }
}
