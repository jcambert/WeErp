using Newtonsoft.Json;
using System;

namespace weerp.domain.Orders.Messsages.Commands
{

    public class CompleteOrder : OrderBaseCommand
    {
        public Guid CustomerId { get; }

        public override Guid Id { get; set; }

        [JsonConstructor]
        public CompleteOrder(Guid id, Guid customerId) : base()
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
