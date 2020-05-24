using System;

namespace weerp.domain.Orders.Messsages.Events
{
    public class CreateOrderRejected : OrderBaseRejectedEvent
    {
        public Guid CustomerId { get; }

        public CreateOrderRejected(Guid id, string reason, string code, Guid customerId) : base(id, reason, code)
        {
            CustomerId = customerId;
        }
    }
}
