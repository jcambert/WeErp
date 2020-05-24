using MicroS_Common.Mvc;
using MicroS_Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System;
using System.Threading.Tasks;
using weerp.api.Framework;
using weerp.api.Services;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Settings.Messages.Commands;
using weerp.domain.Settings.Queries;

namespace weerp.api.Controllers
{
    [AdminAuth]
    public class SettingsController : BaseController
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(IBusPublisher busPublisher, ITracer tracer,
            ISettingsService settingsService) : base(busPublisher, tracer)
        {
            _settingsService = settingsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] BrowseSettings query)
            => 
            Collection(await _settingsService.BrowseAsync(query));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _settingsService.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(CreateSetting command)
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "settings");

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateProduct command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "settings");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteProduct(id));
    }
}
