using MicroS_Common.Types;
using System;
using weerp.domain.Products.Dto;

namespace weerp.domain.Products.Queries
{
    public class GetProduct : IQuery<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
