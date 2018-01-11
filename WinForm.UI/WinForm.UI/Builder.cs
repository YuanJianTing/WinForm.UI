using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WinForm.UI.Animations;

namespace WinForm.UI
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 15:45:56
    * 说明：
    * ==========================================================
    * */
    public class Builder
    {
        private Font defauleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (134));
        /// <summary>
        /// 默认字体
        /// </summary>
        public Font Font
        {
            get { return defauleFont; }
            set { defauleFont = value; }
        }

        private Color defaultForeColor = Color.Black;
        /// <summary>
        /// 设置默认字体颜色
        /// </summary>
        public Color ForeColor
        {
            get { return defaultForeColor; }
            set { defaultForeColor = value; }
        }


        private Color defaultTitleForeColor = Color.White;
        /// <summary>
        /// 默认标题栏字体颜色
        /// </summary>
        public Color TitleForeColor
        {
            get { return defaultTitleForeColor; }
            set { defaultTitleForeColor = value; }
        }

        private int defaultTitleHeight = 30;
        /// <summary>
        /// 默认标题栏高
        /// </summary>
        public int TitleHeight
        {
            get { return defaultTitleHeight; }
            set { defaultTitleHeight = value; }
        }


        #region button
        private Color defaultButtonBeginBackColor = Color.Black;
        /// <summary>
        /// 按钮默认开始背景色
        /// </summary>
        public Color ButtonBeginBackColor
        {
            get { return defaultButtonBeginBackColor; }
            set { defaultButtonBeginBackColor = value; }
        }
        private Color defaultButtonEndBackColor = Color.Black;
        /// <summary>
        /// 按钮默认结束背景色
        /// </summary>
        public Color ButtonEndBackColor
        {
            get { return defaultButtonEndBackColor; }
            set { defaultButtonEndBackColor = value; }
        }

        private Color defaultButtonForeColor = Color.White;
        /// <summary>
        /// 按钮默认背景色
        /// </summary>
        public Color ButtonForeColor
        {
            get { return defaultButtonForeColor; }
            set { defaultButtonForeColor = value; }
        }
        #endregion




        private bool defaultDragSize = true;
        /// <summary>
        /// 是否允许拖到改变大小
        /// </summary>
        public bool DragSize
        {
            get { return defaultDragSize; }
            set { defaultDragSize = value; }
        }

        private bool defaultSkinMobile = true;
        /// <summary>
        /// 窗体是否可以移动
        /// </summary>
        public bool SkinMobile
        {
            get { return defaultSkinMobile; }
            set { defaultSkinMobile = value; }
        }

        private bool defaultIsShadow = true;
        /// <summary>
        /// 设置窗体是否显示阴影效果
        /// </summary>
        public bool IsShadow
        {
            get { return defaultIsShadow; }
            set { defaultIsShadow = value; }
        }

        private Color defaultTitleBackColor = Color.FromArgb(194, 186, 181);
        /// <summary>
        /// 标题栏默认背景色
        /// </summary>
        public Color TitleBackColor
        {
            get { return defaultTitleBackColor; }
            set { defaultTitleBackColor = value; }
        }


        private bool defaultTitleIsCenter = false;
        /// <summary>
        /// 标题默认是否居中
        /// </summary>
        public bool TitleIsCenter
        {
            get { return defaultTitleIsCenter; }
            set { defaultTitleIsCenter = value; }
        }

        private bool defaultIsTitle = true;
        /// <summary>
        /// 默认是否显示标题
        /// </summary>
        public bool IsTitle
        {
            get { return defaultIsTitle; }
            set { defaultIsTitle = value; }
        }


        private bool defaultIsLogo = true;
        /// <summary>
        /// 默认是否显示logo
        /// </summary>
        public bool IsLogo
        {
            get { return defaultIsLogo; }
            set { defaultIsLogo = value; }
        }


        private bool defaultMaximizeBox = true;
        /// <summary>
        /// 设置默认窗体是否显示最大化按钮
        /// </summary>
        public bool MaximizeBox
        {
            get { return defaultMaximizeBox; }
            set { defaultMaximizeBox = value; }
        }

        private bool defaultMinimizeBox = true;
        /// <summary>
        /// 设置默认窗体是否显示最小化按钮
        /// </summary>
        public bool MinimizeBox
        {
            get { return defaultMinimizeBox; }
            set { defaultMinimizeBox = value; }
        }


        private Image defaultMaxBoxImage = null;
        /// <summary>
        /// 设置默认窗体最大化按钮背景图
        /// </summary>
        public Image MaxBoxImage
        {
            get { return defaultMaxBoxImage; }
            set { defaultMaxBoxImage = value; }
        }

        private Image defaultRestoreBoxImage = null;
        /// <summary>
        /// 设置默认窗体还原按钮背景图
        /// </summary>
        public Image RestoreBoxImage
        {
            get { return defaultRestoreBoxImage; }
            set { defaultRestoreBoxImage = value; }
        }

        private Image defaultMinBoxImage = null;
        /// <summary>
        /// 设置默认窗体最小化按钮背景图
        /// </summary>
        public Image MinBoxImage
        {
            get { return defaultMinBoxImage; }
            set { defaultMinBoxImage = value; }
        }

        private Image defaultCloseBoxImage = null;
        /// <summary>
        /// 设置默认窗体关闭按钮背景图
        /// </summary>
        public Image CloseBoxImage
        {
            get { return defaultCloseBoxImage; }
            set { defaultCloseBoxImage = value; }
        }


        private Color defaultMaxBoxBackColor = Color.FromArgb(203, 196, 192);
        /// <summary>
        /// 设置默认窗体最大化按钮背景颜色
        /// </summary>
        public Color MaxBoxBackColor
        {
            get { return defaultMaxBoxBackColor; }
            set { defaultMaxBoxBackColor = value; }
        }

        private Color defaultMinBoxBackColor = Color.FromArgb(203, 196, 192);
        /// <summary>
        /// 设置默认窗体最小化按钮背景颜色
        /// </summary>
        public Color MinBoxBackColor
        {
            get { return defaultMinBoxBackColor; }
            set { defaultMinBoxBackColor = value; }
        }

        private Color defaultCloseBoxBackColor = Color.FromArgb(212, 64, 39);
        /// <summary>
        /// 设置默认窗体关闭按钮背景颜色
        /// </summary>
        public Color CloseBoxBackColor
        {
            get { return defaultCloseBoxBackColor; }
            set { defaultCloseBoxBackColor = value; }
        }


        private Color defaultMaxBoxFontColor = Color.White;
        /// <summary>
        /// 设置默认窗体最大化按钮字体颜色
        /// </summary>
        public Color MaxBoxFontColor
        {
            get { return defaultMaxBoxFontColor; }
            set { defaultMaxBoxFontColor = value; }
        }

        private Color defaultMinBoxFontColor = Color.White;
        /// <summary>
        /// 设置默认窗体最小化按钮字体颜色
        /// </summary>
        public Color MinBoxFontColor
        {
            get { return defaultMinBoxFontColor; }
            set { defaultMinBoxFontColor = value; }
        }

        private Color defaultCloseBoxFontColor = Color.White;
        /// <summary>
        /// 设置默认窗体关闭按钮字体颜色
        /// </summary>
        public Color CloseBoxFontColor
        {
            get { return defaultCloseBoxFontColor; }
            set { defaultCloseBoxFontColor = value; }
        }


        private Color defaultFormBackColor = Color.White;
        /// <summary>
        /// 设置默认窗体背景颜色
        /// </summary>
        public Color FormBackColor
        {
            get { return defaultFormBackColor; }
            set { defaultFormBackColor = value; }
        }

        private Icon defaultIcon = null;
        /// <summary>
        /// 设置窗体默认icon
        /// </summary>
        public Icon Icon
        {
            get { return defaultIcon; }
            set { defaultIcon = value; }
        }

        public Animation defaultAnimation = new DefaultAnimation();
        /// <summary>
        /// 设置窗体动画
        /// </summary>
        public Animation Animation
        {
            get { return defaultAnimation; }
            set { defaultAnimation = value; }
        }

    }
}
