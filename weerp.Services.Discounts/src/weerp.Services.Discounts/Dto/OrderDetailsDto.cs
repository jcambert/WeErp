using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeErpServicesDiscounts.Dto
{
    public class OrderDetailsDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int ItemsCount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
    }
}
