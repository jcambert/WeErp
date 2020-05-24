using System;
using System.Collections.Generic;
using System.Text;

namespace weerp.domain.Products.Messages.Events
{
    public class ReleaseProductsRejected : ProductBaseRejectedEvent
    {
        public ReleaseProductsRejected(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
