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
                     
            // Identity server staff
            //services.AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication("Bearer", options =>
            //    {
            //        options.ApiName = "otus.publicsale.webapi";
            //        options.Authority = "https://localhost:44337";
            //    });

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

            // Identity server staff
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Protected API", Version = "v1" });

            //    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //    {
            //        Type = SecuritySchemeType.OAuth2,
            //        Flows = new OpenApiOAuthFlows
            //        {
            //            AuthorizationCode = new OpenApiOAuthFlow
            //            {
            //                AuthorizationUrl = new Uri("https://localhost:44337/connect/authorize"),
            //                TokenUrl = new Uri("https://localhost:44337/connect/token"),
            //                Scopes = new Dictionary<string, string>
            //                {
            //                    {"otus.publicsale.webapi", "PublicSale WebApi - full access"}
            //                }
            //            }
            //        }
            //    });
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    options.IncludeXmlComments(xmlPath);

            //    options.OperationFilter<AuthorizeCheckOperationFilter>();
            //});

            services.AddSwaggerDocumentation();

            // Redis
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

            // Identity server staff
            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "PublicSale WebApi V1");
            //    options.OAuthClientId("Otus.PublicSale.WebApi");
            //    options.OAuthClientSecret("secret");
            //    options.OAuthAppName("PublicSale WebApi - Swagger");
            //    options.OAuthScopes(new[] { "otus.publicsale.webapi" });
            //    options.OAuthUsePkce();
            //});

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

    // Identity server staff
    //public class AuthorizeCheckOperationFilter : IOperationFilter
    //{
    //    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    //    {
    //        var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
    //                           context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

    //        if (hasAuthorize)
    //        {
    //            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
    //            operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

    //            operation.Security = new List<OpenApiSecurityRequirement>
    //            {
    //                new OpenApiSecurityRequirement
    //                {
    //                    [new OpenApiSecurityScheme {Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "oauth2"}}]
    //                        = new[] { "otus.publicsale.webapi" }
    //                }
    //            };
    //        }
    //    }
    //}
}
