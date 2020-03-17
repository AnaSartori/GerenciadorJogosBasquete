using GerenciadorJogosBasquete.Comum.Enums;
using NUnit.Framework;

namespace GerenciadorJogosBasquete.Comum.Test
{
    public class ResultadoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Deve_Retornar_Resultado_Com_Sucesso_Com_Valor()
        {
            var resultado = new Resultado<int>(StatusResultado.Sucesso, 100);

            Assert.AreEqual(string.Empty, resultado.Mensagem);
            Assert.AreEqual(StatusResultado.Sucesso, resultado.Status);
            Assert.AreEqual(100, resultado.Valor);
        }

        [Test]
        public void Deve_Retornar_Resultado_Com_Sucesso_Sem_Valor()
        {
            var resultado = new Resultado(StatusResultado.Sucesso);

            Assert.AreEqual(string.Empty, resultado.Mensagem);
            Assert.AreEqual(StatusResultado.Sucesso, resultado.Status);

            var resultadoComMsg = new Resultado("Retornado com Sucesso!", StatusResultado.Sucesso);

            Assert.AreEqual("Retornado com Sucesso!", resultadoComMsg.Mensagem);
            Assert.AreEqual(StatusResultado.Sucesso, resultadoComMsg.Status);
        }

        [Test]
        public void Deve_Retornar_Resultado_Com_Erro_Com_Valor()
        {
            var resultado = new Resultado<int>("Erro", StatusResultado.Erro, 0);

            Assert.AreEqual("Erro", resultado.Mensagem);
            Assert.AreEqual(StatusResultado.Erro, resultado.Status);
            Assert.AreEqual(0, resultado.Valor);
        }

        [Test]
        public void Deve_Retornar_Resultado_Com_Erro_Sem_Valor()
        {
            var resultado = new Resultado("Erro", StatusResultado.Erro);

            Assert.AreEqual("Erro", resultado.Mensagem);
            Assert.AreEqual(StatusResultado.Erro, resultado.Status);
        }
    }
}