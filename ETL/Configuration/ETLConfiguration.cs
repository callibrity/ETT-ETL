using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETL.Configuration
{
    public static class ETLConfiguration
    {
        private static IConfigurationRoot configuration;
        static ETLConfiguration()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            string dir = System.AppDomain.CurrentDomain.BaseDirectory;
            configuration = new ConfigurationBuilder()
                .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
        }

        public static string GetValue(string configurationKey)
        {
            string result = Environment.GetEnvironmentVariable(configurationKey.ToUpper());
            if (String.IsNullOrEmpty(result))
                result = configuration.GetSection(configurationKey).Value;
            Console.WriteLine(result);
            Console.WriteLine(configurationKey);
            return result;
        }
    }
}
