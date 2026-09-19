CREATE TABLE [dbo].[Category]
(
[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Titre ] NVARCHAR(50) NULL, 
    [Description ] NVARCHAR(150) NULL, 
    [CreatedAt ] DATETIME2 NULL, 
)
