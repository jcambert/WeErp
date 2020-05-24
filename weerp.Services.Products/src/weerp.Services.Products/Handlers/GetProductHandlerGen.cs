using AutoMapper;
using MicroS_Common.Handlers;
using System.Threading.Tasks;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;
using weerp.Services.Products.Repositories;

/// <summary>
/// @author: Ambert Jean-Christophe
/// @email: jc.ambert@free.fr
/// @created_on: Mon Nov 11 2019 16:19:55 GMT+0100 (GMT+01:00)
/// </summary>
namespace weerp.Services.Products.Handlers
{
    /// <summary>
    /// Get Product Handler
    /// </summary>
    public partial class GetProductHandler :  IQueryHandler<GetProduct, ProductDto>
    {
        #region private variables
        private readonly IBrowseProductRepository _productsRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public GetProductHandler(IBrowseProductRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        #endregion

        #region public functions
        /// <summary>
        ///  Handle the command with context
        /// </summary>
        /// <param name="command">The command to handle</param>
        /// <param name="context">The correlation context</param>
        /// <returns></returns>
        public async Task<ProductDto> HandleAsync(GetProduct query)
        {
            var model = await _productsRepository.GetAsync(query.Id);

            return model == null ? null : _mapper.Map<ProductDto>(model);
            /*new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Vendor = product.Vendor,
                Price = product.Price
            };*/
        }
        #endregion
    }
}