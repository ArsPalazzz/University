select * from Record
select * from Client
select * from comments

select * from Record where record_id = 101;
select * from Song join Song_Record on Song.song_id = Song_Record.song_id where record_id = 83;


select * from Record where is_deleted = 'y';

select * from song;
select * from Song_record;
delete from song where Artist_name like 'hihi'

delete from genre where genre_id between 101 and 162 
select * from genre order by genre_id
select * from genre_details

select * from Client;
select * from Record where record_id != 1 and record_id != 2
select * from record


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












select * from genre