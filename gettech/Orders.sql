CREATE TABLE [dbo].[Orders]
(
	[OrderID] INT NOT NULL,
	[UserID] int NOT NULL,
	[DataPedido] datetime DEFAULT getdate(),
	[Status] varchar(50) check (Status IN ('Pendente', 'Enviado', 'Entregue', 'Cancelado')),
	[Total] decimal(10,2) NOT NULL,
	[EnderecoEntregaID] int NULL,
	[CupomID] int NOT NULL,
)
