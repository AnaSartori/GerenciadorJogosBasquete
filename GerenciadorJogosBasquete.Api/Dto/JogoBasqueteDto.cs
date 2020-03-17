using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorJogosBasquete.Api.Dto
{
    public class JogoBasqueteDto
    {
        public int IdJogo { get; set; }

        [Required]
        public DateTime DataJogo { get; set; }

        [Required]
        public int QtdPontos { get; set; }
    }
}
