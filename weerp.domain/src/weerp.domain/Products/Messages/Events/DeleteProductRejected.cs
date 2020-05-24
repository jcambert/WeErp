using System;
using System.Collections.Generic;
using System.Text;

namespace weerp.domain.Products.Messages.Events
{
    public class DeleteProductRejected : ProductBaseRejectedEvent
    {
        public DeleteProductRejected(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
