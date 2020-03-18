using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Repository.Interfaces;
using GerenciadorJogosBasquete.Repository.Repositories;
using Moq;
using NUnit.Framework;

namespace GerenciadorJogosBasquete.Repository.Test.Repositories
{
    public class JogoRepositoryTest
    {
        private Mock<IConnectionFactory> _mockConnection;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<IConnectionFactory>();
        }

        [Test]
        public void Repository_Deve_Retornar_Jogos_Com_Erro()
        {
            _mockConnection.Setup(s => s.Connection()).Throws(new Exception("Erro no banco de dados!"));

            var jogoRepository = new JogoRepository(_mockConnection.Object);
            var result = jogoRepository.GetJogos();

            Assert.AreEqual("Erro no banco de dados!", result.Message);
            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual(new List<JogoBasquete>(), result.Data);
        }

        [Test]
        public void Repository_Deve_Retornar_Resultado_No_Repository()
        {
            _mockConnection.Setup(s => s.Connection()).Returns(new SqlConnection(""));
            var jogoRepository = new JogoRepository(_mockConnection.Object);

            var resultTipado = jogoRepository.GetJogos();

            Assert.NotNull(resultTipado.Data);
            Assert.NotNull(resultTipado.IsSuccess);


            var jogoBasquete = new JogoBasquete(DateTime.Now, 10);

            var resultNoValue = jogoRepository.AddJogo(jogoBasquete);

            Assert.NotNull(resultNoValue.IsSuccess);

            _mockConnection.Verify(v => v.Connection(), Times.Exactly(2));
        }
    }
}