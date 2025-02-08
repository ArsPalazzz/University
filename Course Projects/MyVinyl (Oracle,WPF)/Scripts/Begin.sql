--1. orcl connection sys - 12345Sys - creation of OTHERUSERCORE


CREATE ROLE RL_OTHERUSERCORE;

grant create session,
      create table,
      create view,
      create procedure,
      drop any table,
      drop any view,
      drop any procedure,
     create job,
      create sequence,
       create trigger
to RL_OTHERUSERCORE;
commit;



CREATE PROFILE PF_OTHERUSERCORE LIMIT
    PASSWORD_LIFE_TIME 180
    SESSIONS_PER_USER 3
    FAILED_LOGIN_ATTEMPTS 7
    PASSWORD_LOCK_TIME 1
    PASSWORD_REUSE_TIME 10
    PASSWORD_GRACE_TIME DEFAULT
    CONNECT_TIME 180
    IDLE_TIME 30;


ALTER SESSION SET "_ORACLE_SCRIPT"=true


CREATE TABLESPACE TS_USER
    DATAFILE 'TS_foruser_cdb.dbf'
    SIZE 7M
    AUTOEXTEND ON NEXT 5M
    MAXSIZE 20M
    EXTENT MANAGEMENT LOCAL;
    
CREATE TEMPORARY TABLESPACE  TS_USER_TEMP
    TEMPFILE 'TS_foruser_temp_cdb.dbf'
    SIZE 5M
    AUTOEXTEND ON NEXT 3M
    MAXSIZE 30M
    EXTENT MANAGEMENT LOCAL;
    
    
    
    
    create user OTHERUSERCORE identified by 12345
default tablespace TS_USER quota unlimited on TS_USER
temporary tablespace TS_USER_TEMP
profile PF_OTHERUSERCORE
account unlock;

grant RL_OTHERUSERCORE to OTHERUSERCORE;
    
    
    
    
    
    
    
    
    

CREATE ROLE RL_GUESTCORE;

grant create session to RL_GUESTCORE;
grant execute on GETSONGSFORRECORD to RL_GUESTCORE;
grant execute on getUserInfo to RL_GUESTCORE;
grant execute on filterByCost to RL_GUESTCORE;
grant execute on filterByIdAsc to RL_GUESTCORE;
grant execute on filterByYear to RL_GUESTCORE;
grant execute on regNewUser to RL_GUESTCORE;
grant execute on getUsers to RL_GUESTCORE;
grant execute on getRecordsInfo to RL_GUESTCORE;
grant execute on GetPopularRecords to RL_GUESTCORE;
grant execute on getRecordsAmountNotZero to RL_GUESTCORE;
commit;


CREATE PROFILE PF_GUESTCORE LIMIT
    PASSWORD_LIFE_TIME 180
    SESSIONS_PER_USER 3
    FAILED_LOGIN_ATTEMPTS 7
    PASSWORD_LOCK_TIME 1
    PASSWORD_REUSE_TIME 10
    PASSWORD_GRACE_TIME DEFAULT
    CONNECT_TIME 180
    IDLE_TIME 30;
    
create user GUESTCORE identified by 12345
default tablespace TS_USER quota unlimited on TS_USER
temporary tablespace TS_USER_TEMP
profile PF_GUESTCORE
account unlock;

grant RL_GUESTCORE to GUESTCORE;





--user
GETSUPPLIERNAME
getAllComments
INSERT_SONGS
INSERT_GENRES
DELETE_RECORD
update_record
UPDATE_SONGS
UPDATE_GENRES
GETSONGSFORRECORD
GETGENRESFORRECORD
ADD_NEW_RECORD
reduceAmountOfRecord
GetRecordsByGenre
PurchaseRecords
GetPopularRecords

--guest
GETSONGSFORRECORD
getUserInfo
filterByCost
filterByIdAsc
filterByYear
regNewUser
getUsers
getRecordsInfo
GetPopularRecords

CREATE ROLE RL_USERCORE;


grant create session to RL_USERCORE;
grant execute on GETSONGSFORRECORD to RL_USERCORE;
grant execute on getUserInfo to RL_USERCORE;
grant execute on filterByCost to RL_USERCORE;
grant execute on filterByIdAsc to RL_USERCORE;
grant execute on filterByYear to RL_USERCORE;
grant execute on regNewUser to RL_USERCORE;
grant execute on getUsers to RL_USERCORE;
grant execute on getRecordsInfo to RL_USERCORE;
grant execute on GETSUPPLIERNAME to RL_USERCORE;
grant execute on getAllComments to RL_USERCORE;
grant execute on INSERT_SONGS to RL_USERCORE;
grant execute on INSERT_GENRES to RL_USERCORE;
grant execute on DELETE_RECORD to RL_USERCORE;
grant execute on update_record to RL_USERCORE;
grant execute on UPDATE_SONGS to RL_USERCORE;
grant execute on UPDATE_GENRES to RL_USERCORE;
grant execute on GETSONGSFORRECORD to RL_USERCORE;
grant execute on GETGENRESFORRECORD to RL_USERCORE;
grant execute on ADD_NEW_RECORD to RL_USERCORE;
grant execute on reduceAmountOfRecord to RL_USERCORE;
grant execute on GetRecordsByGenre to RL_USERCORE;
grant execute on PurchaseRecords to RL_GUESTCORE;
grant execute on GetPopularRecords to RL_GUESTCORE;
grant execute on getRecordsAmountNotZero to RL_GUESTCORE;
grant execute on getNewRecords to RL_GUESTCORE;
grant execute on WriteReview to RL_GUESTCORE;

commit;


CREATE PROFILE PF_USERCORE LIMIT
    PASSWORD_LIFE_TIME 180
    SESSIONS_PER_USER 3
    FAILED_LOGIN_ATTEMPTS 7
    PASSWORD_LOCK_TIME 1
    PASSWORD_REUSE_TIME 10
    PASSWORD_GRACE_TIME DEFAULT
    CONNECT_TIME 180
    IDLE_TIME 30;
    
create user USERCORE identified by 12345
default tablespace TS_USER quota unlimited on TS_USER
temporary tablespace TS_USER_TEMP
profile PF_USERCORE
account unlock;

grant RL_USERCORE to USERCORE;





CREATE ROLE RL_MODERCORE;


grant create session to RL_MODERCORE;
grant execute on GetUserComments to RL_MODERCORE;
grant execute on GetAllClients to RL_MODERCORE;
grant execute on DeleteComment to RL_MODERCORE;

commit;


CREATE PROFILE PF_MODERCORE LIMIT
    PASSWORD_LIFE_TIME 180
    SESSIONS_PER_USER 3
    FAILED_LOGIN_ATTEMPTS 7
    PASSWORD_LOCK_TIME 1
    PASSWORD_REUSE_TIME 10
    PASSWORD_GRACE_TIME DEFAULT
    CONNECT_TIME 180
    IDLE_TIME 30;
    
create user MODERCORE identified by 12345
default tablespace TS_USER quota unlimited on TS_USER
temporary tablespace TS_USER_TEMP
profile PF_MODERCORE
account unlock;

grant RL_MODERCORE to MODERCORE;