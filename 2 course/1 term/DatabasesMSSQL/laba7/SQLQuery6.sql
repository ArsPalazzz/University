USE UNIVER;
GO

ALTER VIEW [���������� ������] WITH SCHEMABINDING
	AS SELECT FACULTY.FACULTY_NAME [���������], COUNT (*) [���������� ������]
		FROM dbo.FACULTY JOIN dbo.PULPIT
			ON FACULTY.FACULTY = PULPIT.FACULTY
				GROUP BY FACULTY.FACULTY_NAME
		GO
	SELECT * FROM  [���������� ������];

	/*����� SCHEMABINDING ������������� ���������� �� �������� � ��������� � ���������������, ������� ����� �������� � ��������� 
	����������������� �������������*/