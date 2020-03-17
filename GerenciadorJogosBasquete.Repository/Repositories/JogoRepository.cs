using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using GerenciadorJogosBasquete.Comum;
using GerenciadorJogosBasquete.Comum.Enums;
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
            _connection = connection;
        }

        public IResultado AddJogo(JogoBasquete jogoBasquete)
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

                return new Resultado(StatusResultado.Sucesso);
            }
            catch (Exception ex)
            {
                return new Resultado(ex.Message, StatusResultado.Erro);
            }
        }

        public IResultado<IEnumerable<JogoBasquete>> GetJogos()
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

                    return new Resultado<IEnumerable<JogoBasquete>>
                    (
                        StatusResultado.Sucesso,
                        result
                    );
                }
            }
            catch (Exception ex)
            {
                return new Resultado<IEnumerable<JogoBasquete>>
                (
                    ex.Message, 
                    StatusResultado.Erro,
                    new List<JogoBasquete>()
                );
            }
        }
    }
}