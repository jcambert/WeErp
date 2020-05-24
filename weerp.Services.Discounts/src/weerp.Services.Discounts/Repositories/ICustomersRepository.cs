using System;
using System.Threading.Tasks;
using WeErpServicesDiscounts.Domain;

namespace WeErpServicesDiscounts.Repositories
{

    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task AddAsync(Customer customer);
    }

}
