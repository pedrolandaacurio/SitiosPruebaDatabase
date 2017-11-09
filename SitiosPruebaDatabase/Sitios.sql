CREATE TABLE [dbo].[Sitios]
(
	[Id_Sitio] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CodigoSitio] NVARCHAR(9) NULL, 
    [Ubicacion] [sys].[geography] NULL, 
    [Propiedad] INT NULL, 
    [Antecedentes] NVARCHAR(MAX) NULL, 
    [RelatoAcontecimientos] NVARCHAR(MAX) NULL, 
    [FechaEvento] DATE NULL, 
    [FechaInhumacion] DATE NULL, 
    [NumeroVictimas] DECIMAL NULL, 
    [ExhumacionAnterior] BIT NULL, 
    [MaterialesAdicionales] BIT NULL
)
