USE UNIVER;

DROP VIEW [���������� ������];
GO

CREATE VIEW [���������� ������]
	AS SELECT	FACULTY.FACULTY_NAME [���������],
				count (distinct PULPIT.PULPIT) [���������� ������]
	FROM FACULTY JOIN PULPIT
		ON FACULTY.FACULTY = PULPIT.FACULTY
			GROUP BY FACULTY.FACULTY_NAME;
	go
select * from [���������� ������];