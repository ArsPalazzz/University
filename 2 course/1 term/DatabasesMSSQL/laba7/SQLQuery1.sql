use UNIVER

DROP VIEW [Преподаватель];
GO

CREATE VIEW [Преподаватель]
	AS SELECT	TEACHER [Код],
				TEACHER_NAME [Имя преподавателя],
				GENDER [Пол],
				PULPIT [Код кафедры]
	FROM TEACHER;