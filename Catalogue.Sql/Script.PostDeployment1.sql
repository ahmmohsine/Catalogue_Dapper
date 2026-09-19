INSERT INTO [dbo].[Category]
    ([Titre ], [Description ], [CreatedAt ])
VALUES
    ('Informatique', 'Ordinateurs et accessoires informatiques', GETDATE()),
    ('Smartphones', 'Téléphones et accessoires mobiles', GETDATE()),
    ('Audio', 'Casques, écouteurs et enceintes', GETDATE()),
    ('Gaming', 'Produits et accessoires pour gamers', GETDATE()),
    ('Maison', 'Produits et équipements pour la maison', GETDATE());

    INSERT INTO [dbo].[Product]
    ([Titre ], [Description ], [Stock ], [CreatedAt ], [CategoryId ])
VALUES
    ('Laptop Dell', 'Ordinateur portable professionnel', 15, GETDATE(), 1),
    ('Clavier Logitech', 'Clavier sans fil ergonomique', 30, GETDATE(), 1),
    ('Souris Logitech', 'Souris sans fil USB', 45, GETDATE(), 1),
    ('Écran Samsung', 'Écran 27 pouces Full HD', 12, GETDATE(), 1),
    ('iPhone 15', 'Smartphone Apple 128 Go', 10, GETDATE(), 2),
    ('Samsung Galaxy S24', 'Smartphone Android 256 Go', 18, GETDATE(), 2),
    ('iPad Air', 'Tablette Apple 10 pouces', 8, GETDATE(), 2),
    ('Casque Sony', 'Casque audio Bluetooth', 25, GETDATE(), 2),
    ('Sac à dos', 'Sac à dos pour ordinateur portable', 20, GETDATE(), 3),
    ('Webcam HD', 'Webcam Full HD avec microphone', 14, GETDATE(), 3);