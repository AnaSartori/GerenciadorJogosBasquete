using System;
using NUnit.Framework;
using System.Collections.Generic;
using GerenciadorJogosBasquete.Api.Controllers;
using GerenciadorJogosBasquete.Api.Dto;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Interfaces.Services;
using Moq;
using GerenciadorJogosBasquete.Comum;
using GerenciadorJogosBasquete.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorJogosBasquete.Api.Test.Controllers
{
    public class JogoControllerTest
    {
        private Mock<IJogoService> _mockService;
        private IEnumerable<JogoBasquete> _listaJogosTeste;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IJogoService>();

            _listaJogosTeste = new List<JogoBasquete>
            {
                new JogoBasquete(1, new DateTime(2019, 8, 10), 1),
                new JogoBasquete(2, new DateTime(2019, 10, 5), 10),
                new JogoBasquete(3, new DateTime(2019, 12, 15), 5),
                new JogoBasquete(4, new DateTime(2020, 1, 12), 15),
                new JogoBasquete(5, new DateTime(2020, 3, 7), 12)
            };
        }

        [Test]
        public void Api_Deve_Adicionar_Novo_Jogo_Com_Sucesso()
        {
            var newJogo = new JogoBasqueteRequestDto { DataJogo = DateTime.Now, QtdPontos = 10 };

            var expectResult = new ResultBag(true);

            _mockService.Setup(mock => mock.AddJogo(It.IsAny<DateTime>(), It.IsAny<int>())).Returns(expectResult);

            var jogoController = new JogoController(_mockService.Object);
            var result = jogoController.Add(newJogo) as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectResult, result.Value);
        }

        [Test]
        public void Api_Deve_Retornar_Erro_No_AddJogo()
        {
            var jogoRequest = new JogoBasqueteRequestDto { DataJogo = DateTime.Now, QtdPontos = 10 };

            _mockService.Setup(mock => mock.AddJogo(It.IsAny<DateTime>(), It.IsAny<int>()))
                .Throws(new Exception("Erro"));

            var jogoController = new JogoController(_mockService.Object);
            var result = jogoController.Add(jogoRequest) as BadRequestObjectResult;

            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual(false, ((ResultBag)result.Value).IsSuccess);
            Assert.AreEqual("Erro", ((ResultBag)result.Value).Message);
        }

        [Test]
        public void Api_Deve_Retornar_Erro_Data_Invalida_Ao_Adicionar()
        {
            var jogoRequest = new JogoBasqueteRequestDto { DataJogo = DateTime.MinValue, QtdPontos = 10 };

            _mockService.Setup(mock => mock.AddJogo(It.IsAny<DateTime>(), It.IsAny<int>()))
                .Throws(new Exception("Erro"));

            var jogoController = new JogoController(_mockService.Object);
            var result = jogoController.Add(jogoRequest) as BadRequestObjectResult;

            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual(false, ((ResultBag)result.Value).IsSuccess);
            Assert.AreEqual("A data do jogo é inválida.", ((ResultBag)result.Value).Message);
        }

        [Test]
        public void Api_Deve_Retornar_Erro_Qtd_Pontos_Invalida_Ao_Adicionar()
        {
            var jogoRequest = new JogoBasqueteRequestDto { DataJogo = DateTime.Now, QtdPontos = -10 };

            _mockService.Setup(mock => mock.AddJogo(It.IsAny<DateTime>(), It.IsAny<int>()))
                .Throws(new Exception("Erro"));

            var jogoController = new JogoController(_mockService.Object);
            var result = jogoController.Add(jogoRequest) as BadRequestObjectResult;

            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual(false, ((ResultBag)result.Value).IsSuccess);
            Assert.AreEqual("A quantidade de pontos é inválida.", ((ResultBag)result.Value).Message);
        }

        [Test]
        public void Api_Deve_Retornar_Todos_Os_Jogos_Com_Sucesso()
        {
            var expectResult = new ResultBag<IEnumerable<JogoBasquete>>(true, _listaJogosTeste);

            _mockService.Setup(mock => mock.GetJogos()).Returns(expectResult);

            var jogoController = new JogoController(_mockService.Object);
            var result = jogoController.GetJogos() as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectResult, result.Value);
        }

        [Test]
        public void Api_Deve_Retornar_Erro_No_GetJogos()
        {
            _mockService.Setup(mock => mock.GetJogos()).Throws(new Exception("Erro"));

            var jogoController = new JogoController(_mockService.Object);
            var result = jogoController.GetJogos() as BadRequestObjectResult;

            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual(false, ((ResultBag)result.Value).IsSuccess);
            Assert.AreEqual("Erro", ((ResultBag)result.Value).Message);
        }

        [Test]
        public void Api_Deve_Retornar_Os_Resultados_Com_Sucesso()
        {
            var expectResult = new ResultBag<ResultadoJogos>(true, new ResultadoJogos());

            _mockService.Setup(mock => mock.GetResultadoJogos()).Returns(expectResult);

            var jogoController = new JogoController(_mockService.Object);
            var result = jogoController.GetResultadoJogos() as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expectResult, result.Value);
        }

        [Test]
        public void Api_Deve_Retornar_Erro_No_GetResultadoJogos()
        {
            _mockService.Setup(mock => mock.GetResultadoJogos()).Throws(new Exception("Erro"));

            var jogoController = new JogoController(_mockService.Object);
            var result = jogoController.GetResultadoJogos() as BadRequestObjectResult;

            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual(false, ((ResultBag)result.Value).IsSuccess);
            Assert.AreEqual("Erro", ((ResultBag)result.Value).Message);
        }

    }
}