using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.DataAccess.Data;
using Otus.PublicSale.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MassTransit;
using System;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

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

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "otus.publicsale.webapi";
                    options.Authority = "https://localhost:44337";
                });


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

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Protected API", Version = "v1" });

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:44337/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:44337/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"otus.publicsale.webapi", "PublicSale WebApi - full access"}
                            }
                        }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PublicSale WebApi V1");
                options.OAuthClientId("Otus.PublicSale.WebApi");
                options.OAuthClientSecret("secret");
                options.OAuthAppName("PublicSale WebApi - Swagger");
                options.OAuthScopes(new[] { "otus.publicsale.webapi" });
                options.OAuthUsePkce();
            });

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }

    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                               context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (hasAuthorize)
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [new OpenApiSecurityScheme {Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "oauth2"}}]
                            = new[] { "otus.publicsale.webapi" }
                    }
                };
            }
        }
    }
}
