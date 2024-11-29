CREATE TABLE [dbo].[Carrinho]
(
	[CarrinhoID] INT NOT NULL,
	[UserID] int NOT NULL,
	[ProdutoID] int NOT NULL,
	[Quantidade] int NOT NULL,
	[DataAdicionado] datetime DEFAULT getdate()
)
