go
create procedure SUBJECT_REPORT @p nvarchar(10) as 
begin
	declare @counter int = 0;
	begin try
		declare @sub nvarchar(10), @line_sub nvarchar(500) = ''
		declare Subjects cursor local static for
		select SUBJECT from SUBJECT where PULPIT = @p order by PULPIT
		if not exists (select PULPIT from SUBJECT where PULPIT = @p)
		begin
			raiserror('������, ��� ����� ������', 11, 1);
			/*RAISERROR, ������� �������� ��� ���������: ��������� ��������� �� ������, ������� ����������� ������ � �����. 
			���� ������� ������-����� ����� 11, �� ���������� ���������� � ���� ��������� ������*/
		end
		else
		begin
			open Subjects
			fetch Subjects into @sub
			set @line_sub = rtrim(@sub)
			--rtrim ���������� ������ ��������, �� ������� ������� ��� ����������� �������.
			set @counter +=1
			fetch Subjects into @sub
			while @@FETCH_STATUS = 0
			begin
				set @line_sub = '' + rtrim(@sub) + ', ' + @line_sub
				set @counter +=1
				fetch Subjects into @sub
			end
			print '�������� �� ������� ' + @p + ': ' + @line_sub
			return @counter
		end
	end try
	begin catch
		print '������ � ����������' 
        if error_procedure() is not null   
			print '��� ��������� : ' + error_procedure()
        return @counter
	end catch
end
go

declare @c int
exec @c = Subject_Report @p = '����'
print '���������� ��������� �� �������������: ' + cast(@c as nvarchar)

drop procedure SUBJECT_REPORT;
