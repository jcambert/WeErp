using System;

namespace weerp.domain.Products.Messages.Events
{
    public class UpdateProductRejected : ProductBaseRejectedEvent
    {
        public UpdateProductRejected(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
