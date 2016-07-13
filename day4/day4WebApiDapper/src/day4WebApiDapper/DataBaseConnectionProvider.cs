using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace day4WebApiDapper
{
    public class DataBaseConnectionProvider
    {
        public IDbConnection GetConnection(String connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
