using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI.Properties;
using WinForm.UI.Sys;

namespace WinForm.UI.Forms
{
    public partial class BaseForm : Form
    {
        #region Fields
        private bool titleVisible = true;
        private Color titleForeColor = Color.FromArgb(187, 187, 187);
        private int titleHeight = 30;
        private int titleTextOffset = 0;
        private bool dragSize = true;
        private Rectangle closeBounds;
        private Rectangle maxBounds;
        private Rectangle minBounds;
        private Rectangle titleBounds;


        private MouseState mouseState = MouseState.None;
        private Bitmap closeIcon;
        private Bitmap normalIcon;
        private Bitmap maxIcon;
        private Bitmap minIcon;
        private bool border = true;
        protected SynchronizationContext m_context;
        protected TaskFactory taskFactory;
        private Dictionary<string, object> Session;

        #endregion

        #region Constructors
        public BaseForm()
        {
            m_context = WindowsFormsSynchronizationContext.Current;
            base.WindowState = FormWindowState.Normal;
            //this.StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("微软雅黑", 9, FontStyle.Regular);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(60, 63, 65);
            ForeColor = titleForeColor;
            closeIcon = Resources.ImageCloseIcon;
            normalIcon = Resources.ImageNormalIcon;
            maxIcon = Resources.ImageMaximizedIcon;
            minIcon = Resources.ImageMinimizedIcon;
            taskFactory = new TaskFactory();
            Session = new Dictionary<string, object>();
            if (!DesignMode)
                this.Opacity = 0;
            titleBounds = new Rectangle(0, 0, this.Width, titleHeight);
        }
        #endregion


        #region Properties
        private MouseState MouseLocationState
        {
            set
            {
                if (mouseState == value)
                    return;
                mouseState = value;
                this.Invalidate(titleBounds);
            }
        }
        [Category("Appearance")]
        [Description("获取或设置是否显示标题栏")]
        public bool TitleVisible
        {
            get { return titleVisible; }
            set { titleVisible = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        [Description("获取或设置窗体标签的X坐标偏移量")]
        [DefaultValue(0)]
        public int TitleTextOffset
        {
            get { return titleTextOffset; }
            set { titleTextOffset = value; this.Invalidate(); }
        }
        [Category("Appearance")]
        [Description("获取或设置窗体是否显示边框")]
        public bool Border
        {
            get { return border; }
            set { border = value; this.Invalidate(); }
        }

        [Category("Appearance")]
        [Description("是否允许拖到改变大小")]
        [DefaultValue(typeof(bool), "true")]
        public bool DragSize { get { return dragSize; } set { dragSize = value; } }
        #endregion


        #region Methods
        protected override void OnLoad(EventArgs e)
        {

            if (!DesignMode)
            {
                (new DropShadow()).ApplyShadows(this);

                string iconPath = Path.Combine(Application.StartupPath, "logo.ico");
                if (File.Exists(iconPath))
                    Icon = new Icon(iconPath);
            }
            base.OnLoad(e);

            if (!DesignMode)
            {
                taskFactory.StartNew(StartFormShow);
            }
        }

        private void StartFormShow()
        {
            for (double i = 0; i < 1; i += 0.1)
            {
                Thread.Sleep(10);
                m_context.Post((o) => this.Opacity = Convert.ToDouble(o), i);
            }
        }



        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!DesignMode)
                ResetButton();
            if (DragSize && MouseButtons == MouseButtons.Left)
            {
                this.Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (closeBounds.Contains(e.Location))
                MouseLocationState = MouseState.MouseClose;
            else if (MaximizeBox && maxBounds.Contains(e.Location))
                MouseLocationState = MouseState.MouseMax;
            else if (MinimizeBox && minBounds.Contains(e.Location))
                MouseLocationState = MouseState.MouseMin;
            else
                MouseLocationState = MouseState.None;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseLocationState = MouseState.None;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (DesignMode) return;


            //释放鼠标焦点捕获
            Win32.ReleaseCapture();
            ////向当前窗体发送拖动消息
            Win32.SendMessage(this.Handle, 0x0112, 0xF011, 0);
            OnMouseUp(e);

            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (closeBounds.Contains(e.Location))
                this.Close();
            else if (MaximizeBox && maxBounds.Contains(e.Location))
            {
                if (WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Normal;
                else
                    WindowState = FormWindowState.Maximized;
                this.Invalidate();
            }
            else if (MinimizeBox && minBounds.Contains(e.Location))
                WindowState = FormWindowState.Minimized;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (TitleVisible)
            {
                if (Icon != null)
                    g.DrawIcon(Icon, new Rectangle(5, 5, 18, 18));
                if (!string.IsNullOrEmpty(Text))
                    g.DrawString(Text, Font, new SolidBrush(titleForeColor), TitleTextOffset + 30, titleHeight / 2 - 8);
                DrawButton(g);
            }
            if (Border)
            {
                using (Pen pen = new Pen(ColorStyles.LineColor))
                    g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Session.Clear();
                Session = null;
                closeIcon.Dispose();
                normalIcon.Dispose();
                maxIcon.Dispose();
                minIcon.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawButton(Graphics g)
        {
            if (mouseState != MouseState.None)
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
                {
                    switch (mouseState)
                    {
                        case MouseState.None:
                            break;
                        case MouseState.MouseClose:
                            if (mouseState == MouseState.MouseClose)
                                sb.Color = Color.FromArgb(232, 17, 35);
                            g.FillRectangle(sb, closeBounds);
                            break;
                        case MouseState.MouseMax:
                            g.FillRectangle(sb, maxBounds);
                            break;
                        case MouseState.MouseMin:
                            g.FillRectangle(sb, minBounds);
                            break;
                        default:
                            break;
                    }

                }

            g.DrawImage(closeIcon, closeBounds.X + closeBounds.Width / 2 - 8, closeBounds.Y + 6, 16, 16);
            if (MaximizeBox)
            {
                if (WindowState == FormWindowState.Maximized)
                    g.DrawImage(normalIcon, maxBounds.X + maxBounds.Width / 2 - 8, maxBounds.Y + 6, 16, 16);
                else
                    g.DrawImage(maxIcon, maxBounds.X + maxBounds.Width / 2 - 8, maxBounds.Y + 6, 16, 16);

            }
            if (MinimizeBox)
                g.DrawImage(minIcon, minBounds.X + minBounds.Width / 2 - 8, minBounds.Y + 6, 16, 16);

        }

        private void ResetButton()
        {
            int size = 50;
            int x = this.Width - size;
            closeBounds = new Rectangle(x, 0, size, titleHeight);
            x -= closeBounds.Width;
            if (MaximizeBox)
            {
                maxBounds = new Rectangle(x, 0, size, titleHeight);
                x -= maxBounds.Width;
            }
            minBounds = new Rectangle(x, 0, size, titleHeight);

            titleBounds = new Rectangle(0, 0, this.Width, titleHeight);
        }

        #endregion


        #region 最大化处理

        protected override CreateParams CreateParams
        {
            get
            {
                if (DesignMode)
                    return base.CreateParams;

                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        /*任务栏位置*/
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SystemParametersInfo(int uAction, int uParam, ref RECT re, int fuWinTni);
        [System.Runtime.InteropServices.DllImport("SHELL32", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct APPBARDATA
        {
            public int cbSize;
            public IntPtr hWnd;
            public int uCallbackMessage;
            public int uEdge;//属性代表上、下、左、右
            public RECT rc;
            public IntPtr lParam;
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public override string ToString()
            {
                return "{left=" + left.ToString() + ", " + "top=" + top.ToString() + ", " +
                "right=" + right.ToString() + ", " + "bottom=" + bottom.ToString() + "}";
            }
        }
        /*窗体坐标*/
        private const long WM_GETMINMAXINFO = 0x24;

        #region 拖动改变大小
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;
        const long WM_DRAG_SIZE = 0x0084;
        #endregion


        private struct POINTAPI
        {
            public int x;
            public int y;
        }
        private struct MINMAXINFO
        {
            //public POINTAPI ptReserved;
            //public POINTAPI ptMaxSize;
            public POINTAPI ptMaxPosition;
            public POINTAPI ptMinTrackSize;
            public POINTAPI ptMaxTrackSize;
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_GETMINMAXINFO)
            {
                this.MaximumSize = SystemInformation.WorkingArea.Size;
                MINMAXINFO mmi = (MINMAXINFO)m.GetLParam(typeof(MINMAXINFO));
                mmi.ptMinTrackSize.x = this.MinimumSize.Width;
                mmi.ptMinTrackSize.y = this.MinimumSize.Height;
                if (this.MaximumSize.Width != 0 || this.MaximumSize.Height != 0)
                {
                    mmi.ptMaxTrackSize.x = this.MaximumSize.Width;
                    mmi.ptMaxTrackSize.y = this.MaximumSize.Height;
                }
                //-------------------------
                int aaa = 0x00000005;
                APPBARDATA pdat = new APPBARDATA();
                SHAppBarMessage(aaa, ref pdat);

                if (pdat.uEdge == 0) //左
                {
                    mmi.ptMaxPosition.x = Screen.PrimaryScreen.Bounds.Width - SystemInformation.WorkingArea.Width;
                    mmi.ptMaxPosition.y = 0;
                }
                else if (pdat.uEdge == 1) //上
                {
                    mmi.ptMaxPosition.x = 0;
                    mmi.ptMaxPosition.y = Screen.PrimaryScreen.Bounds.Height - SystemInformation.WorkingArea.Height;
                }
                else if (pdat.uEdge == 2) //右
                {
                    mmi.ptMaxPosition.x = 0;
                    mmi.ptMaxPosition.y = 0;
                }
                else if (pdat.uEdge == 3) //下
                {
                    mmi.ptMaxPosition.x = 0;
                    mmi.ptMaxPosition.y = 0;
                }

                System.Runtime.InteropServices.Marshal.StructureToPtr(mmi, m.LParam, true);
            }
            else if (DragSize && m.Msg == WM_DRAG_SIZE)
            {
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
            }
        }
        #endregion



        enum MouseState
        {
            None,
            MouseClose,
            MouseMax,
            MouseMin
        }

    }
}
