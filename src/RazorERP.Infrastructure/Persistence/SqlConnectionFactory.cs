using Microsoft.Data.SqlClient;
using RazorERP.Application.Interfaces;

namespace RazorERP.Infrastructure.Persistence
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connString;

        public SqlConnectionFactory(string connString)
        {
            _connString = connString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connString);
        }
    }
}