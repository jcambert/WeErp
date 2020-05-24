using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace weerp.api.Messages.Commands.Customers
{
    [MessageNamespace("customers")]
    public class AddProductToCart : ICommand
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }

        [JsonConstructor]
        public AddProductToCart(Guid customerId, Guid productId,
            int quantity)
        {
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
