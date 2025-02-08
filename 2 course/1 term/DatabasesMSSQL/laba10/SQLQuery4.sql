deallocate Local

set nocount on

declare @type nvarchar(20), @capacity nvarchar(20)
declare Local cursor global static scroll for select AUDITORIUM_TYPE, AUDITORIUM_CAPACITY from AUDITORIUM

open Local
print '���: '
fetch Local into @type, @capacity
while @@FETCH_STATUS = 0
	begin
		print '' + @type + ' ' + @capacity
		fetch Local into @type, @capacity
	end
close Local

open Local
print '������ ������: '
fetch first from Local into @type, @capacity
print '' + @type + @capacity

print '������ ������ (absolute)'
fetch absolute 2 from Local into @type, @capacity
print ''  + @type + @capacity

print '������ ������ � ����� (absolute)'
fetch absolute -5 from Local into @type, @capacity
print ''  + @type + @capacity

print '������ ������ ������������ ������� (relative)'
fetch relative 2 from Local into @type, @capacity
print ''  + @type + @capacity

print '��������� ������ ������������ �������: '
fetch next from Local into @type, @capacity
print ''  + @type + @capacity

print '���������� ������ ������������ �������: '
fetch prior from Local into @type, @capacity
print ''  + @type + @capacity

print '��������� ������: '
fetch last from Local into @type, @capacity
print ''  + @type + @capacity

close Local
go