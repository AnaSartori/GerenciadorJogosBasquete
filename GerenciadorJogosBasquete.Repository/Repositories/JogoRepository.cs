using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using GerenciadorJogosBasquete.Comum;
using GerenciadorJogosBasquete.Comum.Interfaces;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Interfaces.Repositories;
using GerenciadorJogosBasquete.Repository.Interfaces;

namespace GerenciadorJogosBasquete.Repository.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly IConnectionFactory _connection;

        public JogoRepository(IConnectionFactory connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public IResultBag AddJogo(JogoBasquete jogoBasquete)
        {
            try
            {
                using (var conn = _connection.Connection())
                {
                    conn.Open();

                    var sql = new StringBuilder();
                    sql.AppendLine(" INSERT INTO Jogos          ");
                    sql.AppendLine("    (DataJogo, QtdPontos)   ");
                    sql.AppendLine(" VALUES                     ");
                    sql.AppendLine("    (@DataJogo, @QtdPontos) ");

                    conn.ExecuteAsync(sql.ToString(), jogoBasquete);
                }

                return new ResultBag(true);
            }
            catch (Exception ex)
            {
                return new ResultBag(ex.Message, false);
            }
        }

        public IResultBag<IEnumerable<JogoBasquete>> GetJogos()
        {
            try
            {
                using (var conn = _connection.Connection())
                {
                    conn.Open();

                    var sql = new StringBuilder();
                    sql.AppendLine(" SELECT IdJogo, DataJogo, QtdPontos ");
                    sql.AppendLine(" FROM Jogos                         ");
                    sql.AppendLine(" ORDER BY DataJogo                  ");

                    var result = conn.Query<JogoBasquete>(sql.ToString());

                    return new ResultBag<IEnumerable<JogoBasquete>>
                    (
                        true,
                        result
                    );
                }
            }
            catch (Exception ex)
            {
                return new ResultBag<IEnumerable<JogoBasquete>>
                (
                    ex.Message,
                    false,
                    new List<JogoBasquete>()
                );
            }
        }
    }
}