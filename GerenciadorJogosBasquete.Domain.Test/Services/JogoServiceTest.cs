using GerenciadorJogosBasquete.Comum;
using GerenciadorJogosBasquete.Comum.Enums;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Entities;
using GerenciadorJogosBasquete.Domain.Interfaces.Repositories;
using GerenciadorJogosBasquete.Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void Deve_Adicionar_Novo_Jogo()
        {
            var novoJogo = new JogoBasquete(6, DateTime.Now, 25);
            var expectResult = new Resultado(StatusResultado.Sucesso);

            _mockJogoRepository.Setup(s => s.AddJogo(It.IsAny<JogoBasquete>())).Returns(expectResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.AddJogo(novoJogo);

            _mockJogoRepository.Verify(v => v.AddJogo(novoJogo), Times.Once);

            Assert.AreEqual(expectResult.Mensagem, result.Mensagem);
            Assert.AreEqual(expectResult.Status, result.Status);
        }

        [Test]
        public void Deve_Retornar_Erro_Ao_Adicionar_Novo_Jogo()
        {
            var novoJogo = new JogoBasquete(6, DateTime.Now, 25);
            var expectResult = new Resultado("Erro ao adicionar novo Jogo!", StatusResultado.Erro);

            _mockJogoRepository.Setup(s => s.AddJogo(It.IsAny<JogoBasquete>())).Returns(expectResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.AddJogo(novoJogo);

            _mockJogoRepository.Verify(v => v.AddJogo(novoJogo), Times.Once);

            Assert.AreEqual(expectResult.Mensagem, result.Mensagem);
            Assert.AreEqual(expectResult.Status, result.Status);
        }
        
        [Test]
        public void Deve_Retornar_Todos_Jogos()
        {
            var expectResult =  new Resultado<IEnumerable<JogoBasquete>>(StatusResultado.Sucesso, _listaJogosTeste);

            _mockJogoRepository.Setup(s => s.GetJogos()).Returns(expectResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.GetJogos();

            _mockJogoRepository.Verify(v => v.GetJogos(), Times.Once);

            Assert.AreEqual(expectResult.Mensagem, result.Mensagem);
            Assert.AreEqual(expectResult.Status, result.Status);
            Assert.AreEqual(expectResult.Valor, result.Valor);
        }

        [Test]
        public void Deve_Retornar_Resultados_Dos_Jogos_Com_Sucesso()
        {
            var expectRepositoryResult = new Resultado<IEnumerable<JogoBasquete>>(StatusResultado.Sucesso, _listaJogosTeste);

            _mockJogoRepository.Setup(s => s.GetJogos()).Returns(expectRepositoryResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.GetResultadoJogos();

            _mockJogoRepository.Verify(v => v.GetJogos(), Times.Once);

            Assert.AreEqual(expectRepositoryResult.Mensagem, result.Mensagem);
            Assert.AreEqual(expectRepositoryResult.Status, result.Status);
            Assert.AreEqual(expectRepositoryResult.Valor, result.Valor.JogosBasquete);
            Assert.AreEqual(13, result.Valor.TotalPontos);
            Assert.AreEqual(2, result.Valor.TotalJogos);
        }

        [Test]
        public void Deve_Retornar_Resultados_Dos_Jogos_Com_Erro()
        {
            var expectRepositoryResult = new Resultado<IEnumerable<JogoBasquete>>("Erro ao retornar jogos!", StatusResultado.Erro, new List<JogoBasquete>());

            _mockJogoRepository.Setup(s => s.GetJogos()).Returns(expectRepositoryResult);

            var jogoService = new JogoService(_mockJogoRepository.Object);
            var result = jogoService.GetResultadoJogos();

            _mockJogoRepository.Verify(v => v.GetJogos(), Times.Once);

            Assert.AreEqual(expectRepositoryResult.Mensagem, result.Mensagem);
            Assert.AreEqual(expectRepositoryResult.Status, result.Status);
            Assert.AreEqual(false, result.Valor.JogosBasquete.Any());
            Assert.AreEqual(0, result.Valor.TotalPontos);
            Assert.AreEqual(0, result.Valor.TotalJogos);
        }
    }
}