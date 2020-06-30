using Npgsql;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETL.Repository
{
    public class DBConnection : IDisposable
    {
        public bool IsConnectionOpen
        {
            get
            {
                return connection.State == System.Data.ConnectionState.Open;
            }
            private set { }
        }
        private static IConfigurationRoot configuration;
        private NpgsqlConnection connection;

        public DBConnection()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            String connectionString = GetConnectionString();
            connection = new NpgsqlConnection(connectionString);
        }

        public void Connect()
        {
            connection.Open();
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public List<T> ExecuteQuery<T>(string query)
        {
            var cmd = new NpgsqlCommand(query, connection);
            List<T> result = new List<T>();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                object[] arr = new object[reader.VisibleFieldCount];
                for(int i = 0; i < reader.VisibleFieldCount; i++)
                {
                    arr[i] = reader.GetValue(i);
                }
                T obj = (T)Activator.CreateInstance(typeof(T), arr);
                result.Add(obj);
            }

            return result;
        }

        public int ExecuteNonQuery(string query)
        {
            var cmd = new NpgsqlCommand(query, connection);
            return cmd.ExecuteNonQuery();
        }

        private string  GetConnectionString()
        {
            string host = configuration.GetConnectionString("Host");
            string username = configuration.GetConnectionString("UserName");
            string password = configuration.GetConnectionString("Password");
            string database = configuration.GetConnectionString("Database");
            return $"Host={host};Username={username};Password={password};Database={database}";
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

    }
}