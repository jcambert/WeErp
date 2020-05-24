using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace weerp.domain.Products.Messages.Events
{
    public class ProductDeleted:ProductBaseEvent
    {

        public Guid Id { get; }

        [JsonConstructor]
        public ProductDeleted(Guid id)
        {
            Id = id;
        }
    }
}
