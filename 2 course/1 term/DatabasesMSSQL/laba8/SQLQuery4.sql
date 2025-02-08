--������� 4.1

declare @z float, @t float = 21, @x float = 5

	if @t > @x
		set @z = power(sin(@t), 2) 

	else if @t < @x
		set @z = 4*(@t + @x)

	else
		set @z = 1 - exp(@x-2)

	select @z

--������� 4.2

declare @lastName nvarchar(20) = '��������',
		@firstName nvarchar(20) = '�������',
		@surname nvarchar(20) = '����������',
		@longName nvarchar(60),
		@shortName nvarchar(30);

set @longName = @lastName + ' ' + @firstName + ' ' + @surname;

set @firstName = substring(@firstName, 1,1)+'.'; --��������� ���������� � ������� �� ����� ������� � ������� �� 1 ������� 
set @surname = substring(@surname, 1,1)+'.';
set @shortName = @lastName + ' ' + @firstName + ' ' + @surname;

select @longName [������];
select @shortName [�����������];

--������� 4.3

use UNIVER;

-- DATEDIFF(datepart, startdate, enddate)
--DATEDIFF: ���������� ������� ����� ����� ������. ������ �������� - ��������� ����, ������� ���������, � ����� �������� ����� �������� �������. 
--������ � ������ ��������� - ������������ ����:

select STUDENT.NAME, STUDENT.BDAY, (datediff(YY, STUDENT.BDAY, sysdatetime())) as [�������]
from STUDENT
where month(STUDENT.BDAY) = month(sysdatetime()) + 1; --month ���������� ����� ����

--SYSDATETIME: ���������� ������� ��������� ���� � ����� �� ������ ��������� �����, �� ������� �� GETDATE ������� � ���, 
--��� ���� � ����� ������������ � ���� ������� datetime2

--������� 4.4

declare @groupNumber int = 3;

--DATEPART: ���������� ����� ���� � ���� �����. �������� ������ ����� ���� ���������� � �������� ������� ��������� 
--(������������ �� �� ���������, ��� � ��� DATENAME), � ���� ���� ���������� � �������� ������� ���������:

select distinct PROGRESS.PDATE[���� ���������� ��������], case 
		when DATEPART(dw,PROGRESS.PDATE) = 1 then '�����������'
		when DATEPART(dw,PROGRESS.PDATE) = 2 then '�������'
		when DATEPART(dw,PROGRESS.PDATE) = 3 then '�����'
		when DATEPART(dw,PROGRESS.PDATE) = 4 then '�������'
		when DATEPART(dw,PROGRESS.PDATE) = 5 then '�������'
		when DATEPART(dw,PROGRESS.PDATE) = 6 then '�������'
		when DATEPART(dw,PROGRESS.PDATE) = 7 then '�����������'
end [���� ������]
from GROUPS inner join STUDENT on STUDENT.IDGROUP = GROUPS.IDGROUP
			inner join PROGRESS on STUDENT.IDSTUDENT= PROGRESS.IDSTUDENT
	where GROUPS.IDGROUP = @groupNumber