using Base.Core;
using Microsoft.Data.SqlClient;
using System.Data;


namespace Base.Infrastructure.Dapper
{
    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;

        public DapperContext(DapperSettings settings)
        {
            _connectionString = settings.ConnectionString;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
