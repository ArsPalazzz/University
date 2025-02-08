--PROFILE
create profile C##PFPAV limit
  password_life_time 180 
  sessions_per_user 3 
  failed_login_attempts 7 
  password_lock_time 1
  password_reuse_time 10 
  password_grace_time default 
  connect_time 180 
  idle_time 30; 

  select * from dba_profiles;
  select * from dba_profiles where profile='C##PFPAV';
--ROLE
 create role C##RL_PAV;
 select * from dba_roles where role like '%PAV%';
  GRANT CREATE SESSION TO C##RL_PAV;
  GRANT CREATE VIEW, DROP ANY VIEW TO C##RL_PAV;
  GRANT CREATE PROCEDURE, DROP ANY PROCEDURE TO C##RL_PAV;
  GRANT CREATE TABLE, DROP ANY TABLE TO C##RL_PAV;
 


select *from dba_sys_privs where grantee like '%C##RL_PAV';

--USER
  create user C##PAV identified by qwe
    profile C##PFPAV
    account unlock;
 GRANT CREATE DATABASE LINK TO C##PAV;

    select * from all_users where username like '%PAV%';
GRANT 
GRANT C##RL_PAV TO C##PAV;
GRANT ALL PRIVILEGES TO C##PAV;
---------------------------------------------------
CREATE DATABASE LINK LUJA
CONNECT TO C##STS IDENTIFIED BY "qwe"
USING '192.168.117.184/xe';
drop database link LUJA;
---------------------------------------
---------------------------------------
---------------------------------------
drop table RIS;
truncate table RIS;
commit;
create table RIS(id int primary key,str varchar(20), numb NUMBER GENERATED ALWAYS AS IDENTITY);
--drop table RIS@LUJA;
select * from RIS@LUJA;
select * from RIS;
delete RIS@LUJA;
--delete RIS;
commit;
rollback;---отмен комит
--«адание 1
begin
    insert into RIS(id,str) values(2,'ars');
    insert into RIS@LUJA(id,str) values(2,'tanya');
commit;
end;

select * from RIS@LUJA;
select * from RIS;

begin
    insert into RIS(id,str) values(3,'vlad');
    update RIS@LUJA set str='tanyatanya' where str ='tanya';
commit;
end;

begin
    update RIS set str='arsars' where str ='ars';
    insert into RIS@LUJA(id,str) values(10,'hzkto');
commit;
end;

--«адание 2 (нарушение ограничени€ целостности на стороне удаленного сервера)
insert into RIS@LUJA(id,str) values(11,'hzkto');
commit;

-- блокировка
BEGIN
    -- ¬ыполн€ем блокировку строки, имитиру€ длительную операцию
    UPDATE RIS SET str = 'aaaars' WHERE id = 1;
    -- Ќе коммитим изменени€, чтобы удерживать блокировку
END;

BEGIN
    -- ¬ыполн€ем блокировку строки, имитиру€ длительную операцию
    UPDATE RIS@LUJA SET str = 'LUJA' WHERE id = 35;
    -- Ќе коммитим изменени€, чтобы удерживать блокировку
END;