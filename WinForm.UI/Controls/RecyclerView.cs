using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI.Animations;
using WinForm.UI.Extension;

namespace WinForm.UI.Controls
{
    public class RecyclerView : BorderPanel
    {
        #region Fields
        private Orientation _orientation = Orientation.Vertical;
        private int VirtualHeight = 0;
        private int VirtualWidth = 0;
        private Adapter<ViewHolder> _adapter;
        private VScroll _vScroll;    //滚动条
        private bool _MouseVisible;
        private AnimationManager _animationManager;
        private ViewHolder _clickViewHolder;
        #endregion

        #region Constructors
        public RecyclerView()
        {
            _vScroll = new VScroll(this);
            _vScroll.BackColor = ColorStyles.ScrollBackColor;
            _vScroll.MouseMoveColor = ColorStyles.ScrollMouseMoveColor;
            _vScroll.OnScrollEvent += new EventHandler<ScrollEventArgs>(VScroll_OnScrollEvent);
            _animationManager = new AnimationManager(this, 3);
            _animationManager.Speed = 10;
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

        #endregion

        [Category("外观")]
        [Description("获取或设置控件的方向")]
        public Orientation Orientation { get { return _orientation; } set { if (_orientation == value) return; _orientation = value; this.Invalidate(); } }

        [Bindable(false), Browsable(false)]
        public Adapter<ViewHolder> Adapter { get { return _adapter; } set { _adapter = value; if (_adapter != null) _adapter.Control = this; } }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Adapter == null)
                return;
            VirtualHeight = 0;
            VirtualWidth = 0;
            

            if (_animationManager.IsAnimating() && _clickViewHolder != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Color bg = BackColor.TakeBackColor();//取相反色
                using (SolidBrush hrush = new SolidBrush(Color.FromArgb(50, bg)))
                {
                    float animationValue = (float)_animationManager.GetProgress();
                    float x = _animationManager.GetMouseDown().X - animationValue / 2;
                    float y = _animationManager.GetMouseDown().Y - animationValue / 2;
                    RectangleF rect = new RectangleF(x, y, animationValue, animationValue);
                    e.Graphics.FillEllipse(hrush, rect);
                }
                e.Graphics.SmoothingMode = SmoothingMode.Default;
            }

            int count = Adapter.GetItemCount();

            for (int i = 0; i < count; i++)
            {
                ViewHolder viewHolder = Adapter.OnCreateViewHolder(this, -_vScroll.Value, i);
                VirtualHeight += viewHolder.Bounds.Height;
                VirtualWidth += viewHolder.Bounds.Width;

                if (viewHolder.Bounds.Bottom >= 0 && viewHolder.Bounds.Y <= this.Height)
                {
                    Adapter.OnDrawItem(e.Graphics, viewHolder, i);
                }
            }

            _vScroll.VirtualHeight = VirtualHeight;   //绘制完成计算虚拟高度决定是否绘制滚动条
            if (_MouseVisible && _vScroll.Visible)   //是否绘制滚动条
                _vScroll.ReDrawScroll(e.Graphics);

        }

        private void VScroll_OnScrollEvent(object sender, ScrollEventArgs e)
        {
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
            if (!_animationManager.IsAnimating())
                this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (DesignMode)
                return;
            if (e.Button == MouseButtons.Left)
            {
                _clickViewHolder = FindPointView(e.Location);
                _animationManager.StartNewAnimation(e.Location, _clickViewHolder.Bounds);
            }
        }

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //    m_ptMousePos = e.Location;
        //    m_ptMousePos.Y += _vScroll.Value;
        //}


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (DesignMode)
                return;

            if (_vScroll.IsMouseDown)
                return;
        }

        //protected override void OnMouseClick(MouseEventArgs e)
        //{
        //    base.OnMouseClick(e);
        //    if (_vScroll.IsMouseDown)
        //        return;
        //    MouseNodeClick(Nodes);
        //}

        private ViewHolder FindPointView(Point point)
        {
            int count = Adapter.GetItemCount();
            for (int i = 0; i < count; i++)
            {
                ViewHolder viewHolder = Adapter.OnCreateViewHolder(this, -_vScroll.Value, i);
                if (viewHolder.Bounds.Contains(point))
                    return viewHolder;
            }
            return null;
        }


        #endregion


    }
}
