/*using MicroS.Services.SignalR.Messages.Events;
using MicroS.Services.SignalR.Services;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using System.Threading.Tasks;

namespace MicroS.Services.SignalR.Handlers
{
    public class OperationUpdatedHandler : IEventHandler<OperationPending>,
        IEventHandler<OperationCompleted>, IEventHandler<OperationRejected>
    {
        private readonly IHubService _hubService;

        public OperationUpdatedHandler(IHubService hubService)
        {
            _hubService = hubService;
        }

        public async Task HandleAsync(OperationPending @event, ICorrelationContext context)
            => await _hubService.PublishOperationPendingAsync(@event);

        public async Task HandleAsync(OperationCompleted @event, ICorrelationContext context)
            => await _hubService.PublishOperationCompletedAsync(@event);

        public async Task HandleAsync(OperationRejected @event, ICorrelationContext context)
            => await _hubService.PublishOperationRejectedAsync(@event);
    }
}
*/