using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Events;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:13:03
    * 说明：
    * ==========================================================
    * */
    [ComVisibleAttribute(true)]
    [ToolboxItem(true), DefaultProperty("Columns"), DefaultEvent("ItemClick")]
    public class FTable : Control
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
        private ViewHolder m_mouseHolder;
        /// <summary>
        /// 当前选中项
        /// </summary>
        private ViewHolder selectHolder;

        public FTable()
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

        private TableColumnHeaderCollection columns;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [MergableProperty(false)]
        [Description("获取或设置标题栏集合"), Category("Header")]
        public TableColumnHeaderCollection Columns
        {
            get
            {
                if (columns == null)
                    columns = new TableColumnHeaderCollection(this);
                return columns;
            }
        }

        private int headerHeight = 40;
        [DefaultValue(typeof(BorderStyle), "40")]
        [Description("获取或设置标题栏高"), Category("Header")]
        public int HeaderHeight
        {
            get { return headerHeight; }
            set { headerHeight = value; }
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



        private int columnHeight = 40;
        [DefaultValue(typeof(int), "40")]
        [Description("获取或设置表格列高")]
        public int ColumnHeight
        {
            get { return columnHeight; }
            set { if (columnHeight == value) return; columnHeight = value; this.Invalidate(); }
        }

        private CellBorderStyle cellBorderStyle = CellBorderStyle.FixedSingle;
        [DefaultValue(typeof(BorderStyle), "1")]
        [Description("获取或设置单元格边框样式")]
        public CellBorderStyle CellBorderStyle
        {
            get { return cellBorderStyle; }
            set { cellBorderStyle = value; }
        }

        private Color columnHeaderColor = Color.FromArgb(246, 246, 246);
        [DefaultValue(typeof(Color), "246, 246, 246"), Category("Header")]
        [Description("获取或设置标题栏背景色")]
        public Color ColumnHeaderColor
        {
            get { return columnHeaderColor; }
            set { if (columnHeaderColor == value) return; columnHeaderColor = value; this.Invalidate(); }
        }

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
            DrawColumnHeaders(g);
            g.TranslateTransform(0, -chatVScroll.Value);        //根据滚动条的值设置坐标偏移
            //Console.WriteLine(chatVScroll.Value);
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
            //Rows.Clear();
            g.TranslateClip(0, columnHeight);//平移 绕过 标题
            int y = headerHeight;
            for (int i = 0; i < adapter.GetCount(); i++)
            {
                ViewHolder holder = null;
                if (Rows.Count > i)
                {
                    holder = Rows[i];
                }
                else
                {
                    Rectangle rect = new Rectangle(1, y, VirtualWidth, columnHeight);
                    holder = new ViewHolder(rect);
                    holder.position = i;
                    Rows.Add(holder);
                }
                holder.isMouseClick = false;
                holder.isMouseMove = false;
                if (selectHolder == holder)
                    holder.isMouseClick = true;
                else if (m_mouseHolder == holder)
                    holder.isMouseMove = true;

                adapter.GetView(i, holder, g);
                y += columnHeight;
            }
            g.TranslateClip(0, -columnHeight);
            VirtualHeight = y;
            if (listHScroll.Visible)
                VirtualHeight += listHScroll.Height;
        }


        /// <summary>
        /// 绘制标题
        /// </summary>
        /// <param name="g"></param>
        private void DrawColumnHeaders(Graphics g)
        {
            if (columns == null)
                return;

            g.FillRectangle(new SolidBrush(columnHeaderColor), 1, 1, this.Width - 2, headerHeight);
            int x = 0;
            StringFormat StringFormat = StringFormat.GenericDefault;
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
            Pen p = new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)), 1);
            switch (cellBorderStyle)
            {
                case CellBorderStyle.None:
                    break;
                case CellBorderStyle.FixedSingle:
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                case CellBorderStyle.Dot:
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    break;
                default:
                    break;
            }
            foreach (TableColumn item in columns)
            {
                if (!item.Visible)
                    continue;
                SolidBrush sb = new SolidBrush(this.ForeColor);
                Rectangle rect = new Rectangle(x, 1, item.Width, headerHeight);
                switch (item.TextAlign)
                {
                    case HorizontalAlignment.Left:
                        StringFormat.Alignment = StringAlignment.Far;
                        break;
                    case HorizontalAlignment.Right:
                        StringFormat.Alignment = StringAlignment.Near;
                        break;
                }
                g.DrawString(item.Text, this.Font, sb, rect, StringFormat);
                item.Location = rect.Location;
                x += item.Width;

                if (cellBorderStyle != CellBorderStyle.None)
                    g.DrawLine(p, x, 0, x, headerHeight);
            }
            VirtualWidth = x;
            if (chatVScroll.Visible)
                VirtualWidth += chatVScroll.Width;
            //if (cellBorderStyle != CellBorderStyle.None)
            g.DrawLine(p, 1, headerHeight, VirtualWidth, headerHeight);

        }
        #endregion

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (chatVScroll.IsMouseOnSlider || listHScroll.IsMouseOnSlider)
                return;

            m_ptMousePos = e.Location;
            m_ptMousePos.Y += chatVScroll.Value;
            //判断鼠标是否在行中
            foreach (ViewHolder item in Rows)
            {
                if (item.bounds.Contains(m_ptMousePos))
                {
                    if (item == m_mouseHolder)
                        break;
                    m_mouseHolder = item;
                    this.Invalidate();
                    break;
                }
            }
           
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (chatVScroll.IsMouseOnSlider|| listHScroll.IsMouseOnSlider)
                return;
            foreach (ViewHolder item in Rows)
            {
                if (item.bounds.Contains(m_ptMousePos))
                {
                    if (item.CellBounds.Count > 0)
                    {
                        int ce = 0;
                        foreach (var cellBound in item.CellBounds)
                        {
                            if (cellBound.Contains(m_ptMousePos))
                                OnCellClick(new CellClickEventArgs(item, ce));
                            ce++;
                        }
                    }

                    if (item == selectHolder)
                        break;
                    selectHolder = item;
                    this.Invalidate();
                    OnItemClick(new ItemClickEventArgs(item));
                    break;
                }
            }
           
        }

        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);
        //    chatVScroll.Visible = true;
        //    listHScroll.Visible = true;
        //}
        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    chatVScroll.Visible = false;
        //    listHScroll.Visible = false;
        //}
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
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

        public delegate void CellClickHandler(object sender, CellClickEventArgs e);
        public event CellClickHandler CellClick;
        public virtual void OnCellClick(CellClickEventArgs e)
        {
            CellClick?.Invoke(this, e);
        }
    }
}
