using System;

namespace weerp.domain.Orders.Messsages.Events
{
    public class CompleteOrderRejected : OrderBaseRejectedEvent
    {
        public Guid CustomerId { get; }
        public CompleteOrderRejected(Guid id, string reason, string code, Guid customerId) : base(id, reason, code)
        {
            CustomerId = customerId;
        }
    }
}
