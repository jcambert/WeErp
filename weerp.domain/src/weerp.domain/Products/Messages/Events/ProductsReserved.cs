using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace weerp.domain.Products.Messages.Events
{
    public class ProductsReserved : ProductBaseEvent
    {
        public Guid Id { get; set; }
        public IDictionary<Guid, int> Products { get; }

        [JsonConstructor]
        public ProductsReserved(Guid id, IDictionary<Guid, int> products)
        {
            Id = id;
            Products = products;
        }
    }
}
