using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.DataAccess.Data;
using Otus.PublicSale.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MassTransit;
using System;

namespace Otus.PublicSale.WebApi
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options
               .UseSqlServer(Configuration.GetConnectionString("DBConnection"))
               .UseLazyLoadingProxies()
               .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
               .EnableSensitiveDataLogging()               
            );

            services.AddControllers();

            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(Configuration["RabbitMQ:Url"]), c =>
                    {
                        c.Username(Configuration["RabbitMQ:Username"]);
                        c.Password(Configuration["RabbitMQ:Password"]);
                    });
                });
            });
            services.AddMassTransitHostedService();

            services.AddOpenApiDocument(options =>
            {
                options.Title = "Otus.PublicSale API Doc";
                options.Version = "1.0";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3(x =>
            {
                x.DocExpansion = "list";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
