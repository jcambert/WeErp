using System;

namespace weerp.domain.Products.Messages.Commands
{
    public class DeleteProduct : ProductBaseCommand
    {
        public override Guid Id { get; set; }
        public DeleteProduct(Guid id) : base()
        {
            this.Id = id;
        }

    }
}
