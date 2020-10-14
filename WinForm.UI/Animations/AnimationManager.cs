using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.UI.Animations
{
    public class AnimationManager
    {
        private Timer _animationTimer;

        private Control owner;

        private double Progress = 0;
        private int max = 0;
        private Point MouseDown;
        private Rectangle region;

        /// <summary>
        /// Constructor
        /// </summary>
        public AnimationManager(Control owner, int Interval = 5)
        {
            this.owner = owner;
            max = (owner.Width > owner.Height) ? owner.Width : owner.Height;
            _animationTimer = new Timer();
            _animationTimer.Interval = Interval;
            _animationTimer.Tick += AnimationTimerOnTick;


        }

        public int Speed { get; set; } = 4;

        private void AnimationTimerOnTick(object sender, EventArgs eventArgs)
        {
            Progress += Speed;
            if (region != Rectangle.Empty)
                owner.Invalidate(region);
            else
                owner.Invalidate();
            if (Progress > max)
                _animationTimer.Stop();
        }


        public void StartNewAnimation(Point location)
        {
            StartNewAnimation(location, Rectangle.Empty);
        }

        public void StartNewAnimation(Point location, Rectangle region)
        {
            if (IsAnimating())
            {
                _animationTimer.Stop();
                if (this.region != Rectangle.Empty)
                    owner.Invalidate(this.region);
            }

            this.region = region;
            MouseDown = location;
            if (region != Rectangle.Empty)
            {
                max = (region.Width > region.Height) ? region.Width : region.Height;
            }
            else
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
