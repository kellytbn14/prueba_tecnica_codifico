IF OBJECT_ID('PredictNextOrderDate', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE PredictNextOrderDate;
END
GO

CREATE PROCEDURE PredictNextOrderDate
AS
BEGIN
    -- Crear tabla temporal
    CREATE TABLE #CustomerOrderDetails (
        custid NVARCHAR(10),
        orderdate DATE,
        companyname NVARCHAR(100)
    );

    -- Insertar datos en la tabla temporal
    INSERT INTO #CustomerOrderDetails (custid, orderdate, companyname)
		SELECT o.custid, o.orderdate, c.companyname
		FROM [StoreSample].[Sales].[Orders] o
		INNER JOIN [StoreSample].[Sales].[Customers] c ON o.custid = c.custid;

    -- Crear tabla temporal para almacenar diferencias de días
    CREATE TABLE #OrderDateDifferences (
        custid NVARCHAR(10),
        companyname NVARCHAR(100),
        orderdate DATE,
        days_diff INT
    );

    INSERT INTO #OrderDateDifferences (custid, companyname, orderdate, days_diff)
		SELECT custid, companyname, orderdate,
			   DATEDIFF(DAY, LAG(orderdate) OVER (PARTITION BY custid ORDER BY orderdate), orderdate) AS days_diff
		FROM #CustomerOrderDetails
		ORDER BY custid, orderdate;

    -- Crear tabla temporal para calcular el promedio de días por cliente
    CREATE TABLE #CustomerAvgDays (
        custid NVARCHAR(10),
        companyname NVARCHAR(100),
        avg_days_diff FLOAT
    );

    INSERT INTO #CustomerAvgDays (custid, companyname, avg_days_diff)
		SELECT custid, companyname, AVG(days_diff) AS avg_days_diff
		FROM #OrderDateDifferences
		WHERE days_diff IS NOT NULL
		GROUP BY custid, companyname;

    -- Crear tabla temporal para almacenar la fecha mayor y la fecha predicha
    CREATE TABLE #CustomerFutureOrderDate (
        custid NVARCHAR(10),
        companyname NVARCHAR(100),
        last_order_date DATE,
        future_order_date DATE
    );

    INSERT INTO #CustomerFutureOrderDate (custid, companyname, last_order_date, future_order_date)
		SELECT o.custid, o.companyname, 
			   MAX(o.orderdate) AS last_order_date,
			   DATEADD(DAY, a.avg_days_diff, MAX(o.orderdate)) AS future_order_date
		FROM #CustomerOrderDetails o
		INNER JOIN #CustomerAvgDays a ON o.custid = a.custid AND o.companyname = a.companyname
		GROUP BY o.custid, o.companyname, a.avg_days_diff;

    SELECT companyname AS CustomerName, last_order_date AS LastOrderDate, future_order_date AS NextPredictedOrder
    FROM #CustomerFutureOrderDate
    ORDER BY custid;

    -- Eliminar las tablas temporales
    DROP TABLE #CustomerOrderDetails;
    DROP TABLE #OrderDateDifferences;
    DROP TABLE #CustomerAvgDays;
    DROP TABLE #CustomerFutureOrderDate;
END;
GO
