using System.Collections.Generic;
using GerenciadorJogosBasquete.Comum.Interfaces;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Entities;

namespace GerenciadorJogosBasquete.Domain.Interfaces.Services
{
    public interface IJogoService
    {
        IResultado AddJogo(JogoBasquete jogoBasquete);

        IResultado<IEnumerable<JogoBasquete>> GetJogos();

        IResultado<ResultadoJogos> GetResultadoJogos();
    }
}
