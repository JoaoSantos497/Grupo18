CREATE TABLE [dbo].[Cupons]
(
	[CumpomID] INT NOT NULL,
	[Codigo] varchar(50) NOT NULL,
	[Desconto] decimal(5, 2) NOT NULL,
	[DataExpiracao] datetime NULL,
	[Status] varchar(50) NOT NULL check (Status IN ('Ativo', 'Inativo'))
)
