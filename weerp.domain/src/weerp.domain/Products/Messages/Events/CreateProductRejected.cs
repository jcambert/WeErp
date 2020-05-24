using System;

namespace weerp.domain.Products.Messages.Events
{
    public class CreateProductRejected : ProductBaseRejectedEvent
    {
        public CreateProductRejected(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
