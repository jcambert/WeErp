using Newtonsoft.Json;
using System;

namespace weerp.domain.Orders.Messsages.Events
{
    public class OrderRevoked : OrderBaseEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public OrderRevoked(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
