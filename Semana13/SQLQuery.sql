SELECT * FROM Products;

UPDATE Products 
SET UnitPrice = UnitPrice*(1+10/100.0)
WHERE ProductID = 1;

ALTER PROCEDURE SP_ActualizarPrecio
@ProductID INT,
@Procentaje DECIMAL(18,2),
@NuevoPrecio DECIMAL(18,2) OUTPUT,
@RowVersion ROWVERSION
AS
BEGIN
	UPDATE Products 
	SET UnitPrice = UnitPrice*(1+(@Procentaje/100.0))
	WHERE ProductID = @ProductID AND RowVersion=@RowVersion;

	SELECT @NuevoPrecio = UnitPrice
	FROM Products
	WHERE ProductID = @ProductID;

	PRINT 'Precio actualizado: '+CAST(@NuevoPrecio AS VARCHAR);
END;

SELECT 'Precio actualizado: '+CAST(10.5 AS VARCHAR);

DECLARE @Precio DECIMAL(18,2);
DECLARE @Version TIMESTAMP;
DECLARE @ProductID INT;
SET @ProductID=1;
SELECT @Version=RowVersion FROM Products WHERE ProductID = @ProductID;
EXECUTE SP_ActualizarPrecio 1,10,@Precio OUTPUT,@RowVersion=@Version;
SELECT @Precio;

select * from Products where ProductID=1
--0x000000000001ADC2
--0x000000000001ADC3

UPDATE Products 
SET UnitPrice = UnitPrice*(1+10/100.0)
WHERE ProductID = 1;


ALTER TABLE Products
ADD RowVersion ROWVERSION;