using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.UI.Controls
{
    [ComVisibleAttribute(true)]
    [ToolboxItem(true), DefaultProperty("Border")]
    public class BorderPanel : Panel
    {
        private string border = "1";
        private Color borderColor = ColorStyles.LineColor;

        #region Constructors
        public BorderPanel()
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
        public Color BorderColor { get { return borderColor; } set { borderColor = value; } }

        [Bindable(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text { get => base.Text; set => base.Text = value; }

        [Bindable(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new BorderStyle BorderStyle { get { return base.BorderStyle; } }

        [Category("外观")]
        [Description("获取或设置当前控件的边框(例:1,1,1,1)")]
        public string Border
        {
            get { return border; }
            set { border = value; this.Invalidate(); }
        }
        #endregion



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (string.IsNullOrEmpty(border))
                return;

            using (Pen pen = new Pen(BorderColor))
            {
                if (border.IndexOf(',') == -1)
                {
                    if (int.TryParse(border, out int b))
                    {
                        pen.Width = b;
                        e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                    }
                    else
                        border = string.Empty;
                }
                else
                {
                    string[] array = border.Split(',');
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (i > 4)
                            break;
                        if (!int.TryParse(array[i], out int b))
                            continue;
                        if (b == 0)
                            continue;
                        pen.Width = b;
                        switch (i)
                        {
                            case 0://上
                                e.Graphics.DrawLine(pen, 0, 0, this.Width, 0);
                                break;
                            case 1://右
                                e.Graphics.DrawLine(pen, this.Width - b, 0, this.Width - b, this.Height);
                                break;
                            case 2://下
                                e.Graphics.DrawLine(pen, 0, this.Height, this.Width, this.Height);
                                break;
                            case 3://左
                                e.Graphics.DrawLine(pen, 0, 0, 0, this.Height);
                                break;
                            default:
                                break;
                        }
                    }

                }
            }


        }
    }
}
