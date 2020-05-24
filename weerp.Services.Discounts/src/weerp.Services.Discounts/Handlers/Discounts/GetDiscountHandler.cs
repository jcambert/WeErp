using MicroS_Common.Handlers;
using MicroS_Common.Mongo;
using System.Threading.Tasks;
using WeErpServicesDiscounts.Domain;
using WeErpServicesDiscounts.Dto;
using WeErpServicesDiscounts.Queries;

namespace WeErpServicesDiscounts.Handlers.Discounts
{
    public class GetDiscountHandler : IQueryHandler<GetDiscount, DiscountDetailsDto>
    {
        private readonly IMongoRepository<Discount> _discountsRepository;
        private readonly IMongoRepository<Customer> _customersRepository;

        public GetDiscountHandler(IMongoRepository<Discount> discountsRepository,
            IMongoRepository<Customer> customersRepository)
        {
            _discountsRepository = discountsRepository;
            _customersRepository = customersRepository;
        }

        public async Task<DiscountDetailsDto> HandleAsync(GetDiscount query)
        {
            var discount = await _discountsRepository.GetAsync(query.Id);
            if (discount is null)
            {
                return null;
            }

            var customer = await _customersRepository.GetAsync(discount.CustomerId);

            return new DiscountDetailsDto
            {
                Customer = new CustomerDto
                {
                    Id = customer.Id,
                    Email = customer.Email
                },
                Discount = new DiscountDto
                {
                    Id = discount.Id,
                    CustomerId = discount.CustomerId,
                    Code = discount.Code,
                    Percentage = discount.Percentage,
                    Available = !discount.UsedAt.HasValue
                }
            };
        }
    }
}
