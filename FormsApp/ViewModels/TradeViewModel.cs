using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsApp.ViewModels
{
    public class TradeViewModel
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
