using System;
using System.Collections.Generic;
using System.Linq;
using GerenciadorJogosBasquete.Comum;
using GerenciadorJogosBasquete.Comum.Interfaces;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Entities;
using GerenciadorJogosBasquete.Domain.Interfaces.Repositories;
using GerenciadorJogosBasquete.Domain.Interfaces.Services;

namespace GerenciadorJogosBasquete.Domain.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _repository;

        public JogoService(IJogoRepository repository)
        {
            _repository = repository;
        }

        public IResultBag AddJogo(DateTime data, int pontos)
        {
            return _repository.AddJogo(new JogoBasquete(data, pontos));
        }

        public IResultBag<IEnumerable<JogoBasquete>> GetJogos()
        {
            return _repository.GetJogos();
        }

        public IResultBag<ResultadoJogos> GetResultadoJogos()
        {
            var result = _repository.GetJogos();

            if (result.IsSuccess && result.Data.Any())
            {
                var resultadoJogos = new ResultadoJogos(result.Data);

                resultadoJogos.CalcularResultados();

                return new ResultBag<ResultadoJogos>
                (
                    true,
                    resultadoJogos
                );
            }

            return new ResultBag<ResultadoJogos>
            (
                result.Message,
                result.IsSuccess,
                new ResultadoJogos()
            );
        }
    }
}
