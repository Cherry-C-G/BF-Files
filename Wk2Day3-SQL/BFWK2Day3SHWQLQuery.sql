select * from DimAccount
select * from DimCustomer
select * from DimSalesTerritory
select * from DimGeography
select * from FactProductInventory
select * from FactResellerSales	
select * from FactSalesQuota
select * from FactSurveyResponse
select * from ProspectiveBuyer


--All questions are based on AdventureWorks data warehouse unless otherwise specified.
--(We only have internet sales in our data warehouse)(note: I remove some tables in the
--data warehouse, so it only has internet sales in the database)
--1. Find the total Internet sales tax amount.

Use AdventureWorksDW2019

Select * from FactInternetSales
SELECT SUM(TaxAmt) AS 'Total Internet Sales Tax'
FROM FactInternetSales


--2. Find the Internet sales amount per order by year and quarter of order date.
SELECT 
  YEAR(OrderDate) AS OrderYear, 
  DATEPART(QUARTER, OrderDate) AS OrderQuarter
FROM FactInternetSales
WHERE OrderDate IS NOT NULL
GROUP BY YEAR(OrderDate), DATEPART(QUARTER, OrderDate)
ORDER BY YEAR(OrderDate), DATEPART(QUARTER, OrderDate) ASC;

--3. Find the percentage of sales amount for each order over total sales amount of that
--month by shipping date.

SELECT 
  YEAR(ShipDate) AS ShippedYear, 
  MONTH(ShipDate) AS ShippedMonth, 
  SalesAmount, 
  (SalesAmount / SUM(SalesAmount) OVER (PARTITION BY YEAR(ShipDate), MONTH(ShipDate))) * 100 AS PercentageOfTotalSales
FROM FactInternetSales
WHERE ShipDate IS NOT NULL



--4. Display the full name, age, address(City, State, Country), and marital status of all
--customers who live in the US

SELECT c.FirstName + ' ' + c.LastName as FullName,
       DATEDIFF(YEAR, c.BirthDate, GETDATE()) as Age,
       g.City + ', ' + g.StateProvinceCode + ', ' + g.CountryRegionCode as Address,
       c.MaritalStatus as MaritalStatus
FROM DimCustomer c
JOIN DimGeography g
ON c.GeographyKey = g.GeographyKey
WHERE g.CountryRegionCode = 'US'

--5. Create a view with the product sold amount by subcategory by category by year and
--month order date.
CREATE VIEW ProductSalesByCategory AS
SELECT c.EnglishProductCategoryName AS Category, s.EnglishProductSubcategoryName
AS SubCategory,
       YEAR(o.OrderDate) AS OrderYear, MONTH(o.OrderDate) AS OrderMonth,
       SUM(d.OrderQuantity) AS SoldQty, SUM(d.SalesOrderLineNumber) AS SoldAmount
FROM DimProduct p
INNER JOIN FactInternetSales d ON p.ProductKey = d.ProductKey
INNER JOIN FactInternetSales o ON d.SalesOrderNumber = o.SalesOrderNumber
INNER JOIN DimProductSubcategory s ON p.ProductSubcategoryKey = s.ProductSubcategoryKey
INNER JOIN DimProductCategory c ON s.ProductCategoryKey = c.ProductCategoryKey
GROUP BY c.EnglishProductCategoryName, s.EnglishProductSubcategoryName, YEAR(o.OrderDate), MONTH(o.OrderDate)

SELECT * FROM ProductSalesByCategory



--6. Use the view created to display product sold amount by category by year of order
--date.

SELECT
    OrderYear,
    Category,
    SUM(SoldQty) AS TotalUnitsSoldByCategory
FROM ProductSalesByCategory
GROUP BY OrderYear, Category



--7. deleted
--8. Group the customers into different age groups: < 30, 30-50, and 50+. Get the total
--number of customers and a total number of Internet sales in each group.

SELECT
  CASE
    WHEN DATEDIFF(YEAR, BirthDate, GETDATE()) < 30 THEN '< 30'
    WHEN DATEDIFF(YEAR, BirthDate, GETDATE()) BETWEEN 30 AND 50 THEN '30-50'
    ELSE '50+'
  END AS 'Age Group',
  COUNT(*) AS 'Number of Customers',
  SUM(SalesAmount) AS 'Total Internet Sales'
FROM DimCustomer AS p
JOIN FactInternetSales AS c
  ON p.CustomerKey = c.CustomerKey
GROUP BY
  CASE
    WHEN DATEDIFF(YEAR, BirthDate, GETDATE()) < 30 THEN '< 30'
    WHEN DATEDIFF(YEAR, BirthDate, GETDATE()) BETWEEN 30 AND 50 THEN '30-50'
    ELSE '50+'
  END


--9. Create a stored procedure to input the first or last name of the customer, and
--return the Internet sale orders the customer(s) have created.

CREATE PROCEDURE GetInternetSalesOrders
    @FirstName varchar(50),
    @LastName varchar(50)
AS
BEGIN
    SELECT o.*
    FROM FactInternetSales o
    INNER JOIN DimCustomer c ON o.CustomerKey = c.CustomerKey
    WHERE c.FirstName = @FirstName OR c.LastName = @LastName
    AND o.SalesOrderLineNumber = 1
END

EXEC GetInternetSalesOrders @FirstName = 'John', @LastName = 'Doe'


--10. Create a stored procedure to display the total number of sales and sales amount for
--each month by category, with a specified year.

CREATE PROCEDURE GetSalesByMonthByCategory
    @Year int
AS
BEGIN
    SELECT
        MONTH(o.OrderDate) AS OrderMonth,
        c.EnglishProductCategoryName AS CategoryName,
        COUNT(o.SalesOrderNumber) AS TotalOrders,
        SUM(od.SalesOrderLineNumber) AS TotalSalesAmount
    FROM FactInternetSales o
    INNER JOIN FactInternetSales od ON o.SalesOrderNumber = od.SalesOrderNumber
    INNER JOIN DimProduct p ON od.ProductKey = p.ProductKey
    INNER JOIN DimProductSubcategory sc ON p.ProductSubcategoryKey = sc.ProductSubcategoryKey
    INNER JOIN DimProductCategory c ON sc.ProductCategoryKey = c.ProductCategoryKey
    WHERE YEAR(o.OrderDate) = @Year
    GROUP BY MONTH(o.OrderDate), c.EnglishProductCategoryName
END


EXEC GetSalesByMonthByCategory @Year = 2012



--11. Create a function that will calculate the Hypotenuse of a triangle after you give the
--length of the two other sides of a triangle.

CREATE FUNCTION Hypotenuse
(@side1 float, @side2 float)
RETURNS float
AS
BEGIN
  DECLARE @hypotenuse float;
  SET @hypotenuse = SQRT(@side1*@side1 + @side2*@side2);
  RETURN @hypotenuse;
END;

SELECT dbo.Hypotenuse(3, 4) AS Hypotenuse;



--Use sub-queries to complete the following questions
--13. Find the name of the customers who have made more than one purchase on the
--Internet

SELECT FirstName + ' ' + LastName AS 'Full Name'
FROM DimCustomer AS p
JOIN FactInternetSales AS c
  ON p.CustomerKey = c.CustomerKey
WHERE (SELECT COUNT(*) FROM FactInternetSales WHERE CustomerKey = c.CustomerKey) > 1
