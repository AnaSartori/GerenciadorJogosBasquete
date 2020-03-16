using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorJogosBasquete.Domain.Dto
{
    public class JogoBasquete   
    {
        public int IdJogo { get; private set; }

        [Required]
        public DateTime DataJogo { get; private set; }

        [Required]
        public int QtdPontos { get; private set; }

        public JogoBasquete(int idJogo, DateTime dataJogo, int qtdPontos)
        {
            IdJogo = idJogo;
            DataJogo = dataJogo;
            QtdPontos = qtdPontos;
        }
    }
}
