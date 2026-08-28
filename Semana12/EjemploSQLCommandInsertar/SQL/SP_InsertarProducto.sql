ALTER PROCEDURE SP_AgregarProducto @Nombre NVARCHAR(40), @Precio MONEY
AS
BEGIN
	WAITFOR DELAY '00:00:45';
	INSERT INTO Products(ProductName,UnitPrice) VALUES(@Nombre,@Precio);

END;