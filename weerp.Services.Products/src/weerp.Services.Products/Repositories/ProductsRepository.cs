/*
 * using AutoMapper;
using MicroS_Common.Mongo;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using System.Threading.Tasks;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;

namespace weerp.Services.Products.Repositories
{
    public class ProductsRepository : BrowseRepository<Product,BrowseProducts,ProductDto>,IProductsRepository
    {

        public ProductsRepository(IMongoRepository<Product> repository,IMapper mapper):base (repository,mapper)
        {
            
        }


        public async Task<bool> ExistsAsync(string name)
            => await Repository.ExistsAsync(p => p.Name.ToLowerInvariant() == name.ToLowerInvariant());

        
        public override async Task<PagedResult<Product>> BrowseAsync(BrowseProducts query)
            => await Repository.BrowseAsync(p =>p.Price >= query.PriceFrom && p.Price <= query.PriceTo, query);


        
    }
}*/
