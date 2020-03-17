using NUnit.Framework;

namespace GerenciadorJogosBasquete.Comum.Test
{
    public class ResultBagTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Deve_Retornar_Resultado_Com_Sucesso_Com_Valor()
        {
            var resultado = new ResultBag<int>(true, 100);

            Assert.AreEqual(string.Empty, resultado.Message);
            Assert.AreEqual(true, resultado.IsSuccess);
            Assert.AreEqual(100, resultado.Data);
        }

        [Test]
        public void Deve_Retornar_Resultado_Com_Sucesso_Sem_Valor()
        {
            var resultado = new ResultBag(true);

            Assert.AreEqual(string.Empty, resultado.Message);
            Assert.AreEqual(true, resultado.IsSuccess);

            var resultadoComMsg = new ResultBag("Retornado com Sucesso!", true);

            Assert.AreEqual("Retornado com Sucesso!", resultadoComMsg.Message);
            Assert.AreEqual(true, resultadoComMsg.IsSuccess);
        }

        [Test]
        public void Deve_Retornar_Resultado_Com_Erro_Com_Valor()
        {
            var resultado = new ResultBag<int>("Erro", false, 0);

            Assert.AreEqual("Erro", resultado.Message);
            Assert.AreEqual(false, resultado.IsSuccess);
            Assert.AreEqual(0, resultado.Data);
        }

        [Test]
        public void Deve_Retornar_Resultado_Com_Erro_Sem_Valor()
        {
            var resultado = new ResultBag("Erro", false);

            Assert.AreEqual("Erro", resultado.Message);
            Assert.AreEqual(false, resultado.IsSuccess);
        }
    }
}