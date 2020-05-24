using Newtonsoft.Json;
using System;

namespace weerp.domain.Orders.Messsages.Commands
{
    public class CancelOrder : OrderBaseCommand
    {
        public Guid CustomerId { get; }
        public override Guid Id { get; set; }

        [JsonConstructor]
        public CancelOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
