using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Utils;

namespace WinForm.UI.Controls
{
    public class VerticalScroll : Control
    {
        [DefaultValue(typeof(Color), "196, 198, 204")]
        [Description("获取或设置导轨的背景色")]
        public Color TrackColor { get; set; }

        [DefaultValue(typeof(Color), "196, 198, 204")]
        [Description("获取或设置导轨的背景色")]
        public Color ScrollColor { get; set; }


        //虚拟的一个高(控件中内容的高度)
        private int virtualHeight;
        [Browsable(false)]
        public int VirtualHeight
        {
            get { return virtualHeight; }
            set
            {
                if (value < 0)
                    return;
                virtualHeight = value;
                if (virtualHeight == 0)
                    this.Visible = false;
                else
                {
                    this.Visible = true;
                    sliderHeight = (int)(((double)Height / virtualHeight) * Height);
                }
                this.Invalidate();
            }
        }
        //滑块高
        private int sliderHeight;
        private Rectangle bounds;

        [Browsable(false)]
        public override Color BackColor { get => base.BackColor; }

        private int value = 0;
        [DefaultValue(typeof(int), "0")]
        [Description("获取或设置滚动条的值")]
        public int Value
        {
            get { return value; }
            set
            {
                if (value > virtualHeight)
                    value = virtualHeight;
                this.value = value;
            }
        }
        //被点击
        private bool isMouseDown = false;
        public bool IsMouseDown
        {
            get { return isMouseDown; }
            set
            {
                if (value)
                {
                    m_nLastSliderY = bounds.Y;
                }
                isMouseDown = value;
            }
        }
        //滑块移动前的 滑块的Y坐标
        private int m_nLastSliderY;
        //鼠标在滑块点下时候的y坐标
        private int mouseDownY;
        private Point m_ptMousePos;             //鼠标的位置
                                                //鼠标在滚动条上方
        private bool isMouseOnSlider = false;
        public bool IsMouseOnSlider
        {
            get { return isMouseOnSlider; }
            set
            {
                if (isMouseOnSlider == value)
                    return;
                isMouseOnSlider = value;
                owner.Invalidate(this.bounds);
            }
        }
        private Control owner;
        public Control Owner
        {
            get { return owner; }
            set
            {
                if (value == null)
                    return;
                owner = value;
                //this.Location = new Point(owner.Width-this.Width,0);
                this.Height = owner.Height-50;
            }
        }


        public VerticalScroll()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Selectable, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();

            this.Width = 10;
            ScrollColor = Color.FromArgb(196, 198, 204);
            TrackColor = Color.FromArgb(245, 245, 245);
            base.BackColor = Color.Transparent;
            bounds = new Rectangle(0, 0, this.Width, this.Height);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            bounds = new Rectangle(0, 0, this.Width, this.Height);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Visible)
                return;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawTrack(g);
            DrawSlider(g);

        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (Visible)
            {
                //如果有滚动条 判断是否在滚动条类点击
                //如果左键在滚动条滑块上点击
                if (bounds.Contains(m_ptMousePos))
                {
                    MoveSliderToLocation(m_ptMousePos.Y);
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!Visible)
                return;
            if (e.Button == MouseButtons.Left)
            {
                //如果左键在滚动条滑块上点击
                if (bounds.Contains(e.Location))
                {
                    IsMouseDown = true;
                    mouseDownY = e.Y;
                }
                
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!Visible)
                return;
            ClearAllMouseOn();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!Visible)
                return;
            if (e.Button == MouseButtons.Left)
            {
                IsMouseDown = false;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!Visible)
                return;
            m_ptMousePos = e.Location;
            //如果滚动条的滑块处于被点击 那么移动
            if (IsMouseDown)
            {
                MoveSliderFromLocation(e.Y);
                return;
            }

            if (bounds.Contains(e.Location))
            {
                IsMouseOnSlider = true;
                return;
            }
            else
            {
                ClearAllMouseOn();
            }
            IsMouseOnSlider = false;
        }

        public void ClearAllMouseOn()
        {
            if (!this.isMouseOnSlider)
                return;
            this.isMouseOnSlider = false;
            owner.Invalidate(this.bounds);
        }

        //将滑块跳动至一个地方
        public void MoveSliderToLocation(int nCurrentMouseY)
        {
            if (nCurrentMouseY - bounds.Height / 2 < 1)
                bounds.Y = 1;
            else if (nCurrentMouseY + bounds.Height / 2 > owner.Height - 1)
                bounds.Y = owner.Height - bounds.Height - 1;
            else
                bounds.Y = nCurrentMouseY - bounds.Height / 2;
            this.value = (int)((double)(bounds.Y) / (owner.Height - bounds.Height) * (virtualHeight - owner.Height));
            OnScrollHandler(new ScrollEventArgs(ScrollEventType.SmallDecrement, this.value));
            owner.Invalidate();
        }

        public void MoveSliderFromLocation(int nCurrentMouseY)
        {
            if (m_nLastSliderY + nCurrentMouseY - mouseDownY < 1)
            {
                if (bounds.Y == 1)
                    return;
                bounds.Y = 1;
            }
            else if (m_nLastSliderY + nCurrentMouseY - mouseDownY > owner.Height - bounds.Height)
            {
                if (bounds.Y == owner.Height - bounds.Height)
                    return;
                bounds.Y = owner.Height - bounds.Height;
            }
            else
            {
                bounds.Y = m_nLastSliderY + nCurrentMouseY - mouseDownY;
            }
            this.value = (int)((double)(bounds.Y) / (owner.Height - bounds.Height) * (virtualHeight - owner.Height));
            OnScrollHandler(new ScrollEventArgs(ScrollEventType.ThumbTrack, this.value));
            owner.Invalidate();
        }

        /// <summary>
        /// 绘制滑块
        /// </summary>
        /// <param name="g"></param>
        private void DrawSlider(Graphics g)
        {
            if (VirtualHeight < this.Height)
                return;
            bounds.Height = sliderHeight;
            bounds.Y = (int)(((double)value / (virtualHeight - Height)) * (Height - bounds.Height));

            GraphicsPath path = GetRoundRectangle(bounds, 5);
            using (SolidBrush sb = new SolidBrush(ScrollColor))
            {
                g.FillPath(sb, path);
            }
        }


        /// <summary>
        /// 绘制轨道
        /// </summary>
        /// <param name="g"></param>
        private void DrawTrack(Graphics g)
        {
            if (TrackColor == Color.Transparent)
                return;
            GraphicsPath path = GetRoundRectangle(ClientRectangle, 5);
            using (SolidBrush sb = new SolidBrush(TrackColor))
            {
                g.FillPath(sb, path);
            }
        }

        /// <summary>  
        /// 根据普通矩形得到圆角矩形的路径  
        /// </summary>  
        /// <param name="rectangle">原始矩形</param>  
        /// <param name="r">半径</param>  
        /// <returns>图形路径</returns>  
        private static GraphicsPath GetRoundRectangle(Rectangle rectangle, int r)
        {
            int l = 2 * r;
            // 把圆角矩形分成八段直线、弧的组合，依次加到路径中  
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(rectangle.X + r, rectangle.Y), new Point(rectangle.Right - r, rectangle.Y));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Y, l, l), 270F, 90F);

            gp.AddLine(new Point(rectangle.Right, rectangle.Y + r), new Point(rectangle.Right, rectangle.Bottom - r));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Bottom - l, l, l), 0F, 90F);

            gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), new Point(rectangle.X + r, rectangle.Bottom));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Bottom - l, l, l), 90F, 90F);

            gp.AddLine(new Point(rectangle.X, rectangle.Bottom - r), new Point(rectangle.X, rectangle.Y + r));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Y, l, l), 180F, 90F);
            return gp;
        }
        /// <summary>
        /// 滚动时
        /// </summary>
        public event EventHandler<ScrollEventArgs> OnScrollEvent;
        public virtual void OnScrollHandler(ScrollEventArgs e)
        {
            OnScrollEvent?.Invoke(this, e);
        }
    }
}
