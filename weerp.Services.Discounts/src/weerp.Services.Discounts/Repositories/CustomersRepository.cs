using MicroS_Common.Mongo;
using System;
using System.Threading.Tasks;
using WeErpServicesDiscounts.Domain;

namespace WeErpServicesDiscounts.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IMongoRepository<Customer> _repository;

        public CustomersRepository(IMongoRepository<Customer> repository)
        {
            _repository = repository;
        }

        public Task<Customer> GetAsync(Guid id)
            => _repository.GetAsync(id);

        public Task AddAsync(Customer customer)
            => _repository.AddAsync(customer);
    }
}
