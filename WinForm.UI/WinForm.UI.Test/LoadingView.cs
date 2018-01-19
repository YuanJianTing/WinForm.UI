using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinForm.UI.Test
{
    /****************************************************************
	*   作者：yuanj
	*   CLR版本：4.0.30319.42000
	*   创建时间：2018/01/18 19:47:19
	*   2018
	*   描述说明：
	*
	*   修改历史：
	*
	*
	*****************************************************************/
    public class LoadingView:Control
    {


        public LoadingView()
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

            //初始化绘图timer  
            _graphicsTmr = new System.Windows.Forms.Timer { Interval = 1 };
            //Invalidate()强制重绘,绘图操作在OnPaint中实现  
            _graphicsTmr.Tick += (sender1, e1) => Invalidate(false);

            _dotSize = Width / 10f;
            

            //初始化"点"  
            _dots = new Dot[5];

            Color = Color.White;
        }

        #region 属性  

        /// <summary>  
        ///     圆心  
        /// </summary>  
        [Browsable(false)]
        public PointF CircleCenter
        {
            get { return new PointF(Width / 2f, Height / 2f); }
        }

        /// <summary>  
        ///     半径  
        /// </summary>  
        [Browsable(false)]
        public float CircleRadius
        {
            get { return Width / 2f - _dotSize; }
        }

        /// <summary>  
        ///     颜色  
        /// </summary>  
        [Browsable(true), Category("Appearance"), Description("设置\"点\"的前景色")]
        public Color Color { get; set; }

        #endregion 属性  

        #region 字段  

        //点数组  
        private readonly Dot[] _dots;

        //Timers  
        private readonly System.Windows.Forms.Timer _graphicsTmr;
        private System.Threading.Timer _actionTmr;

        //点大小  
        private float _dotSize;

        //是否活动  
        private bool _isActived;

        //是否绘制:用于状态重置时挂起与恢复绘图  
        private bool _isDrawing = true;

        //Timer计数:用于延迟启动每个点  
        private int _timerCount;

        #endregion 字段  

        #region 常量  

        //动作间隔(Timer)  
        private const int ActionInterval = 30;

        //计数基数：用于计算每个点启动延迟：index * timerCountRadix  
        private const int TimerCountRadix = 45;

        #endregion 常量  

        #region 方法  

        //检查是否重置  
        private bool CheckToReset()
        {
            return _dots.Count(d => d.Opacity > 0) == 0;
        }

        //初始化点元素  
        private void CreateDots()
        {
            for (int i = 0; i < _dots.Length; ++i)
                _dots[i] = new Dot(CircleCenter, CircleRadius);
        }

        /// <summary>  
        ///     开关  
        /// </summary>  
        public bool Switch()
        {
            if (!_isActived)
                Start();
            else
                Stop();

            return _isActived;
        }

        /// <summary>  
        /// 开始  
        /// </summary>  
        public void Start()
        {
            CreateDots();

            _timerCount = 0;
            foreach (Dot dot in _dots)
                dot.Reset();

            _graphicsTmr.Start();

            //初始化动作timer  
            _actionTmr = new System.Threading.Timer(
                state =>
                {
                    //动画动作  
                    for (int i = 0; i < _dots.Length; i++)
                        if (_timerCount++ > i * TimerCountRadix)
                            _dots[i].DotAction();

                    //是否重置  
                    if (CheckToReset())
                    {
                        //重置前暂停绘图  
                        _isDrawing = false;

                        _timerCount = 0;

                        foreach (Dot dot in _dots)
                            dot.Reset();

                        //恢复绘图  
                        _isDrawing = true;
                    }

                    _actionTmr.Change(ActionInterval, Timeout.Infinite);
                },
                null, ActionInterval, Timeout.Infinite);

            _isActived = true;
        }

        /// <summary>  
        /// 停止  
        /// </summary>  
        public void Stop()
        {
            _graphicsTmr.Stop();
            _actionTmr.Dispose();
            _isActived = false;
        }

        #endregion 方法  

        #region 重写  

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_isActived && _isDrawing)
            {
                //抗锯齿  
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                using (var bmp = new Bitmap(200, 200))
                {
                    //缓冲绘制  
                    using (Graphics bufferGraphics = Graphics.FromImage(bmp))
                    {
                        //抗锯齿  
                        bufferGraphics.SmoothingMode = SmoothingMode.HighQuality;
                        foreach (Dot dot in _dots)
                        {
                            var rect = new RectangleF(
                                new PointF(dot.Location.X - _dotSize / 2, dot.Location.Y - _dotSize / 2),
                                new SizeF(_dotSize, _dotSize));

                            bufferGraphics.FillEllipse(new SolidBrush(Color.FromArgb(dot.Opacity, Color)),
                                rect);
                        }
                    }

                    //贴图  
                    e.Graphics.DrawImage(bmp, new PointF(0, 0));
                } //bmp disposed  
            }

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Height = Width;
            _dotSize = Width / 12f;

            base.OnResize(e);
        }

        #endregion 重写  

    }
}
