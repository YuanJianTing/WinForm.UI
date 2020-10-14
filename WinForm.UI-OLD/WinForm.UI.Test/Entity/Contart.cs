using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinForm.UI.Test.Entity
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:32:04
    * 说明：
    * ==========================================================
    * */
    public class Contart
    {
        public string HeadUrl { get; internal set; }
        public bool IsLastMessage { get; internal set; }
        public string LastMessage { get; internal set; }
        public DateTime? LastMessageTime { get; internal set; }
        public string NickName { get; internal set; }
    }
}
