use Northwind
go
select * from Orders

/**********SCRIPT***********/
ALTER TABLE Orders ADD Confirmed BIT
ALTER TABLE Orders ADD ConfirmationDate DATETIME
ALTER TABLE Orders ADD Comments VARCHAR(MAX)

