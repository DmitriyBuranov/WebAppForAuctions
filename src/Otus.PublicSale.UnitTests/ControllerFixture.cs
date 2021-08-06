using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otus.PublicSale.WebApi;
using System;

namespace Otus.PublicSale.UnitTests
{
    /// <summary>
    /// Controller Fixture
    /// </summary>
    public class ControllerFixture: IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ControllerFixture()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();
            var serviceCollection = new ServiceCollection();
            new Startup(configuration).ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            
        }
    }
}
