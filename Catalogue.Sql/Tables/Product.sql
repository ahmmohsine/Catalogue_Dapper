CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Titre] NVARCHAR(50) NULL, 
    [Description ] NVARCHAR(50) NULL, 
    [Stock ] INT NULL, 
    [CreatedAt ] DATETIME2 NULL, 
    [CategoryId ] INT NOT NULL  CONSTRAINT [FK_Product_ToCategory] FOREIGN KEY  REFERENCES [Category]([Id])
   
)
