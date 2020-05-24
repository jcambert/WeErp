using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace weerp.domain.Orders.Messsages.Events
{
    public class OrderApproved:OrderBaseEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public OrderApproved(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
