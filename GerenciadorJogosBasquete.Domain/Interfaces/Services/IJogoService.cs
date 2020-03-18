using System;
using System.Collections.Generic;
using GerenciadorJogosBasquete.Comum.Interfaces;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Entities;

namespace GerenciadorJogosBasquete.Domain.Interfaces.Services
{
    public interface IJogoService
    {
        IResultBag AddJogo(DateTime data, int pontos);

        IResultBag<IEnumerable<JogoBasquete>> GetJogos();

        IResultBag<ResultadoJogos> GetResultadoJogos();
    }
}
