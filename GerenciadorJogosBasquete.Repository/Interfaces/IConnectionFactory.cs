using System.Data;

namespace GerenciadorJogosBasquete.Repository.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
