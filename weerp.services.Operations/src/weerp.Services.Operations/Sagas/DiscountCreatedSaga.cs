using Chronicle;
using MicroS.Services.Operations.Messages.Discounts.Events;
using MicroS.Services.Operations.Messages.Notifications.Commands;
using MicroS_Common.RabbitMq;
using System.Threading.Tasks;

namespace MicroS.Services.Operations.Sagas
{
    public class DiscountCreatedSaga : Saga,
        ISagaStartAction<DiscountCreated>
    {
        private readonly IBusPublisher _busPublisher;

        public DiscountCreatedSaga(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        public Task HandleAsync(DiscountCreated message, ISagaContext context)
        {
            return _busPublisher.SendAsync(new SendEmailNotification("jc.ambert@free.fr",
                    "Discount", $"New discount: {message.Code}"),
                CorrelationContext.Empty);
        }

        public Task CompensateAsync(DiscountCreated message, ISagaContext context)
        {
            return Task.CompletedTask;
        }
    }

    public class State
    {
        public string Code { get; set; }
    }
}
