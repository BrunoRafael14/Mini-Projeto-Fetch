using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace back_end.Repositories
{
    public class DbConnectionFactory
    {
        private readonly String _dbSettings;

        public DbConnectionFactory()
        {
            _dbSettings = "Host=localhost;Port=5432;Database=miniprojetofetch;Username=postgres;Password=Brutn15000;";
        }

        public NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_dbSettings);
        }
    }
}