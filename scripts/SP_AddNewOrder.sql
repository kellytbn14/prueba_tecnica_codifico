IF OBJECT_ID('AddNewOrder', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE AddNewOrder;
END
GO

CREATE PROCEDURE AddNewOrder
    @EmpId INT,
    @ShipperId INT,
    @ShipName NVARCHAR(100),
    @ShipAddress NVARCHAR(200),
    @ShipCity NVARCHAR(100),
    @ShipCountry NVARCHAR(100),
    @OrderDate DATE,
    @RequiredDate DATE,
    @ShippedDate DATE,
    @Freight DECIMAL(18, 2),
 
    -- detalles del producto
    @ProductId INT,
    @UnitPrice DECIMAL(18, 2),
    @Qty INT,
    @Discount DECIMAL(5, 2)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
		-- Insertar la nueva orden en la tabla Orders
        INSERT INTO [StoreSample].[Sales].[Orders] (
			empid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry
		) VALUES (
			@EmpId, @ShipperId, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry
		);

        -- Obtener el ID de la orden recién creada
        DECLARE @OrderId INT;
        SET @OrderId = SCOPE_IDENTITY();

	    -- Insertar los detalles de la orden en la tabla OrderDetails
        INSERT INTO [StoreSample].[Sales].[OrderDetails] (
            orderid, productid, unitprice, qty, discount
        ) VALUES (
			@OrderId, @ProductId, @UnitPrice, @Qty, @Discount
		);

        COMMIT TRANSACTION;
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
