USE UNIVER;

DROP VIEW [����������_���������];
GO

CREATE VIEW ����������_��������� (���, [������������ ���������], [��� ���������])
	AS SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE
		FROM AUDITORIUM
			WHERE AUDITORIUM_TYPE LIKE '��%'
		GO
	SELECT * FROM  ����������_���������;

INSERT ��������� values('275-1', '275-1', '����')
INSERT ��������� values('276-1', '276-1', '��')

DELETE FROM ���������
	WHERE ��� = '275-1' or ��� = '276-1'

GO

--����� �������� ������� �� ����� ������������� � ��� ������, ����� ���������� �� ������������� �������, 
--����������� � ������ Where, �� ������� ��������� ������������� � ������ WITH CHECK OPTION
ALTER VIEW ����������_��������� (���, [������������ ���������], [��� ���������])
	AS SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE
		FROM AUDITORIUM
			WHERE AUDITORIUM_TYPE LIKE '��%' WITH CHECK OPTION
		GO
	SELECT * FROM  ����������_���������;

INSERT ����������_��������� values('277-1', '275-1', '��-�')
INSERT ����������_��������� values('276-1', '276-1', '��')

DELETE FROM ���������
	WHERE ��� = '276-1'