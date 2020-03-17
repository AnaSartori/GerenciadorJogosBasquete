using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorJogosBasquete.Domain.Dto
{
    public class JogoBasquete   
    {
        public int IdJogo { get; }

        [Required]
        public DateTime DataJogo { get; }

        [Required]
        public int QtdPontos { get; }

        public JogoBasquete(int idJogo, DateTime dataJogo, int qtdPontos)
        {
            IdJogo = idJogo;
            DataJogo = dataJogo;
            QtdPontos = qtdPontos;
        }
    }
}
