using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorJogosBasquete.Api.Dto
{
    /// <summary>
    ///     Informações necessárias para adicionar um novo jogo de basquete.
    /// </summary>
    public class JogoBasqueteRequestDto
    {
        /// <summary>
        ///     Data do novo jogo de basquete.
        /// </summary>
        [Required]
        public DateTime DataJogo { get; set; }

        /// <summary>
        ///     Quantidade total de pontos do jogador na partida.
        /// </summary>
        [Required]
        public int QtdPontos { get; set; }
    }
}
