-- Sales Date Prediction
EXEC dbo.PredictNextOrderDate


-- Get Client Orders
SELECT o.orderid, o.requireddate, o.shippeddate, o.shipname, o.shipaddress, o.shipcity 
FROM [StoreSample].Sales.Orders o
WHERE o.custid = 1


-- Get employees
SELECT e.empid, CONCAT(e.firstname, ' ', e.lastname) AS FullName
FROM [StoreSample].HR.Employees e


-- Get Shippers
SELECT s.shipperid, s.companyname
FROM [StoreSample].Sales.Shippers s


-- Get Products
SELECT p.productid, p.productname
FROM [StoreSample].Production.Products p


-- Add New Order
EXEC dbo.AddNewOrder 
    @EmpId = 1,
    @ShipperId = 2,
    @ShipName = 'Fast Shipping',
    @ShipAddress = '123 Main St',
    @ShipCity = 'New York',
    @ShipCountry = 'USA',
    @OrderDate = '2024-09-18',
    @RequiredDate = '2024-09-25',
    @ShippedDate = '2024-09-19',
    @Freight = 50.00,
    @ProductId = 10,
    @UnitPrice = 10.50,
    @Qty = 5,
    @Discount = 0.10;
