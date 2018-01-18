using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Utils;

namespace WinForm.UI.Controls
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/12 8:37:08
    * 说明：
    * ==========================================================
    * */
    public class CirclePictureBox : PictureBox
    {
        private Image tempImage;
        private bool isSelected = false;
        /// <summary>
        /// 是否选中
        /// </summary>
        [Browsable(false)]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected == value)
                    return;
                isSelected = value;
                if (isSelected && selectedImage != null)
                {
                    tempImage = this.Image;
                    base.Image = selectedImage;
                }
                else
                {
                    if (selectedImage != null)
                    {
                        base.Image = tempImage;
                    }
                }
                OnSelectedChange();
            }
        }

        private int radius = 10;
        [Category("Skin")]
        [Description("获取或设置当前控件圆角的弧度")]
        [DefaultValue(typeof(int), "10")]
        public int Radius { get { return radius; } set { if (value == radius) return; radius = value; this.Invalidate(); } }

        private Image selectedImage;
        [Category("Skin")]
        [Description("获取或设置当前控件选中图片")]
        public Image SelectedImage { get { return selectedImage; } set { selectedImage = value; this.Invalidate(); } }

        private Image mouseMoveImage;
        [Category("Skin")]
        [Description("获取或设置当前控件鼠标移上显示的图片")]
        public Image MouseMoveImage { get { return mouseMoveImage; } set { mouseMoveImage = value; this.Invalidate(); } }


        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = GraphicsPathHelper.CreatePath(rect, radius, RoundStyle.All, true);
            g.SetClip(path);

            base.OnPaint(pe);
        }

        private void DrowImage(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, Image.Width, Image.Height);
            //GraphicsPath path = GraphicsPathHelper.DrawRoundRect(0,0, this.Width, this.Height,10);
            GraphicsPath path = GraphicsPathHelper.CreatePath(rect, 10, RoundStyle.All, true);
            g.SetClip(path);
            g.DrawImage(Image, 0, 0);
            //g.DrawImageUnscaledAndClipped(Image, rect);
        }


        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            MouseMove += (obj, e) =>
            {
                if (mouseMoveImage != null)
                {
                    tempImage = base.Image;
                    base.Image = mouseMoveImage;
                }
            };

            MouseLeave += (obj, e) =>
            {
                if (mouseMoveImage != null)
                {
                    base.Image = tempImage;
                }
            };
        }


        public static Image CropToCircle(Image srcImage, Color backGround)
        {
            Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
            Graphics g = Graphics.FromImage(dstImage);
            using (Brush br = new SolidBrush(backGround))
            {
                g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
            }
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, dstImage.Width, dstImage.Height);
            g.SetClip(path);
            g.DrawImage(srcImage, 0, 0);

            return dstImage;
        }


        public delegate void SelectedChangeHandler(object sender, EventArgs e);
        public event SelectedChangeHandler SelectedChange;
        public virtual void OnSelectedChange()
        {
            SelectedChange?.Invoke(this, EventArgs.Empty);
        }

    }

}
