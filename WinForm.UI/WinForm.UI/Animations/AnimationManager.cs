using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm.UI.Animations
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/15 8:43:30
    * 说明：
    * ==========================================================
    * */
    public class AnimationManager
    {
        private Timer _animationTimer;
        private Control owner;

        private double Progress = 0;
        private int max = 0;
        private Point MouseDown;

        /// <summary>
        /// Constructor
        /// </summary>
        public AnimationManager(Control owner)
        {
            this.owner = owner;
            max = (owner.Width > owner.Height) ? owner.Width : owner.Height;
            _animationTimer = new Timer();
            _animationTimer.Interval = 5;
            _animationTimer.Tick += AnimationTimerOnTick;
        }

        private void AnimationTimerOnTick(object sender, EventArgs eventArgs)
        {
            Progress += 4;
            owner.Invalidate();
            if (Progress > max)
                _animationTimer.Stop();
        }
       

        public void StartNewAnimation(Point location)
        {
            MouseDown = location;
            max = (owner.Width > owner.Height) ? owner.Width : owner.Height;
            Progress = 0;
            _animationTimer.Start();
        }

        public double GetProgress()
        {
            return Progress;
        }
        public bool IsAnimating()
        {
            return _animationTimer.Enabled;
        }

        public Point GetMouseDown()
        {
            return MouseDown;
        }
    }
}
