select * from categories

select distinct CategoryID from Products

INSERT INTO Products(ProductName,CategoryID,UnitPrice) VALUES('Nuevo Producto',2012,10);

select * from Products

delete Categories where CategoryID=9;


alter table Products
add Constraint FK_Products_Categories 
FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE CASCADE;

SELECT * FROM [Order Details];