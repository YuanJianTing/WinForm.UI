using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Utils;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/12 15:33:36
    * 说明：
    * ==========================================================
    * */
    public class FErrorProvider : Control
    {

        private Timer timer = null;

        public FErrorProvider()
        {
            SetStyle(
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.SupportsTransparentBackColor |
               ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();

            base.Size = new Size(160, 40);
            base.MinimumSize = new Size(160, 40);
            base.BackColor = Color.Transparent;
            base.ForeColor = Color.White;
            base.Margin = new Padding(0, 0, 0, 0);
            base.Visible = false;
            base.Location = new Point(-50,-50);
            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 4000;
            timer.Tick += Timer_Tick;
        }

        

        #region 隐藏父容器控件
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text { get { return base.Text; } }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size { get { return base.Size; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Visible { get { return base.Visible; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int TabIndex { get { return base.TabIndex; } }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool TabStop { get { return base.TabStop; } }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseWaitCursor { get { return base.UseWaitCursor; } }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new RightToLeft RightToLeft { get { return base.RightToLeft; } }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding { get { return base.Padding; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Margin { get { return base.Margin; } }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImeMode ImeMode { get { return base.ImeMode; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Point Location { get { return base.Location; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DockStyle Dock { get { return base.Dock; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image BackgroundImage { get { return base.BackgroundImage; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Enabled { get { return base.Enabled; } }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Cursor Cursor { get { return base.Cursor; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AnchorStyles Anchor { get { return base.Anchor; } }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContextMenuStrip ContextMenuStrip { get { return base.ContextMenuStrip; } }

        #endregion

        /// <summary>
        /// 三角形宽
        /// </summary>
        private int TriangleWidth = 20;
        /// <summary>
        /// 三角形高
        /// </summary>
        private int TriangleHeight = 20;
        private Control Owner;
        private ErrorAlignment errorAlignment = ErrorAlignment.Right;
        private Color backColor = Color.FromArgb(62, 194, 46);
        [Category("Skin")]
        [Description("获取或设置当前控件的背景色")]
        [DefaultValue(typeof(ErrorAlignment), "1")]
        public new Color BackColor { get { return backColor; } set { backColor = value; } }
        [Category("Skin")]
        [Description("获取或设置当前控件相对位置")]
        [DefaultValue(typeof(ErrorAlignment), "1")]
        public ErrorAlignment ErrorAlignment
        {
            get { return errorAlignment; }
            set { if (errorAlignment == value) return; errorAlignment = value; this.Invalidate(); }
        }

        private string message;
        [Category("Skin")]
        [Description("获取或设置当前控件说提示的错误信息")]
        [DefaultValue(typeof(ErrorAlignment), "")]
        public string Error
        {
            get { return message; }
            set { if (message == value) return; message = value; this.Invalidate(); }
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!base.Visible)
                return;
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rect = Rectangle.Empty;
            switch (errorAlignment)
            {
                case ErrorAlignment.Top:
                    rect = new Rectangle(0, 0, this.Width, this.Height - (TriangleHeight - 2));
                    break;
                case ErrorAlignment.Right:
                    //TriangleWidth = 15;
                    rect = new Rectangle(TriangleWidth - 2, 0, this.Width, this.Height);
                    break;
                case ErrorAlignment.Left:
                    rect = new Rectangle(0, 0, this.Width - TriangleWidth + 4, this.Height);
                    break;
                case ErrorAlignment.Bottom:
                    rect = new Rectangle(0, TriangleHeight - 2, this.Width, this.Height);
                    break;
                default:
                    break;
            }

            //绘制背景
            GraphicsPathHelper.Draw(rect, g, 18, false, backColor);
            DrawTriangle(g);

            DrawText(g, rect);

        }

        private void DrawText(Graphics g, Rectangle rect)
        {
            if (string.IsNullOrEmpty(message))
                return;
            using (Brush hrush = new SolidBrush(this.ForeColor))
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;
                g.DrawString(message, this.Font, hrush, rect, format);
            }
        }

        /// <summary>
        /// 绘制三角形
        /// </summary>
        /// <param name="g"></param>
        private void DrawTriangle(Graphics g)
        {
            Point[] point = new Point[3];
            int x = 0, y = 0;
            switch (errorAlignment)
            {
                case ErrorAlignment.Top:
                    x = 30;
                    y = this.Height - TriangleHeight;//第一个点位置 总高- 三角形高
                    point[0] = new Point(x, y);

                    x = x + TriangleHeight / 2;//第二个点 X= 前一个点的X+ 三角形宽/2
                    y = 30 + TriangleWidth / 2;//
                    point[1] = new Point(x, y);

                    x = TriangleWidth + 30;
                    y = this.Height - TriangleHeight;//第一个点位置 总高- 三角形高
                    point[2] = new Point(x, y);
                    break;
                case ErrorAlignment.Right:
                    x = TriangleWidth;
                    y = 10;
                    point[0] = new Point(x, y);

                    x = 0;//第二个点 X= 前一个点的X+ 三角形宽/2
                    y = y + TriangleWidth / 2;//
                    point[1] = new Point(x, y);

                    x = TriangleWidth;
                    y = 10 + TriangleWidth;//第一个点位置 总高- 三角形高
                    point[2] = new Point(x, y);
                    break;
                case ErrorAlignment.Left:
                    x = this.Width - TriangleWidth;
                    y = 10;
                    point[0] = new Point(x, y);

                    x = this.Width;//第二个点 X= 前一个点的X+ 三角形宽/2
                    y = y + TriangleWidth / 2;//
                    point[1] = new Point(x, y);

                    x = this.Width - TriangleWidth;
                    y = y + TriangleWidth / 2;
                    point[2] = new Point(x, y);
                    break;
                case ErrorAlignment.Bottom:
                    x = 15;
                    y = TriangleHeight;
                    point[0] = new Point(x, y);

                    x = 15 + TriangleWidth / 2;//第二个点 X= 前一个点的X+ 三角形宽/2
                    y = 0;//
                    point[1] = new Point(x, y);

                    x = x + TriangleWidth / 2;
                    y = TriangleHeight;
                    point[2] = new Point(x, y);
                    break;
                default:
                    break;
            }

            using (Brush brushes = new SolidBrush(backColor))
            {
                g.FillPolygon(brushes, point);
            }
        }

        public void SetError(Control control, string message,int Time=4000)
        {
            if (base.Visible)
                return;

            this.Owner = control;
            InitSize(message);
            InitLocation();
            base.Visible = true;
            if (this.FindForm() == null)
            {
                Form form = control.FindForm();
                form.Controls.Add(this);
            }
            timer.Interval = Time;
            timer.Start();
        }

        private void InitSize(string message)
        {
            this.message = message;
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(message, this.Font);
            if (size.Height > 40)
                this.Height = Convert.ToInt32(size.Height + 10);


        }


        private void InitLocation()
        {
            Point point = Owner.Location;
            int x = 0, y = 0;
            switch (errorAlignment)
            {
                case ErrorAlignment.Top:
                    this.Height = this.Height + TriangleHeight;
                    x = point.X;
                    y = point.Y - this.Height;
                    break;
                case ErrorAlignment.Right:
                    x = point.X + Owner.Width + 5;
                    y = point.Y - 5;
                    break;
                case ErrorAlignment.Left:
                    x = point.X - this.Width;
                    y = point.Y - 5;
                    break;
                case ErrorAlignment.Bottom:
                    this.Height = this.Height + TriangleHeight;
                    x = point.X;
                    y = point.Y + Owner.Height;
                    break;
                default:
                    break;
            }
            base.Location = new Point(x, y);
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Visible = false;
            timer.Stop();
        }
    }
}
