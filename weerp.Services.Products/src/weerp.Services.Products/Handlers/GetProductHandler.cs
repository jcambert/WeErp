using AutoMapper;
using MicroS_Common.Handlers;
using System.Threading.Tasks;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{
    public sealed partial class GetProductHandler //:  IQueryHandler<GetProduct, ProductDto>
    {
      /*  #region private variables
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public GetProductHandler(IProductsRepository productsRepository, IMapper mapper)
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
            var product = await _productsRepository.GetAsync(query.Id);

            return product == null ? null : _mapper.Map<ProductDto>(product);

        }
        #endregion*/
    }
}