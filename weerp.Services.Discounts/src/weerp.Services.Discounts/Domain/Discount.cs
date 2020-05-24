using MicroS_Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeErpServicesDiscounts.Domain
{
    // Aggregate
    public class Discount : IIdentifiable
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public string Code { get; private set; }
        public double Percentage { get; private set; }
        public DateTime? UsedAt { get; private set; }

        private Discount()
        {
        }

        public Discount(Guid id, Guid customerId, string code, double percentage)
        {
            if (id == Guid.Empty)
            {
                throw new MicroSException("invalid_discount_id",
                    "Invalid discount id.");
            }

            if (customerId == Guid.Empty)
            {
                throw new MicroSException("invalid_discount_customer_id",
                    "Invalid discount customers id.");
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new MicroSException("empty_discount_code",
                    "Empty discount code.");
            }

            if (percentage < 1 || percentage > 100)
            {
                throw new MicroSException("invalid_discount_percentage",
                    $"Invalid discount percentage: {percentage}.");
            }

            Id = id;
            CustomerId = customerId;
            Code = code;
            Percentage = percentage;
        }

        public void Use()
        {
            if (UsedAt.HasValue)
            {
                throw new MicroSException("discount_already_applied",
                    $"Discount: '{Id}' was already applied at: {UsedAt}.");
            }

            UsedAt = DateTime.UtcNow;
        }
    }
}
