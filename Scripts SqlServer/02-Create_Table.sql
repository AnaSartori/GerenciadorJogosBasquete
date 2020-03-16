USE GerenciadorJogosBasquete;
GO

CREATE TABLE Jogos (
    IdJogo INT IDENTITY,
    DataJogo DATETIME NOT NULL,
    QtdPontos INT NOT NULL,
    CONSTRAINT PK_Jogos PRIMARY KEY (IdJogo)
)
GO
