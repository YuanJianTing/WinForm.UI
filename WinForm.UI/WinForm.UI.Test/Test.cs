using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Animations;

namespace WinForm.UI.Test
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/15 9:39:58
    * 说明：
    * ==========================================================
    * */
    public class Test : Control
    {

        private AnimationManager _animationManager;

        public Test()
        {
            _animationManager = new AnimationManager(this);
            SetStyle(
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.SupportsTransparentBackColor |
               ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            //g.Clear(Parent.BackColor);
            using (SolidBrush hrush = new SolidBrush(this.BackColor))
            {
                g.FillRectangle(hrush, ClientRectangle);
            }

            if (_animationManager.IsAnimating())
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color bg = GetTakeBackColor(BackColor);
                using (SolidBrush hrush = new SolidBrush(Color.FromArgb(50, bg)))
                {
                    float animationValue = (float)_animationManager.GetProgress();
                    float x = _animationManager.GetMouseDown().X - animationValue / 2;
                    float y = _animationManager.GetMouseDown().Y - animationValue / 2;
                    RectangleF rect = new RectangleF(x, y, animationValue, animationValue);
                    g.FillEllipse(hrush, rect);
                }
                g.SmoothingMode = SmoothingMode.None;
            }


        }
        /// <summary>
        /// 取相反色
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private Color GetTakeBackColor(Color color)
        {
            int R,G,B = 0;
            R = 255 - color.R;
            G = 255 - color.G;
            B = 255 - color.B;
            Color Result = Color.FromArgb(R,G,B);
            return Result;
        }


        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (DesignMode) return;
            //MouseEnter += (sender, args) =>
            //{
            //    //_hoverAnimationManager.StartNewAnimation(AnimationDirection.In);
            //    Invalidate();
            //};
            //MouseLeave += (sender, args) =>
            //{
            //    //_hoverAnimationManager.StartNewAnimation(AnimationDirection.Out);
            //    Invalidate();
            //};
            MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    _animationManager.StartNewAnimation(args.Location);
                    Invalidate();
                }
            };
            MouseUp += (sender, args) =>
            {
                Invalidate();
            };
        }


    }
}
