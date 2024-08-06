/*
  В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много 
  категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар 
  «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.


  Допустим, имееются таблицы:
   - Products, сожержащяя поля PK Id integer, Name nvarchar(max)
   - Categories, содержащяя поля PK Id ineger, Name nvarchar(max)
   - ProductCategory, содержащяя поля FK(Products.ProductId) ProductId, FK(Categories.CategoryId) CategoryId

  Писал на pg, но там различий мало
*/


SELECT 
    p."Name",
    c."Name"
FROM 
    public."Products" p
LEFT JOIN 
    public."ProductCategory" pc ON p."Id" = pc."ProductId"
LEFT JOIN 
    public."Categories" c ON pc."CategoryId" = c."Id"