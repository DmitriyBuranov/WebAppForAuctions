using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PublicSale.NotificationService.Core.Abstractions;
using PublicSale.NotificationService.DataAccess;
using PublicSale.NotificationService.DataAccess.Data;
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

            //services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
