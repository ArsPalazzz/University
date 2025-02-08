--Задание 4.1

declare @z float, @t float = 21, @x float = 5

	if @t > @x
		set @z = power(sin(@t), 2) 

	else if @t < @x
		set @z = 4*(@t + @x)

	else
		set @z = 1 - exp(@x-2)

	select @z

--Задание 4.2

declare @lastName nvarchar(20) = 'Палазник',
		@firstName nvarchar(20) = 'Арсений',
		@surname nvarchar(20) = 'Викторович',
		@longName nvarchar(60),
		@shortName nvarchar(30);

set @longName = @lastName + ' ' + @firstName + ' ' + @surname;

set @firstName = substring(@firstName, 1,1)+'.'; --подстрока начинается с первого по счету символа и состоит из 1 символа 
set @surname = substring(@surname, 1,1)+'.';
set @shortName = @lastName + ' ' + @firstName + ' ' + @surname;

select @longName [Полное];
select @shortName [Сокращенное];

--Задание 4.3

use UNIVER;

-- DATEDIFF(datepart, startdate, enddate)
--DATEDIFF: возвращает разницу между двумя датами. Первый параметр - компонент даты, который указывает, в каких единицах стоит измерять разницу. 
--Второй и третий параметры - сравниваемые даты:

select STUDENT.NAME, STUDENT.BDAY, (datediff(YY, STUDENT.BDAY, sysdatetime())) as [Возраст]
from STUDENT
where month(STUDENT.BDAY) = month(sysdatetime()) + 1; --month возвращает месяц даты

--SYSDATETIME: возвращает текущую локальную дату и время на основе системных часов, но отличие от GETDATE состоит в том, 
--что дата и время возвращаются в виде объекта datetime2

--Задание 4.4

declare @groupNumber int = 3;

--DATEPART: возвращает часть даты в виде числа. Параметр выбора части даты передается в качестве первого параметра 
--(используются те же параметры, что и для DATENAME), а сама дата передается в качестве второго параметра:

select distinct PROGRESS.PDATE[Дата проведения экзамена], case 
		when DATEPART(dw,PROGRESS.PDATE) = 1 then 'Понедельник'
		when DATEPART(dw,PROGRESS.PDATE) = 2 then 'Вторник'
		when DATEPART(dw,PROGRESS.PDATE) = 3 then 'Среда'
		when DATEPART(dw,PROGRESS.PDATE) = 4 then 'Четверг'
		when DATEPART(dw,PROGRESS.PDATE) = 5 then 'Пятница'
		when DATEPART(dw,PROGRESS.PDATE) = 6 then 'Суббота'
		when DATEPART(dw,PROGRESS.PDATE) = 7 then 'Воскресенье'
end [День недели]
from GROUPS inner join STUDENT on STUDENT.IDGROUP = GROUPS.IDGROUP
			inner join PROGRESS on STUDENT.IDSTUDENT= PROGRESS.IDSTUDENT
	where GROUPS.IDGROUP = @groupNumber