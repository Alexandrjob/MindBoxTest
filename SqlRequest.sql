CREATE TABLE Products(
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Categories(
   Id INT PRIMARY KEY IDENTITY,
   Name NVARCHAR(50) NOT NULL
);

CREATE TABLE ProductsMap(
  ProductId INT NOT NULL,
  CategoryId INT NULL,

  CONSTRAINT FK_ProductsMap_To_Products FOREIGN KEY (ProductId) REFERENCES Products (Id),  
  CONSTRAINT FK_ProductsMap_To_Categories FOREIGN KEY (CategoryId) REFERENCES Categories (Id)
);

GO

INSERT INTO Categories
VALUES
('Инструменты'),
('Одежда'),
('Продукты')

INSERT INTO Products
VALUES
('Ключ разводной'),
('Молоток'),
('Пила'),
('Перчатки'),
('Футболка'),
('Штаны'),
('Мясо'),
('Хлеб'),
('Молоко'),
('Швабра'),
('Плюшевая игрушка')

INSERT INTO ProductsMap
VALUES 
(1,1),
(2,1),
(3,1),
(4,2),
(5,2),
(6,2),
(7,3),
(8,3),
(9,3),
(10,1)

INSERT INTO ProductsMap (ProductId)
VALUES (11)

GO

SELECT p.Name + ' - ' + ISNULL(c.Name, 'Not found') AS Result
FROM Products p
JOIN ProductsMap ON p.Id = ProductsMap.ProductId
LEFT JOIN Categories c ON ProductsMap.CategoryId = c.Id