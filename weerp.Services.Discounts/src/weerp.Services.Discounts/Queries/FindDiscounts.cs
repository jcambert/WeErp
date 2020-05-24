using MicroS_Common.Types;
using System;
using System.Collections.Generic;
using WeErpServicesDiscounts.Dto;

namespace WeErpServicesDiscounts.Queries
{
    public class FindDiscounts : IQuery<IEnumerable<DiscountDto>>
    {
        public Guid CustomerId { get; set; }
    }
}
