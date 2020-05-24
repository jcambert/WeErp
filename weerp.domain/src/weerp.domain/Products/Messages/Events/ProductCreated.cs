using System;

namespace weerp.domain.Products.Messages.Events
{
    public class ProductCreated : ProductBaseEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Vendor { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public ProductCreated(Guid id, string name, string description, string vendor, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Vendor = vendor;
            Price = price;
            Quantity = quantity;
        }
    }
}
