using MicroS_Common.Domain;
using System;
using weerp.domain.Products.Messages.Events;

namespace weerp.domain.Products.Messages.Commands
{
    [OnRejected(typeof(DeleteProductRejected))]
    public class DeleteProduct : ProductBaseCommand
    {
        public override Guid Id { get; set; }
        public DeleteProduct(Guid id) : base()
        {
            this.Id = id;
        }

    }
}
