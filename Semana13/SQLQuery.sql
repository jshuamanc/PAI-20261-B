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
	WHERE ProductID = @ProductID AND @RowVersion=@RowVersion;

	SELECT @NuevoPrecio = UnitPrice
	FROM Products
	WHERE ProductID = @ProductID;
END;

DECLARE @Precio DECIMAL(18,2);
EXECUTE SP_ActualizarPrecio 1,10,@Precio OUTPUT;
SELECT @Precio;

select * from Products where ProductID=1
--0x000000000001ADC2
--0x000000000001ADC3

UPDATE Products 
SET UnitPrice = UnitPrice*(1+10/100.0)
WHERE ProductID = 1 and RowVersion='0x000000000001ADC3';