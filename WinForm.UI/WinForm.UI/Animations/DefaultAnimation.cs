using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Utils;

namespace WinForm.UI.Animations
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:01:18
    * 说明：
    * ==========================================================
    * */
    public class DefaultAnimation: Animation
    {
        int iActulaWidth = 0;
        int iActulaHeight = 0;

        public DefaultAnimation()
        {
            iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
        }

        public override void OnShow()
        {
            //淡入特效
            Win32.AnimateWindow(this.Handle, 150, Win32.AW_VER_POSITIVE);
        }

        public override void OnClosing()
        {
            Win32.AnimateWindow(this.Handle, 150, Win32.AW_BLEND | Win32.AW_HIDE);
            base.OnClosing();
            form.Close();
        }

        public override void Init(Form form)
        {
            form.Location = new System.Drawing.Point(iActulaWidth / 2 - form.Width / 2, iActulaHeight / 2 - form.Height / 2);
        }
    }
}
