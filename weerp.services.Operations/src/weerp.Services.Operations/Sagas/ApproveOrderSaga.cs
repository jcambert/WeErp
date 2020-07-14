using Chronicle;
using MicroS_Common.RabbitMq;
using System.Threading.Tasks;
using weerp.domain.Orders.Messsages.Commands;
using weerp.domain.Orders.Messsages.Events;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Messages.Events;

namespace MicroS.Services.Operations.Sagas
{
    public class ApproveOrderSaga : Saga,
        ISagaStartAction<OrderCreated>,
        ISagaAction<OrderRevoked>,
        ISagaAction<RevokeOrderRejected>,
        ISagaAction<ProductsReserved>,
        ISagaAction<ReserveProductsRejected>,
        ISagaAction<OrderApproved>,
        ISagaAction<ApproveOrderRejected>
    {
        private readonly IBusPublisher _busPublisher;

        public ApproveOrderSaga(IBusPublisher busPublisher)
            => _busPublisher = busPublisher;

        public override SagaId ResolveId(object message, ISagaContext context)
        {
            switch (message)
            {
                case OrderCreated m: return SagaId.NewSagaId();
                case ProductsReserved m: return SagaId.NewSagaId();
                case ReserveProductsRejected m: return SagaId.NewSagaId();
                case OrderApproved m: return SagaId.NewSagaId();
                case ApproveOrderRejected m: return SagaId.NewSagaId();
                default: return base.ResolveId(message, context);
            }
        }

        public async Task HandleAsync(OrderCreated message, ISagaContext context)
        {
            await _busPublisher.SendAsync(new ReserveProducts(message.Id, message.Products), CorrelationContext.Empty);
        }

        public async Task CompensateAsync(OrderCreated message, ISagaContext context)
        {
            await _busPublisher.SendAsync(new RevokeOrder(message.Id, message.CustomerId), CorrelationContext.Empty);
        }

        public async Task HandleAsync(ProductsReserved message, ISagaContext context)
        {
            await _busPublisher.SendAsync(new ApproveOrder(message.Id), CorrelationContext.Empty);
        }

        public async Task CompensateAsync(ProductsReserved message, ISagaContext context)
        {
            await _busPublisher.SendAsync(new ReleaseProducts(message.Id, message.Products),
                CorrelationContext.Empty);
        }

        public async Task HandleAsync(ReserveProductsRejected message, ISagaContext context)
        {
            Reject();
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(ReserveProductsRejected message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(OrderApproved message, ISagaContext context)
        {
            Complete();
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(OrderApproved message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(ApproveOrderRejected message, ISagaContext context)
        {
            Reject();
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(ApproveOrderRejected message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        public async Task HandleAsync(OrderRevoked message, ISagaContext context)
        {
            Complete();
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(OrderRevoked message, ISagaContext context)
        {
            await Task.CompletedTask;
        }

        //Edge case
        public async Task HandleAsync(RevokeOrderRejected message, ISagaContext context)
        {
            Reject();
            await Task.CompletedTask;
        }

        public async Task CompensateAsync(RevokeOrderRejected message, ISagaContext context)
        {
            await Task.CompletedTask;
        }
    }
}
