using MicroS_Common.Domain;
using System;
using weerp.domain.Products.Messages.Events;

namespace weerp.domain.Products.Messages.Commands
{
    [OnRejected(typeof(UpdateProductRejected))]
    public class UpdateProduct : CreateProduct
    {
        public UpdateProduct(Guid id, string name, string description, string vendor, decimal price, int quantity) : base(id, name, description, vendor, price, quantity)
        {
        }
    }
}
