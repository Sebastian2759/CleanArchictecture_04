using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Context.Configuration
{
    public class ConfigurationDbContextTienda
    {
        private readonly string _connectionString;
        public ConfigurationDbContextTienda(string connectionString)
        {
            _connectionString = connectionString;
        }
        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
