USE UNIVER;

DROP VIEW [���������];
GO

CREATE VIEW ��������� (���, [������������ ���������], [��� ���������])
	AS SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE
		FROM AUDITORIUM
			WHERE AUDITORIUM_TYPE LIKE '��%'
		GO
	SELECT * FROM  ���������;

INSERT ��������� values('275-1', '275-1', '��')
INSERT ��������� values('276-1', '276-1', '��')

DELETE FROM ���������
	WHERE ��� = '275-1' or ��� = '276-1'