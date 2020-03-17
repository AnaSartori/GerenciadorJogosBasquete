using GerenciadorJogosBasquete.Comum.Enums;
using GerenciadorJogosBasquete.Comum.Interfaces;

namespace GerenciadorJogosBasquete.Comum
{
    public class Resultado : IResultado
    {
        public string Mensagem { get; }
        public StatusResultado Status { get; }

        public Resultado(StatusResultado status)
        {
            Mensagem = string.Empty;
            Status = status;
        }

        public Resultado(string mensagem, StatusResultado status)
        {
            Mensagem = mensagem;
            Status = status;
        }
    }

    public class Resultado<T> : IResultado<T>
    {
        public string Mensagem { get; }
        public StatusResultado Status { get; }
        public T Valor { get; }

        public Resultado(StatusResultado status, T valor)
        {
            Mensagem = string.Empty;
            Status = status;
            Valor = valor;
        }

        public Resultado(string mensagem, StatusResultado status, T valor)
        {
            Mensagem = mensagem;
            Status = status;
            Valor = valor;
        }
    }
}
