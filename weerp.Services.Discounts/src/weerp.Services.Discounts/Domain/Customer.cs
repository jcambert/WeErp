using MicroS_Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeErpServicesDiscounts.Domain
{
    public class Customer : IIdentifiable
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }

        public Customer(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
