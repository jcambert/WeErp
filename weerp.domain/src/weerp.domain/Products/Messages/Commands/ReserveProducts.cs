﻿using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace weerp.domain.Products.Messages.Commands
{
    public class ReserveProducts : ICommand
    {
        public Guid OrderId { get; set; }
        public IDictionary<Guid, int> Products { get; }

        [JsonConstructor]
        public ReserveProducts(Guid orderId, IDictionary<Guid, int> products)
        {
            OrderId = orderId;
            Products = products;
        }
    }
}
