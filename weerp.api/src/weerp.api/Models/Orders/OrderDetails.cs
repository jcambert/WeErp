using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weerp.api.Models.Orders
{
    public class OrderDetails : Order
    {
        public OrderCustomer Customer { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
