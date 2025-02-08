
-- 1. �������� ������ ���� ��������� ����������� (������������, ��������� � UNDO).
SELECT tablespace_name, contents 
FROM dba_tablespaces;

-- 2. �������� ������ ���� ������ ��������� ����������� (������������, ��������� � UNDO).
SELECT  file_name
FROM dba_data_files 
UNION ALL 
SELECT  file_name 
FROM dba_temp_files;


-- 3. �������� �������� ���� ����� �������� �������. ���������� ������� ������ �������� �������.
SELECT group#, status
FROM v$log;

-- 4. �������� �������� ������ ���� �������� �������
SELECT member 
FROM v$logfile;


-- 5. � ������� ������������ �������� ������� �������� ������ ���� ������������. ���������� ������������������ SCN.
-- ����� ��������� ������ ��� ������� ������ (���� � ��� 3 ������� ����������)
select * from v$log;

ALTER SYSTEM SWITCH LOGFILE;

-- 6. �������� �������������� ������ �������� ������� � ����� ������� �������. ��������� � ������� ������ � 
-- ������, � ����� � ����������������� ������ (�������������). ���������� ������������������ SCN. 

ALTER DATABASE ADD LOGFILE GROUP 4 'E:\Apps\Oracle\oradata\DB13\REDO04.LOG'
SIZE 50M BLOCKSIZE 512;

ALTER DATABASE ADD LOGFILE MEMBER 'E:\Apps\Oracle\oradata\DB13\REDO041.LOG' TO GROUP 4;
ALTER DATABASE ADD LOGFILE MEMBER 'E:\Apps\Oracle\oradata\DB13\REDO042.LOG' TO GROUP 4;
ALTER DATABASE ADD LOGFILE MEMBER 'E:\Apps\Oracle\oradata\DB13\REDO043.LOG' TO GROUP 4;


-- 7. ������� ��������� ������ �������� �������. ������� ��������� ���� ����� �������� �� �������.

ALTER DATABASE DROP LOGFILE MEMBER 'E:\Apps\Oracle\oradata\DB13\REDO041.LOG';
ALTER DATABASE DROP LOGFILE MEMBER 'E:\Apps\Oracle\oradata\DB13\REDO042.LOG';
ALTER DATABASE DROP LOGFILE MEMBER 'E:\Apps\Oracle\oradata\DB13\REDO043.LOG';

ALTER DATABASE DROP LOGFILE GROUP 4;

-- 8
SELECT NAME, LOG_MODE FROM V$DATABASE;

--11 - ����� ������������� �� �� ��, ��� �������� ������
ALTER SYSTEM SWITCH LOGFILE;
SELECT * FROM V$ARCHIVED_LOG;

-- 13
SELECT * FROM V$CONTROLFILE;
-- 14
Show PARAMETER CONTROL;