using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Linq;
using System.Windows.Input;
using CourseProject.Vinyl;
//using CourseProject.Services;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Entity.Core.Objects;
using CourseProject;

namespace CourseProject
{
   
    public partial class UserWindow : Window
    {

       
        BindingList<RecordDisplay> records = new BindingList<RecordDisplay>();
        BindingList<RecordDisplay> userRecords = new BindingList<RecordDisplay>();
        BindingList<RecordDisplay> recordsForSearch = new BindingList<RecordDisplay>();


       

        public UserWindow()
        {
            InitializeComponent();
            
            
            //all records except user_records
            using (Entities1 ent = new Entities1())
            {

                records.Clear();
                foreach (var item in ent.GETRECORDSINFO())
                {
                    if (Global.USER_ID != item.SUPPLIER_ID && item.IS_DELETED == "n")
                    {
                        var record = new RecordDisplay()
                        {
                            RECORD_ID = item.RECORD_ID,
                            YEAR = item.YEAR,
                            COST = item.COST,
                            AMOUNT = item.AMOUNT,
                            DESCRIPTION = item.DESCRIPTION,
                            SUPPLIER_ID = item.SUPPLIER_ID,
                            SUPPLIER_NAME = "nulllll",
                            ARTIST_NAME = item.ARTIST_NAME,
                            ALBUM_NAME = item.ALBUM_NAME,
                            PICTURE = item.PICTURE,
                            STATUS = item.STATUS,
                            DATE_OF_DELIV_TO_WAREHOUSE = item.DATE_OF_DELIV_TO_WAREHOUSE,
                            SongsA = new List<string>(),
                            SupplierNameList = new List<string>(),
                            SongsB = new List<string>(),
                            Genres = new List<string>()
                        };

                        //record.SUPPLIER_NAME = ent.GETSUPPLIERNAME(record.RECORD_ID, record.SUPPLIER_ID);
                        // Получаем список песен для записи
                        var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        var sideAParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                        var sideBParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                        var supplierIdParam = new OracleParameter("p_SUPPLIER_ID", OracleDbType.Varchar2);

                        recordIdParam.Direction = ParameterDirection.Input;
                        sideAParam.Direction = ParameterDirection.Input;
                        sideBParam.Direction = ParameterDirection.Input;
                        supplierIdParam.Direction = ParameterDirection.Input;


                        recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
                        supplierIdParam.Value = Convert.ToInt32(item.SUPPLIER_ID);
                        sideAParam.Value = "A";
                        sideBParam.Value = "B";


                        var suppName = ent.Database.SqlQuery<string>("BEGIN :result := GETSUPPLIERNAME(:p_RECORD_ID, :p_SUPPLIER_ID); END;",
                           new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                           recordIdParam, supplierIdParam).ToList();
                        record.SupplierNameList = suppName;

                        var songsA = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                            recordIdParam, sideAParam).ToList();
                        record.SongsA.AddRange(songsA);


                        var songsB = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                           new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                           recordIdParam, sideBParam).ToList();
                        record.SongsB.AddRange(songsB);



                        var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        recordIdParam2.Direction = ParameterDirection.Input;
                        recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);


                        var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
                            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                            recordIdParam2).ToList();
                        record.Genres.AddRange(genres);

                        // Преобразуем списки песен и жанров в строки
                        record.SongsAString = string.Join(", ", record.SongsA);
                        record.SongsBString = string.Join(", ", record.SongsB);
                        record.GenresString = string.Join(", ", record.Genres);
                        record.SupplierNameString = string.Join(", ", record.SupplierNameList);

                        // Добавляем объект record в список records
                        records.Add(record);
                    }
                   


                }
                Records.ItemsSource = records;


                

            }

            //only user_records
            using (Entities1 ent = new Entities1())
            {

                userRecords.Clear();
                foreach (var item in ent.GETRECORDSINFO())
                {
                    if (Global.USER_ID == item.SUPPLIER_ID && item.IS_DELETED == "n")
                    {
                        var record = new RecordDisplay()
                        {
                            RECORD_ID = item.RECORD_ID,
                            YEAR = item.YEAR,
                            COST = item.COST,
                            AMOUNT = item.AMOUNT,
                            DESCRIPTION = item.DESCRIPTION,
                            SUPPLIER_ID = item.SUPPLIER_ID,
                            ARTIST_NAME = item.ARTIST_NAME,
                            ALBUM_NAME = item.ALBUM_NAME,
                            PICTURE = item.PICTURE,
                            STATUS = item.STATUS,
                            DATE_OF_DELIV_TO_WAREHOUSE = item.DATE_OF_DELIV_TO_WAREHOUSE,
                            SongsA = new List<string>(),
                            SongsB = new List<string>(),
                            Genres = new List<string>()
                        };


                        // Получаем список песен для записи
                        var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        var sideAParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                        var sideBParam = new OracleParameter("p_side", OracleDbType.Varchar2);

                        recordIdParam.Direction = ParameterDirection.Input;
                        sideAParam.Direction = ParameterDirection.Input;
                        sideBParam.Direction = ParameterDirection.Input;


                        recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
                        sideAParam.Value = "A";
                        sideBParam.Value = "B";

                        var songsA = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                            recordIdParam, sideAParam).ToList();
                        record.SongsA.AddRange(songsA);


                        var songsB = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                           new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                           recordIdParam, sideBParam).ToList();
                        record.SongsB.AddRange(songsB);



                        var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        recordIdParam2.Direction = ParameterDirection.Input;
                        recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
                        var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
                            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                            recordIdParam2).ToList();
                        record.Genres.AddRange(genres);

                        // Преобразуем списки песен и жанров в строки
                        record.SongsAString = string.Join(", ", record.SongsA);
                        record.SongsBString = string.Join(", ", record.SongsB);
                        record.GenresString = string.Join(", ", record.Genres);

                        // Добавляем объект record в список records
                        userRecords.Add(record);
                    }



                }
                Records2.ItemsSource = userRecords;




            }
            
            //using (var context = new Entities1())
            //{

            //    decimal p_id = 1; // пример значения параметра



            //    //var records = new ObjectParameter("records", typeof(ObjectResult<RecordDisplay>));

            //    List<RecordDisplay> result = context.GETRECORDSINFOBYID(p_id);



            //    //var records = new ObjectParameter("records", typeof(ObjectResult<>));
            //    //context.GETRECORDSINFOBYID(p_id);
            //    //var result = (ObjectResult<RecordDisplay>)records.Value;
            //    foreach (var item in result)
            //    {
            //        var record = new RecordDisplay()
            //        {
            //            RECORD_ID = item.RECORD_ID,
            //            YEAR = item.YEAR,
            //            COST = item.COST,
            //            AMOUNT = item.AMOUNT,
            //            DESCRIPTION = item.DESCRIPTION,
            //            ARTIST_NAME = item.ARTIST_NAME,
            //            ALBUM_NAME = item.ALBUM_NAME,
            //            PICTURE = item.PICTURE,
            //            STATUS = item.STATUS,
            //            DATE_OF_DELIV_TO_WAREHOUSE = item.DATE_OF_DELIV_TO_WAREHOUSE,
            //            Songs = new List<string>(),
            //            Genres = new List<string>()
            //        };


            //        // Получаем список песен для записи
            //        var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
            //        recordIdParam.Direction = ParameterDirection.Input;
            //        recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
            //        var songs = context.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID); END;",
            //            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
            //            recordIdParam).ToList();
            //        record.Songs.AddRange(songs);



            //        var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
            //        recordIdParam2.Direction = ParameterDirection.Input;
            //        recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
            //        var genres = context.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
            //            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
            //            recordIdParam2).ToList();
            //        record.Genres.AddRange(genres);

            //        // Преобразуем списки песен и жанров в строки
            //        record.SongsString = string.Join(", ", record.Songs);
            //        record.GenresString = string.Join(", ", record.Genres);

            //        // Добавляем объект record в список records
            //        userRecords.Add(record);
            //    }
            //    //ent.Database.ExecuteSqlCommand("BEGIN GETRECORDSINFOBYID(:p_id); END;",
            //    //       new OracleParameter("p_id", Global.USER_ID)
            //    //       );



            //    //foreach (var item in ent.GETRECORDSINFOBYID(Global.USER_ID))
            //    //{
            //    //    var record = new RecordDisplay()
            //    //    {
            //    //        RECORD_ID = item.RECORD_ID,
            //    //        YEAR = item.YEAR,
            //    //        COST = item.COST,
            //    //        AMOUNT = item.AMOUNT,
            //    //        DESCRIPTION = item.DESCRIPTION,
            //    //        ARTIST_NAME = item.ARTIST_NAME,
            //    //        ALBUM_NAME = item.ALBUM_NAME,
            //    //        PICTURE = item.PICTURE,
            //    //        STATUS = item.STATUS,
            //    //        DATE_OF_DELIV_TO_WAREHOUSE = item.DATE_OF_DELIV_TO_WAREHOUSE,
            //    //        Songs = new List<string>(),
            //    //        Genres = new List<string>()
            //    //    };


            //    //    // Получаем список песен для записи
            //    //    var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
            //    //    recordIdParam.Direction = ParameterDirection.Input;
            //    //    recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
            //    //    var songs = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID); END;",
            //    //        new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
            //    //        recordIdParam).ToList();
            //    //    record.Songs.AddRange(songs);



            //    //    var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
            //    //    recordIdParam2.Direction = ParameterDirection.Input;
            //    //    recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
            //    //    var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
            //    //        new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
            //    //        recordIdParam2).ToList();
            //    //    record.Genres.AddRange(genres);

            //    //    // Преобразуем списки песен и жанров в строки
            //    //    record.SongsString = string.Join(", ", record.Songs);
            //    //    record.GenresString = string.Join(", ", record.Genres);

            //    //    // Добавляем объект record в список records
            //    //    records.Add(record);


            //    //}
            //    Records2.ItemsSource = userRecords;
            //}
        }

        //public void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    _fileOIService = new FileIOService(PathForDate);

        //    try
        //    {

        //        RecordsList = _fileOIService.LoadDate();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Что-то не так с загрузкой данных из файла. Ошибка: {ex}");
        //        Close();
        //    }

        //    Records.ItemsSource = RecordsList;

        //    RecordsList.ListChanged += RecordsList_ListChanged1;


        //}

        private void ProfileOpen_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profileWindow = new ProfilePage();
            profileWindow.Show();

            Close();
        }

        private void BuyRecord_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var currentRecord = button.DataContext as RecordDisplay;
            int i;

            ModalWindowBuy modalWin = new ModalWindowBuy(currentRecord);
            

            if (modalWin.ShowDialog() == true)
            {
                bool isValid = true;

                if (modalWin.amountBuyTextBox.Text != "")
                {
                    if (!int.TryParse(modalWin.amountBuyTextBox.Text, out i)) 
                    {
                        modalWin.amountBuyTextBox.Text = "";
                        isValid = false;
                        MessageBox.Show("Please enter a valid amount");
                    }
                    else if (int.Parse(modalWin.amountBuyTextBox.Text) < 1)
                    {
                        modalWin.amountBuyTextBox.Text = "";
                        isValid = false;
                        MessageBox.Show("You can buy at least one record");
                    }
                    else if (int.Parse(modalWin.amountBuyTextBox.Text) > currentRecord.AMOUNT)
                    {
                        modalWin.amountBuyTextBox.Text = "";
                        isValid = false;
                        MessageBox.Show("You can't buy so many records");
                    }

                    if (isValid)
                    {
                        decimal reduceAmountValue = Convert.ToDecimal(modalWin.amountBuyTextBox.Text);
                        using (Entities1 ent = new Entities1())
                        {
                            ent.REDUCEAMOUNTOFRECORD(currentRecord.RECORD_ID, reduceAmountValue);
                            MessageBox.Show("It's valid");
                        }
                       
                    }
                }
                else
                {
                    MessageBox.Show("Enter a value");
                }

                //var button = sender as Button;
                if (button != null)
                {
                    var deletedRecord = button.DataContext as RecordDisplay;

                    using (Entities1 ent = new Entities1())
                    {
                        ent.DELETE_RECORD(deletedRecord.RECORD_ID);
                    }
                }
            }
        }

        private void MoreInfo_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            

            if (button != null)
            {
                var myRecord = button.DataContext as RecordDisplay;

                new RecordPage(myRecord).Show();
            }
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(ProductsPhoto.Source);
            var button = sender as Image;
            if (button != null)
            {
                var editedRecord = button.DataContext as RecordDisplay;

                new EditItem(editedRecord).Show();
            }
            //AddItem wind = new AddItem();
            //wind.Show();
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {


            ModalWindow modalWin = new ModalWindow();

            if (modalWin.ShowDialog() == true)
            {
                var button = sender as Image;
                if (button != null)
                {
                    var deletedRecord = button.DataContext as RecordDisplay;

                    using (Entities1 ent = new Entities1())
                    {
                        ent.DELETE_RECORD(deletedRecord.RECORD_ID);
                    }
                }
            }


           
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            //Refresh catalog
            using (Entities1 ent = new Entities1())
            {

                records.Clear();
                foreach (var item in ent.GETRECORDSINFO())
                {
                    if (Global.USER_ID != item.SUPPLIER_ID && item.IS_DELETED == "n")
                    {
                        var record = new RecordDisplay()
                        {
                            RECORD_ID = item.RECORD_ID,
                            YEAR = item.YEAR,
                            COST = item.COST,
                            AMOUNT = item.AMOUNT,
                            DESCRIPTION = item.DESCRIPTION,
                            ARTIST_NAME = item.ARTIST_NAME,
                            ALBUM_NAME = item.ALBUM_NAME,
                            PICTURE = item.PICTURE,
                            STATUS = item.STATUS,
                            DATE_OF_DELIV_TO_WAREHOUSE = item.DATE_OF_DELIV_TO_WAREHOUSE,
                            SongsA = new List<string>(),
                            SongsB = new List<string>(),
                            Genres = new List<string>()
                        };


                        // Получаем список песен для записи
                        var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        var sideAParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                        var sideBParam = new OracleParameter("p_side", OracleDbType.Varchar2);

                        recordIdParam.Direction = ParameterDirection.Input;
                        sideAParam.Direction = ParameterDirection.Input;
                        sideBParam.Direction = ParameterDirection.Input;


                        recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
                        sideAParam.Value = "A";
                        sideBParam.Value = "B";

                        var songsA = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                            recordIdParam, sideAParam).ToList();
                        record.SongsA.AddRange(songsA);


                        var songsB = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                           new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                           recordIdParam, sideBParam).ToList();
                        record.SongsB.AddRange(songsB);


                        // Получаем список жанров для записи
                        var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        recordIdParam2.Direction = ParameterDirection.Input;
                        recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
                        var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
                            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                            recordIdParam2).ToList();
                        record.Genres.AddRange(genres);


                        // Преобразуем списки песен и жанров в строки
                        record.SongsAString = string.Join(", ", record.SongsA);
                        record.SongsBString = string.Join(", ", record.SongsB);
                        record.GenresString = string.Join(", ", record.Genres);


                        // Добавляем объект record в список records
                        records.Add(record);
                    }

                  

                }
                Records.ItemsSource = records;
            }


            //Refresh user_records
            using (Entities1 ent = new Entities1())
            {

                userRecords.Clear();
                foreach (var item in ent.GETRECORDSINFO())
                {
                    if (Global.USER_ID == item.SUPPLIER_ID && item.IS_DELETED == "n")
                    {
                        var record = new RecordDisplay()
                        {
                            RECORD_ID = item.RECORD_ID,
                            YEAR = item.YEAR,
                            COST = item.COST,
                            AMOUNT = item.AMOUNT,
                            DESCRIPTION = item.DESCRIPTION,
                            ARTIST_NAME = item.ARTIST_NAME,
                            ALBUM_NAME = item.ALBUM_NAME,
                            PICTURE = item.PICTURE,
                            STATUS = item.STATUS,
                            DATE_OF_DELIV_TO_WAREHOUSE = item.DATE_OF_DELIV_TO_WAREHOUSE,
                            SongsA = new List<string>(),
                            SongsB = new List<string>(),
                            Genres = new List<string>()
                        };


                        // Получаем список песен для записи
                        var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        var sideAParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                        var sideBParam = new OracleParameter("p_side", OracleDbType.Varchar2);

                        recordIdParam.Direction = ParameterDirection.Input;
                        sideAParam.Direction = ParameterDirection.Input;
                        sideBParam.Direction = ParameterDirection.Input;


                        recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
                        sideAParam.Value = "A";
                        sideBParam.Value = "B";

                        var songsA = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                            recordIdParam, sideAParam).ToList();
                        record.SongsA.AddRange(songsA);


                        var songsB = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                           new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                           recordIdParam, sideBParam).ToList();
                        record.SongsB.AddRange(songsB);


                        // Получаем список жанров для записи
                        var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        recordIdParam2.Direction = ParameterDirection.Input;
                        recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
                        var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
                            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                            recordIdParam2).ToList();
                        record.Genres.AddRange(genres);


                        // Преобразуем списки песен и жанров в строки
                        record.SongsAString = string.Join(", ", record.SongsA);
                        record.SongsBString = string.Join(", ", record.SongsB);
                        record.GenresString = string.Join(", ", record.Genres);


                        // Добавляем объект record в список records
                        userRecords.Add(record);
                    }

                   

                }
                Records2.ItemsSource = userRecords;
            }
        }


        public void AddItemFunc_Click(object sender, RoutedEventArgs e)
        {
            AddItem newWin = new AddItem();
            newWin.Show();
        }

        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            using (Entities1 ent = new Entities1())
            {
                if (SearchBoxUser.Text == string.Empty)
                {
                    Records.ItemsSource = records;
                }
                else
                {
                    recordsForSearch.Clear();
                    foreach (var item in ent.GETRECORDSINFO())
                    {
                        if (item.IS_DELETED == "n" && (item.ARTIST_NAME.ToLower().Contains(SearchBoxUser.Text.ToLower()) || item.ALBUM_NAME.ToLower().Contains(SearchBoxUser.Text.ToLower())))
                        {
                            var record = new RecordDisplay()
                            {
                                RECORD_ID = item.RECORD_ID,
                                YEAR = item.YEAR,
                                COST = item.COST,
                                AMOUNT = item.AMOUNT,
                                DESCRIPTION = item.DESCRIPTION,
                                ARTIST_NAME = item.ARTIST_NAME,
                                ALBUM_NAME = item.ALBUM_NAME,
                                PICTURE = item.PICTURE,
                                STATUS = item.STATUS,
                                DATE_OF_DELIV_TO_WAREHOUSE = item.DATE_OF_DELIV_TO_WAREHOUSE,
                                SongsA = new List<string>(),
                                SongsB = new List<string>(),
                                Genres = new List<string>()
                            };


                            //Получаем список песен для записи
                            var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                            var sideAParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                            var sideBParam = new OracleParameter("p_side", OracleDbType.Varchar2);

                            recordIdParam.Direction = ParameterDirection.Input;
                            sideAParam.Direction = ParameterDirection.Input;
                            sideBParam.Direction = ParameterDirection.Input;


                            recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
                            sideAParam.Value = "A";
                            sideBParam.Value = "B";

                            var songsA = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                                new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                                recordIdParam, sideAParam).ToList();
                            record.SongsA.AddRange(songsA);


                            var songsB = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                               new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                               recordIdParam, sideBParam).ToList();
                            record.SongsB.AddRange(songsB);




                            var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                            recordIdParam2.Direction = ParameterDirection.Input;
                            recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
                            var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
                                new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                                recordIdParam2).ToList();
                            record.Genres.AddRange(genres);

                            // Преобразуем списки песен и жанров в строки
                            record.SongsAString = string.Join(", ", record.SongsA);
                            record.SongsBString = string.Join(", ", record.SongsB);
                            record.GenresString = string.Join(", ", record.Genres);

                            //Добавляем объект record в список records
                            recordsForSearch.Add(record);
                        }
                    }
                    Records.ItemsSource = recordsForSearch;
                }

            }
        }

        //private void Light_Selected(object sender, RoutedEventArgs e)
        //{
        //    var uri = new Uri("Resources/LightTheme.xaml", UriKind.Relative);                           // определяем путь к файлу ресурсов
        //    ResourceDictionary resourseDict = Application.LoadComponent(uri) as ResourceDictionary;     // загружаем словарь ресурсов
        //    Application.Current.Resources.Clear();                                                      // очищаем коллекцию ресурсов приложения
        //    Application.Current.Resources.MergedDictionaries.Add(resourseDict);                         // добавляем загруженный словарь ресурсов
        //}

        //private void Dark_Selected(object sender, RoutedEventArgs e)
        //{
        //    var uri = new Uri("Resources/DarkTheme.xaml", UriKind.Relative);
        //    ResourceDictionary resourseDict = Application.LoadComponent(uri) as ResourceDictionary;
        //    Application.Current.Resources.Clear();
        //    Application.Current.Resources.MergedDictionaries.Add(resourseDict);
        //}

        //private void RecordsList_ListChanged1(object sender, ListChangedEventArgs e)
        //{
        //    if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
        //    {
        //        try
        //        {
        //            _fileOIService.SaveData(sender);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");
        //            Close();
        //        }
        //    }
        //}

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void RusLocal_Selected(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources/rusLang.xaml", UriKind.Relative);
            ResourceDictionary resourseDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourseDict);
        }

        private void EngLocal_Selected(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources/engLang.xaml", UriKind.Relative);
            ResourceDictionary resourseDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourseDict);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        //private void btnGeometric_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sender == btnGeometric)
        //    {
        //        this.Cursor = Diamond;
        //    }
        //    else if (sender == btnPixel)
        //    {
        //        this.Cursor = Latte;
        //    }
        //}

        //public void AddItem_func(object sender, RoutedEventArgs e)
        //{
        //    new AddItem(RecordsList).Show();
        //}

        public void FilterWin_Open(object sender, RoutedEventArgs e)
        {
            
                //new FilterItems(RecordsList, Records).Show();
                FilterItems filtWindow = new FilterItems(records, Records);
                filtWindow.Show();


            
        }





        //private void Refresh_Click(object sender, RoutedEventArgs e)
        //{

        //    try
        //    {
        //        RecordsList = _fileOIService.LoadDate();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Что-то не так с загрузкой данных из файла. Ошибка: {ex}");
        //        Close();
        //    }
        //    Records.ItemsSource = RecordsList;
        //}

        //private void Delete_Click(object sender, RoutedEventArgs e)
        //{
        //    var button = sender as Image;
        //    if (button != null)
        //    {
        //        var deletedRecord = button.DataContext as Record;

        //        RecordsList.Remove(deletedRecord);
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        _fileOIService.SaveData(RecordsList);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");
        //        Close();
        //    }


        //}
        //private void Edit_Click(object sender, RoutedEventArgs e)
        //{
        //    var button = sender as Image;
        //    if (button != null)
        //    {
        //        var editedAuto = button.DataContext as Record;

        //        new EditItem(editedAuto).Show();

        //        editedAuto = EditItem.ShowEditedRecord();

        //    }
        //    else
        //    {
        //        return;
        //    }


        //    try
        //    {
        //        _fileOIService.SaveData(RecordsList);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");
        //        Close();
        //    }

        //    Records.ItemsSource = RecordsList;
        //}

        //private void msUndo_Click(object sender, MouseButtonEventArgs e)
        //{
        //    if (undoAction.Count < 1)
        //    {
        //        return;
        //    }

        //    if (redoAction.Count == 0 || SearchBoxUser.Text != string.Empty)
        //    {
        //        redoAction.Push(SearchBoxUser.Text);
        //    }

        //    SearchBoxUser.Text = undoAction.Pop();
        //}
        //private void msRedo_Click(object sender, MouseButtonEventArgs e)
        //{
        //    if (redoAction.Count < 1)
        //    {
        //        return;
        //    }


        //    if (undoAction.Count == 0 || SearchBoxUser.Text != string.Empty)
        //    {
        //        undoAction.Push(SearchBoxUser.Text);
        //    }

        //    SearchBoxUser.Text = redoAction.Pop();
        //}

        //private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    undoAction.Push(SearchBoxUser.Text);
        //}


        

        private void SingUpOpen_Click(object sender, RoutedEventArgs e)
        {
            SignUpForm signUpFormWindow = new SignUpForm();
            signUpFormWindow.Show();
            Close();
        }


    }
}
