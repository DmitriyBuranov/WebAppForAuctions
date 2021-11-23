using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PublicSale.NotificationService.Core.Abstractions;
using PublicSale.NotificationService.Core.Abstractions.Repositories;
using PublicSale.NotificationService.Core.Abstractions.Services;
using PublicSale.NotificationService.Core.Domain.NotificationManagement;
using PublicSale.NotificationService.Core.Services;
using PublicSale.NotificationService.DataAccess;
using PublicSale.NotificationService.DataAccess.Data;
using PublicSale.NotificationService.DataAccess.Repositories;
using PublicSale.NotificationService.WebHost.EventConsumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace PublicSale.NotificationService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

    public  Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddMvcOptions(x =>
            x.SuppressAsyncSuffixInActionNames = false);

            services.Configure<MongoOptions>(Configuration.GetSection(nameof(MongoOptions)));
            services.AddSingleton<IMongoOptions>(x => x.GetRequiredService<IOptions<MongoOptions>>().Value);

            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddTransient<INotificationSaveService, NotificationSaveService>();
            services.AddTransient<ISendNotificationService, SendNotificationService>();

            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));

            services.AddMassTransit(x =>
            {
                x.AddConsumer<NotifiactionEventConsumer>();

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(Configuration["RabbitMQ:Url"]), c =>
                    {
                        c.Username(Configuration["RabbitMQ:Username"]);
                        c.Password(Configuration["RabbitMQ:Password"]);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddMassTransitHostedService();

            services.AddHostedService<TimedHostedService>();

            services.AddTransient<SendNotificationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PSNotificationAPI", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PSNotificationAPI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            dbInitializer.InitializeDb();
        }
    }
}
