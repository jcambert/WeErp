using Newtonsoft.Json;
using System;

namespace weerp.domain.Orders.Messsages.Commands
{

    public class CreateOrder : OrderBaseCommand
    {
        public Guid CustomerId { get; }
        public override Guid Id { get; set; }
        [JsonConstructor]
        public CreateOrder(Guid id, Guid customerId) : base() 
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
