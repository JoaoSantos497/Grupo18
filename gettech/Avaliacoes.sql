CREATE TABLE [dbo].[Avaliacoes]
(
	[AvaliacaoID] INT NOT NULL,
	[ProdutoID] int NOT NULL,
	[UserID] int NOT NULL,
	[Comentario] int NOT NULL,
	[Classificacao] INT CHECK (Classificacao BETWEEN 1 AND 5),
	[DataAdicionado] datetime DEFAULT getdate()
)
