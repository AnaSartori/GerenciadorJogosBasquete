USE GerenciadorJogosBasquete;
GO 

/*
INSERT INTO Jogos (DataJogo, QtdPontos) VALUES ('2019-10-05', 10);
INSERT INTO Jogos (DataJogo, QtdPontos) VALUES ('2019-20-07', 5);
INSERT INTO Jogos (DataJogo, QtdPontos) VALUES ('2019-15-10', 20);
INSERT INTO Jogos (DataJogo, QtdPontos) VALUES ('2019-20-12', 0);
INSERT INTO Jogos (DataJogo, QtdPontos) VALUES ('2020-05-01', 10);
INSERT INTO Jogos (DataJogo, QtdPontos) VALUES ('2020-12-02', 25);
INSERT INTO Jogos (DataJogo, QtdPontos) VALUES ('2020-15-02', 3);
INSERT INTO Jogos (DataJogo, QtdPontos) VALUES ('2020-05-03', 30);
*/

/*
DELETE FROM Jogos
DBCC CHECKIDENT('Jogos', RESEED, 0)
*/

-- Retornar Todos os Jogos
SELECT IdJogo, DataJogo, QtdPontos FROM Jogos ORDER BY DataJogo
                                           
-- Jogos disputados	                 
SELECT COUNT(*)AS TotalJogos FROM Jogos 

-- Total de Pontos
SELECT SUM(QtdPontos)AS TotalPontos FROM Jogos

-- Média
SELECT AVG(QtdPontos)AS Media FROM Jogos

-- Maior Pontuação
SELECT MAX(QtdPontos)AS Maior FROM Jogos

-- Menor Pontuação
SELECT MIN(QtdPontos)AS Menor FROM Jogos

-- Maior Data
SELECT MAX(DataJogo)AS Maior FROM Jogos

-- Menor Data
SELECT MIN(DataJogo)AS Menor FROM Jogos