using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinForm.UI.Test.Entity
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/11 16:53:11
    * 说明：
    * ==========================================================
    * */
    public class TradeBean
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public DateTime UpdateTime { get; set; }
        public decimal FirstPrice { get; set; }
        public decimal Price { get; set; }
        public decimal Settlement { get; set; }
        public decimal Highest { get; set; }
        public decimal Minimum { get; set; }
        public decimal Newest { get; set; }
        public decimal Number { get; set; }
        public decimal WarehouseCount { get; set; }


    }
}
