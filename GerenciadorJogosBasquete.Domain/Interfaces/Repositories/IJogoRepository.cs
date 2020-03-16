using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Interfaces.Comum;
using System.Collections.Generic;

namespace GerenciadorJogosBasquete.Domain.Interfaces.Repositories
{
    public interface IJogoRepository
    {
        IResultado AddJogo(JogoBasquete jogoBasquete);

        IResultado<IEnumerable<JogoBasquete>> GetJogos();
    }
}
