using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Procurement.Configuration
{
    public class Connections:IDisposable
    {
        protected readonly static string connectiongStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected SqlConnection _connection;
        protected SqlConnection connection => connection ?? (_connection = getOpenConnection());

        public static SqlConnection getOpenConnection(bool mars = false)
        {
            var cs = connectiongStr;
            if (mars)
            {
                var scs = new SqlConnectionStringBuilder(cs)
                {
                    MultipleActiveResultSets = true
                };
                cs = scs.ConnectionString;
            }
            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            connection?.Dispose();
        }
    }
}
