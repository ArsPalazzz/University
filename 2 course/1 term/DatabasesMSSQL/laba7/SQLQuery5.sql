USE UNIVER;

DROP VIEW [����������];
GO

CREATE VIEW ���������� (���, [������������ ����������], [��� �������])
	AS SELECT TOP 150 SUBJECT, SUBJECT_NAME, PULPIT
		FROM SUBJECT
			ORDER BY SUBJECT_NAME
		GO
	SELECT * FROM  ����������;