using GerenciadorJogosBasquete.Domain.Interfaces.Repositories;
using GerenciadorJogosBasquete.Domain.Interfaces.Services;
using System.Collections.Generic;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Entities;
using System.Linq;
using GerenciadorJogosBasquete.Domain.Enums;
using GerenciadorJogosBasquete.Domain.Interfaces.Comum;

namespace GerenciadorJogosBasquete.Domain.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _repository;

        public JogoService(IJogoRepository repository)
        {
            _repository = repository;
        }

        public IResultado AddJogo(JogoBasquete jogoBasquete)
        {
            return _repository.AddJogo(jogoBasquete);
        }

        public IResultado<IEnumerable<JogoBasquete>> GetJogos()
        {
            return _repository.GetJogos();
        }

        public IResultado<ResultadoJogos> GetResultadoJogos()
        {
            var result = _repository.GetJogos();

            if (result.Status == StatusResultado.Sucesso)
            {
                if (result.Valor.Any())
                {                    
                    var resultadoJogos = new ResultadoJogos(result.Valor);

                    resultadoJogos.CalcularResultados();

                    return new Resultado<ResultadoJogos>
                    (
                        StatusResultado.Sucesso, 
                        resultadoJogos
                    );
                }
            }

            return new Resultado<ResultadoJogos>
            (
                result.Mensagem,
                result.Status, 
                new ResultadoJogos()
            );
        }
    }
}
