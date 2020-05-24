using MicroS_Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace weerp.domain.Products.Messages.Events
{
    [MessageNamespace("products")]
    public class ProductBaseRejectedEvent : BaseRejectedEvent
    {
        public ProductBaseRejectedEvent(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
