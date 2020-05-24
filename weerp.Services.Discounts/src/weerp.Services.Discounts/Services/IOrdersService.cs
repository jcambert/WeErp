using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeErpServicesDiscounts.Dto;

namespace WeErpServicesDiscounts.Services
{
    public interface IOrdersService
    {
        [AllowAnyStatusCode]
        [Get("orders/{id}")]
        Task<OrderDetailsDto> GetAsync([Path] Guid id);
    }
}
