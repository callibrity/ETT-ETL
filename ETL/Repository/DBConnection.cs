using Npgsql;
using System;
using System.Collections.Generic;

namespace ETL.Repository
{
    public class DBConnection : IDisposable
    {
        private NpgsqlConnection connection;
        public bool IsConnectionOpen
        {
            get
            {
                return connection.State == System.Data.ConnectionState.Open;
            }
            private set { }
        }

        public DBConnection(string Host, string Username, string Password, string Database)
        {
            connection = new NpgsqlConnection($"Host={Host};Username={Username};Password={Password};Database={Database}");
        }

        public void Connect()
        {
            connection.Open();
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public List<T> executeQuery<T>(string query)
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

        public int executeNonQuery(string query)
        {
            var cmd = new NpgsqlCommand(query, connection);
            return cmd.ExecuteNonQuery();
        }



    }
}