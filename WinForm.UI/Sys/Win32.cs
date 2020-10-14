using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.UI.Sys
{
    public static class Win32
    {
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;// 从右到左打开窗口
        public const Int32 AW_BLEND = 0x00080000;//使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
        public const Int32 AW_SLIDE = 0x00040000;//使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。
        public const Int32 AW_HIDE = 0x00010000; //隐藏窗口，缺省则显示窗口。

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessageA")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
    }
}
