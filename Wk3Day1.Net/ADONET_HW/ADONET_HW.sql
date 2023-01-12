IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
     WHERE name = N'ADO_HW'
    )
DROP DATABASE ADO_HW

CREATE DATABASE ADO_HW
GO

USE ADO_HW
GO


CREATE TABLE Pizza (
	Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(42),
    Price FLOAT
);

GO

INSERT INTO Pizza (name, price) VALUES 
('pepperoni pizza', 42.42),
('veggie pizza', 12.34),
('margherita pizza', 1.23),
('square pizza', 3.14),
('triple cheese pizza', 33.3),
('leaning tower of pizza', 10.0);

SELECT * FROM Pizza;



--Create an UD-Stored Procedure called “The Signiture Menu” to get TOP3 expensive Pizzas and execute the SP using your .NET application:
CREATE PROCEDURE TheSignatureMenu
AS
BEGIN
SELECT TOP 3 * FROM Pizza ORDER BY price DESC;
END
