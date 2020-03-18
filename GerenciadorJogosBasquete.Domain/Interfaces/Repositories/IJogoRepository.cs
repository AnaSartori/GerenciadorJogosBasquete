using System.Collections.Generic;
using GerenciadorJogosBasquete.Comum.Interfaces;
using GerenciadorJogosBasquete.Domain.Dto;

namespace GerenciadorJogosBasquete.Domain.Interfaces.Repositories
{
    public interface IJogoRepository
    {
        IResultBag AddJogo(JogoBasquete jogoBasquete);

        IResultBag<IEnumerable<JogoBasquete>> GetJogos();
    }
}
