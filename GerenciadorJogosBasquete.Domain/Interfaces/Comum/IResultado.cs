using GerenciadorJogosBasquete.Domain.Enums;

namespace GerenciadorJogosBasquete.Domain.Interfaces.Comum
{
    public interface IResultado
    {
        string Mensagem { get; }
        StatusResultado Status { get; }
    }

    public interface IResultado<T> : IResultado
    {
        T Valor { get; }
    }
}
