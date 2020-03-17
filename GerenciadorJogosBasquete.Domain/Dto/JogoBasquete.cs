using System;

namespace GerenciadorJogosBasquete.Domain.Dto
{
    public class JogoBasquete
    {
        public int IdJogo { get; }

        public DateTime DataJogo { get; }

        public int QtdPontos { get; }

        public JogoBasquete(DateTime dataJogo, int qtdPontos)
        {
            DataJogo = dataJogo;
            QtdPontos = qtdPontos;
        }

        public JogoBasquete(int idJogo, DateTime dataJogo, int qtdPontos)
        {
            IdJogo = idJogo;
            DataJogo = dataJogo;
            QtdPontos = qtdPontos;
        }
    }
}
