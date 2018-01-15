using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:16:55
    * 说明：
    * ==========================================================
    * */
    public class VScroll
    {
        /// <summary>
        /// 滚动时
        /// </summary>
        public event EventHandler<ScrollEventArgs> OnScrollEvent;
        public virtual void OnScrollHandler(ScrollEventArgs e)
        {
            OnScrollEvent?.Invoke(this, e);
        }

        private Control owner;


        private int width = 10;
        /// <summary>
        /// 获取滚动条宽
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height = 10;
        /// <summary>
        /// 滚动条高度
        /// </summary>
        public int Height
        {
            get { return height; }
        }
        /// <summary>
        /// 滚动条自身区域
        /// </summary>
        private Rectangle bounds;
        private bool visible = false;
        /// <summary>
        /// 是否显示滚动条
        /// </summary>
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        private Color backColor = Color.FromArgb(214, 219, 233);
        /// <summary>
        /// 设置滚动条背景色
        /// </summary>
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }
        private Color mouseMoveColor = Color.FromArgb(104, 104, 104);
        /// <summary>
        /// 鼠标移动到滚动条上的背景色
        /// </summary>
        public Color MouseMoveColor
        {
            get { return mouseMoveColor; }
            set { mouseMoveColor = value; }
        }

        //虚拟的一个高(控件中内容的高度)
        private int virtualHeight;
        public int VirtualHeight
        {
            get { return virtualHeight; }
            set
            {
                if (value <= owner.Height)
                {
                    if (visible == false)
                        return;
                    visible = false;
                    if (this.value != 0)
                    {
                        this.value = 0;
                        owner.Invalidate();
                    }
                }
                else
                {
                    visible = true;
                    if (value - this.value < owner.Height)
                    {
                        this.value -= owner.Height - value + this.value;
                        owner.Invalidate();
                    }
                }
                virtualHeight = value;
            }
        }
        //当前滚动条位置
        private int value = 0;
        public int Value
        {
            get { return value; }
            set
            {
                if (!visible)
                    return;
                if (value < 0)
                {
                    if (this.value == 0)
                        return;
                    this.value = 0;
                    owner.Invalidate();
                    return;
                }
                if (value > virtualHeight - owner.Height)
                {
                    if (this.value == virtualHeight - owner.Height)
                        return;
                    this.value = virtualHeight - owner.Height;
                    owner.Invalidate();
                    return;
                }
                this.value = value;
                owner.Invalidate();
                OnScrollHandler(new ScrollEventArgs(ScrollEventType.ThumbTrack, this.value));
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



        private Point m_ptMousePos;             //鼠标的位置


        public VScroll(Control owner)
        {
            this.owner = owner;
            owner.MouseMove += Owner_MouseMove;
            owner.MouseDown += Owner_MouseDown;
            owner.MouseUp += Owner_MouseUp;
            owner.MouseLeave += Owner_MouseLeave;
            owner.MouseWheel += Owner_MouseWheel;
            //owner.Click += Owner_Click;
            height = owner.Height;

            virtualHeight = this.owner.Height;
            int x = this.owner.Width - width;
            bounds = new Rectangle(x, 0, width, height);
        }

        private void Owner_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) Value -= 50;
            if (e.Delta < 0) Value += 50;
        }
        

        private void Owner_Click(object sender, EventArgs e)
        {
            if (visible)
            {
                //如果有滚动条 判断是否在滚动条类点击
                //如果左键在滚动条滑块上点击
                if (bounds.Contains(m_ptMousePos))
                {
                    MoveSliderToLocation(m_ptMousePos.Y);
                }
            }
        }

        private void Owner_MouseLeave(object sender, EventArgs e)
        {
            if (!visible)
                return;
            ClearAllMouseOn();
        }

        private void Owner_MouseUp(object sender, MouseEventArgs e)
        {
            if (!visible)
                return;
            if (e.Button == MouseButtons.Left)
            {
                IsMouseDown = false;
            }
        }

        private void Owner_MouseDown(object sender, MouseEventArgs e)
        {
            if (!visible)
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

        private void Owner_MouseMove(object sender, MouseEventArgs e)
        {
            if (!visible)
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

        //绘制滚动条
        public void ReDrawScroll(Graphics g)
        {
            if (!visible)
                return;
            bounds.X = this.owner.Width - width;
            bounds.Height = (int)(((double)owner.Height / virtualHeight) * owner.Height);
            bounds.Y = (int)(((double)value / (virtualHeight - owner.Height)) * (owner.Height - bounds.Height));
            if (isMouseOnSlider)
                FillRoundRectangle(g, bounds, mouseMoveColor, 4);
            else
                FillRoundRectangle(g, bounds, backColor, 4);

        }

        //滑块移动前的 滑块的Y坐标
        private int m_nLastSliderY;
        //鼠标在滑块点下时候的y坐标
        private int mouseDownY;
        //根据鼠标位置移动滑块


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


        public void ClearAllMouseOn()
        {
            if (!this.isMouseOnSlider)
                return;
            this.isMouseOnSlider = false;
            owner.Invalidate(this.bounds);
        }

        /// <summary>  
        /// C# GDI+ 绘制圆角实心矩形  
        /// </summary>  
        /// <param name="g">Graphics 对象</param>  
        /// <param name="rectangle">要填充的矩形</param>  
        /// <param name="backColor">填充背景色</param>  
        /// <param name="r">圆角半径</param>  
        public static void FillRoundRectangle(Graphics g, Rectangle rectangle, Color backColor, int r)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
            Brush b = new SolidBrush(backColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(b, GetRoundRectangle(rectangle, r));
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
    }
}
