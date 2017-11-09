CREATE TABLE [dbo].[Victimas]
(
	[Id_Victima] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CodigoVictima] NVARCHAR(MAX) NULL, 
    [NA] NVARCHAR(MAX) NULL, 
    [Sexo] INT NULL, 
    [Edad] DECIMAL NULL, 
    [Procedencia] NVARCHAR(MAX) NULL, 
    [Familia] NVARCHAR(MAX) NULL, 
    [PresuntaAfiliacion] NVARCHAR(MAX) NULL, 
    [Id_Sitio] INT NULL, 
    CONSTRAINT [FK_Victimas_ToSitios] FOREIGN KEY (Id_Sitio) REFERENCES [Sitios]([Id_Sitio])
)
