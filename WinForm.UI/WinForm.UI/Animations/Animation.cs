using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm.UI.Animations
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:00:01
    * 说明：
    * ==========================================================
    * */
    public abstract class Animation
    {
        public bool IsClose = false;
        protected Form form;
        protected IntPtr Handle;
        public Animation()
        {
        }
        ///
        public void SetForm(Form form)
        {
            this.form = form;
            Handle = form.Handle;
            Init(form);
        }

        public virtual void Init(Form form)
        {

        }

        /// <summary>
        /// 显示
        /// </summary>
        public virtual void OnShow()
        {
            IsClose = false;

        }
        /// <summary>
        /// 关闭
        /// </summary>
        public virtual void OnClosing()
        {

            IsClose = true;
        }
    }
}
