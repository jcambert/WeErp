using MicroS_Common.Types;
using weerp.domain.Products.Dto;

namespace weerp.domain.Products.Queries
{
    public class BrowseProducts : PagedQueryBase, IQuery<PagedResult<ProductDto>>
    {
        //public decimal PriceFrom { get; set; }
        //public decimal PriceTo { get; set; } = decimal.MaxValue;
    }
}
