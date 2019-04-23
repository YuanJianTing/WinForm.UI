using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UITimer = System.Windows.Forms.Timer;
using ThreadingTimer = System.Threading.Timer;
using System.Threading;

namespace WinForm.UI.Controls
{
    public class Loading : Control
    {
        #region 常量  

        [Description("动作间隔(Timer)")] private const int ActionInterval = 30;

        [Description("计数基数：用于计算每个点启动延迟：index * timerCountRadix")] private const int TimerCountRadix = 45;

        #endregion 常量  

        [Description("点数组")] private readonly LoadingDot[] _dots;
        [Description("是否活动")] private bool _isActived;
        [Description("是否绘制：用于状态重置时挂起与恢复绘图")] private bool _isDrawing = true;
        [Browsable(false), Description("圆心")]
        public PointF CircleCenter => new PointF(this.Width / 2f, this.Height / 2f);
        [Description("Timer计数：用于延迟启动每个点 ")] private int _timerCount;
        [Description("UITimer")] private readonly UITimer _tmrGraphics;

        [Description("ThreadingTimer")] private ThreadingTimer _tmrAction;



        [Browsable(true), Category("Appearance"), Description("半径")]
        public float CircleRadius { get; set; } = 50;
        [Browsable(true), Category("Appearance"),Description("点大小")]
        public float DotSize { get => _dotSize; set => _dotSize=value; }
        private float _dotSize = 10;

        [Browsable(true), Category("Appearance"), Description("设置\"点\"的前景色")]
        public Color Color { get; set; }


        


        public Loading()
        {
            //双缓冲，禁擦背景
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.SupportsTransparentBackColor|
                ControlStyles.OptimizedDoubleBuffer,
                true);

            //初始化绘图timer
            _tmrGraphics = new UITimer { Interval = 1 };
            //Invalidate()强制重绘,绘图操作在OnPaint中实现
            _tmrGraphics.Tick += (sender, e) => Invalidate(false);
            //初始化"点"
            _dots = new LoadingDot[5];
            Color = Color.Orange;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            if (_isActived && _isDrawing)
            {
                Graphics g = e.Graphics;
                //抗锯齿  
                g.SmoothingMode = SmoothingMode.HighQuality;
                //缓冲绘制  
                foreach (var dot in _dots)
                {
                    var rectangleF = new RectangleF(
                        new PointF(dot.Location.X - _dotSize / 2, dot.Location.Y - _dotSize / 2),
                        new SizeF(_dotSize, _dotSize));
                    g.FillEllipse(new SolidBrush(Color.FromArgb(dot.Opacity, Color)),
                        rectangleF);
                } 
            }

        }

        /// <summary>
        /// 检查是否重置
        /// </summary>
        /// <returns></returns>
        private bool CheckToReset()
        {
            return _dots.Count(d => d.Opacity > 0) == 0;
        }

        /// <summary>
        /// 初始化点元素
        /// </summary>
        private void CreateLoadingDots()
        {
            for (var i = 0; i < _dots.Length; ++i)
                _dots[i] = new LoadingDot(CircleCenter, CircleRadius);
        }

        /// <summary>  
        /// 开始  
        /// </summary>  
        public void Start()
        {
            CreateLoadingDots();
            _timerCount = 0;
            foreach (var dot in _dots)
            {
                dot.Reset();
            }
            _tmrGraphics.Start();
            //初始化动作timer  
            _tmrAction = new ThreadingTimer(
                state =>
                {
                    //动画动作  
                    for (var i = 0; i < _dots.Length; i++)
                    {
                        if (_timerCount++ > i * TimerCountRadix)
                        {
                            _dots[i].LoadingDotAction();
                        }
                    }
                    //是否重置  
                    if (CheckToReset())
                    {
                        //重置前暂停绘图  
                        _isDrawing = false;
                        _timerCount = 0;
                        foreach (var dot in _dots)
                        {
                            dot.Reset();
                        }
                        //恢复绘图  
                        _isDrawing = true;
                    }
                    _tmrAction.Change(ActionInterval, Timeout.Infinite);
                },
                null, ActionInterval, Timeout.Infinite);
            _isActived = true;
        }

        /// <summary>  
        /// 停止  
        /// </summary>  
        public void Stop()
        {
            _tmrGraphics.Stop();
            _tmrAction.Dispose();
            _isActived = false;
        }



        public static Loading ShowLoading(Form form)
        {
            Loading loading = new Loading();
            loading.Size = form.ClientSize;
            loading.BackColor = Color.FromArgb(100,0,0,0);
            loading.Location = new Point(0,0);
            loading.Margin = new Padding(0,0,0,0);
            form.Controls.Add(loading);
            loading.BringToFront();
            loading.Start();
            return loading;
        }

        public static void StopLoading(Loading loading)
        {
            loading.Visible = false;
            loading.Stop();
            Form form= loading.FindForm();
            form.Controls.Remove(loading);
        }


    }
}
