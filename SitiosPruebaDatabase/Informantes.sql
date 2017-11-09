CREATE TABLE [dbo].[Informantes]
(
	[Id_Informante] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombres] NVARCHAR(MAX) NULL, 
    [ApellidoPaterno] NVARCHAR(MAX) NULL, 
    [ApellidoMaterno] NVARCHAR(MAX) NULL, 
    [Id_Sitio] INT NULL, 
    CONSTRAINT [FK_Informantes_ToSitios] FOREIGN KEY ([Id_Sitio]) REFERENCES [Sitios]([Id_Sitio])
)
