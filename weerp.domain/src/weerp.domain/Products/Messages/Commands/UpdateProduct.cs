using System;

namespace weerp.domain.Products.Messages.Commands
{
    public class UpdateProduct : CreateProduct
    {
        public UpdateProduct(Guid id, string name, string description, string vendor, decimal price, int quantity) : base(id, name, description, vendor, price, quantity)
        {
        }
    }
}
