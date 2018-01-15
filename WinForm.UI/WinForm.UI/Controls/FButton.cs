using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Animations;
using WinForm.UI.Utils;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:21:30
    * 说明：
    * ==========================================================
    * */
    [ComVisibleAttribute(true)]
    [ToolboxItem(true), DefaultProperty("Text"), DefaultEvent("Click")]
    public class FButton : Control, IButtonControl
    {
        private Style builder = FormsManager.Style;

        #region 属性

        private int radius = 10;
        [Category("Skin")]
        [Description("获取或设置当前控件圆角的弧度")]
        [DefaultValue(typeof(int), "10")]
        public int Radius { get { return radius; } set { if (value == radius) return; radius = value; this.Invalidate(); } }

        //private Color beginColor = Color.FromArgb(80, Color.Black);
        //[Category("BackColor")]
        //[Description("获取或设置当前控件的起始背景色")]
        //[DefaultValue(typeof(Color), "0, 122, 204")]
        //public Color BeginBackColor { get { return beginColor; } set { if (value == beginColor) return; beginColor = value; this.Invalidate(); } }


        //private Color endColor = Color.FromArgb(80, Color.Black);
        //[Category("BackColor")]
        //[Description("获取或设置当前控件的结束背景色")]
        //[DefaultValue(typeof(Color), "8, 39, 57")]
        //public Color EndBackColor { get { return endColor; } set { if (value == endColor) return; endColor = value; this.Invalidate(); } }


        private Color MouseOverBackColor = Color.FromArgb(215, 210, 206);
        [Category("BackColor")]
        [Description("获取或设置当鼠标指针位于控件边框内时按钮工作区的颜色")]
        [DefaultValue(typeof(Color), "215, 210, 206")]
        public Color mouseOverBackColor { get { return MouseOverBackColor; } set { MouseOverBackColor = value; } }



        //[Category("Skin")]
        //[Description("获取或设置控件的背景颜色")]
        //[DefaultValue(typeof(Color))]
        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        private Color backColor = Color.FromArgb(194, 186, 181);
        [Category("BackColor")]
        [Description("获取或设置控件的背景色")]
        [DefaultValue(typeof(string), "")]
        public new Color BackColor { get { return backColor; } set { if (backColor == value) return; backColor = value; this.Invalidate(); } }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoSize { get { return base.AutoSize; } set { base.AutoSize = false; } }

        private string text = string.Empty;
        [Category("Font")]
        [Description("获取或设置控件的文本")]
        [DefaultValue(typeof(string), "")]
        public new string Text { get { return text; } set { text = value; this.Invalidate(); } }

        private ContentAlignment textAlign;
        [Category("Font")]
        [Description("获取或设置控件文本的方向")]
        [DefaultValue(typeof(ContentAlignment), "32")]
        public ContentAlignment TextAlign { get { return textAlign; } set { textAlign = value; this.Invalidate(); } }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImeMode ImeMode { get { return base.ImeMode; } set { base.ImeMode = ImeMode.NoControl; } }


        private DialogResult dialogResult = DialogResult.Cancel;
        [Category("行为")]
        [Description("获取或设置窗体产生的结果")]
        [DefaultValue(typeof(DialogResult), "0")]
        public DialogResult DialogResult { get { return dialogResult; } set { dialogResult = value; } }


        private Image image = null;
        [Category("Skin")]
        [Description("获取或设置控件的背景图片")]
        [DefaultValue(typeof(Image), "")]
        public Image Image { get { return image; } set { image = value; this.Invalidate(); } }

        private ContentAlignment imageAlign;
        [Category("Skin")]
        [Description("获取或设置控件背景图的方向")]
        [DefaultValue(typeof(ContentAlignment), "32")]
        public ContentAlignment ImageAlign { get { return imageAlign; } set { imageAlign = value; this.Invalidate(); } }

        #endregion

        private AnimationManager _animationManager;
        public FButton()
        {
            this.BackColor = builder.ButtonBackColor;
            this.ForeColor = builder.ButtonForeColor;

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();

            base.BackColor = Color.Transparent;
            base.AutoSize = false;
            base.Height = 25;
            base.Size = new Size(90, 28);
            textAlign = ContentAlignment.MiddleCenter;
            imageAlign = ContentAlignment.MiddleCenter;
            _animationManager = new AnimationManager(this);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPathHelper.Draw(rec, e.Graphics, radius, false, BackColor);
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (_animationManager.IsAnimating())
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color bg = BackColor.TakeBackColor();//取相反色
                using (SolidBrush hrush = new SolidBrush(Color.FromArgb(50, bg)))
                {
                    float animationValue = (float)_animationManager.GetProgress();
                    float x = _animationManager.GetMouseDown().X - animationValue / 2;
                    float y = _animationManager.GetMouseDown().Y - animationValue / 2;
                    RectangleF rect = new RectangleF(x, y, animationValue, animationValue);
                    g.FillEllipse(hrush, rect);
                }
                g.SmoothingMode = SmoothingMode.None;
            }

            DrawImage(e.Graphics);
            DrawText(e.Graphics);

        }

        private void DrawImage(Graphics g)
        {
            if (image != null)
            {
                float x = this.Padding.Left;
                float y = this.Padding.Top;
                switch (imageAlign)
                {
                    case ContentAlignment.TopLeft:
                        break;
                    case ContentAlignment.TopCenter:
                        x += this.Width / 2 - (image.Width / 2);
                        break;
                    case ContentAlignment.TopRight:
                        x = this.Width - image.Width - Padding.Right;
                        break;
                    case ContentAlignment.MiddleLeft:
                        y += this.Height / 2 - (image.Height / 2) - 2;
                        break;
                    case ContentAlignment.MiddleCenter:
                        x += this.Width / 2 - (image.Width / 2);
                        y += this.Height / 2 - (image.Height / 2) - 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        x = this.Width - image.Width - Padding.Right;
                        y += this.Height / 2 - (image.Height / 2) - 2;
                        break;
                    case ContentAlignment.BottomLeft:
                        y = this.Height - image.Height - Padding.Bottom;
                        break;
                    case ContentAlignment.BottomCenter:
                        y = this.Height - image.Height - Padding.Bottom;
                        x += this.Width / 2 - (image.Width / 2);
                        break;
                    case ContentAlignment.BottomRight:
                        y = this.Height - image.Height - Padding.Bottom;
                        x = this.Width - image.Width - Padding.Right;
                        break;
                    default:
                        break;
                }
                g.DrawImage(image, new PointF(x, y));

            }
        }

        private void DrawText(Graphics g)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                SizeF size = g.MeasureString(text, this.Font);
                float x = this.Padding.Left;
                float y = this.Padding.Top;
                switch (textAlign)
                {
                    case ContentAlignment.TopLeft:
                        break;
                    case ContentAlignment.TopCenter:
                        x += this.Width / 2 - (size.Width / 2);
                        break;
                    case ContentAlignment.TopRight:
                        x = this.Width - size.Width;
                        break;
                    case ContentAlignment.MiddleLeft:
                        y += this.Height / 2 - (size.Height / 2);
                        break;
                    case ContentAlignment.MiddleCenter:
                        x += this.Width / 2 - (size.Width / 2);
                        y += this.Height / 2 - (size.Height / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        x = this.Width - size.Width;
                        y += this.Height / 2 - (size.Height / 2);
                        break;
                    case ContentAlignment.BottomLeft:
                        y = this.Height - Padding.Bottom - size.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        x += this.Width / 2 - (size.Width / 2);
                        y = this.Height - Padding.Bottom - size.Height;
                        break;
                    case ContentAlignment.BottomRight:
                        x = this.Width - size.Width - Padding.Right;
                        y = this.Height - Padding.Bottom - size.Height;
                        break;
                    default:
                        break;
                }


                using (Brush brush = new SolidBrush(this.ForeColor))
                {
                    g.DrawString(text, this.Font, brush, new PointF(x, y));
                }
            }
        }
        private Padding tempPadding = Padding.Empty;
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            MouseDown += (sender, args) =>
            {
                tempPadding = this.Padding;
                this.Padding = new Padding(tempPadding.Left + 1, tempPadding.Top + 1, tempPadding.Right, tempPadding.Bottom);
                if (args.Button == MouseButtons.Left)
                {
                    _animationManager.StartNewAnimation(args.Location);
                    Invalidate();
                }
            };
            MouseUp += (sender, args) =>
            {
                this.Padding = tempPadding;
                Invalidate();
            };
        }



        public void PerformClick()
        {
            if (this.Enabled)
                OnClick(EventArgs.Empty);
        }

        public void NotifyDefault(bool value)
        {

        }
    }
}
