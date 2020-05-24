using Chronicle;
using MicroS_Common.RabbitMq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using weerp.domain.Settings.Messages.Events;

namespace MicroS.Services.Operations.Sagas
{
    public class SettingSaga : Saga,
        ISagaStartAction<SettingCreated>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly ILogger<SettingSaga> _logger;

        public SettingSaga(IBusPublisher busPublisher, ILogger<SettingSaga> logger)
        {
            this._busPublisher = busPublisher;
            this._logger = logger;
        }
        public Task CompensateAsync(SettingCreated message, ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task HandleAsync(SettingCreated message, ISagaContext context)
        {
            Complete();
            _logger.LogInformation("a setting was created");
            return Task.CompletedTask;
        }
    }
}
