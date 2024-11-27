CREATE TABLE [dbo].[Favoritos]
(
	[FavoritoID] INT NOT NULL,
	[UserID] int NOT NULL,
	[ProdutoID] int NOT NULL,
	[DataAdicionado] datetime DEFAULT getdade(),
)
