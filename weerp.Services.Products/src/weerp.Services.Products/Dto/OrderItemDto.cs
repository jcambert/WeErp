using System;

namespace weerp.Services.Products.Dto
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
