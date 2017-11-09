CREATE TABLE [dbo].[Testigos]
(
	[Id_Testigo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombres] NVARCHAR(MAX) NULL, 
    [ApellidoPaterno] NVARCHAR(MAX) NULL, 
    [ApellidoMaterno] NVARCHAR(MAX) NULL, 
    [Id_Sitio] INT NULL, 
    CONSTRAINT [FK_Testigos_ToSitios] FOREIGN KEY ([Id_Sitio]) REFERENCES [Sitios]([Id_Sitio])
)
