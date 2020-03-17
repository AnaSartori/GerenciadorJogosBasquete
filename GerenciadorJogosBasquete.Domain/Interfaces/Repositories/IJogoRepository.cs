using System.Collections.Generic;
using GerenciadorJogosBasquete.Comum.Interfaces;
using GerenciadorJogosBasquete.Domain.Dto;

namespace GerenciadorJogosBasquete.Domain.Interfaces.Repositories
{
    public interface IJogoRepository
    {
        IResultado AddJogo(JogoBasquete jogoBasquete);

        IResultado<IEnumerable<JogoBasquete>> GetJogos();
    }
}
