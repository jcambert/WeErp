#define SERVICE_PRODUCT
using Consul;
using MicroS_Common;
using MicroS_Common.Dispatchers;
using MicroS_Common.Domain;
using MicroS_Common.RabbitMq;
using MicroS_Common.Services.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using weerp.domain;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Messages.Events;

namespace weerp.Services.Products
{


    public class Startup : ServiceStartup
    {

        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override Type DomainType => typeof(DomainProfile);

        protected override void SubscribeEventAndMessageBus(IBusSubscriber bus)
        {
            // base.SubscribeEventAndMessageBus(bus);
            if (DomainType != null)
            {
                bus.SubscribeAllCommands(true, DomainType.Assembly);
                //bus.SubscribeOnRejected(DomainType.Assembly);
            }
            //bus.SubscribeCommand<CreateProduct>(onError: (c, e) => new CreateProductRejected(c.Id, e.Message, e.Code));
        }
        public override void ConfigureServices(IServiceCollection services)
        {


            base.ConfigureServices(services);
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            //services.AddTransient<IValidateContext, ValidateContext>();
            //services.AddTransient<IValidate<Product>, weerp.domain.Products.Validators.Validate>();
        }
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime, IStartupInitializer startupInitializer, IConsulClient consulClient, IServiceProvider services, ILogger<BaseStartup> logger)
        {
            var supportedCultures = new[]{new CultureInfo("fr")};
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(supportedCultures[0]),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                //SupportedUICultures = supportedCultures
            });
            base.Configure(app, env, applicationLifetime, startupInitializer, consulClient, services, logger);
        }
    }
}
