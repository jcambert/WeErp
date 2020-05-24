
using MicroS_Common.Handlers;
using MicroS_Common.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeErpServicesDiscounts.Domain;
using WeErpServicesDiscounts.Dto;
using WeErpServicesDiscounts.Metrics;
using WeErpServicesDiscounts.Queries;

namespace WeErpServicesDiscounts.Handlers.Discounts
{
    public class FindDiscountsHandler : IQueryHandler<FindDiscounts, IEnumerable<DiscountDto>>
    {
        private readonly IMongoRepository<Discount> _discountsRepository;
        private readonly IMetricsRegistry _registry;


        public FindDiscountsHandler(IMongoRepository<Discount> discountsRepository, IMetricsRegistry registry)
        {
            _discountsRepository = discountsRepository;
            _registry = registry;
        }

        public async Task<IEnumerable<DiscountDto>> HandleAsync(FindDiscounts query)
        {
            _registry?.IncrementFindDiscountsQuery();

            var discounts = await _discountsRepository.FindAsync(
                c => c.CustomerId == query.CustomerId);

            return discounts.Select(d => new DiscountDto
            {
                Id = d.Id,
                CustomerId = d.CustomerId,
                Code = d.Code,
                Percentage = d.Percentage,
                Available = !d.UsedAt.HasValue
            });
        }
    }
}
