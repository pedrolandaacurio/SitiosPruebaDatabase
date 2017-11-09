CREATE TABLE [dbo].[Familiares]
(
	[Id_Familiar] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Familiar] NVARCHAR(MAX) NULL, 
    [Id_Victima] INT NULL, 
    CONSTRAINT [FK_Familiares_ToVictimas] FOREIGN KEY (Id_Victima) REFERENCES [Victimas]([Id_Victima])
)
