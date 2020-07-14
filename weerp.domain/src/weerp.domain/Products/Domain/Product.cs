using System;
using MicroS_Common.Mongo;
using MicroS_Common.Types;
using MongoDB.Bson.Serialization.Attributes;
using WeCommon;

namespace weerp.domain.Products.Domain
{
    [MongoDocument("product")]
    public class Product : BaseEntity
    {
        internal string _name;
        internal string _vendor;
        internal string _description;
        internal decimal _price;
        internal int _quantity;

        
        public string Name { get => _name; private set { _name = value; } }
        public string Description { get => _description; private set { _description = value; } }
        public string Vendor { get => _vendor; private set { _vendor = value; } }
        public decimal Price { get => _price; private set { _price = value; } }
        public int Quantity { get => _quantity; private set { _quantity = value; } }

        [BsonSerializer(typeof(DynamicSerializer<dynamic, double>))]
        public dynamic Taxes { get; set; } = new Property<double>();

        public Product(Guid id, string name, string description, string vendor,
            decimal price, int quantity)
            : base(id)
        {

            Name = name;
            SetDescription(description);
            SetVendor(vendor);
            SetPrice(price);
            SetQuantity(quantity);

        }



        //public void SetName(string name) => this.SetProperty(ref _name, name?.Trim()?.ToLowerInvariant(), string.IsNullOrEmpty, "empty_product_name", "Product name cannot be empty.", () => this.SetUpdatedDate());

        public void SetDescription(string description) => this.SetProperty(ref _description, description?.Trim()?.ToLowerInvariant(), string.IsNullOrEmpty, "empty_product_description", "Product description cannot be empty.", () => this.SetUpdatedDate());

        public void SetVendor(string vendor) => this.SetProperty(ref _vendor, vendor?.Trim()?.ToLowerInvariant(), string.IsNullOrEmpty, "empty_product_vendor", "Product vendor cannot be empty.", () => this.SetUpdatedDate());

        public void SetPrice(decimal price) => this.SetProperty(ref _price, price, p => p <= 0, "invalid_product_price", "Product price cannot be zero or negative.", () => this.SetUpdatedDate());

        public void SetQuantity(int quantity) => this.SetProperty(ref _quantity, quantity, p => p < 0, "invalid_product_quantity", "Product quantity cannot be negative.", () => this.SetUpdatedDate());

    }
}
