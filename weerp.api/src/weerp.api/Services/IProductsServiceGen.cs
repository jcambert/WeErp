using MicroS_Common.RestEase;
using MicroS_Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;

/// <summary>
/// @author: Ambert Jean-Christophe
/// @email: jc.ambert@free.fr
/// @created_on: Mon Nov 11 2019 15:18:52 GMT+0100 (GMT+01:00)
/// </summary>
namespace weerp.api.Services
{
    /// <summary>
    /// Product Service created by <see cref="https://www.nuget.org/packages/RestEase/">Restease</see>
    /// </summary>
    [ServiceForwarder("products-service")]
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public partial interface IProductsService:IServiceForwarder
    {
        /// <summary>
        /// Get product by its Id
        /// </summary>
        /// <param name="id">the id of  Product</param>
        /// <returns>ProductDto</returns>
        [AllowAnyStatusCode]
        [Get("products/{id}")]
        Task<ProductDto> GetAsync([Path] Guid id);


         /// <summary>
        /// Get list of products by BrowseProducts Query
        /// </summary>
        /// <param name="query">The Browse products query</param>
        /// <returns>a list of ProductDto</returns>
        [AllowAnyStatusCode]
        [Get("products")]
        Task<PagedResult<ProductDto>> BrowseAsync([Query] BrowseProducts query);
    }
}
