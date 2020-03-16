using GerenciadorJogosBasquete.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GerenciadorJogosBasquete.Repository.Connection
{
    public class DefaultSqlConnectionFactory : IConnectionFactory
    {
        IConfiguration _configuration;

        public DefaultSqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection()
        {
            var connectionString = GetConnection();
            return new SqlConnection(connectionString);
        }

        private string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("JogoBasqueteConnection").Value;
            return connection;
        }
    }
}
