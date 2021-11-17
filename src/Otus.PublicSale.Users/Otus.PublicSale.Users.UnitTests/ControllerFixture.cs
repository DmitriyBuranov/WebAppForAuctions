﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otus.PublicSale.Users.WebApi;
using System;

namespace Otus.PublicSale.Users.UnitTests
{
    /// <summary>
    /// Controller Fixture
    /// </summary>
    public class ControllerFixture : IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ControllerFixture()
        {
            //TODO - errors here
            //var builder = new ConfigurationBuilder();
            //builder.AddJsonFile("appsettings.json", false, true);
            //var configuration = builder.Build();
            //var serviceCollection = new ServiceCollection();
            //var testWebHostEnvironment = new TestWebHostEnvironment();
            //new Startup(configuration, testWebHostEnvironment).ConfigureServices(serviceCollection);
            //var serviceProvider = serviceCollection.BuildServiceProvider();
            //ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {

        }
    }
}
