USE UNIVER;
DECLARE @discip char(20), @d char(300) ='';
DECLARE Discipline CURSOR
				for SELECT SUBJECT.SUBJECT --1 �������
					FROM SUBJECT 
					WHERE SUBJECT.PULPIT IN('����')
	OPEN Discipline; --������ ����������� � ������� ��������� OPEN
	FETCH Discipline into @discip; --1 ����������
	print '���������� � ������� ����';
	while @@fetch_status = 0
		begin
			set @d = rtrim(@discip) + ',' + @d;
			FETCH Discipline into @discip; --1 ����������
		end;
	print @d;
	CLOSE Discipline;
	DEALLOCATE Discipline /*������� ������ �������. ����� ��������� ��������� ������ �������, Microsoft SQL Server ����������� 
							��������� ������, ������������ ������. */