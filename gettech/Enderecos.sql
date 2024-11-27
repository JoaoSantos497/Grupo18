CREATE TABLE [dbo].[Enderecos]
(
	[EnderecoID] INT NOT NULL,
	[UserID] int NOT NULL,	
	[EnderecoLinha1] varchar(255) NOT NULL,
	[EnderecoLinha2] varchar(255) NOT NULL,
	[Pais] varchar(50) NOT NULL,
	[Distrito] varchar(50) NOT NULL,
	[Cidade] varchar(50) NOT NULL,
	[Tipo] varchar(50) NOT NULL check (Tipo IN ('Entrega', 'Faturacao'))
)
