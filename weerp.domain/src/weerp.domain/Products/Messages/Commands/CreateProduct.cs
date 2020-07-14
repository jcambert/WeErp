using MicroS_Common.Domain;
using MongoDB.Bson.Serialization.Serializers;
using System;
using WeCommon;
using weerp.domain.Products.Messages.Events;

namespace weerp.domain.Products.Messages.Commands
{
    [OnRejected(typeof(CreateProductRejected))]
    public class CreateProduct : ProductBaseCommand
    {
        public override Guid Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public string Vendor { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public Property<double> Taxes { get; }

        public CreateProduct(Guid id, string name,
            string description, string vendor,
            decimal price, int quantity,Property<double> taxes) : base()
        {
            Id = id;
            Name = name;
            Description = description;
            Vendor = vendor;
            Price = price;
            Quantity = quantity;
            Taxes = taxes;
        }
    }
}
