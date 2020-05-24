using System;
using System.Collections.Generic;
using System.Text;

namespace weerp.domain.Products.Messages.Events
{
    public class ReserveProductsRejected : ProductBaseRejectedEvent
    {
        public ReserveProductsRejected(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
