using System;
using NUnit.Framework;
using System.Collections.Generic;
using AutoMapper;
using GerenciadorJogosBasquete.Api.Controllers;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Interfaces.Services;
using Moq;
using GerenciadorJogosBasquete.Comum;
using GerenciadorJogosBasquete.Comum.Enums;

namespace GerenciadorJogosBasquete.Api.Test.Controllers
{
    public class JogoControllerTest
    {
        private readonly Mock<IJogoService> _mockService = new Mock<IJogoService>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private IEnumerable<JogoBasquete> _listaJogosTeste;


        [SetUp]
        public void Setup()
        {
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
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GetJogos_Deve_Retornar_Todos_Os_Jogos()
        {
            var expectResult = new Resultado<IEnumerable<JogoBasquete>>(StatusResultado.Sucesso, _listaJogosTeste);

            _mockService.Setup(mock => mock.GetJogos()).Returns(expectResult);

            var jogoController = new JogoController(_mockService.Object, _mockMapper.Object);

            var result = jogoController.GetJogos() as Resultado<IEnumerable<JogoBasquete>>;

            Assert.AreEqual(expectResult.Status, result.Status);
            Assert.AreEqual(expectResult.Mensagem, result.Mensagem);
            Assert.AreEqual(expectResult.Valor, result.Valor);
        }
    }
}