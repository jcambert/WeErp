using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace weerp.api.Messages.Commands.Customers
{
    [MessageNamespace("customers")]
    public class ClearCart : ICommand
    {
        public Guid CustomerId { get; }

        [JsonConstructor]
        public ClearCart(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
