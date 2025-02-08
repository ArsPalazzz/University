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
using System.Data.Entity.Core.Objects;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {

        //private static string PathForDate = $"{Environment.CurrentDirectory}\\alldata3.json";
        //public FileIOService _fileOIService = new FileIOService(PathForDate);

        BindingList<RecordDisplay> records = new BindingList<RecordDisplay>();
        BindingList<RecordDisplay> recordsForSearch = new BindingList<RecordDisplay>();

        BindingList<SongsDisplay> songs = new BindingList<SongsDisplay>();
        
        //Cursor Diamond, Latte;

        //Stack<string> undoAction = new Stack<string>();
        //Stack<string> redoAction = new Stack<string>();

        public GuestWindow()
        {
            InitializeComponent();


            using (Entities1 ent = new Entities1())
            {
               
                records.Clear();
                foreach (var item in ent.GETRECORDSINFO())
                {
                    if (item.IS_DELETED == "n")
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

            


            //using (Entities3 ent = new Entities3())
            //{

            //    records.Clear();
            //    foreach (var item in ent.GETRECORDSINFO())
            //    {
            //        records.Add(new RecordDisplay()
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

            //        }) ;


            //    }





            //    Records.ItemsSource = records;



            //}

            //string cursorDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\MyCursors";
            //Diamond = new Cursor($"{cursorDir}\\diamond.cur");
            //Latte = new Cursor($"{cursorDir}\\cursor2.cur");
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

        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            using (Entities1 ent = new Entities1())
            {
                if (SearchBoxGuest.Text == string.Empty)
                {
                    Records.ItemsSource = records;
                }
                else
                {
                    recordsForSearch.Clear();
                    foreach (var item in ent.GETRECORDSINFO())
                    {
                        if (item.IS_DELETED == "n" && (item.ARTIST_NAME.ToLower().Contains(SearchBoxGuest.Text.ToLower()) || item.ALBUM_NAME.ToLower().Contains(SearchBoxGuest.Text.ToLower())))
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

       

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        

       

        public void FilterWin_Open(object sender, RoutedEventArgs e)
        {
            //new FilterItems(RecordsList, Records).Show();
            FilterItems filtWindow = new FilterItems(records, Records);
            filtWindow.Show();


        }


        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            using (Entities1 ent = new Entities1())
            {

                records.Clear();
                foreach (var item in ent.GETRECORDSINFO())
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
                Records.ItemsSource = records;
            }
        }




        //private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    undoAction.Push(SearchBoxGuest.Text);
        //}




        private void SingUpOpen_Click(object sender, RoutedEventArgs e)
        {
            SignUpForm signUpFormWindow = new SignUpForm();
            signUpFormWindow.Show();
            Close();
        }


    }
}
