using System;
using System.Collections.Generic;
using System.Text;

namespace weerp.domain.Products.Messages.Events
{
    public class ProductUpdated : ProductCreated
    {
        public ProductUpdated(Guid id, string name, string description, string vendor, decimal price, int quantity) : base(id, name, description, vendor, price, quantity)
        {
        }
    }
}
