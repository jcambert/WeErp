using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using MicroS_Common;
using MicroS_Common.Consul;
using MicroS_Common.Dispatchers;
using MicroS_Common.Jeager;
using MicroS_Common.Mongo;
using MicroS_Common.Mvc;
using MicroS_Common.RabbitMq;
using MicroS_Common.RestEase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WeErpServicesDiscounts.Domain;
using WeErpServicesDiscounts.Messages.Commands;
using WeErpServicesDiscounts.Messages.Events;
using WeErpServicesDiscounts.Metrics;
using WeErpServicesDiscounts.Services;

namespace src
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
       // public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutofac();
            services.AddCustomMvc();
            services.AddInitializers(typeof(IMongoDbInitializer));
            services.AddConsul();
            services.AddJaeger();
            services.RegisterServiceForwarder<IOrdersService>("orders-service");
            services.AddTransient<IMetricsRegistry, MetricsRegistry>();




            //return new AutofacServiceProvider(Container);

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsImplementedInterfaces();

            builder.AddDispatchers();
            builder.AddMongo();

            builder.AddMongoRepository<Customer>("Customers");
            builder.AddMongoRepository<Discount>("Discounts");

            builder.AddRabbitMq();

            
            // var reg = Container.IsRegistered<RabbitMqOptions>();

            //  reg = Container.IsRegistered<IDispatcher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime, IStartupInitializer initializer
            ,IConsulClient consulClient)
        {
            //this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            initializer.InitializeAsync();
#pragma warning disable MVC1005
            app.UseMvc();
#pragma warning restore MVC1005

            var serviceId = app.UseConsul();

            applicationLifetime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceId);
                //Container.Dispose();
            });

            app.UseRabbitMq()
                .SubscribeCommand<CreateDiscount>(onError: (cmd, ex)
                    => new CreateDiscountRejected(cmd.CustomerId, ex.Message, "customer_not_found"))
                .SubscribeEvent<CustomerCreated>(@namespace: "customers")
                .SubscribeEvent<OrderCompleted>(@namespace: "orders");


        }


    }
}
