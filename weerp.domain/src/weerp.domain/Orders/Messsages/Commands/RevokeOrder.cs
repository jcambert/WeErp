using Newtonsoft.Json;
using System;

namespace weerp.domain.Orders.Messsages.Commands
{
    public class RevokeOrder : OrderBaseCommand
    {
        public override Guid Id { get; set; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public RevokeOrder(Guid id, Guid customerId):base()
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
