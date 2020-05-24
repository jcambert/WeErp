using MicroS_Common.Types;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weerp.api.Models.Customers;
using weerp.api.Queries;

namespace weerp.api.Services
{
    
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICustomersService
    {
        [AllowAnyStatusCode]
        [Get("customers/{id}")]
        Task<Customer> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("customers")]
        Task<PagedResult<Customer>> BrowseAsync([Query] BrowseCustomers query);

        [AllowAnyStatusCode]
        [Get("carts/{id}")]
        Task<Cart> GetCartAsync([Path] Guid id);
    }

}
