using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI.Extension;

namespace WinForm.UI.Controls
{
    [ComVisibleAttribute(true)]
    [ToolboxItem(true), DefaultProperty("TableColumns"), DefaultEvent("SelectionChange")]
    public class Table : BorderPanel
    {
        #region Constants
        private static readonly object _eventColumnDragChanged = new object();
        private static readonly object _eventRowDragChanged = new object();
        private static readonly object _eventSortClick = new object();
        private static readonly object _eventSelectionChanged = new object();
        private static readonly object _eventScrollChanged = new object();
        #endregion

        #region Fields
        private int VirtualHeight = 0;
        private int VirtualWidth = 0;
        private VScroll _vScroll;    //滚动条
        private HScroll _hScroll;    //滚动条
        private bool _MouseVisible;
        private TableColumnCollection _tableColumns;
        private int columnHeight = 40;
        private int rowHeight = 40;
        private IList dataSource;
        private List<RectangleF> _rows;
        private Point m_MouseDownPos;//鼠标按下的位置
        private Point m_MouseMovePos;
        private Bitmap m_MousePreview;//当前鼠标拖动的预览图
        private RectangleF m_Prepare;//保存预备插入的位置
        private int m_BeforeDragPos = -1;//拖放前的位置
        private int m_AfterDragPos = -1;//拖放后的位置
        private int m_DragColumnPos = -1;//调整列宽，选中的位置
        private int m_DragRowOrColumn = -1;//拖放行或列，0=行 1=列
        private PointF m_MouseDownOffset;
        private bool m_AllowUserToOrderColumns;
        private bool m_AllowUserToOrderRows;
        private bool m_AllowUserToResizeColumns;
        private int m_SelectionIndex = -1;
        private int m_MouseMoveIndex = -1;
        private MouseIntent m_MouseIntent = MouseIntent.None;
        #endregion

        #region Constructors
        public Table()
        {
            _vScroll = new VScroll(this);
            _vScroll.BackColor = ColorStyles.ScrollBackColor;
            _vScroll.MouseMoveColor = ColorStyles.ScrollMouseMoveColor;
            _vScroll.OnScrollEvent += new EventHandler<ScrollEventArgs>(VScroll_OnScrollEvent);

            _hScroll = new HScroll(this);
            _hScroll.BackColor = ColorStyles.ScrollBackColor;
            _hScroll.MouseMoveColor = ColorStyles.ScrollMouseMoveColor;
            _hScroll.OnScrollEvent += new EventHandler<ScrollEventArgs>(VScroll_OnScrollEvent);

            _tableColumns = new TableColumnCollection(this);
            _rows = new List<RectangleF>();
        }
        #endregion

        #region Properties
        #region 滚动条
        /// <summary>
        /// 获取或者设置滚动条背景色
        /// </summary>
        [DefaultValue(typeof(Color), "104, 104, 104"), Category("Scroll")]
        [Description("滚动条的背景颜色")]
        public Color ScrollBackColor
        {
            get { return _vScroll.BackColor; }
            set
            {
                _vScroll.BackColor = value;
                _hScroll.BackColor = value;
            }
        }
        /// <summary>
        /// 获取或者设置滚动条鼠标移入颜色
        /// </summary>
        [DefaultValue(typeof(Color), "214, 219, 233"), Category("Scroll")]
        [Description("滚动条鼠标移上默认情况下的颜色")]
        public Color ScrollMouseMoveColor
        {
            get { return _vScroll.MouseMoveColor; }
            set
            {
                _vScroll.MouseMoveColor = value;
                _hScroll.MouseMoveColor = value;
            }
        }


        /// <summary>
        /// 获取或者设置纵向滚动条宽
        /// </summary>
        [DefaultValue(typeof(int), "10"), Category("Scroll")]
        [Description("获取或者设置纵向滚动条宽")]
        public int VScrollWidth
        {
            get { return _vScroll.Width; }
            set
            {
                _vScroll.Width = value;
            }
        }
        [DefaultValue(typeof(int), "10"), Category("Scroll")]
        [Description("获取或者设置横向滚动条高")]
        public int HScrollHeight
        {
            get { return _hScroll.Height; }
            set
            {
                _hScroll.Height = value;
            }
        }

        #endregion

        [Bindable(false), Browsable(false)]
        private int MouseMoveIndex { get { return m_MouseMoveIndex; } set { if (m_MouseMoveIndex == value) return; m_MouseMoveIndex = value; this.Invalidate(); } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [MergableProperty(false)]
        [Description("获取或设置标题栏集合"), Category("Header")]
        public TableColumnCollection TableColumns
        {
            get { return _tableColumns; }
        }

        [DefaultValue(40)]
        [Description("获取或设置标题栏高"), Category("Header")]
        public int ColumnHeight
        {
            get { return columnHeight; }
            set { columnHeight = value; }
        }
        [DefaultValue(40)]
        [Description("获取或设置表格的行高")]
        public int RowHeight
        {
            get { return rowHeight; }
            set { if (rowHeight == value) return; rowHeight = value; this.Invalidate(); }
        }
        [DefaultValue(false)]
        [Description("获取或设置是否允许拖动调整列的位置")]
        public bool AllowUserToOrderColumns
        {
            get { return m_AllowUserToOrderColumns; }
            set { if (m_AllowUserToOrderColumns == value) return; m_AllowUserToOrderColumns = value; }
        }
        [DefaultValue(false)]
        [Description("获取或设置是否允许拖动调整行的位置")]
        public bool AllowUserToOrderRows
        {
            get { return m_AllowUserToOrderRows; }
            set { if (m_AllowUserToOrderRows == value) return; m_AllowUserToOrderRows = value; }
        }

        [DefaultValue(false)]
        [Description("获取或设置是否允许调整列的大小")]
        public bool AllowUserToResizeColumns
        {
            get { return m_AllowUserToResizeColumns; }
            set { if (m_AllowUserToResizeColumns == value) return; m_AllowUserToResizeColumns = value; }
        }

        [Bindable(false), Browsable(false)]
        public int SelectionIndex
        {
            get { return m_SelectionIndex; }
            set { if (m_SelectionIndex == value) return; m_SelectionIndex = value; this.Invalidate(); }
        }
        [Description("获取或设置选中行的背景色")]
        public Color SelectionColor { get; set; } = Color.FromArgb(50, Color.White);
        [Description("获取或设置鼠标移到行中的背景色")]
        public Color MouseMoveColor { get; set; } = Color.FromArgb(60, Color.Black);

        [Bindable(false), Browsable(false)]
        public IList DataSource
        {
            get { return dataSource; }
            set { dataSource = value; this.Invalidate(); }
        }

        #endregion

        #region Events
        [Category("Action"), Description("当用户拖动调整列的位置时发生")]
        public event EventHandler ColumnDragChanged
        {
            add { this.Events.AddHandler(_eventColumnDragChanged, value); }
            remove { this.Events.RemoveHandler(_eventColumnDragChanged, value); }
        }
        [Category("Action"), Description("当用户拖动调整行的位置时发生")]
        public event EventHandler RowDragChanged
        {
            add { this.Events.AddHandler(_eventRowDragChanged, value); }
            remove { this.Events.RemoveHandler(_eventRowDragChanged, value); }
        }
        [Category("Action"), Description("当用户点击标题触发排序时发生")]
        public event EventHandler<TableColumnSortEventArgs> SortClick
        {
            add { this.Events.AddHandler(_eventSortClick, value); }
            remove { this.Events.RemoveHandler(_eventSortClick, value); }
        }
        [Category("Action"), Description("当用户选中某行时发生")]
        public event EventHandler<SelectionChangeEventArgs> SelectionChanged
        {
            add { this.Events.AddHandler(_eventSelectionChanged, value); }
            remove { this.Events.RemoveHandler(_eventSelectionChanged, value); }
        }
        [Category("Action"), Description("当控件的滚动条发生更改时")]
        public event EventHandler<ScrollEventArgs> ScrollChanged
        {
            add { this.Events.AddHandler(_eventScrollChanged, value); }
            remove { this.Events.RemoveHandler(_eventScrollChanged, value); }
        }
        protected virtual void OnColumnDragChanged(EventArgs e)
        {
            EventHandler handler;
            handler = (EventHandler)this.Events[_eventColumnDragChanged];
            handler?.Invoke(this, e);
        }
        protected virtual void OnRowDragChanged(EventArgs e)
        {
            EventHandler handler;
            handler = (EventHandler)this.Events[_eventRowDragChanged];
            handler?.Invoke(this, e);
        }
        protected virtual void OnSortClick(TableColumnSortEventArgs e)
        {
            EventHandler<TableColumnSortEventArgs> handler;
            handler = (EventHandler<TableColumnSortEventArgs>)this.Events[_eventSortClick];
            handler?.Invoke(this, e);
        }
        protected virtual void OnSelectionChanged(SelectionChangeEventArgs e)
        {
            EventHandler<SelectionChangeEventArgs> handler;
            handler = (EventHandler<SelectionChangeEventArgs>)this.Events[_eventSelectionChanged];
            handler?.Invoke(this, e);
        }
        protected virtual void OnScrollChanged(ScrollEventArgs e)
        {
            EventHandler<ScrollEventArgs> handler;
            handler = (EventHandler<ScrollEventArgs>)this.Events[_eventScrollChanged];
            handler?.Invoke(this, e);
        }
        #endregion

        #region Methods
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ResetColumns();
        }

        #region Draw
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            VirtualHeight = 0;

            _rows.Clear();

            e.Graphics.TranslateTransform(-_hScroll.Value, 0);        //根据滚动条的值设置坐标偏移

            DrawColumn(e.Graphics);

            e.Graphics.TranslateTransform(0, -_vScroll.Value);        //根据滚动条的值设置坐标偏移



            if (DataSource != null)
            {
                e.Graphics.TranslateClip(0, ColumnHeight);//平移 绕过 标题

                using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
                {
                    Pen pen = new Pen(BorderColor);
                    string value = string.Empty;
                    float y = ColumnHeight;
                    VirtualHeight = ColumnHeight;
                    int i = 0;
                    foreach (var item in DataSource)
                    {
                        DrawRow(e.Graphics, solidBrush, pen, y, item);
                        RectangleF rectangle = new RectangleF(0, y, (this.Width > VirtualWidth) ? VirtualWidth : this.VirtualWidth, RowHeight);
                        _rows.Add(rectangle);

                        y += RowHeight;
                        e.Graphics.DrawLine(pen, 0, y, (this.Width > VirtualWidth) ? VirtualWidth : this.VirtualWidth, y);
                        VirtualHeight += RowHeight;

                        if (SelectionIndex == i)
                        {
                            solidBrush.Color = SelectionColor;
                            e.Graphics.FillRectangle(solidBrush, rectangle);
                        }
                        else if (m_MouseMoveIndex == i)
                        {
                            solidBrush.Color = MouseMoveColor;
                            e.Graphics.FillRectangle(solidBrush, rectangle);
                        }
                        i++;
                    }
                }
                e.Graphics.TranslateClip(0, -ColumnHeight);
            }

            if (m_DragRowOrColumn == 0)
            {
                if (m_MousePreview != null)
                {
                    e.Graphics.DrawImage(m_MousePreview, m_MouseMovePos.X - m_MouseDownOffset.X, m_MouseMovePos.Y - m_MouseDownOffset.Y);
                }
                //绘制预插入的位置
                if (!m_Prepare.IsEmpty)
                {
                    e.Graphics.DrawRectangle(Pens.Black, m_Prepare.X - 0.5f, m_Prepare.Y, m_Prepare.Width + 0.5f, m_Prepare.Height);
                    e.Graphics.FillRectangle(Brushes.White, m_Prepare);
                }
            }
            e.Graphics.ResetTransform();             //重置坐标系

            _vScroll.VirtualHeight = VirtualHeight;   //绘制完成计算虚拟高度决定是否绘制滚动条
            if (_MouseVisible && _vScroll.Visible)   //是否绘制滚动条
                _vScroll.ReDrawScroll(e.Graphics);

            _hScroll.VirtualWidth = VirtualWidth;
            if (_MouseVisible && _hScroll.Visible)
                _hScroll.ReDrawScroll(e.Graphics);


            if (m_DragRowOrColumn == 1)
            {
                if (m_MousePreview != null)
                {
                    e.Graphics.DrawImage(m_MousePreview, m_MouseMovePos.X - m_MouseDownOffset.X, m_MouseMovePos.Y - m_MouseDownOffset.Y);
                }
                //绘制预插入的位置
                if (!m_Prepare.IsEmpty)
                {
                    e.Graphics.DrawRectangle(Pens.Black, m_Prepare.X - 0.5f, m_Prepare.Y, m_Prepare.Width + 0.5f, m_Prepare.Height);
                    e.Graphics.FillRectangle(Brushes.White, m_Prepare);
                }
            }
        }


        protected virtual void DrawColumn(Graphics g)
        {
            using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
            {
                Pen pen = new Pen(BorderColor);
                foreach (var item in TableColumns)
                {
                    item.Draw(g, solidBrush, item.Bounds);
                    //g.DrawNoPaddingStringMiddleCenter(item.Text, item.Font, solidBrush, item.Bounds);
                    g.DrawLine(pen, item.Bounds.X, 0, item.Bounds.X, item.Bounds.Height);
                }
                g.DrawLine(pen, 0, ColumnHeight, (this.Width > VirtualWidth) ? VirtualWidth : this.VirtualWidth, ColumnHeight);
            }
        }

        protected virtual void DrawRow(Graphics g, SolidBrush solidBrush, Pen pen, float y, object DataBind)
        {
            foreach (var column in TableColumns)
            {
                RectangleF rectangle = new RectangleF(column.Bounds.X, y, column.Bounds.Width, RowHeight);
                solidBrush.Color = column.ForeColor;
                string value = GetDataBindValue(column, DataBind);
                g.DrawNoPaddingStringMiddleCenter(value, column.Font, solidBrush, rectangle);
                g.DrawLine(pen, rectangle.X, rectangle.Y, rectangle.X, rectangle.Bottom);
            }
        }
        #endregion

        #region BindData
        protected virtual string GetDataBindValue(TableColumn tableColumn, object DataBind)
        {
            if (string.IsNullOrEmpty(tableColumn.BindingData) || DataBind == null)
                return string.Empty;
            string bind = tableColumn.BindingData;
            string value = GetDataPropertyValue(DataBind, bind);
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(tableColumn.Format))
            {
                switch (tableColumn.DataType)
                {
                    case Emuns.DataType.String:
                        value = string.Format(tableColumn.Format, value);
                        break;
                    case Emuns.DataType.DateTime:
                        if (DateTime.TryParse(value, out DateTime temp))
                        {
                            value = temp.ToString(tableColumn.Format);
                        }
                        break;
                    case Emuns.DataType.Decimal:
                        if (decimal.TryParse(value, out decimal temp1))
                        {
                            value = temp1.ToString(tableColumn.Format);
                        }
                        break;
                    default:
                        break;
                }
            }
            return value;
        }

        private string GetDataPropertyValue(object t, string PropertyName)
        {
            if (string.IsNullOrEmpty(PropertyName))
                return string.Empty;
            Type type = t.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            PropertyInfo property = propertyInfos.FirstOrDefault(n => n.Name.ToUpper() == PropertyName.ToUpper());
            if (property == null)
                return string.Empty;
            return property.GetValue(t) == null ? string.Empty : property.GetValue(t).ToString();
        }
        #endregion

        private void VScroll_OnScrollEvent(object sender, ScrollEventArgs e)
        {
            OnScrollChanged(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResetColumns();
        }

        internal void ResetColumns()
        {
            float x = 0;
            float w = 0;
            //float t = 0;
            //foreach (var item in TableColumns)
            //{
            //    if (item.Width > 0)
            //    {
            //        t += item.Width;
            //    }
            //}
            foreach (var item in TableColumns)
            {
                if (item.Width > 0)
                {
                    w = item.Width;
                }
                else
                {
                    w = this.Width * (item.Weight / 100);
                }
                //w = this.Width * (item.Weight / 100);
                item.Bounds = new RectangleF(x, 0, w, ColumnHeight);
                x += w;
            }
            VirtualWidth = (int)x;
        }


        #region mouse
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _MouseVisible = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _MouseVisible = false;
            m_MouseMoveIndex = -1;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (DesignMode)
                return;
            m_MouseDownPos = e.Location;
            m_MouseDownPos.X += _hScroll.Value;
            m_MouseDownPos.Y += _vScroll.Value;

            if (_vScroll.IsMouseDown)
                return;
            if (_hScroll.IsMouseDown)
                return;

            if (e.Button == MouseButtons.Left)
            {
                int i = 0;
                if (m_DragColumnPos > 0)
                {
                    m_DragRowOrColumn = 2;
                    return;
                }

                if (AllowUserToOrderColumns)
                {
                    i = 0;
                    foreach (var item in TableColumns)
                    {
                        if (item.Bounds.Contains(e.Location))
                        {
                            m_DragRowOrColumn = 1;
                            m_MousePreview?.Dispose();
                            m_MousePreview = new Bitmap((int)item.Bounds.Width, (int)item.Bounds.Height);
                            using (Graphics g = Graphics.FromImage(m_MousePreview))
                            {
                                g.Clear(Color.FromArgb(60, Color.White));
                                using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
                                    item.Draw(g, solidBrush, new RectangleF(0, 0, item.Bounds.Width, item.Bounds.Height));
                            }
                            m_BeforeDragPos = i;
                            m_MouseDownOffset = new PointF(m_MouseDownPos.X - item.Bounds.X, m_MouseDownPos.Y - item.Bounds.Y);
                            m_MouseIntent = MouseIntent.MouseDown;
                            return;
                        }
                        i++;
                    }
                }
                //处理行拖放
                i = 0;
                if (AllowUserToOrderRows)
                {
                    foreach (var item in _rows)
                    {
                        if (item.Contains(m_MouseDownPos))
                        {
                            m_DragRowOrColumn = 0;
                            m_MousePreview?.Dispose();
                            m_MousePreview = new Bitmap((int)item.Width, (int)item.Height);
                            using (Graphics g = Graphics.FromImage(m_MousePreview))
                            {
                                g.Clear(Color.FromArgb(60, Color.White));
                                using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
                                {
                                    Pen pen = new Pen(BorderColor);
                                    DrawRow(g, solidBrush, pen, 0, DataSource[i]);
                                }
                            }
                            m_BeforeDragPos = i;
                            m_MouseDownOffset = new PointF(m_MouseDownPos.X - item.X, m_MouseDownPos.Y - item.Y);
                            m_MouseIntent = MouseIntent.MouseDown;
                            return;
                        }
                        i++;
                    }
                }

            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (DesignMode)
                return;
            m_MouseMovePos = e.Location;
            m_MouseMovePos.X += _hScroll.Value;
            m_MouseMovePos.Y+= _vScroll.Value;

            if (_vScroll.IsMouseDown)
                return;
            if (_hScroll.IsMouseDown)
                return;

            int i = 0;

            if (AllowUserToResizeColumns && m_DragRowOrColumn != 2)//调整列宽
            {
                foreach (var item in TableColumns)
                {
                    RectangleF temp = new RectangleF(item.Bounds.Right - 2, 0, 4, item.Bounds.Height);
                    if (temp.Contains(e.Location))
                    {
                        this.Cursor = Cursors.SizeWE;
                        m_DragColumnPos = i;
                        m_MouseIntent = MouseIntent.PressMove;
                        return;
                    }
                    i++;
                }
                m_DragColumnPos = -1;
                this.Cursor = Cursors.Default;
            }
            //this.Cursor = Cursors.Default;
            i = 0;
            int t = -1;
            foreach (var item in _rows)
            {
                if (item.Contains(m_MouseMovePos))
                {
                    t = i;
                    break;
                }
                i++;
            }

            if (e.Button == MouseButtons.Left && m_DragRowOrColumn > -1)
            {
                i = 0;
                if (m_DragRowOrColumn == 1)
                {
                    foreach (var item in TableColumns)
                    {
                        if (item.Bounds.Contains(e.Location))
                        {
                            m_Prepare = new RectangleF(item.Bounds.Location, new SizeF(2, item.Bounds.Height));
                            m_AfterDragPos = i;
                            m_MouseIntent = MouseIntent.PressMove;
                            this.Invalidate();
                            return;
                        }
                        i++;
                    }
                }
                else if (m_DragRowOrColumn == 0)
                {
                    //处理行拖放
                    if (t > -1)
                    {
                        m_Prepare = new RectangleF(_rows[t].Location, new SizeF(100, 2));
                        //m_Prepare = new RectangleF(m_MouseMovePos, new SizeF(100, 2));
                        m_AfterDragPos = t;
                        m_MouseIntent = MouseIntent.PressMove;
                        this.Invalidate();
                        return;
                    }
                }
                else if (m_DragRowOrColumn == 2)
                {
                    float w = m_MouseMovePos.X - m_MouseDownPos.X;
                    if (w == 0)
                        return;
                    TableColumns[m_DragColumnPos].Width = (int)(TableColumns[m_DragColumnPos].Bounds.Width + w);
                    this.ResetColumns();
                    this.Invalidate();
                    m_MouseDownPos = m_MouseMovePos;
                    m_MouseIntent = MouseIntent.PressMove;
                    return;
                    //Console.WriteLine(m_DragColumnPos);
                }
                //this.Invalidate();
            }
            MouseMoveIndex = t;
            //if (m_MouseMoveIndex > -1)
            //this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (DesignMode)
                return;

            if (_vScroll.IsMouseDown)
                return;
            if (m_DragRowOrColumn > -1 && m_AfterDragPos != m_BeforeDragPos && m_AfterDragPos > -1 && m_BeforeDragPos > -1)
            {
                //切换位置
                if (m_DragRowOrColumn == 1)
                {
                    TableColumns.Transposition(m_BeforeDragPos, m_AfterDragPos);
                    ResetColumns();
                    OnColumnDragChanged(EventArgs.Empty);
                    m_MouseIntent = MouseIntent.None;
                }
                else
                {
                    m_SelectionIndex = -1;
                    object temp = dataSource[m_BeforeDragPos];
                    dataSource.Remove(temp);
                    dataSource.Insert(m_AfterDragPos, temp);
                    OnRowDragChanged(EventArgs.Empty);
                    m_MouseIntent = MouseIntent.None;
                }
            }

            int tempIndex = m_BeforeDragPos;
            int tempDrag = m_DragRowOrColumn;
            MouseIntent tempIntent = m_MouseIntent;

            m_MouseIntent = MouseIntent.None;
            m_DragRowOrColumn = -1;
            m_DragColumnPos = -1;
            m_AfterDragPos = -1;
            m_BeforeDragPos = -1;
            m_Prepare = Rectangle.Empty;
            m_MouseDownOffset = PointF.Empty;
            this.Cursor = Cursors.Default;
            if (m_MousePreview != null)
            {
                m_MousePreview.Dispose();
                m_MousePreview = null;
                this.Invalidate();
            }


            switch (tempIntent)
            {
                case MouseIntent.None://判断按下位置
                    HandleEvent(e);
                    break;
                case MouseIntent.MouseDown://按下触发 点击事件
                    //判断按下位置为行/标题
                    if (tempDrag == 1 && tempIndex > -1)
                    {
                        //按下位置为 标题行
                        TableColumn item = TableColumns[tempIndex];
                        if (!item.SortColumn)
                            return;
                        item.Desc = !item.Desc;
                        OnSortClick(new TableColumnSortEventArgs(item));
                    }
                    else
                    {
                        SelectionIndex = tempIndex;
                        OnSelectionChanged(new SelectionChangeEventArgs(tempIndex));
                    }
                    break;
                case MouseIntent.PressMove:
                    break;
                default:
                    break;
            }
        }

        //protected override void OnMouseClick(MouseEventArgs e)
        //{
        //    base.OnMouseClick(e);
        //    if (_vScroll.IsMouseDown)
        //        return;
        //    if (_hScroll.IsMouseDown)
        //        return;

        //    if (e.Button == MouseButtons.Left && m_AfterDragPos == -1 && m_DragColumnPos == -1)
        //    {
        //        foreach (var item in TableColumns)
        //        {
        //            if (item.Bounds.Contains(e.Location))
        //            {
        //                if (!item.SortColumn)
        //                    return;
        //                item.Desc = !item.Desc;
        //                this.Invalidate(Rectangle.Round(item.Bounds));
        //                OnSortClick(new TableColumnSortEventArgs(item));
        //                return;
        //            }
        //        }
        //        //OnSelectionChange
        //        int i = 0;
        //        foreach (var item in _rows)
        //        {
        //            if (item.Contains(m_MouseDownPos))
        //            {
        //                SelectionIndex = i;
        //                OnSelectionChanged(new SelectionChangeEventArgs(SelectionIndex));
        //                break;
        //            }
        //            i++;
        //        }
        //    }

        //}


        private void HandleEvent(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && m_AfterDragPos == -1 && m_DragColumnPos == -1)
            {
                foreach (var item in TableColumns)
                {
                    if (item.Bounds.Contains(e.Location))
                    {
                        if (!item.SortColumn)
                            return;
                        item.Desc = !item.Desc;
                        this.Invalidate(Rectangle.Round(item.Bounds));
                        OnSortClick(new TableColumnSortEventArgs(item));
                        return;
                    }
                }
                //OnSelectionChange
                int i = 0;
                foreach (var item in _rows)
                {
                    if (item.Contains(m_MouseDownPos))
                    {
                        SelectionIndex = i;
                        OnSelectionChanged(new SelectionChangeEventArgs(SelectionIndex));
                        break;
                    }
                    i++;
                }
            }
        }

        #endregion


        #endregion

        #region Public Methods
        /// <summary>
        /// 当数据源更改时，调用此方法使其重新绘制
        /// </summary>
        public void NotifyDataSetChanged()
        {
            this.Invalidate();
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_MousePreview?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class TableColumnSortEventArgs : EventArgs
    {
        public TableColumnSortEventArgs(TableColumn TableColumn)
        {
            this.TableColumn = TableColumn;
        }

        public TableColumn TableColumn { get; private set; }
    }
    public class SelectionChangeEventArgs : EventArgs
    {
        public SelectionChangeEventArgs(int position)
        {
            this.RowIndex = position;
        }

        public int RowIndex { get; private set; }
    }

    public enum MouseIntent
    {
        None,
        MouseDown,//按下
        PressMove //按下并移动
    }

}
