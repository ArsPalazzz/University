create table #MyTable([�������� ��������] int, ���������� nvarchar(50), ���������� nvarchar(50));
set nocount on; --�� �������� ��������� � ����� �����
declare @i int = 1;
while @i <11
	begin
		if @i = 5
			return
		else
			begin
				insert into #MyTable values
				(cast(@i as int), cast(@i as nvarchar(10)) + ' + 1 = ' + cast((@i + 1) as nvarchar(10)),cast(@i as nvarchar(10)) + ' - 1 = ' + cast((@i - 1) as nvarchar(10)))
				print '�������� ' + cast(@i as nvarchar(10))
				set @i +=1;
			end
	end
select * from #MyTable
order by [�������� ��������] desc
go

drop table #MyTable;