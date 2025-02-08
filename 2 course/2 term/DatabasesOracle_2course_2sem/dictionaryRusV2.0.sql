	--������������� � ��������� ��������� ������������ SYSTEM
	--	USER	�������, ������������� ������������
	--	ALL	�������, � ������� ������������ ����� ������ 
	--	DBA	��� ������� ���� ������ (��� �������������� ��)
	--	V$	 ������������������ �������
	-- ��� ������� � ������� GRANT SELECT ANY DICTIONARY


--����� ��������� ������������� USER_OBJECTS
DESCRIBE user_objects;

--����� ���� ������ ������������
select object_name from user_objects where object_name = 'TABLE';

--��������� ������� ���� �������������
select * from dba_users;
select * from dba_users where usrname like 'C##%';

--��������� ������� ���� �����
select * from dba_roles;

--��������� ������� ����������
select * from dba_sys_privs;

select * from dba_sys_privs where grantee = '���_����';

--����� ������ �������� ��
selct object_name, owner, status from dba_objects;

--����� ������ ���������������� ������������
select constraint_name where table_name = '...';

--����� �������� � �������������� ������� Oracle
select * from dba_synonyms where table_owner = 'SYS';

--��������� ������ ����������� ������
select * from v$controlfile;
select * from dba_data_files; ---------------????????????????????????????????

--�������� ������ �������������� �������� / ����� �����������
select * from v@services;

--�������� ������ ���������� ����������
select instance_name from v$instanse;
show PARAMETR instance;

---------------------------------------dba_pdbs / v$sga------------------------------
--������� ���������� �������� ����������, � �������� ������� ���������� ��� (����. ���-�� �������) - ���� ������� ����������� ����������, ��� ������ ������ � ����������� ����
select * from v$sga;

-- ������ ������������� �������� ����� ��������� ���������� � �������� ���� �����������, ���� ����� ������, ������� ������� �������� �������� ���������� ����������. ��������, ��� ��������� �������� � ������� ��������� ������ � ��� ����� ��������� ������
select * from v$sgastat

--�������� ���������� ���������� sga
select * from v$sgainfo; --����� ���������� ������� �����, ������

--
select * from v$sga_dynamic_components;

--�������� �������� � ������������ ��
select name, open_mode, total_sixe from v$pdbs;
select PDB_NAME from dba_pdbs; --------------????????????????????????????????

-----------------------------------------logfile / log-------------------------------
--��������� ������� ���� ����� �������� �������
select * from v$logfile;

--����������� ������� ������ ������� �������
select * from v$logfile where status = 'CURRENT';

--��������� ������� ������ ���� �������� �������
select * from v$log;

--��������, ������������ �� ������������� �������� �������	---!!!!
select * from v$archive_dest_status;

-----------------------------------------tablespaces---------------------------

--��������� ������ ������������ ��������� ������������ 
select tablespace_name, status, contents logging from sys.DBA_TABLESPACES;

--��������� ������ ��������� ��������� ����������
select file_name, tablespace_name, status, maxbytes, user_bytes from dba_data_files
UNION
select file_name, tablespace_name, status, maxbytes, user_bytes from dba_temp_files;

----------------------------------------------dba_segments--------------------------
--�������� ������ ��������� ���������� ������������
select * from dba_segments where tablespace_name = '���_���������� ������������';

--�������� (���������) ������ ������ � �������
select sum(bytes) from dba_segments where tablespase_name = 'PPPCORE';

--��������� ���������� ������, ������� �������
select sum(blocks) from dba_segments where tablespace_name = 'PPPCORE';

----------------------------------------------user_segments-------------------------
--��������� ������� ��������� �����
select * from user_segments;
select bytes, blocks from user_segments;

--������� ������� �� ���� ��������, ���� �� ������� ��������� ����.
--�������� �������� ���� ���������. �������� ������ � �������. ���������, �������
--� �������� ������� ���������, �� ������ � ������ � ������.
create table TEST 
(
	ID number(10) primary key,
	NAMEE varchar2(20)
);
insert into TEST values (1, 'TEST');
select segment_name, segment_type, EXTENTS, blocks, bytes from user_segments;

-------------------------------------------dictionary---------------------------
--����� ������ ���� ������������� ������� ������, ��������� ������������
select * from dictionary;

--����� ������ ������� ������ �� �������� ����� � ������� COMMENTS ������� DICTIONARY
select * from dictionary where lower(comments) like '%grant%';

--------------------------------------------session-----------------------------
--������� ������ ���� ������
select * from v$session;

--
select * from v$session where TYPE!='BACKGROUND';

--�������� �������� ���� ��������� ���� Oracle. 
--��� ��������� ��������� ������� �����������. 
--��� ������� ������� ���������� � ��������� ������.
select sid, serial#, username, status, process, machine, program, type, loggon_time from v$session;
select sid, serial#, username, status, process, machine, program, type, loggon_time from v$session where type = 'BACKGROUND' and status = 'ACTIVE';

--�������� ����������� � �������
select * from v$session where username is not null;

-----------------------------------------------dba_profiles-----------------------
--��������� ������� ���� �������� �������������
select * from DBA_PROFILES;

--��������� ������� ���� ������� (����������) ������-�. ������� ������������
select * from dba_profiles where profile = '���_�������_������������' --���� 'DEFAULT'

---------------------------------------------CREATE-----------------------------------
--�������� ������� � �������� � ��� 100 �������. ������� ������� � � �������� � �������������� �������.
CREATE table TEST 
(
	ID number(10) primary key,
	NAMEE varchar2(20)
);
begin for i..100
	loop 
		insert into TEST values (i, 'TEST');
	end loop;
end;
select * from dba_tables where table_name = 'TEST';

--����������� PFILE
CREATE PFILE = 'my_init.ora' from memory;  --� sqlplus �� sysdba

--�������� ����
CREATE ROLE TEAT_ROLE;

--�������� ������� ������������
CREATE profile PPPCORE limit 
	PASSWORD_LIFE_TIME 180
	SESSIONS_PER_USER 3
	FAILED_LOGIN_ATTEMPTS 7
	PASSWORD_LOCK_TIME 1
	PASSWORD_REUSE_TIME 10
	PASSWORD_GRACE_TIME DEFAULT
	CONNECT_TIME 180
	IDLE_TIME 30

--������� ���������� ������������
CREATE TABLESPACES tablespase_name
	DATAFILE '����'						--TEMPFILE '����'
	SIZE 10 m
	AUTOEXTEND ON NEXT 500K
	MAXSIZE 100M
	EXTENT MANAGEMENT LOCAL;

--�������� ������������ 
CREATE USER #PPPCORE IDENTIFIED BY 12345
DEFAULT TABLESPACES tablespace_name QUOTA UNLIMITED ON tablespace_name
TEMPORARY TABLESPACES temp_tablespace_name
PROFILE PPPCORE
ACCOUNT UNLOCK
PASSWORD EXPIRE
------------------------------------------------------------------------------
������� 1
--1. �������� ������ ���� ��������� ��������� �����������
 select * from dba_tablespaces where contents='TEMPORARY'
--2. �������� ������ ���������� ��� ���� sys
 select * from dba_sys_privs where grantee='SYS' 
 select * from USER_sys_privs//���� ����� �� sys 
--3. �������� ������ ���� ��������, ������������� ������������
 select * from user_OBJECTS
--4. �������� ������ ������ ������� �������� �������
select * from v$log where status = 'CURRENT';
--5. �������� ��������� ����� �������� �������
select * from v$archived_log;
--6. �������� ����������������� ����� ����������
select * from v$patameter(?)
show parameter pfile; --���� ��� pfile(���������), �� �������� spfile(��������)
--7. ��� ���� ������. ������������ �����, � ����� ���� ��������� ����
select segment_name, segment_type, tablespace_name, buffer_pool 
from dba_segments 
--8. �������� ������ �������������, ������� ���������� sysdba �� ����� �������
select * from v$pwfile_users where sysdba='TRUE'
--9. �������� ������ ������� � �������� ����
select * from v$sgainfo where name = 'Granule Size'
select component,
      current_size,
      max_size,
      granule_size from v$sga_dynamic_components where current_size>0 and component like '%buffer%';
--10. �������� ������ ���������� � ��������� ����� ������� ��������
SELECT * FROM v$BGPROCESS where paddr != hextoraw('00');

������� 2
--1. �������� ��� ������������� �������, ����������� � ���������
SELECT * FROM dict where table_name like '%PROCESS%';
--2. �������� ������ ������ ��������� ����������� ������
select * from dba_tablespaces where contents='UNDO'
--3. �������� ������ ���� �����
select * from DBA_ROLES ;
--4. �������� ������ ������ � ���������� ������� ������������
select pool, name, bytes 
from v$sgastat 
order by bytes desc fetch first 1 rows only;
--5. �������� ������ ����� ������ ����� ���������
show parameter db_block_size;
select distinct bytes/blocks from user_segments;
--6. �������� ������ ���������� ����������
select * from v$instance;
--7. �������� ����������������� ����� �������
select * from v$logfile;
--8. �������� ����� ������, ���������� ��� ������� ���������������� �������
select component, current_size 
from v$sga_dynamic_components 
where component like '%RECYCLE%'
--9. �������� ������ �������������� ��������
SELECT * FROM V$SERVICES;
--10. �������� ������ ���������� � ��������� ����� ��������� ���������.
select * from v$process;






-������� 1
--1. �������� ������ ���� ��������� ��������� �����������

--2. �������� ������ ���������� ��� ���� sys

--3. �������� ������ ���� ��������, ������������� ������������

--4. �������� ������ ������ ������� �������� �������

--5. �������� ��������� ����� �������� �������

--6. �������� ����������������� ����� ����������

--7. ��� ���� ������. ������������ �����, � ����� ���� ��������� ����
?
--8. �������� ������ �������������, ������� ���������� sysdba �� ����� �������

--9. �������� ������ ������� � �������� ����

--10. �������� ������ ���������� � ��������� ����� ������� ��������


--������� 2
--1. �������� ��� ������������� �������, ����������� � ���������

--2. �������� ������ ������ ��������� ����������� ������

--3. �������� ������ ���� �����

--4. �������� ������ ������ � ���������� ������� ������������

--5. �������� ������ ����� ������ ����� ���������

--6. �������� ������ ���������� ����������

--7. �������� ����������������� ����� �������

--8. �������� ����� ������, ���������� ��� ������� ���������������� �������

--9. �������� ������ �������������� ��������

--10. �������� ������ ���������� � ��������� ����� ��������� ���������.