using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ConnectionString
    {

        public static string GetConnection()
        {

            var sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",         // e.g., "localhost"
                InitialCatalog = "bayer-health-care-dev",   // e.g., "MyDatabase"
                IntegratedSecurity = true                // or use UserID & Password
            };

            var entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sqlBuilder.ToString(),
                Metadata = "res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl"
            };

            string efConnectionString = entityBuilder.ToString();

            return efConnectionString;

        }
    }
}
