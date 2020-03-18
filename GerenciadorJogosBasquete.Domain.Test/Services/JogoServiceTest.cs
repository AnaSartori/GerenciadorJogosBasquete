using GerenciadorJogosBasquete.Comum;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Interfaces.Repositories;
using GerenciadorJogosBasquete.Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using GerenciadorJogosBasquete.Domain.Entities;

namespace GerenciadorJogosBasquete.Domain.Test.Services
{
    public class JogoServiceTest
    {
        private Mock<IJogoRepository> _mockJogoRepository;
        private IEnumerable<JogoBasquete> _listaJogosTeste;

        [SetUp]
        public void Setup()
        {
            _mockJogoRepository = new Mock<IJogoRepository>();

            _listaJogosTeste = new List<JogoBasquete>
            {
                new JogoBasquete(1, new DateTime(2019, 8, 10), 3),
                new JogoBasquete(2, new DateTime(2019, 10, 5), 10)
            };
        }

        [Test]
        public void Domain_Deve_Adicionar_Novo_Jogo()
        {
            var novoJogo = new JogoBasquete(0, DateTime.Now, 25);
            var expectResult = new ResultBag(true);

            _mockJogoRepository.Setup(s => s.AddJogo(It.IsAny<JogoBasquete>())).Returns(expectResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.AddJogo(novoJogo.DataJogo, novoJogo.QtdPontos);

            _mockJogoRepository.Verify(v => v.AddJogo(It.IsAny<JogoBasquete>()), Times.Once);

            Assert.AreEqual(expectResult.Message, result.Message);
            Assert.AreEqual(expectResult.IsSuccess, result.IsSuccess);
        }

        [Test]
        public void Domain_Deve_Retornar_Erro_Ao_Adicionar_Novo_Jogo()
        {
            var novoJogo = new JogoBasquete(0, DateTime.Now, 25);
            var expectResult = new ResultBag("Erro ao adicionar novo Jogo!", false);

            _mockJogoRepository.Setup(s => s.AddJogo(It.IsAny<JogoBasquete>())).Returns(expectResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.AddJogo(novoJogo.DataJogo, novoJogo.QtdPontos);

            _mockJogoRepository.Verify(v => v.AddJogo(It.IsAny<JogoBasquete>()), Times.Once);

            Assert.AreEqual(expectResult.Message, result.Message);
            Assert.AreEqual(expectResult.IsSuccess, result.IsSuccess);
        }

        [Test]
        public void Domain_Deve_Retornar_Todos_Jogos()
        {
            var expectResult = new ResultBag<IEnumerable<JogoBasquete>>(true, _listaJogosTeste);

            _mockJogoRepository.Setup(s => s.GetJogos()).Returns(expectResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.GetJogos();

            _mockJogoRepository.Verify(v => v.GetJogos(), Times.Once);

            Assert.AreEqual(expectResult.Message, result.Message);
            Assert.AreEqual(expectResult.IsSuccess, result.IsSuccess);
            Assert.AreEqual(expectResult.Data, result.Data);
        }

        [Test]
        public void Domain_Deve_Retornar_Resultados_Dos_Jogos_Com_Sucesso()
        {
            var expectRepositoryResult = new ResultBag<IEnumerable<JogoBasquete>>(true, _listaJogosTeste);

            _mockJogoRepository.Setup(s => s.GetJogos()).Returns(expectRepositoryResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.GetResultadoJogos();

            _mockJogoRepository.Verify(v => v.GetJogos(), Times.Once);

            Assert.AreEqual(expectRepositoryResult.Message, result.Message);
            Assert.AreEqual(expectRepositoryResult.IsSuccess, result.IsSuccess);
            Assert.AreEqual(expectRepositoryResult.Data, result.Data.JogosBasquete);
            Assert.AreEqual(13, result.Data.TotalPontos);
            Assert.AreEqual(2, result.Data.TotalJogos);
        }

        [Test]
        public void Domain_Deve_Retornar_Resultados_Dos_Jogos_Com_Sucesso_Se_Lista_Vazia()
        {
            var expectRepositoryResult = new ResultBag<IEnumerable<JogoBasquete>>(true, new List<JogoBasquete>());
            var expectServiceResult = new ResultBag<ResultadoJogos>(expectRepositoryResult.Message, expectRepositoryResult.IsSuccess, new ResultadoJogos());

            _mockJogoRepository.Setup(s => s.GetJogos()).Returns(expectRepositoryResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.GetResultadoJogos();

            _mockJogoRepository.Verify(v => v.GetJogos(), Times.Once);

            Assert.AreEqual(expectServiceResult.Message, result.Message);
            Assert.AreEqual(expectServiceResult.IsSuccess, result.IsSuccess);
            Assert.AreEqual(expectRepositoryResult.Data, result.Data.JogosBasquete);
        }

        [Test]
        public void Domain_Deve_Retornar_Resultados_Dos_Jogos_Com_Erro()
        {
            var expectRepositoryResult = new ResultBag<IEnumerable<JogoBasquete>>("Erro ao retornar jogos!", false, new List<JogoBasquete>());

            _mockJogoRepository.Setup(s => s.GetJogos()).Returns(expectRepositoryResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.GetResultadoJogos();

            _mockJogoRepository.Verify(v => v.GetJogos(), Times.Once);

            Assert.AreEqual(expectRepositoryResult.Message, result.Message);
            Assert.AreEqual(expectRepositoryResult.IsSuccess, result.IsSuccess);
            Assert.IsFalse(result.Data.JogosBasquete.Any());
            Assert.AreEqual(0, result.Data.TotalPontos);
            Assert.AreEqual(0, result.Data.TotalJogos);
        }
    }
}