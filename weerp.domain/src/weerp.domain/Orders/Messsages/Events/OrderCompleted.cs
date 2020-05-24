using Newtonsoft.Json;
using System;

namespace weerp.domain.Orders.Messsages.Events
{
    public class OrderCompleted : OrderBaseEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public OrderCompleted(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
