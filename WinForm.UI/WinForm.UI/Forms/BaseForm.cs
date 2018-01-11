using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Animations;
using WinForm.UI.Utils;

namespace WinForm.UI.Forms
{
    public partial class BaseForm : Form
    {

        #region 自定义属性

        private static Style builder = FormsManager.Style;


        private bool dragSize = builder.DragSize;
        [Category("Skin")]
        [Description("是否允许拖到改变大小")]
        [DefaultValue(typeof(bool), "true")]
        public bool DragSize { get { return dragSize; } set { dragSize = value; } }




        //不显示FormBorderStyle属性
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle { get { return base.FormBorderStyle; } set { base.FormBorderStyle = FormBorderStyle.None; } }

        private bool _skinmobile = builder.SkinMobile;
        [Category("Skin")]
        [Description("窗体是否可以移动")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinMobile { get { return _skinmobile; } set { if (_skinmobile != value) { _skinmobile = value; } } }



        private bool isShadow = builder.IsShadow;
        [Category("Skin"),
        Description("设置窗体是否显示阴影效果"),
       DefaultValue(typeof(Boolean), "true")]
        public Boolean IsShadow { get { return isShadow; } set { isShadow = value; } }

        private Color titleForeColor = builder.TitleForeColor;
        [Category("Title")]
        [Description("标题栏字体颜色")]
        [DefaultValue(typeof(Color), "#FF000000")]
        public Color TitleForeColor { get { return titleForeColor; } set { titleForeColor = value; this.Invalidate(); } }

        // Color.FromArgb(194, 186, 181);
        private Color titleBackColor = builder.TitleBackColor;
        [Category("Title")]
        [Description("标题栏背景色")]
        [DefaultValue(typeof(Color), "194, 186, 181")]
        public Color TitleBackColor { get { return titleBackColor; } set { titleBackColor = value; this.Invalidate(); } }

        public override string Text { get { return base.Text; } set { base.Text = value; this.Invalidate(); } }

        private bool TitleIsCenter = builder.TitleIsCenter;//标题是否居中
        [Category("Title")]
        [Description("标题是否居中")]
        public bool _TitleIsCenter { get { return TitleIsCenter; } set { TitleIsCenter = value; this.Invalidate(); } }

        private bool IsTitle = builder.IsTitle;//是否显示标题
        [Category("Title")]
        [Description("是否显示标题")]
        public bool _IsTitle { get { return IsTitle; } set { IsTitle = value; this.Invalidate(); } }

        private bool isLogo = builder.IsLogo;//是否显示标题
        [Category("Title")]
        [Description("是否显示logo")]
        public bool IsLogo { get { return isLogo; } set { isLogo = value; this.Invalidate(); } }

        private bool maximazeBox = builder.MaximizeBox;
        [Category("Title"),
       Description("设置窗体是否显示最大化按钮"),
      DefaultValue(typeof(Boolean), "true")]
        public new Boolean MaximizeBox { get { return maximazeBox; } set { maximazeBox = value; this.Invalidate(); } }


        private bool minimazeBox = builder.MinimizeBox;
        [Category("Title"),
        Description("设置窗体是否显示最小化按钮"),
       DefaultValue(typeof(Boolean), "true")]
        public new Boolean MinimizeBox { get { return minimazeBox; } set { minimazeBox = value; this.Invalidate(); } }

        private Image maxBoxImage = builder.MaxBoxImage;
        [Category("Title"),
        Description("设置窗体最大化按钮背景图"),
       DefaultValue(typeof(Image), "")]
        public Image MaxBoxImage { get { return maxBoxImage; } set { maxBoxImage = value; this.Invalidate(); } }

        private Image restoreBoxImage = builder.RestoreBoxImage;
        [Category("Title"),
        Description("设置窗体还原按钮背景图"),
       DefaultValue(typeof(Image), "")]
        public Image RestoreBoxImage { get { return restoreBoxImage; } set { restoreBoxImage = value; this.Invalidate(); } }

        private Image minBoxImage = builder.MinBoxImage;
        [Category("Title"),
        Description("设置窗体最小化按钮背景图"),
       DefaultValue(typeof(Image), "")]
        public Image MinBoxImage { get { return minBoxImage; } set { minBoxImage = value; this.Invalidate(); } }

        private Image closeBoxImage = builder.CloseBoxImage;
        [Category("Title"),
        Description("设置窗体关闭按钮背景图"),
       DefaultValue(typeof(Image), "")]
        public Image CloseBoxImage { get { return closeBoxImage; } set { closeBoxImage = value; this.Invalidate(); } }



        private Color maxBoxBackColor = builder.MaxBoxBackColor;
        [Category("Title"),
        Description("设置窗体最大化按钮背景颜色"),
       DefaultValue(typeof(Color), "203, 196, 192")]
        public Color MaxBoxBackColor { get { return maxBoxBackColor; } set { maxBoxBackColor = value; this.Invalidate(); } }


        private Color minBoxBackColor = builder.MinBoxBackColor;
        [Category("Title"),
        Description("设置窗体最小化按钮背景颜色"),
       DefaultValue(typeof(Color), "203, 196, 192")]
        public Color MinBoxBackColor { get { return minBoxBackColor; } set { minBoxBackColor = value; this.Invalidate(); } }

        private Color closeBoxBackColor = builder.CloseBoxBackColor;
        [Category("Title"),
        Description("设置窗体关闭按钮背景颜色"),
       DefaultValue(typeof(Color), "212, 64, 39")]
        public Color CloseBoxBackColor { get { return closeBoxBackColor; } set { closeBoxBackColor = value; this.Invalidate(); } }

        private Color maxBoxFontColor = builder.MaxBoxFontColor;
        [Category("Title"),
        Description("设置窗体最大化按钮字体颜色"),
       DefaultValue(typeof(Color), "#FFFFFFFF")]
        public Color MaxBoxFontColor { get { return maxBoxFontColor; } set { maxBoxFontColor = value; this.Invalidate(); } }


        private Color minBoxFontColor = builder.MinBoxFontColor;
        [Category("Title"),
        Description("设置窗体最小化按钮字体颜色"),
       DefaultValue(typeof(Color), "#FFFFFFFF")]
        public Color MinBoxFontColor { get { return minBoxFontColor; } set { minBoxFontColor = value; this.Invalidate(); } }

        private Color closeBoxFontColor = builder.CloseBoxFontColor;
        [Category("Title"),
        Description("设置窗体关闭按钮字体颜色"),
       DefaultValue(typeof(Color), "#FFFFFFFF")]
        public Color CloseBoxFontColor { get { return closeBoxFontColor; } set { closeBoxFontColor = value; this.Invalidate(); } }

        private int titleHeight = 30;
        [Category("TitleHeight"),
        Description("设置窗体标题栏高"),
       DefaultValue(typeof(int), "30")]
        public int TitleHeight { get { return titleHeight; } set { titleHeight = value; this.Invalidate(); } }

        #endregion

        //标题
        private Rectangle Title;
        private Rectangle _minButtonBounds;
        private Rectangle _maxButtonBounds;
        private Rectangle _xButtonBounds;
        private ButtonState _buttonState = ButtonState.None;
        private bool _maximized = true;

        private Animation animation;
        public Animation Animation
        {
            get { return animation; }
            set
            {
                animation = value;
                animation.SetForm(this);
            }
        }
        //绘制层
        internal ShadowForm skin;

        public BaseForm()
        {
            this.dragSize = builder.DragSize;
            this._skinmobile = builder.SkinMobile;
            this.isShadow = builder.IsShadow;
            this.Font = builder.Font;
            this.ForeColor = builder.ForeColor;
            this.titleBackColor = builder.TitleBackColor;
            this.TitleIsCenter = builder.TitleIsCenter;
            this.IsTitle = builder.IsTitle;
            this.isLogo = builder.IsLogo;
            this.maximazeBox = builder.MaximizeBox;
            this.minimazeBox = builder.MinimizeBox;
            this.maxBoxImage = builder.MaxBoxImage;
            this.restoreBoxImage = builder.RestoreBoxImage;
            this.maxBoxImage = builder.MinBoxImage;
            this.closeBoxImage = builder.CloseBoxImage;
            this.maxBoxBackColor = builder.MaxBoxBackColor;
            this.minBoxBackColor = builder.MinBoxBackColor;
            this.closeBoxBackColor = builder.CloseBoxBackColor;
            this.maxBoxFontColor = builder.MaxBoxFontColor;
            this.minBoxFontColor = builder.MinBoxFontColor;
            this.closeBoxFontColor = builder.CloseBoxFontColor;
            this.BackColor = builder.FormBackColor;
            this.titleForeColor = builder.TitleForeColor;
            this.titleHeight = builder.TitleHeight;

            Application.AddMessageFilter(new MouseMessageFilter());
            MouseMessageFilter.MouseMove += OnGlobalMouseMove;
            base.FormBorderStyle = FormBorderStyle.None;
            //减少闪烁
            SetStyles();
            Title = new Rectangle(0, 0, this.Width, titleHeight);
            _xButtonBounds = new Rectangle(this.Width - titleHeight, 0, titleHeight, titleHeight);
            _maxButtonBounds = new Rectangle(_xButtonBounds.X - titleHeight, 0, titleHeight, titleHeight);
            _minButtonBounds = new Rectangle(_maxButtonBounds.X - titleHeight, 0, titleHeight, titleHeight);
        }

        private void OnGlobalMouseMove(object sender, MouseEventArgs e)
        {
            if (IsDisposed) return;
            // Convert to client position and pass to Form.MouseMove
            var clientCursorPos = PointToClient(e.Location);
            var newE = new MouseEventArgs(MouseButtons.None, 0, clientCursorPos.X, clientCursorPos.Y, 0);
            OnMouseMove(newE);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (IsTitle)
            {
                DrawTitle(e.Graphics);
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (DesignMode) return;
            UpdateButtons(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (DesignMode) return;
            _buttonState = ButtonState.None;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (DesignMode) return;
            UpdateButtons(e, true);
            base.OnMouseUp(e);
        }





        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (builder.Icon == null)
                return;
            this.Icon = builder.Icon;
            if (!DesignMode)
            {
                animation = builder.Animation;
                animation.SetForm(this);
            }
        }

        #region 标题

        private void UpdateButtons(MouseEventArgs e, bool up = false)
        {
            if (DesignMode) return;
            var oldState = _buttonState;
            bool showMin = MinimizeBox && ControlBox;
            bool showMax = MaximizeBox && ControlBox;

            if (e.Button == MouseButtons.Left && !up)
            {
                if (showMin && !showMax && _maxButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MinDown;
                }
                else if (showMin && showMax && _minButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MinDown;
                }
                else if (showMax && _maxButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MaxDown;
                }
                else if (ControlBox && _xButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.XDown;
                }
                else
                    _buttonState = ButtonState.None;
            }
            else
            {
                if (showMin && !showMax && _maxButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MinOver;

                    if (oldState == ButtonState.MinDown && up)
                        WindowState = FormWindowState.Minimized;
                }
                else if (showMin && showMax && _minButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MinOver;

                    if (oldState == ButtonState.MinDown && up)
                        WindowState = FormWindowState.Minimized;
                }
                else if (MaximizeBox && ControlBox && _maxButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.MaxOver;

                    if (oldState == ButtonState.MaxDown && up)
                        MaximizeWindow();

                }
                else if (ControlBox && _xButtonBounds.Contains(e.Location))
                {
                    _buttonState = ButtonState.XDown;

                    if (oldState == ButtonState.XDown && up)
                        Close();
                }
                else _buttonState = ButtonState.None;
            }

            if (oldState != _buttonState) Invalidate();

        }

        private void DrawTitle(Graphics g)
        {
            Title.Width = this.Width;
            if (titleBackColor != Color.Transparent)
            {
                using (Brush bg = new SolidBrush(titleBackColor))
                {
                    // Draw the gradient onto the form
                    g.FillRectangle(bg, Title);
                }
            }
            if (isLogo)
            {
                //绘制标题和logo
                DrawTextAndLogo(g);
            }

            DrawButton(g);
        }

        private void DrawButton(Graphics g)
        {
            bool showMin = MinimizeBox && ControlBox;
            bool showMax = MaximizeBox && ControlBox;

            Font font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            _xButtonBounds.X = this.Width - titleHeight;
            _maxButtonBounds.X = _xButtonBounds.X - titleHeight;
            _minButtonBounds.X = _maxButtonBounds.X - titleHeight;


            Brush hoverBrush = new SolidBrush(Color.Transparent);

            Brush downBrush = new SolidBrush(closeBoxBackColor);
            Brush minBoxBackColordownBrush = new SolidBrush(minBoxBackColor);
            Brush maxBoxBackColordownBrush = new SolidBrush(maxBoxBackColor);


            if (_buttonState == ButtonState.MinOver && showMin)
                g.FillRectangle(minBoxBackColordownBrush, showMax ? _minButtonBounds : _maxButtonBounds);

            if (_buttonState == ButtonState.MinDown && showMin)
                g.FillRectangle(minBoxBackColordownBrush, showMax ? _minButtonBounds : _maxButtonBounds);

            if (_buttonState == ButtonState.MaxOver && showMax)
                g.FillRectangle(maxBoxBackColordownBrush, _maxButtonBounds);

            if (_buttonState == ButtonState.MaxDown && showMax)
                g.FillRectangle(maxBoxBackColordownBrush, _maxButtonBounds);

            if (_buttonState == ButtonState.XOver && ControlBox)
                g.FillRectangle(hoverBrush, _xButtonBounds);

            if (_buttonState == ButtonState.XDown && ControlBox)
                g.FillRectangle(downBrush, _xButtonBounds);

            hoverBrush.Dispose();
            downBrush.Dispose();
            minBoxBackColordownBrush.Dispose();
            maxBoxBackColordownBrush.Dispose();

            if (closeBoxImage != null)
                g.DrawImage(closeBoxImage, new Point(_xButtonBounds.Location.X + 8, 5));
            if (showMax)
            {
                if (maxBoxImage != null)
                {
                    if (_maximized)
                        g.DrawImage(maxBoxImage, new Point(_maxButtonBounds.Location.X + 8, 5));
                    else if (restoreBoxImage != null)
                        g.DrawImage(restoreBoxImage, new Point(_maxButtonBounds.Location.X + 8, 5));
                }
                if (showMin && minBoxImage != null)
                    g.DrawImage(minBoxImage, new Point(_minButtonBounds.Location.X + 8, 5));
            }
            else if (minBoxImage != null)
                g.DrawImage(minBoxImage, new Point(_maxButtonBounds.Location.X + 8, 5));


            Brush maxBoxFontBrush = new SolidBrush(maxBoxFontColor);
            Brush minBoxFontBrush = new SolidBrush(minBoxFontColor);
            Brush closeBoxFontBrush = new SolidBrush(closeBoxFontColor);
            Brush closeBoxFontDownBrush = new SolidBrush(Color.White);
            if (_buttonState == ButtonState.XDown && ControlBox)
                g.DrawString("X", font, closeBoxFontDownBrush, new Point(_xButtonBounds.Location.X + 8, 5));
            else
                g.DrawString("X", font, closeBoxFontBrush, new Point(_xButtonBounds.Location.X + 8, 5));

            if (showMax)
            {
                g.DrawString("口", font, maxBoxFontBrush, new Point(_maxButtonBounds.Location.X + 8, 5));
                if (showMin)
                    g.DrawString("一", font, minBoxFontBrush, new Point(_minButtonBounds.Location.X + 8, 5));
            }
            else if (showMin)
                g.DrawString("一", font, minBoxFontBrush, new Point(_maxButtonBounds.Location.X + 8, 5));

            maxBoxFontBrush.Dispose();
            minBoxFontBrush.Dispose();
            closeBoxFontBrush.Dispose();
            closeBoxFontDownBrush.Dispose();

        }


        /// <summary>
        /// 绘制标题和logo
        /// </summary>
        /// <param name="g"></param>
        private void DrawTextAndLogo(Graphics g)
        {
            using (Brush bg = new SolidBrush(this.TitleForeColor))
            {
                SizeF sizef = g.MeasureString(this.Text, this.Font);
                if (!TitleIsCenter)
                {
                    g.DrawString(this.Text, this.Font, bg, 25, titleHeight / 2 - sizef.Height / 2);
                    //绘制logo
                    g.DrawIcon(this.Icon, new Rectangle(4, Convert.ToInt32(titleHeight / 2 - 18 / 2), 18, 18));
                }
                else
                {
                    g.DrawString(this.Text, this.Font, bg, this.Width / 2 - sizef.Width / 2, titleHeight / 2 - sizef.Height / 2);
                    //绘制logo
                    g.DrawIcon(this.Icon, new Rectangle(Convert.ToInt32(this.Width / 2 - sizef.Width / 2 - 20), Convert.ToInt32(titleHeight / 2 - 18 / 2), 18, 18));
                }
            }
        }
        #endregion


        private void MaximizeWindow()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                _maximized = false;
            }
            else
            {
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
                _maximized = true;
            }
        }

        #region 窗体拖动
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (DesignMode) return;

            UpdateButtons(e);
            if (SkinMobile)
            {
                //释放鼠标焦点捕获
                Win32.ReleaseCapture();
                //向当前窗体发送拖动消息
                Win32.SendMessage(this.Handle, 0x0112, 0xF011, 0);
                OnMouseUp(e);
            }

            base.OnMouseDown(e);

        }


        #endregion


        #region 减少闪烁
        private void SetStyles()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
            base.AutoScaleMode = AutoScaleMode.None;

        }
        #endregion


        #region 重载事件
        //Show或Hide被调用时
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                //启用窗口淡入淡出
                if (!DesignMode)
                {
                    if (animation != null)
                        animation.OnShow();
                }
                //判断不是在设计器中
                if (!DesignMode && skin == null && isShadow)
                {
                    skin = new ShadowForm(this);
                    skin.Show(this);
                }
                base.OnVisibleChanged(e);
            }
            else
            {
                base.OnVisibleChanged(e);
                if (animation != null)
                    animation.OnClosing();
            }
        }

        //窗体关闭时
        protected override void OnClosing(CancelEventArgs e)
        {
            if (animation != null && animation.IsClose == false)
            {
                animation.OnClosing();
                e.Cancel = true;
            }

            base.OnClosing(e);
            //先关闭阴影窗体
            if (skin != null)
            {
                skin.Close();
            }

        }

        //控件首次创建时被调用
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetReion();
        }

        //圆角
        private void SetReion()
        {
            using (GraphicsPath path =
                    GraphicsPathHelper.CreatePath(
                    new Rectangle(Point.Empty, base.Size), 6, RoundStyle.All, true))
            {
                Region region = new Region(path);
                path.Widen(Pens.White);
                region.Union(path);
                this.Region = region;
            }
        }

        //改变窗体大小时
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetReion();
        }


        #endregion

        #region 允许点击任务栏最小化
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作

                return cp;
            }
        }

        #endregion


        #region 拖动改变大小
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            if (dragSize)
            {
                switch (m.Msg)
                {
                    case 0x0084:
                        base.WndProc(ref m);
                        Point vPoint = new Point((int)m.LParam & 0xFFFF,
                            (int)m.LParam >> 16 & 0xFFFF);
                        vPoint = PointToClient(vPoint);
                        if (vPoint.X <= 5)
                            if (vPoint.Y <= 5)
                                m.Result = (IntPtr)HTTOPLEFT;
                            else if (vPoint.Y >= ClientSize.Height - 5)
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else m.Result = (IntPtr)HTLEFT;
                        else if (vPoint.X >= ClientSize.Width - 5)
                            if (vPoint.Y <= 5)
                                m.Result = (IntPtr)HTTOPRIGHT;
                            else if (vPoint.Y >= ClientSize.Height - 5)
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                            else m.Result = (IntPtr)HTRIGHT;
                        else if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOP;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOM;
                        break;
                    //case 0x0201://鼠标左键按下的消息 
                    //    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标 
                    //    m.LParam = IntPtr.Zero;//默认值 
                    //    m.WParam = new IntPtr(2);//鼠标放在标题栏内 
                    //    base.WndProc(ref m);
                    //    break;

                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
            else
            {
                base.WndProc(ref m);
            }

        }
        #endregion

        private enum ButtonState
        {
            XOver,
            MaxOver,
            MinOver,
            XDown,
            MaxDown,
            MinDown,
            None
        }


    }

    public class MouseMessageFilter : IMessageFilter
    {
        private const int WM_MOUSEMOVE = 0x0200;

        public static event MouseEventHandler MouseMove;

        public bool PreFilterMessage(ref Message m)
        {

            if (m.Msg == WM_MOUSEMOVE)
            {
                if (MouseMove != null)
                {
                    int x = Control.MousePosition.X, y = Control.MousePosition.Y;

                    MouseMove(null, new MouseEventArgs(MouseButtons.None, 0, x, y, 0));
                }
            }
            return false;
        }
    }
}
