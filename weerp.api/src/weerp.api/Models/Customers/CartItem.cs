using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weerp.api.Models.Customers
{
    public class CartItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
