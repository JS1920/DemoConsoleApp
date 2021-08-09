using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal Amount { get; set; }
        public decimal ShippingCost { get; set; }
        public string ShippingMethods { get; set; }

    }
}
