using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI.Extension;

namespace WinForm.UI.Controls
{
    public class GroupBoxView : Panel
    {
        private Color borderColor = ColorStyles.LineColor;

        #region Constructors
        public GroupBoxView()
        {
            SetStyle(
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.ResizeRedraw |
              ControlStyles.SupportsTransparentBackColor |
              ControlStyles.Selectable |
              ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
        }
        #endregion

        #region Properties
        [Category("外观")]
        [Description("获取或设置当前控件的边框颜色")]
        public Color BorderColor { get { return borderColor; } set { if (borderColor == value) return; borderColor = value; this.Invalidate(); } }

        [Bindable(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text { get => base.Text; set => base.Text = value; }

        [Bindable(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new BorderStyle BorderStyle { get { return base.BorderStyle; }  }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            using (Pen pen = new Pen(BorderColor))
                g.DrawRectangle(pen, 0, 10, this.Width - 1, this.Height - 11);

            if (!string.IsNullOrEmpty(Text))
            {
                SizeF size = g.MeasureNoPaddingString(Text, Font);
                using (SolidBrush solidBrush = new SolidBrush(BackColor))
                {
                    g.FillRectangle(solidBrush, 8, 0, size.Width + 8, size.Height);

                    solidBrush.Color = ForeColor;
                    g.DrawString(Text, Font, solidBrush, 10, 0);
                }
            }
        }
    }
}
