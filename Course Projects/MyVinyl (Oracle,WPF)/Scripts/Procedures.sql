--4) orcl OTHERUSERCORE-12345 - creation of all procedures










--регистрация нового пользователя
create or replace procedure regNewUser (
    appClientId in Client.client_id%TYPE,          --params 
    appLogin in Client.login_client%TYPE,
    appPassword in Client.password_client%TYPE,
    appPhone in Client.phone_number%TYPE,
    appEmail in Client.email%TYPE,
    appSex in Client.sex%Type,
    appDateOfBirth in Client.date_of_birth%Type
)
is
begin
    insert into Client(client_id, login_client, password_client, phone_number, email, sex, date_of_birth)
    values (null,appLogin,appPassword,appPhone,appEmail,appSex,appDateOfBirth);
commit;
end;







--get all user info
create or replace procedure getUsers (
     users OUT SYS_REFCURSOR
)
is
begin
     OPEN users FOR 
    SELECT client_id, login_client, password_client
    FROM Client;
end;








--show all inf about Records
create or replace procedure getRecordsInfo (
    records out sys_refcursor
)
IS
--вывод всех пластинок
BEGIN
    OPEN records FOR 
    SELECT record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture,
    status, is_deleted, date_of_deliv_to_warehouse
    FROM Record
    order by record_id desc;
END;






CREATE OR REPLACE PROCEDURE update_record( 
    p_id IN Record.record_id%type,
    p_year IN Record.year%type, 
    p_cost IN Record.cost%type, 
    p_amount IN Record.amount%type,  
    p_description IN Record.description%type, 
    p_artist_name IN Record.artist_name%type, 
    p_album_name IN Record.album_name%type, 
    p_picture IN Record.picture%type, 
    p_status IN Record.status%type, 
    p_date IN Record.date_of_deliv_to_warehouse%type 
) 
IS   
BEGIN 
    update Record 
    set year = p_year,
        cost = p_cost,
        amount = p_amount,
        description = p_description,
        artist_name = p_artist_name,
        album_name = p_album_name,
        picture = p_picture,
        status = p_status,
        date_of_deliv_to_warehouse = p_date
    where record_id = p_id;
COMMIT; 
END;




CREATE OR REPLACE PROCEDURE UPDATE_SONGS(
    p_id in Record.record_id%type,
    p_songs IN VARCHAR2, 
    p_artist_name in Song.song_name%type, 
    p_album_name in Song.album_name%type, 
    p_side in Song.side%type 
    )
IS
  v_songs VARCHAR2(2000) := p_songs; -- создаем новую переменную для разбиения строки
  v_i INTEGER := 1; -- счетчик для цикла WHILE
  v_pos INTEGER; -- позиция разделителя песен
BEGIN
DELETE (SELECT *
        FROM Song_Record sr
        INNER JOIN Song s
            ON sr.song_id = s.song_id
        WHERE sr.record_id = p_id AND s.side = p_side);

  -- Разбиваем строку песен на отдельные песни
  WHILE v_i <= LENGTH(v_songs)
  LOOP
    v_pos := INSTR(v_songs, ';', v_i); -- ищем позицию разделителя
    IF v_pos = 0 -- если разделитель не найден, то вставляем последнюю песню и выходим из цикла
    THEN
    INSERT INTO Song(song_id, song_name, artist_name, album_name, side) VALUES (null, TRIM(SUBSTR(v_songs, v_i)), p_artist_name, p_album_name, p_side);
      INSERT INTO Song_Record(song_id, record_id) VALUES ((SELECT MAX(song_id) FROM Song), p_id); 
    EXIT;
    ELSE -- иначе вставляем песню и продолжаем цикл
 INSERT INTO Song(song_id, song_name, artist_name, album_name, side) VALUES (null, TRIM(SUBSTR(v_songs, v_i, v_pos - v_i)), p_artist_name, p_album_name, p_side);
       INSERT INTO Song_Record(song_id, record_id) VALUES ((SELECT MAX(song_id) FROM Song), p_id);
      v_i := v_pos + 1;
    END IF;
  END LOOP;
  COMMIT;
END;














CREATE OR REPLACE PROCEDURE UPDATE_GENRES(
    p_id in Record.record_id%type,
    p_genres IN VARCHAR2
)
IS
  v_genres VARCHAR2(2000) := p_genres; -- создаем новую переменную для разбиения строки
  v_i INTEGER := 1; -- счетчик для цикла WHILE
  v_pos INTEGER; -- позиция разделителя жанров
BEGIN
    DELETE (SELECT *
        FROM genre_details gd
        INNER JOIN genre g
            ON gd.genre_id = g.genre_id
        WHERE gd.record_id = p_id);

  -- Разбиваем строку жанров на отдельные жанры
  WHILE v_i <= LENGTH(v_genres)
  LOOP
    v_pos := INSTR(v_genres, ';', v_i); -- ищем позицию разделителя
    IF v_pos = 0 -- если разделитель не найден, то вставляем последнюю песню и выходим из цикла
    THEN
    INSERT INTO Genre(genre_id, genre_name) VALUES (null, TRIM(SUBSTR(v_genres, v_i)));
      INSERT INTO Genre_details(record_id, genre_id) VALUES (p_id, (SELECT MAX(genre_id) FROM Genre)); 
    EXIT;
    ELSE -- иначе вставляем песню и продолжаем цикл
        INSERT INTO Genre(genre_id, genre_name) VALUES (null, TRIM(SUBSTR(v_genres, v_i, v_pos - v_i)));
       INSERT INTO Genre_details(record_id, genre_id) VALUES (p_id, (SELECT MAX(genre_id) FROM Genre));
      v_i := v_pos + 1;
    END IF;
  END LOOP;
  COMMIT;
END;












create or replace function GETSONGSFORRECORD(p_RECORD_ID IN RECORD.RECORD_ID%TYPE, p_side in Song.side%type) 
    RETURN SYS_REFCURSOR AS
    c1 SYS_REFCURSOR;
BEGIN
    OPEN c1 FOR 
        SELECT SONG.SONG_NAME
        FROM RECORD
        JOIN SONG_RECORD ON RECORD.RECORD_ID = SONG_RECORD.RECORD_ID
        JOIN SONG ON SONG_RECORD.SONG_ID = SONG.SONG_ID
        WHERE RECORD.RECORD_ID = p_RECORD_ID AND SONG.side = p_side;
    RETURN c1;
END;





--get all songs by record_id
create or replace function GETSONGSFORRECORD(p_RECORD_ID IN RECORD.RECORD_ID%TYPE) 
    RETURN SYS_REFCURSOR AS
    c1 SYS_REFCURSOR;
BEGIN
    OPEN c1 FOR 
        SELECT SONG.SONG_NAME
        FROM RECORD
        JOIN SONG_RECORD ON RECORD.RECORD_ID = SONG_RECORD.RECORD_ID
        JOIN SONG ON SONG_RECORD.SONG_ID = SONG.SONG_ID
        WHERE RECORD.RECORD_ID = p_RECORD_ID;
    RETURN c1;
END;







--get all genres by record_id
create or replace function GETGENRESFORRECORD(p_RECORD_ID IN RECORD.RECORD_ID%TYPE) 
    RETURN SYS_REFCURSOR AS
    c1 SYS_REFCURSOR;
BEGIN
    OPEN c1 FOR 
        SELECT genre_name
        FROM GENRE
        JOIN GENRE_DETAILS ON Genre.genre_ID = GENRE_DETAILS.genre_ID
        JOIN Record ON Record.record_ID = GENRE_DETAILS.record_ID
        WHERE RECORD.RECORD_ID = p_RECORD_ID;
    RETURN c1;
END;









CREATE OR REPLACE PROCEDURE ADD_NEW_RECORD( 
    p_year IN Record.year%type, 
    p_cost IN Record.cost%type, 
    p_amount IN Record.amount%type, 
    p_supplier_id IN Record.supplier_id%type, 
    p_description IN Record.description%type, 
    p_artist_name IN Record.artist_name%type, 
    p_album_name IN Record.album_name%type, 
    p_picture IN Record.picture%type, 
    p_status IN Record.status%type, 
    p_date IN Record.date_of_deliv_to_warehouse%type 
) 
IS 
    v_record_id INTEGER; 
BEGIN 
    SELECT MAX(record_id) + 1 
    INTO v_record_id FROM Record; 
-- получаем новый уникальный идентификатор записи 
INSERT INTO Record(record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture, status, is_deleted, date_of_deliv_to_warehouse) 
VALUES (v_record_id, p_year, p_cost, p_amount, p_supplier_id, p_description, p_artist_name, p_album_name, p_picture, p_status, 'n', p_date); 
COMMIT; 
END;



create or replace procedure DELETE_RECORD(
    p_id in Record.record_id%type
)
IS
BEGIN
    update Record set is_deleted = 'y' where record_id = p_id;
END;




--split string by songs and insert it
CREATE OR REPLACE PROCEDURE INSERT_SONGS(
    p_songs IN VARCHAR2, 
    p_artist_name in Song.song_name%type, 
    p_album_name in Song.album_name%type, 
    p_side in Song.side%type 
   
    )
IS
  v_songs VARCHAR2(2000) := p_songs; -- создаем новую переменную для разбиения строки
  v_i INTEGER := 1; -- счетчик для цикла WHILE
  v_pos INTEGER; -- позиция разделителя песен
BEGIN
  -- Разбиваем строку песен на отдельные песни
  WHILE v_i <= LENGTH(v_songs)
  LOOP
    v_pos := INSTR(v_songs, ';', v_i); -- ищем позицию разделителя
    IF v_pos = 0 -- если разделитель не найден, то вставляем последнюю песню и выходим из цикла
    THEN
    INSERT INTO Song(song_id, song_name, artist_name, album_name, side) VALUES (null, TRIM(SUBSTR(v_songs, v_i)), p_artist_name, p_album_name, p_side);
      INSERT INTO Song_Record(song_id, record_id) VALUES ((SELECT MAX(song_id) FROM Song), (SELECT MAX(record_id) FROM Record)); 
    EXIT;
    ELSE -- иначе вставляем песню и продолжаем цикл
      INSERT INTO Song(song_id, song_name, artist_name, album_name, side) VALUES (null, TRIM(SUBSTR(v_songs, v_i, v_pos - v_i)), p_artist_name, p_album_name, p_side);
       INSERT INTO Song_Record(song_id, record_id) VALUES ((SELECT MAX(song_id) FROM Song), (SELECT MAX(record_id) FROM Record));
      v_i := v_pos + 1;
    END IF;
  END LOOP;
  COMMIT;
END;












--split string by genres and insert it
CREATE OR REPLACE PROCEDURE INSERT_GENRES(
    p_genres IN VARCHAR2
)
IS
  v_genres VARCHAR2(2000) := p_genres; -- создаем новую переменную для разбиения строки
  v_i INTEGER := 1; -- счетчик для цикла WHILE
  v_pos INTEGER; -- позиция разделителя жанров
BEGIN
  -- Разбиваем строку жанров на отдельные жанры
  WHILE v_i <= LENGTH(v_genres)
  LOOP
    v_pos := INSTR(v_genres, ';', v_i); -- ищем позицию разделителя
    IF v_pos = 0 -- если разделитель не найден, то вставляем последнюю песню и выходим из цикла
    THEN
    INSERT INTO Genre(genre_id, genre_name) VALUES (null, TRIM(SUBSTR(v_genres, v_i)));
      INSERT INTO Genre_details(record_id, genre_id) VALUES ((SELECT MAX(record_id) FROM Record), (SELECT MAX(genre_id) FROM Genre)); 
    EXIT;
    ELSE -- иначе вставляем песню и продолжаем цикл
        INSERT INTO Genre(genre_id, genre_name) VALUES (null, TRIM(SUBSTR(v_genres, v_i, v_pos - v_i)));
       INSERT INTO Genre_details(record_id, genre_id) VALUES ((SELECT MAX(record_id) FROM Record), (SELECT MAX(genre_id) FROM Genre));
      v_i := v_pos + 1;
    END IF;
  END LOOP;
  COMMIT;
END;






create or replace procedure reduceAmountOfRecord(
    p_id in Record.record_id%type,
    p_reduceAmount in Record.record_id%type
)
is
begin
    update Record 
    set amount = amount - p_reduceAmount
        where record_id = p_id;
end;











begin
getSupplierName(41,3);
end;


create or replace function GETSONGSFORRECORD(p_RECORD_ID IN RECORD.RECORD_ID%TYPE, p_side in Song.side%type) 
    RETURN SYS_REFCURSOR AS
    c1 SYS_REFCURSOR;
BEGIN
    OPEN c1 FOR 
        SELECT SONG.SONG_NAME
        FROM RECORD
        JOIN SONG_RECORD ON RECORD.RECORD_ID = SONG_RECORD.RECORD_ID
        JOIN SONG ON SONG_RECORD.SONG_ID = SONG.SONG_ID
        WHERE RECORD.RECORD_ID = p_RECORD_ID AND SONG.side = p_side;
    RETURN c1;
END;


select * from Client

CREATE OR REPLACE function GETSUPPLIERNAME (
    p_RECORD_ID in Record.record_id%type,
    p_SUPPLIER_ID in Record.supplier_id%type
)
 RETURN SYS_REFCURSOR AS
    c1 SYS_REFCURSOR;
begin
open c1 for
    select distinct login_client from Client join Comments on Client.client_id = Comments.user_id
    where client_id = p_SUPPLIER_ID;
     RETURN c1;
end;





create or replace procedure getAllComments (
    comments out sys_refcursor
)
IS
BEGIN
    OPEN comments FOR 
    SELECT comment_id, comment_date, user_id, record_id, content
    FROM Comments
    order by comment_date desc;
END;










create or replace procedure getUserInfo (
    currUser out sys_refcursor
)
IS
BEGIN
    OPEN currUser FOR 
    SELECT client_id, login_client, password_client, phone_number, email, sex, date_of_birth
    FROM Client;
END;






--filters
create or replace procedure filterByCost (
    recordcur out sys_refcursor
)
IS
BEGIN
    OPEN recordcur FOR 
    SELECT record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture,
    status, is_deleted, date_of_deliv_to_warehouse
    FROM Record
    order by cost;
END;



create or replace procedure filterByIdAsc (
    recordcur out sys_refcursor
)
IS
BEGIN
    OPEN recordcur FOR 
    SELECT record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture,
    status, is_deleted, date_of_deliv_to_warehouse
    FROM Record
    order by record_id asc;
END;



create or replace procedure filterByYear (
    recordcur out sys_refcursor
)
IS
BEGIN
    OPEN recordcur FOR 
    SELECT record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture,
    status, is_deleted, date_of_deliv_to_warehouse
    FROM Record
    order by year;
END;








