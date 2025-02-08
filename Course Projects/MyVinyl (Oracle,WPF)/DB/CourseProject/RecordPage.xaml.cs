using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using CourseProject.Vinyl;
using System.ComponentModel;
using Microsoft.Win32;
using Oracle.ManagedDataAccess.Client;


using System.Collections.ObjectModel;
using System.Threading;
using System.Data;
using System.Data.Entity.Core.Objects;
using CourseProject;

namespace CourseProject
{ 
    public partial class RecordPage : Window
    {
        public static RecordDisplay currentRecord;
        BindingList<RecordDisplay> recordItem = new BindingList<RecordDisplay>();

        BindingList<RecordDisplay> recordsCurr = new BindingList<RecordDisplay>();
        BindingList<CommentDisplay> reviews = new BindingList<CommentDisplay>();
        public RecordPage(RecordDisplay record)
        {
            currentRecord = record;
            InitializeComponent();

            using (Entities1 ent = new Entities1())
            {
                recordsCurr.Clear();

                foreach (var item in ent.GETRECORDSINFO())
                {
                    if (currentRecord.RECORD_ID == item.RECORD_ID && item.IS_DELETED == "n")
                    {
                        var recordIt = new RecordDisplay()
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
                            SupplierNameList = new List<string>(),
                            SongsA = new List<string>(),
                            SongsB = new List<string>(),
                            Genres = new List<string>()
                        };


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
                        recordIt.SongsA.AddRange(songsA);


                        var songsB = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                           new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                           recordIdParam, sideBParam).ToList();
                        recordIt.SongsB.AddRange(songsB);



                        var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        recordIdParam2.Direction = ParameterDirection.Input;
                        recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
                        var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
                            new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                            recordIdParam2).ToList();
                        recordIt.Genres.AddRange(genres);

                        // Преобразуем списки песен и жанров в строки
                        recordIt.SongsAString = string.Join(", ", record.SongsA);
                        recordIt.SongsBString = string.Join(", ", record.SongsB);
                        recordIt.GenresString = string.Join(", ", record.Genres);
                        recordIt.SupplierNameString = string.Join(", ", record.SupplierNameList);

                        // Добавляем объект record в список records
                        recordsCurr.Add(recordIt);
                    }



                }
                listlist.ItemsSource = recordsCurr;





                reviews.Clear();

                foreach (var item in ent.GETALLCOMMENTS())
                {
                    if (currentRecord.RECORD_ID == item.RECORD_ID)
                    {
                        var comment = new CommentDisplay()
                        {
                            COMMENT_ID = item.COMMENT_ID,
                            COMMENT_DATE = item.COMMENT_DATE,
                            USER_ID = item.USER_ID,
                            RECORD_ID = item.RECORD_ID,
                            CONTENT = item.CONTENT,
                            SupplierNameList = new List<string>()
                        };

                        var userIdParam = new OracleParameter("p_SUPPLIER_ID", OracleDbType.Varchar2);


                        // Получаем список песен для записи
                        var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        //var sideAParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                        //var sideBParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                        //var supplierIdParam = new OracleParameter("p_SUPPLIER_ID", OracleDbType.Varchar2);

                        recordIdParam.Direction = ParameterDirection.Input;
                        //sideAParam.Direction = ParameterDirection.Input;
                        //sideBParam.Direction = ParameterDirection.Input;
                        userIdParam.Direction = ParameterDirection.Input;


                        recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
                        userIdParam.Value = Convert.ToInt32(item.USER_ID);
                        //sideAParam.Value = "A";
                        //sideBParam.Value = "B";


                        var suppName = ent.Database.SqlQuery<string>("BEGIN :result := GETSUPPLIERNAME(:p_RECORD_ID, :p_USER_ID); END;",
                          new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                          recordIdParam, userIdParam).ToList();
                        comment.SupplierNameList = suppName;

                        //var songsA = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                        //    new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                        //    recordIdParam, sideAParam).ToList();
                        //comment.SongsA.AddRange(songsA);


                        //var songsB = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                        //   new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                        //   recordIdParam, sideBParam).ToList();
                        //comment.SongsB.AddRange(songsB);



                        //var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        //recordIdParam2.Direction = ParameterDirection.Input;
                        //recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
                        //var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
                        //    new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                        //    recordIdParam2).ToList();
                        //comment.Genres.AddRange(genres);

                        // Преобразуем списки песен и жанров в строки
                        //comment.SongsAString = string.Join(", ", record.SongsA);
                        //comment.SongsBString = string.Join(", ", record.SongsB);
                        //comment.GenresString = string.Join(", ", record.Genres);
                        comment.SupplierNameString = string.Join(", ", comment.SupplierNameList);

                        // Добавляем объект record в список records
                        reviews.Add(comment);
                    }



                }
                Comments.ItemsSource = reviews;



            }

            //OneRecord.ItemsSource = recordItem;
        }


        public void RecordPage_Loaded(object sender, RoutedEventArgs e)
        {

         
            //ProductsPhotoEdit.Source = null;
            //RecordPageArtistName.Text = currentRecord.ARTIST_NAME;
            //RecordPageAlbumName.Text = currentRecord.ALBUM_NAME;
            //ProductsPhoto.Source = currentRecord.PICTURE;
        }
    }
}
