CREATE OR REPLACE PROCEDURE GetRecordsByGenre(
  p_genre_name IN Genre.genre_name%TYPE
) AS
  v_records_cursor SYS_REFCURSOR;
  v_record_id Record.record_id%TYPE;
  v_year Record.year%TYPE;
  v_cost Record.cost%TYPE;
  v_amount Record.amount%TYPE;
  v_supplier_id Record.supplier_id%TYPE;
  v_description Record.description%TYPE;
  v_artist_name Record.artist_name%TYPE;
  v_album_name Record.album_name%TYPE;
  v_picture Record.picture%TYPE;
  v_status Record.status%TYPE;
  v_is_deleted Record.is_deleted%TYPE;
  v_date_of_delivery Record.date_of_deliv_to_warehouse%TYPE;
   v_genre_count NUMBER;
BEGIN
  -- Проверяем, существует ли указанный жанр
  SELECT COUNT(*)
  INTO   v_genre_count
  FROM   Genre
  WHERE  genre_name = p_genre_name;

  IF v_genre_count = 0 THEN
    -- Если жанр не найден, генерируем исключение
    RAISE_APPLICATION_ERROR(-20001, 'Genre named ' || p_genre_name || ' is not found.');
  END IF;

  OPEN v_records_cursor FOR
    SELECT r.record_id, r.year, r.cost, r.amount, r.supplier_id,
           r.description, r.artist_name, r.album_name, r.picture, r.status, r.is_deleted,
           r.date_of_deliv_to_warehouse
    FROM Record r
    JOIN Genre_details gd ON r.record_id = gd.record_id
    JOIN Genre g ON gd.genre_id = g.genre_id
    WHERE g.genre_name = p_genre_name;

 
  DBMS_OUTPUT.PUT_LINE('--- Records with Genre: ' || p_genre_name || ' ---');

  LOOP
    FETCH v_records_cursor INTO v_record_id, v_year, v_cost, v_amount, v_supplier_id,
                              v_description, v_artist_name, v_album_name, v_picture, v_status, v_is_deleted,
                              v_date_of_delivery;
    EXIT WHEN v_records_cursor%NOTFOUND;

    
    DBMS_OUTPUT.PUT_LINE('Record ID: ' || v_record_id);
    DBMS_OUTPUT.PUT_LINE('Year: ' || v_year);
    DBMS_OUTPUT.PUT_LINE('Cost: ' || v_cost);
    DBMS_OUTPUT.PUT_LINE('Amount: ' || v_amount);
    DBMS_OUTPUT.PUT_LINE('Supplier ID: ' || v_supplier_id);
    DBMS_OUTPUT.PUT_LINE('Description: ' || v_description);
    DBMS_OUTPUT.PUT_LINE('Artist Name: ' || v_artist_name);
    DBMS_OUTPUT.PUT_LINE('Album Name: ' || v_album_name);
    DBMS_OUTPUT.PUT_LINE('Picture: ' || v_picture);
    DBMS_OUTPUT.PUT_LINE('Status: ' || v_status);
    DBMS_OUTPUT.PUT_LINE('Is Deleted: ' || v_is_deleted);
    DBMS_OUTPUT.PUT_LINE('Date of Delivery: ' || v_date_of_delivery);
    DBMS_OUTPUT.PUT_LINE('--------------------------------');
  END LOOP;

  CLOSE v_records_cursor;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
    DBMS_OUTPUT.PUT_LINE('There are no records with genre: ' || p_genre_name);
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('An error occurred: ' || SQLERRM);
end;




begin
GetRecordsByGenre('Polka');
end;


begin
    GetRecordsByGenre('Pop');
end;



begin
    GetRecordsByGenre('Popj');
end;






   

   
DECLARE
  v_account_id Order_card.account_id%TYPE := 1; -- Пример значения для account_id
  v_records SYS.ODCINUMBERLIST := SYS.ODCINUMBERLIST(6); -- Пример списка пластинок
  v_book Order_card.book_a_record%TYPE := 'y'; 
  v_delivery Order_card.delivery_checkbox%TYPE := 'y';
BEGIN
  PurchaseRecords(p_account_id => v_account_id, p_records => v_records, p_book => v_book, p_delivery => v_delivery);
END;
   
   --заказать пластинки
 CREATE OR REPLACE PROCEDURE PurchaseRecords(
  p_account_id IN Order_card.account_id%TYPE,
  p_records IN SYS.ODCINUMBERLIST,
  p_book in Order_card.book_a_record%type,
  p_delivery in Order_Card.delivery_checkbox%type
) AS
  v_order_id Order_card.order_id%TYPE;
BEGIN
  IF p_records IS NULL OR p_records.COUNT = 0 THEN
    RAISE_APPLICATION_ERROR(-20001, 'Record list is empty.');
  END IF;

  -- Создаем новый заказ в таблице Order_card
  INSERT INTO Order_card (order_id, account_id, delivery_checkbox, cost, order_date, status, book_a_record)
  VALUES (null, p_account_id, p_delivery, 0, SYSTIMESTAMP, 'Created', p_book)
  RETURNING order_id INTO v_order_id;

  -- Добавляем пластинки в заказ в таблицу Order_card_details
  FOR i IN 1..p_records.COUNT LOOP
    INSERT INTO Order_card_details (order_details_id, order_id, record_id, amount)
    VALUES (null, v_order_id, p_records(i), 1);

    -- Уменьшаем количество пластинок в таблице Record
    UPDATE Record
    SET amount = amount - 1
    WHERE record_id = p_records(i);
  END LOOP;

  -- Обновляем общую стоимость заказа в таблице Order_card
  UPDATE Order_card
  SET cost = (
    SELECT SUM(r.cost)
    FROM Order_card_details od
    JOIN Record r ON od.record_id = r.record_id
    WHERE od.order_id = v_order_id
  )
  WHERE order_id = v_order_id;

  COMMIT;

  DBMS_OUTPUT.PUT_LINE('Order has been created. Order number: ' || v_order_id);
EXCEPTION
  WHEN OTHERS THEN
    -- Обработка ошибок
    ROLLBACK;
    DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END;
  
   
   
   








CREATE OR REPLACE PROCEDURE GetPopularRecords (
  p_start_date IN TIMESTAMP,
  p_end_date IN TIMESTAMP
) AS
  v_records SYS_REFCURSOR;
  v_record_id Record.record_id%TYPE;
  v_artist_name Record.artist_name%TYPE;
  v_album_name Record.album_name%TYPE;
  v_order_count NUMBER;
BEGIN
  OPEN v_records FOR
    SELECT r.record_id, r.artist_name, r.album_name, COUNT(od.order_id) AS order_count
    FROM Record r
    JOIN Order_card_details od ON r.record_id = od.record_id
    JOIN Order_card o ON od.order_id = o.order_id
    WHERE o.order_date >= p_start_date AND o.order_date <= p_end_date
    GROUP BY r.record_id, r.artist_name, r.album_name
    ORDER BY order_count DESC;

  LOOP
    FETCH v_records INTO v_record_id, v_artist_name, v_album_name, v_order_count;
    EXIT WHEN v_records%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE('Record ID: ' || v_record_id || ', Artist: ' || v_artist_name || ', Album: ' || v_album_name || ', Order Count: ' || v_order_count);
  END LOOP;

  CLOSE v_records;
END;



DECLARE
  v_current_date TIMESTAMP;
  v_past_date TIMESTAMP;
BEGIN
  -- Получение текущей даты и времени
  v_current_date := SYSTIMESTAMP;

  -- Вычитание 3 месяцев из текущей даты
  v_past_date := ADD_MONTHS(v_current_date, -2);

  -- Вызов процедуры с параметрами
  GetPopularRecords(v_past_date, v_current_date);

  -- Вывод завершенного сообщения
  DBMS_OUTPUT.PUT_LINE('Procedure has successfully completed.');
END;
/





select * from record


CREATE OR REPLACE PROCEDURE DeletePoorSellingRecords IS
  -- Создаем тип данных для хранения информации о пластинке
  TYPE record_info_type IS RECORD (
    record_id Record.record_id%TYPE,
    artist_name Record.artist_name%TYPE,
    album_name Record.album_name%TYPE
  );

  -- Создаем коллекцию для хранения информации о пластинках
  TYPE record_info_collection IS TABLE OF record_info_type;

  -- Объявляем переменную для хранения списка обновленных пластинок
  v_updated_records record_info_collection := record_info_collection();
BEGIN
  -- Обновляем поле is_deleted для плохо продаваемых пластинок
  UPDATE Record r
  SET r.is_deleted = 'y'
  WHERE r.date_of_deliv_to_warehouse <= ADD_MONTHS(SYSDATE, -6) -- Проверяем дату поставки пластинки
    AND NOT EXISTS (
      SELECT 1
      FROM Order_card_details od
      WHERE od.record_id = r.record_id
  )
  RETURNING r.record_id, r.artist_name, r.album_name
  BULK COLLECT INTO v_updated_records;

  -- Фиксируем изменения в транзакции
  COMMIT;

  DBMS_OUTPUT.PUT_LINE('Poor selling records have been marked as deleted.');

  -- Выводим список обновленных пластинок
  DBMS_OUTPUT.PUT_LINE('Updated Records:');
  FOR i IN 1..v_updated_records.COUNT LOOP
    DBMS_OUTPUT.PUT_LINE('Record ID: ' || v_updated_records(i).record_id);
    DBMS_OUTPUT.PUT_LINE('Artist Name: ' || v_updated_records(i).artist_name);
    DBMS_OUTPUT.PUT_LINE('Album Name: ' || v_updated_records(i).album_name);
    DBMS_OUTPUT.PUT_LINE('--------------------------------');
  END LOOP;
EXCEPTION
  WHEN OTHERS THEN
    -- Обработка ошибок
    ROLLBACK;
    DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END;
/

update record set is_deleted = 'n' where record_id = 5

BEGIN
  DeletePoorSellingRecords;
END;











--amount > 0
CREATE OR REPLACE PROCEDURE getRecordsAmountNotZero
IS
  CURSOR c_records IS
    SELECT record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture,
    status, is_deleted, date_of_deliv_to_warehouse
    FROM Record
    where amount > 0
    ORDER BY record_id DESC;

  record_row c_records%ROWTYPE;
BEGIN
  FOR record_row IN c_records LOOP
    DBMS_OUTPUT.PUT_LINE('Record ID: ' || record_row.record_id);
    DBMS_OUTPUT.PUT_LINE('Year: ' || record_row.year);
    DBMS_OUTPUT.PUT_LINE('Cost: ' || record_row.cost);
    DBMS_OUTPUT.PUT_LINE('Amount: ' || record_row.amount);
    DBMS_OUTPUT.PUT_LINE('Supplier ID: ' || record_row.supplier_id);
    DBMS_OUTPUT.PUT_LINE('Description: ' || record_row.description);
    DBMS_OUTPUT.PUT_LINE('Artist Name: ' || record_row.artist_name);
    DBMS_OUTPUT.PUT_LINE('Album Name: ' || record_row.album_name);
    DBMS_OUTPUT.PUT_LINE('Picture: ' || record_row.picture);
    DBMS_OUTPUT.PUT_LINE('Status: ' || record_row.status);
    DBMS_OUTPUT.PUT_LINE('Is Deleted: ' || record_row.is_deleted);
    DBMS_OUTPUT.PUT_LINE('Date of Delivery to Warehouse: ' || record_row.date_of_deliv_to_warehouse);
    DBMS_OUTPUT.PUT_LINE('------------------------------');
  END LOOP;
END;



begin
    getRecordsAmountNotZero;
end;





















CREATE OR REPLACE PROCEDURE getNewRecords
IS
  CURSOR c_records IS
    SELECT record_id, year, cost, amount, supplier_id, description, artist_name, album_name, picture,
    status, is_deleted, date_of_deliv_to_warehouse
    FROM Record
     WHERE date_of_deliv_to_warehouse >= ADD_MONTHS(SYSTIMESTAMP, -2)
    ORDER BY date_of_deliv_to_warehouse DESC;

  record_row c_records%ROWTYPE;
BEGIN
  FOR record_row IN c_records LOOP
    DBMS_OUTPUT.PUT_LINE('Record ID: ' || record_row.record_id);
    DBMS_OUTPUT.PUT_LINE('Year: ' || record_row.year);
    DBMS_OUTPUT.PUT_LINE('Cost: ' || record_row.cost);
    DBMS_OUTPUT.PUT_LINE('Amount: ' || record_row.amount);
    DBMS_OUTPUT.PUT_LINE('Supplier ID: ' || record_row.supplier_id);
    DBMS_OUTPUT.PUT_LINE('Description: ' || record_row.description);
    DBMS_OUTPUT.PUT_LINE('Artist Name: ' || record_row.artist_name);
    DBMS_OUTPUT.PUT_LINE('Album Name: ' || record_row.album_name);
    DBMS_OUTPUT.PUT_LINE('Picture: ' || record_row.picture);
    DBMS_OUTPUT.PUT_LINE('Status: ' || record_row.status);
    DBMS_OUTPUT.PUT_LINE('Is Deleted: ' || record_row.is_deleted);
    DBMS_OUTPUT.PUT_LINE('Date of Delivery to Warehouse: ' || record_row.date_of_deliv_to_warehouse);
    DBMS_OUTPUT.PUT_LINE('------------------------------');
  END LOOP;
END;




begin
    getNewRecords();
end;








--можно написать отзыв если пластинка куплена
CREATE OR REPLACE PROCEDURE WriteReview(
  p_user_id IN Client.client_id%TYPE,
  p_record_id IN Record.record_id%TYPE,
  p_content IN Comments.content%TYPE
) AS
  v_order_id Order_card.order_id%TYPE;
BEGIN
  -- Проверяем, заказал ли пользователь данную пластинку
  SELECT o.order_id
  INTO v_order_id
  FROM Order_card_details od
  JOIN Order_card o ON od.order_id = o.order_id
  WHERE o.account_id = p_user_id AND od.record_id = p_record_id;

  -- Если пользователь заказал пластинку, добавляем отзыв
  INSERT INTO Comments (comment_id, comment_date, user_id, record_id, content)
  VALUES (null, SYSTIMESTAMP, p_user_id, p_record_id, p_content);

  COMMIT;

  DBMS_OUTPUT.PUT_LINE('Review added successfully.');
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    DBMS_OUTPUT.PUT_LINE('You can only write a review for the records you have ordered.');
  WHEN OTHERS THEN
    ROLLBACK;
    DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END;


select * from comments

DECLARE
  v_user_id Client.client_id%TYPE := 3; -- Идентификатор пользователя
  v_record_id Record.record_id%TYPE := 3; -- Идентификатор пластинки
  v_content Comments.content%TYPE := 'Great album! Highly recommended.'; -- Содержимое отзыва
BEGIN
  WriteReview(p_user_id => v_user_id, p_record_id => v_record_id, p_content => v_content);
END;








----------------------------------------------------------MODERATOR

--все пользователи и все их комментарии
CREATE OR REPLACE PROCEDURE GetUserComments AS
BEGIN
  FOR user_rec IN (SELECT * FROM Client)
  LOOP
    DBMS_OUTPUT.PUT_LINE('User ID: ' || user_rec.client_id || ' - User: ' || user_rec.login_client || ' - ' || user_rec.email);
    
    FOR comment_rec IN (SELECT c.comment_id, c.content, c.user_id, r.album_name 
                        FROM Comments c
                        JOIN Record r ON c.record_id = r.record_id
                        WHERE c.user_id = user_rec.client_id)
    LOOP
      DBMS_OUTPUT.PUT_LINE('   Comment ID: ' || comment_rec.comment_id || ' - Comment: ' || comment_rec.content || ' - Album: ' || comment_rec.album_name);
    END LOOP;
    
    IF SQL%NOTFOUND THEN
      DBMS_OUTPUT.PUT_LINE('   No comments.');
    END IF;
    
    DBMS_OUTPUT.NEW_LINE;
  END LOOP;
END;



begin
GetUserComments;
end;







CREATE OR REPLACE PROCEDURE GetAllClients AS
BEGIN
  FOR client_rec IN (SELECT * FROM Client)
  LOOP
    DBMS_OUTPUT.PUT_LINE('Client ID: ' || client_rec.client_id);
    DBMS_OUTPUT.PUT_LINE('Login: ' || client_rec.login_client);
    DBMS_OUTPUT.PUT_LINE('Email: ' || client_rec.email);
    DBMS_OUTPUT.PUT_LINE('Phone Number: ' || client_rec.phone_number);
    DBMS_OUTPUT.PUT_LINE('Sex: ' || client_rec.sex);
    DBMS_OUTPUT.PUT_LINE('Date of Birth: ' || client_rec.date_of_birth);
    DBMS_OUTPUT.NEW_LINE;
  END LOOP;
END;


begin
GetAllClients;
end;







CREATE OR REPLACE PROCEDURE DeleteComment(
  p_comment_id IN Comments.comment_id%TYPE
) AS
  v_user_id Comments.user_id%TYPE;
  v_record_id Comments.record_id%TYPE;
  v_content Comments.content%TYPE;
BEGIN
  SELECT user_id, record_id, content
  INTO v_user_id, v_record_id, v_content
  FROM Comments
  WHERE comment_id = p_comment_id;

  DELETE FROM Comments
  WHERE comment_id = p_comment_id;

  COMMIT;

  DBMS_OUTPUT.PUT_LINE('Comment deleted successfully.');
  DBMS_OUTPUT.PUT_LINE('Comment ID: ' || p_comment_id);
  DBMS_OUTPUT.PUT_LINE('User ID: ' || v_user_id);
  DBMS_OUTPUT.PUT_LINE('Record ID: ' || v_record_id);
  DBMS_OUTPUT.PUT_LINE('Content: ' || v_content);
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    DBMS_OUTPUT.PUT_LINE('Comment not found.');
  WHEN OTHERS THEN
    ROLLBACK;
    DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END;


DECLARE
  v_comment_id Comments.comment_id%TYPE := 20; -- Идентификатор комментария
BEGIN
  DeleteComment(p_comment_id => v_comment_id);
END;







--CREATE OR REPLACE PROCEDURE CreateComment(
--  p_user_id IN Comments.user_id%TYPE,
--  p_record_id IN Comments.record_id%TYPE,
--  p_content IN Comments.content%TYPE
--) AS
--BEGIN
--  INSERT INTO Comments (comment_id, comment_date, user_id, record_id, content)
--  VALUES (null, SYSTIMESTAMP, p_user_id, p_record_id, p_content);
--  COMMIT;
--  DBMS_OUTPUT.PUT_LINE('Comment created successfully.');
--EXCEPTION
--  WHEN OTHERS THEN
--    ROLLBACK;
--    DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
--END;
--
--
--
--
--DECLARE
--  v_user_id Comments.user_id%TYPE := 1; -- Идентификатор пользователя
--  v_record_id Comments.record_id%TYPE := 1; -- Идентификатор пластинки
--  v_content Comments.content%TYPE := 'Great album!'; -- Содержимое комментария
--BEGIN
--  CreateComment(p_user_id => v_user_id, p_record_id => v_record_id, p_content => v_content);
--END;



