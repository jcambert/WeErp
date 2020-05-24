﻿/*using MicroS.Services.SignalR.Messages.Events;
using System.Threading.Tasks;

namespace MicroS.Services.SignalR.Services
{
    public class HubService : IHubService
    {
        private readonly IHubWrapper _hubContextWrapper;

        public HubService(IHubWrapper hubContextWrapper)
        {
            _hubContextWrapper = hubContextWrapper;
        }



        public async Task PublishOperationPendingAsync(OperationPending @event)
            => await _hubContextWrapper.PublishToUserAsync(@event.UserId,
                "operation_pending",
                new
                {
                    id = @event.Id,
                    name = @event.Name,
                    resource = @event.Resource
                }
            );

        public async Task PublishOperationCompletedAsync(OperationCompleted @event)
            => await _hubContextWrapper.PublishToUserAsync(@event.UserId,
                "operation_completed",
                new
                {
                    id = @event.Id,
                    name = @event.Name,
                    resource = @event.Resource
                }
            );

        public async Task PublishOperationRejectedAsync(OperationRejected @event)
            => await _hubContextWrapper.PublishToUserAsync(@event.UserId,
                "operation_rejected",
                new
                {
                    id = @event.Id,
                    name = @event.Name,
                    resource = @event.Resource,
                    code = @event.Code,
                    reason = @event.Message
                }
            );
    }
}*/
