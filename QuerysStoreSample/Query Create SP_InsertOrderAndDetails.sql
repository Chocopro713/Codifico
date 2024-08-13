CREATE PROCEDURE InsertOrderAndDetails
    @EmpId INT,
    @ShipperId INT,
    @ShipName NVARCHAR(100),
    @ShipAddress NVARCHAR(100),
    @ShipCity NVARCHAR(100),
    @OrderDate DATE,
    @RequiredDate DATE,
    @ShippedDate DATE,
    @Freight DECIMAL(10, 2),
    @ShipCountry NVARCHAR(100),
    @ProductId INT,
    @UnitPrice DECIMAL(10, 2),
    @Qty INT,
    @Discount DECIMAL(5, 2)
AS
BEGIN
    -- Iniciar la transacción
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Insertar la nueva orden en la tabla Orders
        INSERT INTO StoreSample.Sales.Orders (EmpId, ShipperId, ShipName, ShipAddress, ShipCity, OrderDate, RequiredDate, ShippedDate, Freight, ShipCountry)
        VALUES (@EmpId, @ShipperId, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry);

        -- Recuperar el ID de la orden insertada
        DECLARE @OrderId INT = SCOPE_IDENTITY();

        -- Insertar el detalle de la orden en la tabla OrderDetails
        INSERT INTO StoreSample.Sales.OrderDetails (OrderId, ProductId, UnitPrice, Qty, Discount)
        VALUES (@OrderId, @ProductId, @UnitPrice, @Qty, @Discount);

        -- Si todo está correcto, confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si hay un error, revertir la transacción
        ROLLBACK TRANSACTION;

        -- Re-lanza el error capturado al cliente
        THROW;
    END CATCH
END;
GO


--------------------




EXEC InsertOrderAndDetails
    @EmpId = 1,
    @ShipperId = 2,
    @ShipName = 'Example Ship Name',
    @ShipAddress = '1234 Shipping Lane',
    @ShipCity = 'ShipCity',
    @OrderDate = '2023-01-01',
    @RequiredDate = '2023-01-15',
    @ShippedDate = '2023-01-08',
    @Freight = 100.00,
    @ShipCountry = 'USA',
    @ProductId = 1,
    @UnitPrice = 29.99,
    @Qty = 10,
    @Discount = 0.05;
