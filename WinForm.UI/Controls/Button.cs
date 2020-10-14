using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI.Animations;
using WinForm.UI.Sys;
using WinForm.UI.Extension;

namespace WinForm.UI.Controls
{
    [ComVisibleAttribute(true)]
    [ToolboxItem(true), DefaultProperty("Text"), DefaultEvent("Click")]
    public partial class Button : Control, IButtonControl
    {
        #region Fields
        private DialogResult dialogResult = DialogResult.Cancel;
        private int radius = 5;
        private Color mouseOverBackColor = ColorStyles.MouseOverBackColor;
        private Color backColor = Color.Black;
        private string text = string.Empty;
        private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
        private Image image = null;
        private ContentAlignment imageAlign = ContentAlignment.MiddleLeft;
        private GraphicsPath m_Path;
        private AnimationManager _animationManager;
        private Padding tempPadding = Padding.Empty;
        #endregion

        #region Constructors
        public Button()
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

            base.BackColor = Color.Transparent;
            base.AutoSize = false;
            base.Height = 25;
            _animationManager = new AnimationManager(this);
            image = null;
        }
        #endregion

        #region Properties
        [Category("外观")]
        [Description("获取或设置控件背景图的方向")]
        [DefaultValue(typeof(ContentAlignment), "1")]
        public ContentAlignment ImageAlign { get { return imageAlign; } set { imageAlign = value; this.Invalidate(); } }

        [DefaultValue(null)]
        [Localizable(true)]
        [Category("外观")]
        [Description("获取或设置控件的背景图片")]
        public virtual Image Image { get { return image; } set { image = value; this.Invalidate(); } }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImeMode ImeMode { get { return base.ImeMode; } set { base.ImeMode = ImeMode.NoControl; } }


        [Category("外观")]
        [Description("获取或设置控件文本的方向")]
        [DefaultValue(typeof(ContentAlignment), "1")]
        public ContentAlignment TextAlign { get { return textAlign; } set { textAlign = value; this.Invalidate(); } }


        [Category("内容")]
        [Description("获取或设置控件的文本")]
        [DefaultValue(typeof(string), "")]
        public new string Text { get { return text; } set { text = value; this.Invalidate(); } }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoSize { get { return base.AutoSize; } set { base.AutoSize = false; } }

        [Category("外观")]
        [Description("获取或设置控件的背景色")]
        public new Color BackColor { get { return backColor; } set { if (backColor == value) return; backColor = value; this.Invalidate(); } }


        [Category("外观")]
        [Description("获取或设置当鼠标指针位于控件边框内时按钮工作区的颜色")]
        [DefaultValue(typeof(Color), "215, 210, 206")]
        public Color MouseOverBackColor { get { return mouseOverBackColor; } set { mouseOverBackColor = value; } }


        [Category("外观")]
        [Description("获取或设置当前控件圆角的弧度")]
        [DefaultValue(typeof(int), "5")]
        public int Radius
        {
            get { return radius; }
            set
            {
                if (value == radius) return;
                radius = value;
                UpdateFilletBounds();
                this.Invalidate();
            }
        }

        [Category("行为")]
        [Description("获取或设置窗体产生的结果")]
        [DefaultValue(typeof(DialogResult), "0")]
        public DialogResult DialogResult { get { return dialogResult; } set { dialogResult = value; } }


        #endregion
      


        private void UpdateFilletBounds()
        {
            if (this.Width <= 0)
                return;
            m_Path = RoundRect.GetRoundRectPath(new Rectangle(0, 0, this.Width, this.Height), radius);
        }

        #region Draw
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (m_Path == null)
                return;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush solidBrush = new SolidBrush(BackColor))
            {
                g.FillPath(solidBrush, m_Path);
            }

            if (_animationManager.IsAnimating())
            {
                //g.SmoothingMode = SmoothingMode.AntiAlias;
                Color bg = BackColor.TakeBackColor();//取相反色
                using (SolidBrush hrush = new SolidBrush(Color.FromArgb(50, bg)))
                {
                    float animationValue = (float)_animationManager.GetProgress();
                    float x = _animationManager.GetMouseDown().X - animationValue / 2;
                    float y = _animationManager.GetMouseDown().Y - animationValue / 2;
                    RectangleF rect = new RectangleF(x, y, animationValue, animationValue);
                    g.FillEllipse(hrush, rect);
                }
                //g.SmoothingMode = SmoothingMode.None;
            }

            DrawImage(g);
            DrawText(g);

        }



        private void DrawImage(Graphics g)
        {
            if (image == null)
                return;
            int x = this.Padding.Left;
            int y = this.Padding.Top;
            switch (imageAlign)
            {
                case ContentAlignment.TopLeft:
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.TopCenter:
                    if (image.Width < this.Width)
                        x += this.Width / 2 - image.Width / 2;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.TopRight:
                    if (image.Width < this.Width)
                        x += this.Width - image.Width;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.MiddleLeft:
                    if (image.Height < this.Height)
                        y += this.Height / 2 - image.Height / 2;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.MiddleCenter:
                    x += this.Width / 2 - image.Width / 2;
                    y += this.Height / 2 - image.Height / 2;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.MiddleRight:
                    x += this.Width - image.Width;
                    y += this.Height / 2 - image.Height / 2;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.BottomLeft:
                    y += this.Height - image.Height;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.BottomCenter:
                    x += this.Width / 2 - image.Width / 2;
                    y += this.Height - image.Height;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.BottomRight:
                    x += this.Width - image.Width;
                    y += this.Height - image.Height;
                    g.DrawImage(image, x, y);
                    break;
                default:
                    break;
            }
        }

        private void DrawText(Graphics g)
        {
            if (string.IsNullOrEmpty(text))
                return;
            int x = this.Padding.Left;
            int y = this.Padding.Top;
            Rectangle rectangle = new Rectangle(x, y, this.Width - x, this.Height - y);
            using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
                switch (textAlign)
                {
                    case ContentAlignment.TopLeft:
                        g.DrawNoPaddingStringTopLeft(text, this.Font, solidBrush, rectangle);
                        break;
                    case ContentAlignment.TopCenter:
                        g.DrawNoPaddingStringTopCenter(text, this.Font, solidBrush, rectangle);
                        break;
                    case ContentAlignment.TopRight:
                        g.DrawNoPaddingStringTopRight(text, this.Font, solidBrush, rectangle);
                        break;
                    case ContentAlignment.MiddleLeft:
                        g.DrawNoPaddingStringMiddleLeft(text, this.Font, solidBrush, rectangle);
                        break;
                    case ContentAlignment.MiddleCenter:
                        g.DrawNoPaddingStringMiddleCenter(text, this.Font, solidBrush, rectangle);
                        break;
                    case ContentAlignment.MiddleRight:
                        g.DrawNoPaddingStringMiddleRight(text, this.Font, solidBrush, rectangle);
                        break;
                    case ContentAlignment.BottomLeft:
                        g.DrawNoPaddingStringBottomLeft(text, this.Font, solidBrush, rectangle);
                        break;
                    case ContentAlignment.BottomCenter:
                        g.DrawNoPaddingStringBottomCenter(text, this.Font, solidBrush, rectangle);
                        break;
                    case ContentAlignment.BottomRight:
                        g.DrawNoPaddingStringBottomRight(text, this.Font, solidBrush, rectangle);
                        break;
                    default:
                        break;
                }
        }
        #endregion


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateFilletBounds();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            UpdateFilletBounds();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (DesignMode)
                return;
            tempPadding = this.Padding;
            this.Padding = new Padding(tempPadding.Left + 1, tempPadding.Top + 1, tempPadding.Right, tempPadding.Bottom);
            if (e.Button == MouseButtons.Left)
            {
                _animationManager.StartNewAnimation(e.Location);
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (DesignMode)
                return;
            this.Padding = tempPadding;
            Invalidate();
        }

        public void NotifyDefault(bool value)
        {
        }

        public void PerformClick()
        {
            if (this.Enabled)
                OnClick(EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }
                base.Dispose(disposing);
            }
        }

    }
}
