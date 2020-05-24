using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace weerp.domain.Products.Messages.Commands
{
    public class ReleaseProducts : ICommand
    {

        public Guid OrderId { get; set; }
        public IDictionary<Guid, int> Products { get; }
        [JsonConstructor]
        public ReleaseProducts(Guid orderId, IDictionary<Guid, int> products) 
        {
            OrderId = orderId;
            Products = products;
        }
    }
}
