use Northwind;
go

/*like*/
--1 get all customers where firs letter is 'B'
select * from dbo.Customers c where LOWER(c.CompanyName) like lower('B%');

/*alter*/
--2 add new column to table product
select * from dbo.Products
alter table dbo.Products add newColumn varchar(10) default 'petro';

/*inner join*/
--SQL 87 
select o.OrderID,o.ShipName,o.ShipAddress,o.ShipCity,od.UnitPrice,od.Quantity 
from dbo.Orders o, dbo.[Order Details] od 
where o.OrderID=od.OrderID;
--SQL 92
select o.OrderID,o.ShipName,o.ShipAddress,o.ShipCity,od.UnitPrice,od.Quantity
 from dbo.Orders o join dbo.[Order Details] od 
on o.OrderID=od.OrderID;

 /*промежуточные итоги*/
 --количетсво заказов с накоплением относительно года
 select distinct Year(o.OrderDate), count(od.OrderID)
 from dbo.Orders o join [Order Details] od on  o.OrderID>=od.OrderID
 where o.OrderID is not null
 group by Year(o.OrderDate);

--прибыль с накоплением, итог - сумма заработанная за все года.
 select distinct Year(o.OrderDate), sum(od.Quantity*od.UnitPrice)
 from dbo.Orders o join [Order Details] od on  o.OrderID>=od.OrderID
 where o.OrderID is not null
 group by Year(o.OrderDate);

