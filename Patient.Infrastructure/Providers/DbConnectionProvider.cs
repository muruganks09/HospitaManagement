using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure.Providers
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        readonly ConnectionStrings _connectionStrings;

        public DbConnectionProvider(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public IDbConnection Connection
        {
            get
            {
                var conn = new SqlConnection(_connectionStrings.Default);
                conn.Open();
                return conn;
            }
        }
    }
}
