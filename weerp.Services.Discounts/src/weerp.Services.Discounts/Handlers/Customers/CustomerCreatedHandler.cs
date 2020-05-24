﻿using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeErpServicesDiscounts.Domain;
using WeErpServicesDiscounts.Messages.Events;
using WeErpServicesDiscounts.Repositories;

namespace WeErpServicesDiscounts.Handlers.Customers
{
    public class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ILogger<CustomerCreatedHandler> _logger;

        public CustomerCreatedHandler(ICustomersRepository customersRepository,
            ILogger<CustomerCreatedHandler> logger)
        {
            _customersRepository = customersRepository;
            _logger = logger;
        }

        public async Task HandleAsync(CustomerCreated @event, ICorrelationContext context)
        {
            await _customersRepository.AddAsync(new Customer(@event.Id, @event.Email));
            _logger.LogInformation($"Created customer with id: '{@event.Id}'.");
        }
    }
}
