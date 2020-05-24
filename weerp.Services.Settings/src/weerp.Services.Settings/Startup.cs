using Autofac;
using AutoMapper;
using Consul;
using MicroS_Common;
using MicroS_Common.Consul;
using MicroS_Common.Dispatchers;
using MicroS_Common.Jeager;
using MicroS_Common.Mongo;
using MicroS_Common.Mvc;
using MicroS_Common.RabbitMq;
using MicroS_Common.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using weerp.domain;
using weerp.domain.Settings.Domain;
using weerp.domain.Settings.Messages.Commands;
using weerp.domain.Settings.Messages.Events;

namespace weerp.Services.Settings
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            //services.AddSwaggerDocs();
            services.AddConsul();
            services.AddJaeger();
            //services.AddOpenTracing();
            services.AddRedis();
            services.AddInitializers(typeof(IMongoDbInitializer));
            services.AddAutoMapper(Assembly.GetEntryAssembly(),typeof(DomainProfile).Assembly);
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.AddRabbitMq();
            builder.AddMongo();
            builder.AddMongoRepository<Setting>("Settings");
            builder.AddDispatchers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime, IConsulClient client,
            IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAllForwardedHeaders();
            //app.UseSwaggerDocs();
            app.UseErrorHandler();
            app.UseServiceId();
#pragma warning disable MVC1005
            app.UseMvc();
#pragma warning restore MVC1005
            app.UseRabbitMq()
                .SubscribeCommand<CreateSetting>(onError: (c, e) =>new CreateSettingRejected(c.Id, e.Message, e.Code))
                /*.SubscribeCommand<UpdateProduct>(onError: (c, e) =>new UpdateProductRejected(c.Id, e.Message, e.Code))
                .SubscribeCommand<DeleteProduct>(onError: (c, e) =>new DeleteProductRejected(c.Id, e.Message, e.Code))
                .SubscribeCommand<ReserveProducts>(onError: (c, e) =>new ReserveProductsRejected(c.OrderId, e.Message, e.Code))
                .SubscribeCommand<ReleaseProducts>(onError: (c, e) =>new ReleaseProductsRejected(c.OrderId, e.Message, e.Code))*/
                ;

            var consulServiceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                client.Agent.ServiceDeregister(consulServiceId);
            });

            startupInitializer.InitializeAsync();
        }
    }
}
