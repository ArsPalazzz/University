use UNIVER

declare LinesLocal cursor local for select SUBJECT from SUBJECT
declare @First nvarchar(10), @All nvarchar(200) = ' ';

open LinesLocal
fetch LinesLocal into @First
print '1. ' + @First
go --остановочка между пакетами

declare @First nvarchar(10), @All nvarchar(200) = ' ';
fetch LinesLocal into @First
print '2. ' + @First
go

--deallocate LinesLocal

