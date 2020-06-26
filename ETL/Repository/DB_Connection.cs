using Npgsql;
using System;

namespace ETL.Repository
{
    public class DB_Connection : IDisposable
    {
        private NpgsqlConnection connection;

        public DB_Connection(string Host, string Username, string Password, string Database)
        {
            connection = new NpgsqlConnection($"Host={Host};Username={Username};Password={Password};Database={Database}");
        }

        public void Connect()
        {
            //TODOvar cmd = new NpgsqlCommand("", connection);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}