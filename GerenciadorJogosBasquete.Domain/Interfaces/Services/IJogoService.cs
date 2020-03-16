using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Entities;
using GerenciadorJogosBasquete.Domain.Interfaces.Comum;
using System.Collections.Generic;

namespace GerenciadorJogosBasquete.Domain.Interfaces.Services
{
    public interface IJogoService
    {
        IResultado AddJogo(JogoBasquete jogoBasquete);

        IResultado<IEnumerable<JogoBasquete>> GetJogos();

        IResultado<ResultadoJogos> GetResultadoJogos();
    }
}
