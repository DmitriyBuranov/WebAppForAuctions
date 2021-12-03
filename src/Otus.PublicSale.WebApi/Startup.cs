using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.DataAccess.Data;
using Otus.PublicSale.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MassTransit;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using Otus.PublicSale.WebApi.Models;
using Otus.PublicSale.WebApi.Infostructure;
using Otus.PublicSale.Core.Middlewares;
using Otus.PublicSale.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Otus.PublicSale.Core;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Otus.PublicSale.Core.Services.Hubs;
using Otus.PublicSale.Core.Services;

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllCors", builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .SetIsOriginAllowed(delegate (string requestingOrigin)
                    {
                        return true;
                    }).Build();
                });
            });

            services.AddSignalR(opt =>
            {
                opt.EnableDetailedErrors = true;
                opt.KeepAliveInterval = TimeSpan.FromSeconds(4);
            });

            services.AddDbContext<DataContext>(options => options
               .UseSqlServer(Configuration.GetConnectionString("DBConnection"))
               .UseLazyLoadingProxies()
               .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
               .EnableSensitiveDataLogging()
            );

            services.AddControllers();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });                 

            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
            services.AddScoped(typeof(IAuctionRepository<>), typeof(AuctionRepository<>));
            services.AddScoped(typeof(IAuctionBetRepository<>), typeof(AuctionBetRepository<>));
            services.AddScoped<IDbInitializer, DbInitializer>();

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

            services.AddFluentValidation();
            services.AddTransient<IValidator<AuctionUserDto>, AuctionUserValidator>();
            services.AddTransient<IValidator<AuctionDto>, AuctionValidator>();


            services.AddSwaggerDocumentation();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
                options.InstanceName = "localRedis_";
            });

            services.AddHostedService<TimedHostedService>();
            services.AddHostedService<UserBackgroundService>();

            services.AddTransient<AuctionWorker>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.        
        public void Configure(IApplicationBuilder app, IDbInitializer dbInitializer)
        {            
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseRequestResponseLogging();
            
            app.UseCors("AllowAllCors");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AuctionBetsHub>("/hubs/bet");
                endpoints.MapDefaultControllerRoute();
            });             

            dbInitializer.InitializeDb();

        }
    }
}
