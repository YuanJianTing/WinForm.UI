using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinForm.UI.Animations
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/15 8:44:54
    * 说明：
    * ==========================================================
    * */
    public enum AnimationDirection
    {
        In, //In. Stops if finished.
        Out, //Out. Stops if finished.
        InOutIn, //Same as In, but changes to InOutOut if finished.
        InOutOut, //Same as Out.
        InOutRepeatingIn, // Same as In, but changes to InOutRepeatingOut if finished.
        InOutRepeatingOut // Same as Out, but changes to InOutRepeatingIn if finished.
    }
}
