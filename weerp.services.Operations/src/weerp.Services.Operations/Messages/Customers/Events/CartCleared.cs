using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroS.Services.Operations.Messages.Customers.Events
{
    [MessageNamespace("customers")]
    public class CartCleared : IEvent
    {
        public Guid CustomerId { get; }

        [JsonConstructor]
        public CartCleared(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
