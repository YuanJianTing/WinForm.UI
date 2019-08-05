using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinForm.UI.Utils;

namespace WinForm.UI.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (DesignMode) return;

            //释放鼠标焦点捕获
            Win32.ReleaseCapture();
            ////向当前窗体发送拖动消息
            Win32.SendMessage(this.Handle, 0x0112, 0xF011, 0);
            base.OnMouseDown(e);

        }



    }
}
