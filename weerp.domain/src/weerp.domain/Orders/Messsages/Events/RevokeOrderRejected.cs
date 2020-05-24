using System;

namespace weerp.domain.Orders.Messsages.Events
{
    public class RevokeOrderRejected : OrderBaseRejectedEvent
    {
        public Guid CustomerId { get; }
        public RevokeOrderRejected(Guid id, string reason, string code, Guid customerId) : base(id, reason, code)
        {
            CustomerId = customerId;
        }
    }
}
