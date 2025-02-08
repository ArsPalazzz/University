deallocate Local

set nocount on

declare @type nvarchar(20), @capacity nvarchar(20)
declare Local cursor global static scroll for select AUDITORIUM_TYPE, AUDITORIUM_CAPACITY from AUDITORIUM

open Local
print 'Тип: '
fetch Local into @type, @capacity
while @@FETCH_STATUS = 0
	begin
		print '' + @type + ' ' + @capacity
		fetch Local into @type, @capacity
	end
close Local

open Local
print 'Первая строка: '
fetch first from Local into @type, @capacity
print '' + @type + @capacity

print 'Вторая строка (absolute)'
fetch absolute 2 from Local into @type, @capacity
print ''  + @type + @capacity

print 'Третья строка с конца (absolute)'
fetch absolute -5 from Local into @type, @capacity
print ''  + @type + @capacity

print 'Вторая строка относительно текущей (relative)'
fetch relative 2 from Local into @type, @capacity
print ''  + @type + @capacity

print 'Следующая строка относительно текущей: '
fetch next from Local into @type, @capacity
print ''  + @type + @capacity

print 'Предыдущая строка относительно текущей: '
fetch prior from Local into @type, @capacity
print ''  + @type + @capacity

print 'Последняя строка: '
fetch last from Local into @type, @capacity
print ''  + @type + @capacity

close Local
go