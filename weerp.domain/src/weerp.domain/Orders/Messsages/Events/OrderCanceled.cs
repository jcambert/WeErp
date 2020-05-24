using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace weerp.domain.Orders.Messsages.Events
{
    public class OrderCanceled:OrderBaseEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public IDictionary<Guid, int> Products { get; }

        [JsonConstructor]
        public OrderCanceled(Guid id, Guid customerId, IDictionary<Guid, int> products)
        {
            Id = id;
            CustomerId = customerId;
            Products = products;
        }
    }
}
