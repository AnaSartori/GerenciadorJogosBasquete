using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorJogosBasquete.Domain.Test.Entities
{
    public class ResultadoJogosTest
    {
        private ResultadoJogos _resultadoJogos;
        private IEnumerable<JogoBasquete> _listaJogosTeste;

        [SetUp]
        public void Setup()
        {
            _resultadoJogos = new ResultadoJogos();

            _listaJogosTeste = new List<JogoBasquete>
            {
                new JogoBasquete(1, new DateTime(2019, 8, 10), 3),
                new JogoBasquete(2, new DateTime(2019, 10, 5), 10),
                new JogoBasquete(3, new DateTime(2019, 12, 15), 5),
                new JogoBasquete(4, new DateTime(2020, 1, 12), 15),
                new JogoBasquete(5, new DateTime(2020, 3, 7), 12)
            };
        }

        [Test]
        public void Domain_Deve_Inicializar_Lista_De_Jogos()
        {
            Assert.AreEqual(false, _resultadoJogos.JogosBasquete.Any());

            _resultadoJogos = new ResultadoJogos(_listaJogosTeste);

            Assert.AreEqual(true, _resultadoJogos.JogosBasquete.Any());
            Assert.AreEqual(5, _resultadoJogos.JogosBasquete.Count());
        }

        [Test]
        public void Domain_Deve_Calcular_Resultados_Dos_Jogos()
        {
            _resultadoJogos = new ResultadoJogos(_listaJogosTeste);

            Assert.AreEqual(true, _resultadoJogos.JogosBasquete.Any());
            Assert.AreEqual(5, _resultadoJogos.JogosBasquete.Count());

            _resultadoJogos.CalcularResultados();

            Assert.AreEqual(new DateTime(2019, 8, 10), _resultadoJogos.DataPrimeiroJogo);
            Assert.AreEqual(new DateTime(2020, 3, 7), _resultadoJogos.DataUltimoJogo);
            Assert.AreEqual(5, _resultadoJogos.TotalJogos);
            Assert.AreEqual(45, _resultadoJogos.TotalPontos);
            Assert.AreEqual(9, _resultadoJogos.MediaPontos);
            Assert.AreEqual(15, _resultadoJogos.MaiorPontuacao);
            Assert.AreEqual(3, _resultadoJogos.MenorPontuacao);
            Assert.AreEqual(2, _resultadoJogos.QtdRecorde);
        }

        
        [Test]
        public void Domain_Deve_Retornar_Recorde_Igual_A_Zero()
        {
            _listaJogosTeste = new List<JogoBasquete>
            {
                new JogoBasquete(1, new DateTime(2019, 8, 10), 10),
            };

            _resultadoJogos = new ResultadoJogos(_listaJogosTeste);
            _resultadoJogos.CalcularResultados();

            Assert.AreEqual(0, _resultadoJogos.QtdRecorde);


            _listaJogosTeste = new List<JogoBasquete>
            {
                new JogoBasquete(1, new DateTime(2019, 8, 10), 10),
                new JogoBasquete(1, new DateTime(2020, 10, 10), 10)
            };

            _resultadoJogos = new ResultadoJogos(_listaJogosTeste);
            _resultadoJogos.CalcularResultados();

            Assert.AreEqual(0, _resultadoJogos.QtdRecorde);
        }
    }
}