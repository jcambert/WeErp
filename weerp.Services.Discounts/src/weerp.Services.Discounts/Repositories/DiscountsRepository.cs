using MicroS_Common.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeErpServicesDiscounts.Domain;

namespace WeErpServicesDiscounts.Repositories
{
    public class DiscountsRepository : IDiscountsRepository
    {
        private readonly IMongoRepository<Discount> _repository;

        public DiscountsRepository(IMongoRepository<Discount> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Discount discount)
            => await _repository.AddAsync(discount);

        public async Task UpdateAsync(Discount discount)
            => await _repository.UpdateAsync(discount);
    }
}
