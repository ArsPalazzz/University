--3) orcl OTHERUSERCORE-12345 - insertion of all data  


INSERT ALL
    INTO Client (client_id, login_client, password_client, phone_number, email, sex, date_of_birth) VALUES (null, 'Admin', 'Admin', '+375447325231', 'palaznika609@gmail.com', 'M', TO_TIMESTAMP('2003/02/13 12:02:44', 'yyyy/mm/dd hh24:mi:ss'))
    INTO Client (client_id, login_client, password_client, phone_number, email, sex, date_of_birth) VALUES (null, 'Ars', 'Ars', '+375447325235', 'palaznika608@gmail.com', 'M', TO_TIMESTAMP('2004/03/14 14:02:44', 'yyyy/mm/dd hh24:mi:ss'))
    INTO Client (client_id, login_client, password_client, phone_number, email, sex, date_of_birth) VALUES (null, 'Tanya', 'Tanya', '+375291111111', 't.shi@gmail.com', 'F', TO_TIMESTAMP('2002/10/27 9:02:44', 'yyyy/mm/dd hh24:mi:ss'))
    INTO Client (client_id, login_client, password_client, phone_number, email, sex, date_of_birth) VALUES (null, 'Vlad', 'Vlad', '+375291111111', 'vladvak@gmail.com', 'M', TO_TIMESTAMP('2003/06/13 14:02:44', 'yyyy/mm/dd hh24:mi:ss'))
    INTO Client (client_id, login_client, password_client, phone_number, email, sex, date_of_birth) VALUES (null, 'Halwa', 'Halwa', '+375291111111', 'daprostohalwa@gmail.com', 'M', TO_TIMESTAMP('2003/09/27 22:02:44', 'yyyy/mm/dd hh24:mi:ss'))
    INTO Client (client_id, login_client, password_client, phone_number, email, sex, date_of_birth) VALUES (null, 'Lesha', 'Lesha', '+375291111111', 'archer@gmail.com', 'M', TO_TIMESTAMP('2004/07/13 14:02:44', 'yyyy/mm/dd hh24:mi:ss'))
SELECT * FROM DUAL;    
commit;    






INSERT ALL
    INTO Record (record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture, status, is_deleted, date_of_deliv_to_warehouse) 
        VALUES (null, 1987, 39.99, 2, 2, 'Bad is the seventh studio album by the American singer and songwriter Michael Jackson. It was released on August 31, 1987, by Epic Records, nearly five years after Jacksons previous album, Thriller (1982). Written and recorded between January 1985 and July 1987, Bad was the third and final collaboration between Jackson and producer Quincy Jones, with Jackson co-producing and composing all but two tracks.', 
        'Michael Jackson', 'Bad', '/Assets/recordBad.jpg', 'EX', 'n', TO_TIMESTAMP('2023/04/05 14:02:44', 'yyyy/mm/dd hh24:mi:ss'))
     INTO Record (record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture, status, is_deleted, date_of_deliv_to_warehouse) 
        VALUES (null, 2020, 19.99, 2, 3, 'High Off Life is the eighth studio album by American rapper Future, released on May 15, 2020, by Freebandz and Epic Records. The album was executive produced by close friend and frequent collaborator DJ Esco. It features guest appearances by Travis Scott, YoungBoy Never Broke Again, Young Thug, Lil Uzi Vert, Drake, Lil Durk, Meek Mill, Doe Boy, DaBaby, and Lil Baby. High Off Life received generally favorable reviews from critics and debuted atop the US Billboard 200', 
        'Future', 'High Of Life', '/Assets/recordHighoflife.jpg', 'EX', 'n', TO_TIMESTAMP('2023/02/14 16:02:44', 'yyyy/mm/dd hh24:mi:ss'))
         INTO Record (record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture, status, is_deleted, date_of_deliv_to_warehouse) 
        VALUES (null, 1985, 49.99, 5, 3, 'Bohemian Rhapsody: The Original Soundtrack is the soundtrack album to the Queen biographical film of the same name. The soundtrack features many of the bands songs and unreleased recordings including tracks from their legendary concert at Live Aid in 1985.[6] The soundtrack was released by Hollywood Records and Virgin EMI Records on 19 October 2018, on CD, cassette and digital formats.[7][8] The soundtrack was later released on 8 February 2019, as a vinyl double album specially cut at Abbey Road Studios. ', 
        'Queen', 'Bohemian Rhapsody', '/Assets/recordBohRhapsody.jpg', 'EX', 'n', TO_TIMESTAMP('2023/01/23 8:00:00', 'yyyy/mm/dd hh24:mi:ss'))
    into Record (record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture, status, is_deleted, date_of_deliv_to_warehouse) 
 VALUES (null, 2005, 14.99, 0, 3, 'Youll Rebel to Anything is the third studio album by New York City band Mindless Self Indulgence released on April 12, 2005. The album was released outside of the US on November 5, 2007, in an "Expanded and Remastered" edition. On January 22, 2008, the "Expanded and Remastered" version was released in the US. A special Japanese version of the remastered edition was released on March 5, 2008, which includes a demo version of Bomb This Track, the completed version of which can be found on If.', 
        'Mindless Self Indulgence', 'Youll Rebel to Anything', '/Assets/recordYoullRabel.jpg', 'M', 'n', TO_TIMESTAMP('2023/04/05 8:00:00', 'yyyy/mm/dd hh24:mi:ss'))
SELECT * FROM DUAL;    
commit;    


insert
  into Record (record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture, status, is_deleted, date_of_deliv_to_warehouse) 
 VALUES (null, 2005, 19.99, 0, 2, 'Youll Rebel to Anything is the third studio album by New York City band Mindless Self Indulgence released on April 12, 2005. The album was released outside of the US on November 5, 2007, in an "Expanded and Remastered" edition. On January 22, 2008, the "Expanded and Remastered" version was released in the US. A special Japanese version of the remastered edition was released on March 5, 2008, which includes a demo version of Bomb This Track, the completed version of which can be found on If.', 
        'Mindless Self Indulgence2', 'Youll Rebel to Anything2', '/Assets/recordYoullRabel.jpg', 'M', 'n', TO_TIMESTAMP('2022/04/05 8:00:00', 'yyyy/mm/dd hh24:mi:ss'))


INSERT ALL
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Bad','Michael Jackson', 'Bad', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Speed Demon','Michael Jackson', 'Bad', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Smooth Criminal','Michael Jackson', 'Bad', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'The Way You Make Me Feel','Michael Jackson', 'Bad', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Liberian Girl','Michael Jackson', 'Bad', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Just Good Friends','Michael Jackson', 'Bad', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Another Part of Me','Michael Jackson', 'Bad', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Man In the Mirror','Michael Jackson', 'Bad', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'I Just Cant Stop Loving You','Michael Jackson', 'Bad', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Dirty Diana','Michael Jackson', 'Bad', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Leave Me Alone','Michael Jackson', 'Bad', 'B')
    
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Trapped in the Sun','Future', 'High Off Life', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'HiTek Tek','Future', 'High Off Life', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Touch the Sky','Future', 'High Off Life', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Solitaires','Future', 'High Off Life', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Ridin Strikers','Future', 'High Off Life', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'One of My','Future', 'High Off Life', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Posted with Demons','Future', 'High Off Life', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Hard to Choose One','Future', 'High Off Life', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Trillionaire','Future', 'High Off Life', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Harlem Shake','Future', 'High Off Life', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Up the River','Future', 'High Off Life', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Pray for a Key','Future', 'High Off Life', 'B')
    
  INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Somebody to Love','Queen', 'Bohemian Rhapsody', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Doing All Right... Revisited','Queen', 'Bohemian Rhapsody', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Keep Yourself Alive','Queen', 'Bohemian Rhapsody', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Killer Queen','Queen', 'Bohemian Rhapsody', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Fat Bottomed Girls','Queen', 'Bohemian Rhapsody', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Bohemian Rhapsody','Queen', 'Bohemian Rhapsody', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Now Im Here','Queen', 'Bohemian Rhapsody', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Crazy Little Thing Called Love','Queen', 'Bohemian Rhapsody', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Love of My Life','Queen', 'Bohemian Rhapsody', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'We Will Rock You','Queen', 'Bohemian Rhapsody', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Another One Bites the Dust','Queen', 'Bohemian Rhapsody', 'B')
     INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'I Want to Break Free','Queen', 'Bohemian Rhapsody', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Under Pressure','Queen', 'Bohemian Rhapsody', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Who Wants to Live Forever','Queen', 'Bohemian Rhapsody', 'A')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Ay-Oh','Queen', 'Bohemian Rhapsody', 'B')
  
     INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Shut Me Up','Mindless Self Indulgence', 'Youll Rebel to Anything', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, '1989','Mindless Self Indulgence', 'Youll Rebel to Anything', 'A')
     INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Straight to Vide','Mindless Self Indulgence', 'Youll Rebel to Anything', 'B')
     INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Tom Sawyer','Mindless Self Indulgence', 'Youll Rebel to Anything', 'A')
      INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Youll Rebel to Anything','Mindless Self Indulgence', 'Youll Rebel to Anything', 'B')
    INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'What Do They Know?','Mindless Self Indulgence', 'Youll Rebel to Anything', 'A')
     INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Stupid MF','Mindless Self Indulgence', 'Youll Rebel to Anything', 'B')
     INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, '2 Hookers and an Eightball','Mindless Self Indulgence', 'Youll Rebel to Anything', 'A')
       INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Prom','Mindless Self Indulgence', 'Youll Rebel to Anything', 'B')
     INTO Song (song_id, song_name, artist_name, album_name, side) VALUES (null, 'Bullshit','Mindless Self Indulgence', 'Youll Rebel to Anything', 'A')

SELECT * FROM DUAL;    
commit;

select * from Record
select * from song






INSERT ALL
    INTO Song_Record (song_id, record_id) VALUES (1, 1)
    INTO Song_Record (song_id, record_id) VALUES (2, 1)
    INTO Song_Record (song_id, record_id) VALUES (3, 1)
    INTO Song_Record (song_id, record_id) VALUES (4, 1)
    INTO Song_Record (song_id, record_id) VALUES (5, 1)
    INTO Song_Record (song_id, record_id) VALUES (6, 1)
    INTO Song_Record (song_id, record_id) VALUES (7, 1)
    INTO Song_Record (song_id, record_id) VALUES (8, 1)
    INTO Song_Record (song_id, record_id) VALUES (9, 1)
    INTO Song_Record (song_id, record_id) VALUES (10, 1)
    INTO Song_Record (song_id, record_id) VALUES (11, 1)
    
    INTO Song_Record (song_id, record_id) VALUES (12, 2)
    INTO Song_Record (song_id, record_id) VALUES (13, 2)
    INTO Song_Record (song_id, record_id) VALUES (14, 2)
    INTO Song_Record (song_id, record_id) VALUES (15, 2)
    INTO Song_Record (song_id, record_id) VALUES (16, 2)
    INTO Song_Record (song_id, record_id) VALUES (17, 2)
    INTO Song_Record (song_id, record_id) VALUES (18, 2)
    INTO Song_Record (song_id, record_id) VALUES (19, 2)
    INTO Song_Record (song_id, record_id) VALUES (20, 2)
    INTO Song_Record (song_id, record_id) VALUES (21, 2)
    INTO Song_Record (song_id, record_id) VALUES (22, 2)
    INTO Song_Record (song_id, record_id) VALUES (23, 2)
    
    INTO Song_Record (song_id, record_id) VALUES (24, 3)
    INTO Song_Record (song_id, record_id) VALUES (25, 3)
    INTO Song_Record (song_id, record_id) VALUES (26, 3)
    INTO Song_Record (song_id, record_id) VALUES (27, 3)
    INTO Song_Record (song_id, record_id) VALUES (28, 3)
    INTO Song_Record (song_id, record_id) VALUES (29, 3)
    INTO Song_Record (song_id, record_id) VALUES (30, 3)
    INTO Song_Record (song_id, record_id) VALUES (31, 3)
    INTO Song_Record (song_id, record_id) VALUES (32, 3)
    INTO Song_Record (song_id, record_id) VALUES (33, 3)
    INTO Song_Record (song_id, record_id) VALUES (34, 3)
    INTO Song_Record (song_id, record_id) VALUES (35, 3)
    INTO Song_Record (song_id, record_id) VALUES (36, 3)
    INTO Song_Record (song_id, record_id) VALUES (37, 3)
    INTO Song_Record (song_id, record_id) VALUES (38, 3)
    
     INTO Song_Record (song_id, record_id) VALUES (39, 4)
    INTO Song_Record (song_id, record_id) VALUES (40, 4)
    INTO Song_Record (song_id, record_id) VALUES (41, 4)
    INTO Song_Record (song_id, record_id) VALUES (42, 4)
    INTO Song_Record (song_id, record_id) VALUES (43, 4)
    INTO Song_Record (song_id, record_id) VALUES (44, 4)
    INTO Song_Record (song_id, record_id) VALUES (45, 4)
    INTO Song_Record (song_id, record_id) VALUES (46, 4)
    INTO Song_Record (song_id, record_id) VALUES (47, 4)
    INTO Song_Record (song_id, record_id) VALUES (48, 4)
SELECT * FROM DUAL;    
commit;


select * from genre
delete from genre

SET ESCAPE '\'
INSERT ALL
    INTO Genre (genre_id, genre_name) VALUES (null, 'Pop')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Rock')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Alternative rock')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Jazz')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Hip hop')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Classic')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Pop')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Dance')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Hard rock')
    INTO Genre (genre_id, genre_name) VALUES (null, 'R\&B')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Soul')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Funk')
    INTO Genre (genre_id, genre_name) VALUES (null, 'Polka') 
    INTO Genre (genre_id, genre_name) VALUES (null, 'Electronic rock') 
SELECT * FROM DUAL;    
commit;

INSERT ALL
    INTO Genre_Details (record_id, genre_id) VALUES (1, 1)
    INTO Genre_Details (record_id, genre_id) VALUES (1, 2)
    INTO Genre_Details (record_id, genre_id) VALUES (1, 7)
    INTO Genre_Details (record_id, genre_id) VALUES (1, 9)
    INTO Genre_Details (record_id, genre_id) VALUES (1, 10)
    INTO Genre_Details (record_id, genre_id) VALUES (1, 12)
    INTO Genre_Details (record_id, genre_id) VALUES (2, 5)
    INTO Genre_Details (record_id, genre_id) VALUES (2, 10)
    INTO Genre_Details (record_id, genre_id) VALUES (3, 2)
     INTO Genre_Details (record_id, genre_id) VALUES (4, 3)
    INTO Genre_Details (record_id, genre_id) VALUES (4, 14)
SELECT * FROM DUAL;    
commit;








INSERT ALL
    INTO Comments (comment_id, comment_date, user_id, record_id, content) VALUES (null, TO_TIMESTAMP('2023/02/02 16:02:44', 'yyyy/mm/dd hh24:mi:ss'), 3, 2,
    'This record is amazing. I like that. Shut up and take my money')
    INTO Comments (comment_id, comment_date, user_id, record_id, content) VALUES (null, TO_TIMESTAMP('2023/02/02 13:01:24', 'yyyy/mm/dd hh24:mi:ss'), 3, 1,
    'Bad record')
     INTO Comments (comment_id, comment_date, user_id, record_id, content) VALUES (null, TO_TIMESTAMP('2023/02/05 16:02:44', 'yyyy/mm/dd hh24:mi:ss'), 2, 2,
    'Future is good artist')
     INTO Comments (comment_id, comment_date, user_id, record_id, content) VALUES (null, TO_TIMESTAMP('2022/01/02 16:02:44', 'yyyy/mm/dd hh24:mi:ss'), 2, 1,
    'I dont like Michael Jackson')
    INTO Comments (comment_id, comment_date, user_id, record_id, content) VALUES (null, TO_TIMESTAMP('2023/03/12 12:55:37', 'yyyy/mm/dd hh24:mi:ss'), 4, 2,
    'Man, sounds good')
    INTO Comments (comment_id, comment_date, user_id, record_id, content) VALUES (null, TO_TIMESTAMP('2023/03/03 8:55:37', 'yyyy/mm/dd hh24:mi:ss'), 4, 3,
    'Mamaaaaaaa')
SELECT * FROM DUAL;    
commit;



select * from comments



select * from order_card


INSERT ALL
    INTO order_card (order_id, account_id, delivery_checkbox, cost, order_date, status, book_a_record) values
    (null, 2, 'n', 46.33, sysdate, 'In proccess', 'y')
 INTO order_card (order_id, account_id, delivery_checkbox, cost, order_date, status, book_a_record) values
    (null, 3, 'y', 62.6, sysdate, 'In proccess', 'y')
    INTO order_card (order_id, account_id, delivery_checkbox, cost, order_date, status, book_a_record) values
    (null, 4, 'n', 52.2, sysdate, 'In proccess', 'n')
SELECT * FROM DUAL;    
commit;



INSERT ALL
    INTO order_card_details (order_details_id, order_id, record_id, amount) values
    (null, 1, 3, 4)
 INTO order_card_details (order_details_id, order_id, record_id, amount) values
    (null, 2, 2, 1)
   INTO order_card_details (order_details_id, order_id, record_id, amount) values
    (null, 3, 1, 2)
SELECT * FROM DUAL;    
commit;


