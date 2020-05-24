using Newtonsoft.Json;
using System;

namespace weerp.domain.Orders.Messsages.Commands
{

    public class CreateOrderDiscount : OrderBaseCommand
    {
        public override Guid Id { get; set; }
        public Guid CustomerId { get; }
        public int Percentage { get; }

        [JsonConstructor]
        public CreateOrderDiscount(Guid id, Guid customerId, int percentage) : base()
        {
            Id = id;
            CustomerId = customerId;
            Percentage = percentage;
        }
    }
}
