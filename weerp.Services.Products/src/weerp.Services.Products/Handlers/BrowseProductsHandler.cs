using AutoMapper;
using MicroS_Common.Handlers;
using Microsoft.Extensions.Logging;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{

    public sealed class BrowseProductsHandler : BaseBrowseHandler<Product, BrowseProducts, ProductDto, IBrowseProductRepository>
    {
        public BrowseProductsHandler(IBrowseProductRepository repository, IMapper mapper, ILogger<BaseBrowseHandler<Product, BrowseProducts, ProductDto, IBrowseProductRepository>> logger) : base(repository, mapper,logger)
        {
        }

        
        
    }
}
