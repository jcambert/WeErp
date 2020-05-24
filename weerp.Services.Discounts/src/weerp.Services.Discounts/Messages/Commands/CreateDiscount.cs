using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace WeErpServicesDiscounts.Messages.Commands
{// Immutable
    // Custom routing key: #.discounts.create_discount
    public class CreateDiscount : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public string Code { get; }
        public double Percentage { get; }

        [JsonConstructor]
        public CreateDiscount(Guid id, Guid customerId,
            string code, double percentage)
        {
            Id = id;
            CustomerId = customerId;
            Code = code;
            Percentage = percentage;
        }
    }
}
