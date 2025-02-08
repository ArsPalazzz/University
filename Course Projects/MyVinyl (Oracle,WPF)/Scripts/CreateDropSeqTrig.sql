--2. orcl OTHERUSERCORE-12345 - creation of the main infrastructure


--CLIENT

drop SEQUENCE INCREMENT_Client;
drop trigger TRG_Client;

CREATE SEQUENCE INCREMENT_Client
    START WITH 1
    INCREMENT BY 1
    nocache;
    
CREATE OR REPLACE TRIGGER TRG_Client
    BEFORE INSERT ON Client
        FOR EACH ROW
        BEGIN
            SELECT INCREMENT_Client.NEXTVAL INTO :NEW.client_id FROM DUAL;
        END;



        


--ORDER_CARD

drop SEQUENCE INCREMENT_OrderCard;
drop trigger TRG_OrderCard;


CREATE SEQUENCE INCREMENT_OrderCard
    START WITH 1
    INCREMENT BY 1
    nocache;
    
CREATE OR REPLACE TRIGGER TRG_OrderCard
    BEFORE INSERT ON Order_card
        FOR EACH ROW
        BEGIN
            SELECT INCREMENT_OrderCard.NEXTVAL INTO :NEW.order_id FROM DUAL;
        END;



--RECORD

drop SEQUENCE INCREMENT_Record;
drop trigger TRG_Record

CREATE SEQUENCE INCREMENT_Record
    START WITH 1
    INCREMENT BY 1
    nocache;
    
CREATE OR REPLACE TRIGGER TRG_Record
    BEFORE INSERT ON Record
        FOR EACH ROW
        BEGIN
            SELECT INCREMENT_Record.NEXTVAL INTO :NEW.record_id FROM DUAL;
        END;



--COMMENTS

drop SEQUENCE INCREMENT_Comments;
drop trigger TRG_Comments

CREATE SEQUENCE INCREMENT_Comments
    START WITH 1
    INCREMENT BY 1
    nocache;
    
    
CREATE OR REPLACE TRIGGER TRG_Comments
    BEFORE INSERT ON Comments
        FOR EACH ROW
        BEGIN
            SELECT INCREMENT_Comments.NEXTVAL INTO :NEW.comment_id FROM DUAL;
        END;



--ORDER_CARD_DETAILS

drop SEQUENCE INCREMENT_OrderCardDetails;
drop trigger TRG_OrderCardDetails


CREATE SEQUENCE INCREMENT_OrderCardDetails
    START WITH 1
    INCREMENT BY 1
    nocache;
    
CREATE OR REPLACE TRIGGER TRG_OrderCardDetails
    BEFORE INSERT ON Order_card_details
        FOR EACH ROW
        BEGIN
            SELECT INCREMENT_OrderCardDetails.NEXTVAL INTO :NEW.order_details_id FROM DUAL;
        END;


--GENRE

drop SEQUENCE INCREMENT_Genre;
drop trigger TRG_Genre

CREATE SEQUENCE INCREMENT_Genre
    START WITH 1
    INCREMENT BY 1
    nocache;
    
CREATE OR REPLACE TRIGGER TRG_Genre
    BEFORE INSERT ON Genre
        FOR EACH ROW
        BEGIN
            SELECT INCREMENT_Genre.NEXTVAL INTO :NEW.genre_id FROM DUAL;
        END;


--GENRE_DETAILS


drop trigger TRG_GenreDetails

CREATE SEQUENCE INCREMENT_GenreDetails
    START WITH 1
    INCREMENT BY 1
    nocache;
    



--SONG

drop SEQUENCE INCREMENT_Song;
drop trigger TRG_Song

CREATE SEQUENCE INCREMENT_Song
    START WITH 1
    INCREMENT BY 1
    nocache;
    
    
CREATE OR REPLACE TRIGGER TRG_Song
    BEFORE INSERT ON Song
        FOR EACH ROW
        BEGIN
            SELECT INCREMENT_Song.NEXTVAL INTO :NEW.song_id FROM DUAL;
        END;




--SONG_RECORD

drop SEQUENCE INCREMENT_SongRecord;

CREATE SEQUENCE INCREMENT_SongRecord
    START WITH 1
    INCREMENT BY 1
    nocache;
    
    
    
    
    
    
    



create index ind_accountId on order_card (account_id) tablespace TS_USER;
create index ind_supplierId on record (supplier_id) tablespace TS_USER;
create index ind_userId on comments (user_id) tablespace TS_USER;
create index ind_recordId on comments (record_id) tablespace TS_USER;
create index ind_orderDetId on order_card_details (order_id) tablespace TS_USER;
create index ind_recordDetId on order_card_details (record_id) tablespace TS_USER;
    