namespace GerenciadorJogosBasquete.Comum.Interfaces
{
    public interface IResultBag
    {
        string Message { get; }
        bool IsSuccess { get; }
    }

    public interface IResultBag<T> : IResultBag
    {
        T Data { get; }
    }
}
