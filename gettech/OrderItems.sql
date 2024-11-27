CREATE TABLE [dbo].[OrderItems]
(
	[OrderItemID] INT NOT NULL,
	[OrderID] int NOT NULL, 
	[ProdutoID] int NOT NULL,
	[Quantidade] int NOT NULL,
	[PrecoUnitario] decimal (10,2) NOT NULL,
)
