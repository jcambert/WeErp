using MicroS_Common.Messages;
using System;

namespace weerp.domain.Products.Messages.Commands
{
    
    public class CreateProduct : ProductBaseCommand
    {
        public override Guid Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public string Vendor { get; }
        public decimal Price { get; }
        public int Quantity { get; }


        public CreateProduct(Guid id, string name,
            string description, string vendor,
            decimal price, int quantity) : base()
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
