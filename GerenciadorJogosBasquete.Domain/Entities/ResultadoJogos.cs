using System;
using System.Collections.Generic;
using System.Linq;
using GerenciadorJogosBasquete.Domain.Dto;

namespace GerenciadorJogosBasquete.Domain.Entities
{
public class ResultadoJogos
    {
        public DateTime DataPrimeiroJogo { get; private set; }
        public DateTime DataUltimoJogo { get; private set; }
        public int TotalJogos { get; private set; }
        public int TotalPontos { get; private set; }
        public double MediaPontos { get; private set; }
        public int MaiorPontuacao { get; private set; }
        public int MenorPontuacao { get; private set; }
        public int QtdRecorde { get; private set; }

        public IEnumerable<JogoBasquete> JogosBasquete { get; }

        public ResultadoJogos()
        {
            JogosBasquete = new List<JogoBasquete>();
        }

        public ResultadoJogos(IEnumerable<JogoBasquete> jogosBasquete)
        {
            JogosBasquete = jogosBasquete;
        }

        public void CalcularResultados()
        {
            DataPrimeiroJogo = JogosBasquete.Min(m => m.DataJogo);
            DataUltimoJogo = JogosBasquete.Max(m => m.DataJogo);
            TotalJogos = JogosBasquete.Count();
            TotalPontos = JogosBasquete.Sum(s => s.QtdPontos);
            MediaPontos = JogosBasquete.Average(a => a.QtdPontos);
            MaiorPontuacao = JogosBasquete.Max(m => m.QtdPontos);
            MenorPontuacao = JogosBasquete.Min(m => m.QtdPontos);
            QtdRecorde = ContarRecordes();
        }

        private int ContarRecordes()
        {
            var jogos = JogosBasquete.ToList();
            var contRecorde = 0;

            //Percorre a lista de jogos
            for (var j = 1; j < jogos.Count; j++)
            {
                var jogoAtual = jogos[j].QtdPontos;
                var recorde = true;

                //Compara com os jogos anteriores
                for (var i = 0; i < j; i++)
                {
                    var jogoAnterior = jogos[i].QtdPontos;

                    if (jogoAtual > jogoAnterior) continue;

                    recorde = false;
                    break;
                }

                if (recorde) contRecorde++;
            }

            return contRecorde;
        }
    }
}
