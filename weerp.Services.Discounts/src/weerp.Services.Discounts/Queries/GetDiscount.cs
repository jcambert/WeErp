using MicroS_Common.Types;
using System;
using WeErpServicesDiscounts.Dto;

namespace WeErpServicesDiscounts.Queries
{
    public class GetDiscount : IQuery<DiscountDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
