use UNIVER

SELECT FACULTY.FACULTY, PULPIT.PULPIT, PROFESSION.PROFESSION, SUBJECT.SUBJECT, STUDENT.NAME,
	Case 
	when (PROGRESS.NOTE between 6 and 7) then 'Шесть'
	when (PROGRESS.NOTE between 7 and 8) then 'Семь'
	when (PROGRESS.NOTE between 8 and 9) then 'Восемь'
	else 'Оценка не входит в диапазон от 6 до 8'
	end Оценка
FROM FACULTY, PULPIT, PROFESSION, SUBJECT, STUDENT INNER JOIN PROGRESS
ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	ORDER BY 
	( Case
		when (PROGRESS.NOTE between 6 and 7) then 3
		when (PROGRESS.NOTE between 7 and 8) then 1
		when (PROGRESS.NOTE between 8 and 9) then 2
		else 4
	  end
	) 