CREATE TABLE [dbo].[Users]
(
	[UserID] int NOT NULL,
	[Username] varchar(50) NOT NULL,
	[Nome] varchar(50) NOT NULL,
	[Email] varchar(100) NOT NULL,
	[PasswordHash] varchar(16) NOT NULL,
	[DataNascimento] date,
	[Genero] varchar(50) NOT NULL,
	[ImagemPerfil] varchar(255) NOT NULL,
	[DataRegisto] datetime DEFAULT getdate(),
	[RoleID] int DEFAULT 2
)



