using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Properties;

namespace WinForm.UI.Controls
{
    public partial class LoadingView : Control
    {
        Bitmap animatedImage = null;
        bool currentlyAnimating = false;
        EventHandler ImageEvent = null;

        private bool isRunning = false;

        [Category("Skin")]
        [Description("获取当前控件是否正在运行")]
        [DefaultValue(typeof(bool), "false")]
        public bool IsRunning { get { return isRunning; }}

        public new bool Enabled { get { return base.Enabled; } set { if (value == base.Enabled) return; base.Enabled = value; if (value) isRunning = true;  else isRunning=false; this.Invalidate(); } }


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
            animatedImage = Resources.lg_rotating_balls_spinner;
            ImageEvent = new EventHandler(OnFrameChanged);
            base.Size = new Size(200, 200);
            Enabled = false;
        }

        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                //Begin the animation only once.
                ImageAnimator.Animate(animatedImage, ImageEvent);
                currentlyAnimating = true;
            }
        }


        private void OnFrameChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.Clear(Parent.BackColor);
            if (isRunning)
            {
                //Begin the animation.
                AnimateImage();
                //Get the next frame ready for rendering.
                ImageAnimator.UpdateFrames();
            }
            //Draw the next frame in the animation.
            Point point = new Point(this.Width/2- animatedImage.Width/2,this.Height/2- animatedImage.Height/2);
            e.Graphics.DrawImage(this.animatedImage, point);

        }

        public void Start()
        {
            if (isRunning)
                return;
            isRunning = true;
            this.Invalidate();
        }

        public void Stop()
        {
            if (!isRunning)
                return;
            isRunning = false;
        }

    }

}
