using System.Threading.Tasks;
using WeErpServicesDiscounts.Domain;

namespace WeErpServicesDiscounts.Repositories
{
    public interface IDiscountsRepository
    {
        Task AddAsync(Discount discount);
        Task UpdateAsync(Discount discount);
    }
}
