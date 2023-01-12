IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
     WHERE name = N'Student'
    )
DROP DATABASE Student

CREATE DATABASE Student

GO

USE Student
GO

CREATE TABLE StudentClass (
	ClassId INT PRIMARY KEY IDENTITY(1,1), -- PK auto increment by 1
	ClassName VARCHAR(30) NOT NULL
)

CREATE TABLE StudentInfo (
	StuId INT PRIMARY KEY IDENTITY(1,1),
	StuName VARCHAR(30) NOT NULL
)

INSERT INTO StudentInfo VALUES('Aiden'),('Bill'),('Cindy')
INSERT INTO StudentClass VALUES('SQL Batch'),('C# Batch'),('JAVA Batch'), ('Data Batch')
SELECT * FROM StudentInfo
SELECT * FROM StudentClass

GO

CREATE PROCEDURE GetAllClassName AS
BEGIN
	SELECT ClassName FROM StudentClass
END

GO

EXEC GetAllClassName
GO

Use Student
Go
Grant select on StudentClass to myUser