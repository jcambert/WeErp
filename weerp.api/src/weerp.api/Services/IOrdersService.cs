using MicroS_Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;
using weerp.api.Models.Orders;
using weerp.api.Queries;

namespace weerp.api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IOrdersService
    {
        [AllowAnyStatusCode]
        [Get("orders/{id}")]
        Task<OrderDetails> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("customers/{customerId}/orders/{orderId}")]
        Task<OrderDetails> GetAsync([Path] Guid customerId, [Path] Guid orderId);

        [AllowAnyStatusCode]
        [Get("orders")]
        Task<PagedResult<Order>> BrowseAsync([Query] BrowseOrders query);
    }
}
