using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace weerp.api.Messages.Commands.Orders
{
    [MessageNamespace("orders")]
    public class ApproveOrder : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public ApproveOrder(Guid id)
        {
            Id = id;
        }
    }
}
