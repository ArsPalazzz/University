--2. orcl OTHERUSERCORE-12345 - creation of the main infrastructure

CREATE TABLE Client (
  client_id int PRIMARY KEY,
  login_client VARCHAR(32),
  password_client VARCHAR(16),
  phone_number VARCHAR(16),
  email VARCHAR(64),
  sex nchar(1),
  date_of_birth timestamp
) TABLESPACE TS_USER;


drop table Client;
select * from Client;

select * from Client

CREATE TABLE Record (
  record_id INT primary key,
  year INT,
  cost float,
  amount int,
  supplier_id int,
  description varchar(512),
  artist_name varchar(30),
  album_name varchar(30),
  picture varchar(40),
  status char(3),
  is_deleted CHAR(1),
  date_of_deliv_to_warehouse timestamp,
  CONSTRAINT FK_record_supplier FOREIGN KEY (supplier_id)  REFERENCES Client (client_id)
) TABLESPACE TS_USER;


drop table Record;
select * from Record;








CREATE TABLE Order_card (
  order_id INT primary key,
  account_id INT,
  delivery_checkbox nchar(1) check (delivery_checkbox = 'y' or delivery_checkbox = 'n'),
  cost float,
  order_date timestamp,
  status varchar(16),
  book_a_record nchar(1) check (book_a_record = 'y' or book_a_record = 'n'),
  CONSTRAINT FK_ordercard_client FOREIGN KEY (account_id)  REFERENCES Client (client_id)
) TABLESPACE TS_USER;


drop table Order_card;
select * from Order_card;





drop table Comments;

CREATE TABLE Comments (
  comment_id INT primary key,
  comment_date timestamp,
  user_id int,
  record_id int,
  content varchar(128),
  CONSTRAINT FK_comment_client FOREIGN KEY (user_id)  REFERENCES Client (client_id),
  CONSTRAINT FK_comment_record FOREIGN KEY (record_id)  REFERENCES Record (record_id)
) TABLESPACE TS_USER;


drop table Comments;
select * from Comments;







CREATE TABLE Order_card_details (
  order_details_id INT primary key,
  order_id INT,
  record_id INT,
  amount int,
  CONSTRAINT FK_orderCardDet_orderCard FOREIGN KEY (order_id) REFERENCES Order_card (order_id),
  CONSTRAINT FK_orderCardDetails_record FOREIGN KEY (record_id)  REFERENCES Record (record_id)
) TABLESPACE TS_USER;


drop table Order_card_details;
select * from Order_card_details;






CREATE TABLE Genre (
  genre_id INT primary key,
  genre_name varchar(20)
) TABLESPACE TS_USER;


drop table Genre;
select * from Genre;





CREATE TABLE Genre_details (
  record_id INT,
  genre_id int,
  CONSTRAINT FK_genreDetails_genre FOREIGN KEY (genre_id)  REFERENCES Genre (genre_id),
  CONSTRAINT FK_genreDetails_record FOREIGN KEY (record_id)  REFERENCES Record (record_id),
  CONSTRAINT PK_recordId_genreId primary key (record_id, genre_id)
) TABLESPACE TS_USER;


drop table Genre_details;
select * from Genre_details;



CREATE TABLE Song (
  song_id INT primary key,
  song_name varchar(30),
  artist_name varchar(30),
  album_name varchar(30),
  side nchar(1)
) TABLESPACE TS_USER;


drop table Song;
select * from Song;




CREATE TABLE Song_Record (
  song_id INT,
  record_id int,
  CONSTRAINT FK_songRecord_song FOREIGN KEY (song_id)  REFERENCES Song (song_id),
  CONSTRAINT FK_songRecord_record FOREIGN KEY (record_id)  REFERENCES Record (record_id),
  CONSTRAINT PK_songId_recordId primary key (song_id, record_id)
) TABLESPACE TS_USER;


drop table Song_Record;
select * from Song_Record;







