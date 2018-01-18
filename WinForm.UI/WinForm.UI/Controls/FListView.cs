using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinForm.UI.Animations;
using WinForm.UI.Events;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:20:19
    * 说明：
    * ==========================================================
    * */
    [ComVisibleAttribute(true)]
    [ToolboxItem(true), DefaultProperty("BorderStyle"), DefaultEvent("ItemClick")]
    public class FListView : Control
    {
        /// <summary>
        /// 所有行的矩形
        /// </summary>
        private List<ViewHolder> Rows;
        private VScroll chatVScroll;    //滚动条
        private HScroll listHScroll;
        ///// <summary>
        ///// 鼠标位置
        ///// </summary>
        private Point m_ptMousePos;
        public ViewHolder MouseHolder { get; set; }
        /// <summary>
        /// 当前选中向
        /// </summary>
        public ViewHolder SelectHolder { get; set; }

        public FListView()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Selectable, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
            this.Size = new Size(150, 250);
            borderStyle = BorderStyle.FixedSingle;

            chatVScroll = new VScroll(this);
            listHScroll = new HScroll(this);
            chatVScroll.OnScrollEvent += ChatVScroll_OnScrollEvent;
            listHScroll.OnScrollEvent += ChatVScroll_OnScrollEvent;
            Rows = new List<ViewHolder>();
        }

        private void ChatVScroll_OnScrollEvent(object sender, ScrollEventArgs e)
        {
            OnScroll(e);
        }

        private int VirtualHeight, VirtualWidth = 0;

        #region 属性
        private BorderStyle borderStyle;
        /// <summary>
        /// 指示控件的边框样式
        /// </summary>
        [DefaultValue(typeof(BorderStyle), "1")]
        [Description("获取或设置控件的边框")]
        public BorderStyle BorderStyle
        {
            get { return borderStyle; }
            set
            {
                if (value == borderStyle) return;
                borderStyle = value;
                this.Invalidate();
            }
        }


        [Bindable(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        private int itemDivider = 0;
        [Category("Skin")]
        [Description("获取或设置当前控件Item向的间隔")]
        [DefaultValue(typeof(int), "0")]
        public int ItemDivider { get { return itemDivider; } set { if (itemDivider == value) return; itemDivider = value; this.Invalidate(); } }

        #region 滚动条
        /// <summary>
        /// 获取或者设置滚动条背景色
        /// </summary>
        [DefaultValue(typeof(Color), "214, 219, 233"), Category("Scroll")]
        [Description("滚动条的背景颜色")]
        public Color ScrollBackColor
        {
            get { return chatVScroll.BackColor; }
            set
            {
                chatVScroll.BackColor = value;
                listHScroll.BackColor = value;
            }
        }
        /// <summary>
        /// 获取或者设置滚动条鼠标以上颜色
        /// </summary>
        [DefaultValue(typeof(Color), "104, 104, 104"), Category("Scroll")]
        [Description("滚动条鼠标移上默认情况下的颜色")]
        public Color ScrollMouseMoveColor
        {
            get { return chatVScroll.MouseMoveColor; }
            set
            {
                chatVScroll.MouseMoveColor = value;
                listHScroll.MouseMoveColor = value;
            }
        }

        /// <summary>
        /// 获取或者设置横向滚动条高
        /// </summary>
        [DefaultValue(typeof(int), "10"), Category("Scroll")]
        [Description("获取或者设置横向滚动条高")]
        public int HScrollHeight
        {
            get { return listHScroll.Height; }
            set
            {
                listHScroll.Height = value;
            }
        }

        /// <summary>
        /// 获取或者设置纵向滚动条宽
        /// </summary>
        [DefaultValue(typeof(int), "10"), Category("Scroll")]
        [Description("获取或者设置纵向滚动条宽")]
        public int VScrollWidth
        {
            get { return chatVScroll.Width; }
            set
            {
                chatVScroll.Width = value;
            }
        }

        ///// <summary>
        ///// 获取或者设置滚动条滑块默认颜色
        ///// </summary>
        //[DefaultValue(typeof(Color), "Gray"), Category("ControlColor")]
        //[Description("滚动条滑块默认情况下的颜色")]
        //public Color ScrollSliderDefaultColor
        //{
        //    get { return chatVScroll.SliderDefaultColor; }
        //    set { chatVScroll.SliderDefaultColor = value; }
        //}


        #endregion

        #endregion


        private Adapter adapter;
        [Bindable(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Adapter Adapter
        {
            get { return adapter; }
            set
            {
                if (value == null)
                    return;
                adapter = value;
                adapter.Owner = this;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            VirtualHeight = 0;
            VirtualWidth = 0;
            Graphics g = e.Graphics;
            //绘制边框
            if (borderStyle == BorderStyle.FixedSingle)
            {
                Pen pen = new Pen(Color.FromArgb(100, 100, 100));
                Point[] point = new Point[4];
                point[0] = new Point(0, 0);
                point[1] = new Point(Width - 1, 0);
                point[2] = new Point(Width - 1, Height - 1);
                point[3] = new Point(0, Height - 1);
                g.DrawPolygon(pen, point);//
            }

            g.TranslateTransform(-listHScroll.Value, 0);        //根据滚动条的值设置坐标偏移
            g.TranslateTransform(0, -chatVScroll.Value);        //根据滚动条的值设置坐标偏移
            DrawColumn(g);
            g.ResetTransform();             //重置坐标系
            chatVScroll.VirtualHeight = VirtualHeight;   //绘制完成计算虚拟高度决定是否绘制滚动条
            if (chatVScroll.Visible)   //是否绘制滚动条
                chatVScroll.ReDrawScroll(g);

            listHScroll.VirtualWidth = VirtualWidth;
            if (listHScroll.Visible)
                listHScroll.ReDrawScroll(g);
        }

        #region 绘制行列
        /// <summary>
        /// 绘制行
        /// </summary>
        /// <param name="g"></param>
        private void DrawColumn(Graphics g)
        {
            if (adapter == null || adapter.GetCount() == 0)
                return;
            int y = 0;
            for (int i = 0; i < adapter.GetCount(); i++)
            {
                ViewHolder holder = null;
                if (Rows.Count > i)
                {
                    holder = Rows[i];
                }
                else
                {
                    Rectangle rect = new Rectangle(1, y, this.Width - 2, 50);
                    holder = new ViewHolder(rect);
                    holder.position = i;
                    Rows.Add(holder);
                }
                holder.isMouseClick = false;
                holder.isMouseMove = false;
                holder.MouseLocation = Point.Empty;
                if (SelectHolder == holder)
                {
                    holder.isMouseClick = true;
                    holder.MouseLocation = SelectHolder.MouseLocation;
                }
                else if (MouseHolder == holder)
                    holder.isMouseMove = true;

                adapter.GetView(i, holder, g);
                y += holder.bounds.Height+ itemDivider;
                VirtualWidth = holder.bounds.Width;
            }
            VirtualHeight = y;
            if (listHScroll.Visible)
                VirtualHeight += listHScroll.Height;
        }

        #endregion

        protected override void OnMouseMove(MouseEventArgs e)
        {
            m_ptMousePos = e.Location;
            m_ptMousePos.Y += chatVScroll.Value;
            //判断鼠标是否在行中
            foreach (ViewHolder item in Rows)
            {
                if (item.bounds.Contains(m_ptMousePos))
                {
                    if (item == MouseHolder)
                        break;
                    MouseHolder = item;
                    this.Invalidate();
                    break;
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseHolder = null;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            
            base.OnMouseClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            foreach (ViewHolder item in Rows)
            {
                if (item.bounds.Contains(m_ptMousePos))
                {
                    if (item == SelectHolder)
                        break;
                    SelectHolder = item;
                    SelectHolder.MouseLocation = e.Location;
                    this.Invalidate();
                    OnItemClick(new ItemClickEventArgs(item));
                    break;
                }
            }
            base.OnMouseDown(e);
        }
        /// <summary>
        /// 滚动到底部
        /// </summary>
        public void ScrollBottom(int time=50)
        {
            new Thread(()=> {
                Thread.Sleep(time);//停止50毫秒 否则 如果在add之后执行这无法显示最后一条
                chatVScroll.Value = chatVScroll.VirtualHeight - this.Height - 5;
            }).Start();
            
        }



        public delegate void ScrollHandler(object sender, ScrollEventArgs e);
        /// <summary>
        /// 滚动时
        /// </summary>
        public event ScrollHandler Scroll;
        public virtual void OnScroll(ScrollEventArgs e)
        {
            Scroll?.Invoke(this, e);
        }


        public delegate void ItemClickHandler(object sender, ItemClickEventArgs e);
        public event ItemClickHandler ItemClick;
        public virtual void OnItemClick(ItemClickEventArgs e)
        {
            ItemClick?.Invoke(this, e);
        }
    }
}
