--3.	Read the README file from adventureworks. And create the database in SSMS.
--a)	Return all columns and data regarding employees only
--b)	Return all the names of customer in adventureworks (all 3 columns)
--c)	List all customers whose first name is Eugene.

SELECT * FROM AdventureWorksDW2019.dbo.DimEmployee;
SELECT FirstName, MiddleName, LastName FROM AdventureWorksDW2019.dbo.DimCustomer;
--SELECT * FROM AdventureWorksDW2019.dbo.DimCustomer;
SELECT FirstName, MiddleName, LastName FROM AdventureWorksDW2019.dbo.DimCustomer WHERE FirstName = 'Eugene';
