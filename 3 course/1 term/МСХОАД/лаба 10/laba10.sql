use master;
go

-- 10.1

exec sp_configure 'show advanced options', 1;
go 
reconfigure
go 
exec sp_configure 'clr enabled',1;
exec sp_configure 'clr strict security', 0
RECONFIGURE;


use [5sem];

DECLARE @result FLOAT;

EXEC dbo.CalculateAverageWithoutMinMax
    @values = '10,2,3,4,5',
    @result = @result OUTPUT;

SELECT @result AS Result;


-- 10.2


CREATE TABLE PassportTable
(
    ID INT PRIMARY KEY,
    Passport PassportData
);

INSERT INTO PassportTable (ID, Passport)
VALUES (1, 'AB 123456');


SELECT * FROM PassportTable;