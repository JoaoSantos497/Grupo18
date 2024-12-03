

-- Criação das Tabelas

CREATE TABLE Avaliacoes (
    AvaliacaoID INT IDENTITY(1,1) PRIMARY KEY,
    ProdutoID INT NOT NULL,
    UserID INT NOT NULL,
    Comentario NVARCHAR(500) NULL,
    Classificacao INT NULL CHECK (Classificacao BETWEEN 1 AND 5),
    DataAvaliacao DATETIME DEFAULT GETDATE()
);
