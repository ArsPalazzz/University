declare @Note int, @Name nvarchar(50), @Faculty nvarchar(20);
declare lastCurs cursor dynamic global for select PROGRESS.NOTE, STUDENT.NAME, GROUPS.FACULTY
										  from PROGRESS inner join STUDENT on PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
										  inner join  GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP

open lastCurs
fetch lastCurs into @Note, @Name, @Faculty
while @@FETCH_STATUS = 0
	begin
		print 'Оценка ' + cast(@Note as nvarchar(10)) + ' - ' + @Name + ' - ' + @Faculty
		fetch lastCurs into @Note, @Name, @Faculty

		if @Note <4 
			delete PROGRESS where current of lastCurs

		if @Note <4 
			delete STUDENT where current of lastCurs

		if @Note <4 
			delete GROUPS where current of lastCurs
	end
close lastCurs
deallocate lastCurs
go


--------------------------------------------------------------------------------------



declare @Subject nvarchar(10), @IDStudent int, @Note int
declare Task6 cursor global dynamic for select SUBJECT, IDSTUDENT, NOTE
										from PROGRESS for update

open Task6
fetch Task6 into @Subject, @IDStudent, @Note
while @@FETCH_STATUS = 0
	begin
		print @Subject + ' ' +cast(@IDStudent as nvarchar(10)) + ' ' + cast(@Note as nvarchar(20))
		if @IDStudent = 1021 update PROGRESS set NOTE = NOTE - 1 where current of Task6
		fetch Task6 into @Subject, @IDStudent, @Note
	end
close Task6
deallocate Task6

select SUBJECT[Предмет], IDSTUDENT[Id студента], NOTE[Оценка] from PROGRESS
go

update PROGRESS set NOTE = 9 where IDSTUDENT = 1021
