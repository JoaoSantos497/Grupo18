CREATE TABLE [dbo].[Produtos]
(
	[ProdutoID] int NOT NULL,
	[Nome] varchar(50) NOT NULL,
	[Marca] varchar(50) NOT NULL,
	[Modelo] varchar(100) NOT NULL,
	[Descricao] varchar(255) DEFAULT NULL,
	[Preco] decimal(10,2) NOT NULL,
	[Stock] int DEFAULT 0,
	[CategoriaID] int DEFAULT NULL,
	[ImagemProduto] varchar(255) DEFAULT NULL
)