use UNIVER

declare @amount int = (select count(*) from AUDITORIUM)
if @amount > 10
	begin
		print '���������� ��������� ������, ��� 10'
		print '�����'
		print '�����'
	end
else if @amount < 10
	begin
		print '���������� ��������� ������, ��� 10'
		print '�����'
		print '�����'
	end
else 
	print '���������� ��������� ����� 10'