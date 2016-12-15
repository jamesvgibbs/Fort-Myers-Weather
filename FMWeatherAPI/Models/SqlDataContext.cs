using FMWeatherAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FMWeatherAPI.Models
{
    public class SqlDataContext : ISqlDataContext, IDisposable
    {
        private readonly SqlConnection _connection;
        private SqlCommand _command;

        public SqlDataContext(string connectionString)
        {
            _connection = CreateConnection(connectionString);
        }

        public SqlDataContext()
        {
            var connStr = ConfigurationManager.ConnectionStrings["WeatherConnectionString"].ConnectionString;

            _connection = CreateConnection(connStr);
        }

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
                _command.Dispose();
            }
        }

        public IDataReader ExecuteReader(string storedProcedureName, ICollection<SqlParameter> parameters)
        {
            // execute the command here using the _connection private field.
            // This is where your conn.Open() and "do stuff" happens.

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            _command = new SqlCommand(storedProcedureName, _connection);
            _command.CommandType = CommandType.StoredProcedure;
            if (parameters != null && parameters.Count() > 0)
            {
                foreach (var param in parameters)
                {
                    _command.Parameters.Add(param);
                }
            }
            return _command.ExecuteReader();
        }

        private SqlConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            return new SqlConnection(connectionString);
        }
    }
}
