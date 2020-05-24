using MicroS_Common.Messages;
using System;

namespace weerp.domain.Orders.Messsages.Events
{
    [MessageNamespace("orders")]
    public abstract class OrderBaseRejectedEvent : BaseRejectedEvent
    {
        public OrderBaseRejectedEvent(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }


}
