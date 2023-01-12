IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
     WHERE name = N'Categories'
    )
DROP DATABASE Categories

CREATE DATABASE Categories
GO

USE Categories
GO


 
CREATE TABLE Category (
	Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(42) NOT NULL,
);

GO

INSERT INTO Category Values('.NET'),('Java'),('Data'),('MEAN'),('MERN')

SELECT * FROM Category