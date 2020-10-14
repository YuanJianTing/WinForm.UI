using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI.Properties;

namespace WinForm.UI.Controls
{
    [ComVisibleAttribute(true)]
    [ToolboxItem(true), DefaultProperty("Nodes"), DefaultEvent("SelectedChanged")]
    public class TreeView : BorderPanel
    {
        #region Constants
        private static readonly object _eventSelectedChanged = new object();
        #endregion

        #region Fields
        private TreeNodeCollection nodes;
        private Bitmap ImageOpenIcon;
        private Bitmap ImageCloseIcon;
        private int indent = 25;//缩进距离
        private int rowHeight = 25;
        private int VirtualHeight = 0;
        private VScroll _vScroll;    //滚动条
        private bool MouseVisible = false;
        private Point m_ptMousePos;
        private int draw_y = 0;

        private TreeNodeItem _selectedNode;
        private ImageList _imageList;
        #endregion

        #region Constructors
        public TreeView()
        {
            ImageOpenIcon = Resources.ImageOpenIcon;
            ImageCloseIcon = Resources.ImageTreeCloseIcon;

            _vScroll = new VScroll(this);
            _vScroll.BackColor = ColorStyles.ScrollBackColor;
            _vScroll.MouseMoveColor = ColorStyles.ScrollMouseMoveColor;
            _vScroll.OnScrollEvent += new EventHandler<ScrollEventArgs>(VScroll_OnScrollEvent);
        }
        #endregion

        #region Events
        [Category("Action")]
        public event EventHandler SelectedChanged
        {
            add { this.Events.AddHandler(_eventSelectedChanged, value); }
            remove { this.Events.RemoveHandler(_eventSelectedChanged, value); }
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

        [Bindable(false), Browsable(false)]
        public TreeNodeCollection Nodes
        {
            get
            {
                if (nodes == null)
                {
                    nodes = new TreeNodeCollection();
                    nodes.DataSetChange += new EventHandler(OnDataSetChange);
                }
                return nodes;
            }
        }

        [Bindable(false), Browsable(false)]
        public TreeNodeItem SelectedNode
        {
            get { return _selectedNode; }
            set { if (_selectedNode == value) return; _selectedNode = value; OnSelectedChanged(EventArgs.Empty); }
        }

        public ImageList ImageList
        {
            get { return _imageList; }
            set { _imageList = value; }
        }

        #endregion


        private void OnDataSetChange(object sender, EventArgs e)
        {
            //this.Invalidate();
        }

        protected virtual void OnSelectedChanged(EventArgs e)
        {
            EventHandler handler;
            handler = (EventHandler)this.Events[_eventSelectedChanged];
            handler?.Invoke(this, e);
        }


        #region Draw
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            VirtualHeight = 0;
            draw_y = 0;

            g.TranslateTransform(0, -_vScroll.Value);        //根据滚动条的值设置坐标偏移

            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            using (Pen pen = new Pen(brush, 1))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                foreach (var item in Nodes)
                {
                    item.Bounds = new Rectangle(0, draw_y, this.Width, rowHeight);
                    item.Level = 0;
                    DrawNode(g, brush, pen, item);
                    draw_y += rowHeight;
                }
            }
            g.ResetTransform();             //重置坐标系

            //if (!scrollBottom)
            _vScroll.VirtualHeight = VirtualHeight + 5;   //绘制完成计算虚拟高度决定是否绘制滚动条
            if (MouseVisible && _vScroll.Visible)   //是否绘制滚动条
                _vScroll.ReDrawScroll(g);
        }




        private void DrawNode(Graphics g, SolidBrush brush, Pen pen, TreeNodeItem node)
        {
            node.SwitchBounds = new Rectangle(node.Level * indent + 7, node.Bounds.Y + 6, 12, 12);
            OnDrawNode(g, brush, pen, node);
            VirtualHeight += node.Bounds.Height;
            if (node.Open)
                foreach (var item in node.Nodes)
                {
                    draw_y += rowHeight;
                    item.Bounds = new Rectangle(0, draw_y, this.Width, rowHeight);
                    item.Level = node.Level + 1;
                    DrawNode(g, brush, pen, item);
                }
        }

        protected virtual void OnDrawNode(Graphics g, SolidBrush brush, Pen pen, TreeNodeItem node)
        {
            if (SelectedNode == node)
            {
                using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(75, 110, 175)))
                    g.FillRectangle(solidBrush, node.Bounds);
                //brush.Color = Color.White;
                pen.Color = Color.White;
            }
            else
            {
                //brush.Color = this.ForeColor;
                pen.Color = this.ForeColor;
            }
            if (node.ForeColor != Color.Transparent)
            {
                brush.Color = node.ForeColor;
            }
            else
                brush.Color = this.ForeColor;

            int x = node.Level * indent + 7;
            g.DrawLine(pen, x + 8, node.Bounds.Y + rowHeight / 2, x + 23, node.Bounds.Y + rowHeight / 2);
            if (node.Nodes.Count > 0)//开关
            {
                if (node.Open)
                {
                    g.DrawLine(pen, x + 31, node.Bounds.Y + rowHeight - 13, x + 31, node.Bounds.Y + GetChildCount(node) * rowHeight + rowHeight / 2);//纵线

                    g.DrawImage(ImageCloseIcon, node.SwitchBounds);
                }
                else
                    g.DrawImage(ImageOpenIcon, node.SwitchBounds);
            }

            //文件夹
            if (ImageList != null)
            {
                Image image = ImageList.Images[node.ImageIndex];
                g.DrawImage(image, x + 25, node.Bounds.Y + 3);
            }

            //if (!node.Folder)
            //    g.DrawImage(FileIcon, x + 25, node.Bounds.Y + 3);
            //else
            //    g.DrawImage(FolderIcon, x + 25, node.Bounds.Y + 3);

            g.DrawString(node.Text, this.Font, brush, x + 50, node.Bounds.Y + 3);
        }

        #endregion

        #region mouse
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseVisible = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseVisible = false;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            m_ptMousePos = e.Location;
            m_ptMousePos.Y += _vScroll.Value;
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (_vScroll.IsMouseDown)
                return;
            MouseSwitchClick(Nodes);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (_vScroll.IsMouseDown)
                return;
            MouseNodeClick(Nodes);
        }


        /// <summary>
        /// 节点点击事件
        /// </summary>
        /// <param name="nodes"></param>
        private void MouseNodeClick(TreeNodeCollection nodes)
        {
            foreach (var item in nodes)
            {
                if (item.Bounds.Contains(m_ptMousePos))
                {
                    SelectedNode = item;
                    this.Invalidate();
                    return;
                }
                MouseNodeClick(item.Nodes);
            }
        }

        /// <summary>
        /// 开关点击事件处理
        /// </summary>
        /// <param name="nodes"></param>
        private void MouseSwitchClick(TreeNodeCollection nodes)
        {
            foreach (var item in nodes)
            {
                if (item.SwitchBounds.Contains(m_ptMousePos))
                {
                    item.Open = !item.Open;
                    this.Invalidate();
                    return;
                }
                MouseSwitchClick(item.Nodes);
            }



        }
        #endregion

        private void VScroll_OnScrollEvent(object sender, ScrollEventArgs e)
        {

        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                ImageOpenIcon.Dispose();
                ImageCloseIcon.Dispose();
                ImageOpenIcon = null;
                ImageCloseIcon = null;
            }
        }

        /// <summary>
        /// 获取node节点下所有已展开的字节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetChildCount(TreeNodeItem node)
        {
            int count = node.Nodes.Count;
            foreach (var item in node.Nodes)
            {
                if (item.Open)
                    count += GetChildCount(item);
            }
            return count;
        }


    }

    public class TreeNodeCollection : IList<TreeNodeItem>, ICollection<TreeNodeItem>, IEnumerable
    {
        private readonly List<TreeNodeItem> items;
        public TreeNodeCollection()
        {
            items = new List<TreeNodeItem>();
        }


        public TreeNodeItem this[int index] { get => items[index]; set => items[index] = value; }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        public void Add(TreeNodeItem item)
        {
            items.Add(item);
            OnDataSetChange();
        }

        public void AddRange(IEnumerable<TreeNodeItem> collection)
        {
            items.AddRange(collection);
            OnDataSetChange();
        }

        public void Clear()
        {
            items.Clear();
            OnDataSetChange();
        }

        public bool Contains(TreeNodeItem item)
        {
            return items.Contains(item);
        }

        public void CopyTo(TreeNodeItem[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TreeNodeItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public int IndexOf(TreeNodeItem item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, TreeNodeItem item)
        {
            items.Insert(index, item);
            OnDataSetChange();
        }

        public bool Remove(TreeNodeItem item)
        {
            bool result = items.Remove(item);
            if (result)
                OnDataSetChange();
            return result;
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
            OnDataSetChange();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        private void OnDataSetChange()
        {
            DataSetChange?.Invoke(this, EventArgs.Empty);
        }

        public TreeNodeItem Find(Func<TreeNodeItem, bool> predicate)
        {
            return items.FirstOrDefault(predicate);
        }

        public event EventHandler DataSetChange;

    }
    public class TreeNodeItem
    {
        private TreeNodeCollection nodes;

        public object Tag { get; set; }
        public string Text { get; set; }
        public bool Open { get; set; }

        public Color ForeColor { get; set; } = Color.Transparent;
        public int ImageIndex { get; set; }

        internal Rectangle SwitchBounds { get; set; }
        internal Rectangle Bounds { get; set; }
        /// <summary>
        /// 当前深度
        /// </summary>
        public int Level { get; internal set; }

        public TreeNodeCollection Nodes
        {
            get
            {
                if (nodes == null)
                    nodes = new TreeNodeCollection();
                return nodes;
            }
        }

    }
}
