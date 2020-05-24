using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using System.Threading.Tasks;
using weerp.domain.Settings.Domain;
using weerp.domain.Settings.Messages.Commands;
using weerp.domain.Settings.Messages.Events;
using weerp.Services.Settings.Repositories;

namespace weerp.Services.Settings.Handlers
{
    public sealed class CreateSettingsHandler : DomainCommandHandler<CreateSetting, Setting>
    {
        public CreateSettingsHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Setting> repo) : base(busPublisher, mapper, repo)
        {
        }

        protected override async Task CheckExist(Setting setting)
        {
            if (await(Repository as ISettingsRepository).ExistsAsync(setting.Numero))
            {
                throw new MicroSException("setting_already_exists",$"Setting: '{setting.Numero}' already exists.");
            }
        }

        public override async Task HandleAsync(CreateSetting command, ICorrelationContext context)
        {
            await base.HandleAsync(command, context);

            var product = GetDomainObject(command);

            await Repository.AddAsync(product);

            await BusPublisher.PublishAsync(CreateEvent<SettingCreated>(command), context);
        }
    }
}
