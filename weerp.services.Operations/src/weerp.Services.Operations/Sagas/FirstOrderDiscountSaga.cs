using Chronicle;
using MicroS.Services.Operations.Messages.Customers.Events;
using MicroS_Common.RabbitMq;
using System;
using System.Threading.Tasks;
using weerp.domain.Orders.Messsages.Commands;
using weerp.domain.Orders.Messsages.Events;

namespace MicroS.Services.Operations.Sagas
{
    public class FirstOrderDiscountSagaState
    {
        public DateTime CustomerCreatedAt { get; set; }
    }

    public class FirstOrderDiscountSaga : Saga<FirstOrderDiscountSagaState>,
        ISagaStartAction<CustomerCreated>,
        ISagaAction<OrderCreated>
    {
        private const int CreationHoursLimit = 24;
        private readonly IBusPublisher _busPublisher;

        public FirstOrderDiscountSaga(IBusPublisher busPublisher)
            => _busPublisher = busPublisher;

        public override /*Guid*/ SagaId ResolveId(object message, ISagaContext context)
        {
            switch (message)
            {
                case CustomerCreated cc: return SagaId.NewSagaId(); // cc.Id;
                case OrderCreated oc: return SagaId.NewSagaId();// oc.CustomerId;
                default: return base.ResolveId(message, context);
            }
        }

        //1: Check whether customer creation hours diff fits the limit
        public async Task HandleAsync(CustomerCreated message, ISagaContext context)
        {
            Data.CustomerCreatedAt = DateTime.UtcNow;
            await Task.CompletedTask;
        }

        //2: Check whether customer creation hours diff fits the limit
        public async Task HandleAsync(OrderCreated message, ISagaContext context)
        {
            var diff = DateTime.UtcNow.Subtract(Data.CustomerCreatedAt);

            if (diff.TotalHours <= CreationHoursLimit)
            {
                await _busPublisher.SendAsync(new CreateOrderDiscount(
                    message.Id, message.CustomerId, 10), CorrelationContext.Empty);

                Complete();
            }
            else
            {
                Reject();
            }
        }

        #region Compensate
        public async Task CompensateAsync(CustomerCreated message, ISagaContext context)
        {
            //TOOD: Implement compensation
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(OrderCreated message, ISagaContext context)
        {
            //TOOD: Implement compensation
            await Task.CompletedTask;
        }
        #endregion
    }
}
