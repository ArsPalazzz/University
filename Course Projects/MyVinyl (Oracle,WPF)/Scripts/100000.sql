create table hugeAmountRows(
    id int primary key,
    content nvarchar2(10)
);


create or replace procedure insertTrashData(
    i int,
    text nvarchar2
)
is
begin
    insert into hugeAmountRows (id, content) values (i, text);
end;



select * from hugeAmountRows order by id desc;
truncate table hugeAmountRows



declare
    i number := 1;
begin
    while i <= 100000 loop
        insertTrashData(i, 'content');
        i := i + 1;
    end loop;
end;





EXPLAIN PLAN FOR
SELECT *
    FROM Record r
    JOIN Genre_details gd ON r.record_id = gd.record_id
    JOIN Genre g ON gd.genre_id = g.genre_id;
    SELECT * FROM TABLE (DBMS_XPLAN.DISPLAY);
    
    
    
create index idx_record_isDeleted on record (is_deleted) tablespace TS_USER;
create index idx_genre_genreName on genre (genre_name) tablespace TS_USER;