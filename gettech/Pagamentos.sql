CREATE TABLE [dbo].[Pagamentos]
(
	[PagamentosID] INT NOT NULL,
	[OrderID] int NOT NULL,
	[MetodoPagamento] varchar(50) NOT NULL,
	[StatusPagamento] varchar(10) NOT NULL CHECK (StatusPagamento IN ('Pendente', 'Concluido', 'Cancelado')),
	[DataPagamento] datetime DEFAULT NULL,
	[Montante] decimal(10,2) NOT NULL,
)
