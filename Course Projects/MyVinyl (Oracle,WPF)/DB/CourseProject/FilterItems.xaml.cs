using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using System.Collections.ObjectModel;
using System.Threading;
using System.Data;
using System.Data.Entity.Core.Objects;
using CourseProject;
using Microsoft.Win32;
using Oracle.ManagedDataAccess.Client;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для FilterItems.xaml
    /// </summary>
    public partial class FilterItems : Window
    {
        IEnumerable<RecordDisplay> FilteredRecordList;
        //BindingList<Record> FilteredRecordList = new BindingList<Record>();
        ListBox FilteredRecord = new ListBox();
        BindingList<RecordDisplay> filteredRecords = new BindingList<RecordDisplay>();

        decimal fromCost = 0, toCost = 0;
        decimal fromYear = 0, toYear = 0;
       


        public FilterItems(IEnumerable<RecordDisplay> FilteredRecordList2, ListBox Records)
        {
            InitializeComponent();

            FilteredRecordList = FilteredRecordList2;
            FilteredRecord = Records;
        }

        public void FilterList(object sender, RoutedEventArgs e)
        {
            if ((bool)radiobtnCost.IsChecked)
            {
                if (costFrom.Text != "" && costTo.Text != "")
                {

                    string newChangedCostFrom, newChangedCostTo;

                    if (costFrom.Text.Contains("."))
                    {
                        newChangedCostFrom = costFrom.Text.Replace('.', ',');
                    }
                    else
                    {
                        newChangedCostFrom = costFrom.Text;
                    }

                    if (costTo.Text.Contains("."))
                    {
                        newChangedCostTo = costTo.Text.Replace('.', ',');
                    }
                    else
                    {
                        newChangedCostTo = costTo.Text;
                    }

                    decimal i;
                    if (decimal.TryParse(newChangedCostFrom, out i) && decimal.TryParse(newChangedCostTo, out i) && Convert.ToDecimal(newChangedCostFrom) > 0 && Convert.ToDecimal(newChangedCostTo) > 0)
                    {
                        fromCost = Convert.ToDecimal(newChangedCostFrom);
                        toCost = Convert.ToDecimal(newChangedCostTo);


                        using (Entities1 ent = new Entities1())
                        {
                            filteredRecords.Clear();

                            foreach (var item in ent.FILTERBYCOST())
                            {
                                if (item.COST >= fromCost && item.COST <= toCost && item.IS_DELETED == "n")
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
                                    recordIt.SupplierNameList = suppName;

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
                                    recordIt.SongsAString = string.Join(", ", recordIt.SongsA);
                                    recordIt.SongsBString = string.Join(", ", recordIt.SongsB);
                                    recordIt.GenresString = string.Join(", ", recordIt.Genres);
                                    recordIt.SupplierNameString = string.Join(", ", recordIt.SupplierNameList);





                                    filteredRecords.Add(recordIt);

                                }

                               
                            }
                        }

                        FilteredRecord.ItemsSource = filteredRecords;
                    }
                    else
                    {
                        costFrom.Text = "";
                        costTo.Text = "";
                        MessageBox.Show("Please enter a valid positive cost interval");
                    }
                }
                else
                {
                    costFrom.Text = "";
                    costTo.Text = "";

                    MessageBox.Show("Enter 'from' and 'to' cost interval");
                }
            }

            if ((bool)radiobtnId.IsChecked)
            {

                if ((bool)ascRadio.IsChecked) {

                    using (Entities1 ent = new Entities1())
                    {
                        filteredRecords.Clear();

                        //foreach (var item in ent.FILTERBYIDASC())
                        //{

                        //    var recordIt = new RecordDisplay()
                        //    {
                        //        RECORD_ID = item.RECORD_ID,
                        //        YEAR = item.YEAR,
                        //        COST = item.COST,
                        //        AMOUNT = item.AMOUNT,
                        //        DESCRIPTION = item.DESCRIPTION,
                        //        SUPPLIER_ID = item.SUPPLIER_ID,
                        //        SUPPLIER_NAME = "nulllll",
                        //        ARTIST_NAME = item.ARTIST_NAME,
                        //        ALBUM_NAME = item.ALBUM_NAME,
                        //        PICTURE = item.PICTURE,
                        //        STATUS = item.STATUS,
                        //        DATE_OF_DELIV_TO_WAREHOUSE = item.DATE_OF_DELIV_TO_WAREHOUSE,
                        //        SupplierNameList = new List<string>(),
                        //        SongsA = new List<string>(),
                        //        SongsB = new List<string>(),
                        //        Genres = new List<string>()
                        //    };


                        //    var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        //    var sideAParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                        //    var sideBParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                        //    var supplierIdParam = new OracleParameter("p_SUPPLIER_ID", OracleDbType.Varchar2);

                        //    recordIdParam.Direction = ParameterDirection.Input;
                        //    sideAParam.Direction = ParameterDirection.Input;
                        //    sideBParam.Direction = ParameterDirection.Input;
                        //    supplierIdParam.Direction = ParameterDirection.Input;


                        //    recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
                        //    supplierIdParam.Value = Convert.ToInt32(item.SUPPLIER_ID);
                        //    sideAParam.Value = "A";
                        //    sideBParam.Value = "B";


                        //    var suppName = ent.Database.SqlQuery<string>("BEGIN :result := GETSUPPLIERNAME(:p_RECORD_ID, :p_SUPPLIER_ID); END;",
                        //      new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                        //      recordIdParam, supplierIdParam).ToList();
                        //    recordIt.SupplierNameList = suppName;

                        //    var songsA = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                        //        new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                        //        recordIdParam, sideAParam).ToList();
                        //    recordIt.SongsA.AddRange(songsA);


                        //    var songsB = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                        //       new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                        //       recordIdParam, sideBParam).ToList();
                        //    recordIt.SongsB.AddRange(songsB);



                        //    var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                        //    recordIdParam2.Direction = ParameterDirection.Input;
                        //    recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
                        //    var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
                        //        new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                        //        recordIdParam2).ToList();
                        //    recordIt.Genres.AddRange(genres);

                        //    // Преобразуем списки песен и жанров в строки
                        //    recordIt.SongsAString = string.Join(", ", recordIt.SongsA);
                        //    recordIt.SongsBString = string.Join(", ", recordIt.SongsB);
                        //    recordIt.GenresString = string.Join(", ", recordIt.Genres);
                        //    recordIt.SupplierNameString = string.Join(", ", recordIt.SupplierNameList);





                        //    filteredRecords.Add(recordIt);


                        //}
                    }

                    FilteredRecord.ItemsSource = filteredRecords;
                }

                   
                if ((bool)descRadio.IsChecked)
                {

                    using (Entities1 ent = new Entities1())
                    {
                        filteredRecords.Clear();

                        foreach (var item in ent.GETRECORDSINFO())
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
                                recordIt.SupplierNameList = suppName;

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
                                recordIt.SongsAString = string.Join(", ", recordIt.SongsA);
                                recordIt.SongsBString = string.Join(", ", recordIt.SongsB);
                                recordIt.GenresString = string.Join(", ", recordIt.Genres);
                                recordIt.SupplierNameString = string.Join(", ", recordIt.SupplierNameList);





                                filteredRecords.Add(recordIt);


                        }
                    }

                    FilteredRecord.ItemsSource = filteredRecords;
                }
                   
                

                

            }
            
            

            if ((bool)radiobtnGenre.IsChecked)
            {
                using (Entities1 ent = new Entities1())
                {
                    filteredRecords.Clear();

                    //foreach (var item in ent.FILTERBYIDASC())
                    //{

                    //    var recordIt = new RecordDisplay()
                    //    {
                    //        RECORD_ID = item.RECORD_ID,
                    //        YEAR = item.YEAR,
                    //        COST = item.COST,
                    //        AMOUNT = item.AMOUNT,
                    //        DESCRIPTION = item.DESCRIPTION,
                    //        SUPPLIER_ID = item.SUPPLIER_ID,
                    //        SUPPLIER_NAME = "nulllll",
                    //        ARTIST_NAME = item.ARTIST_NAME,
                    //        ALBUM_NAME = item.ALBUM_NAME,
                    //        PICTURE = item.PICTURE,
                    //        STATUS = item.STATUS,
                    //        DATE_OF_DELIV_TO_WAREHOUSE = item.DATE_OF_DELIV_TO_WAREHOUSE,
                    //        SupplierNameList = new List<string>(),
                    //        SongsA = new List<string>(),
                    //        SongsB = new List<string>(),
                    //        Genres = new List<string>()
                    //    };


                    //    var recordIdParam = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                    //    var sideAParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                    //    var sideBParam = new OracleParameter("p_side", OracleDbType.Varchar2);
                    //    var supplierIdParam = new OracleParameter("p_SUPPLIER_ID", OracleDbType.Varchar2);

                    //    recordIdParam.Direction = ParameterDirection.Input;
                    //    sideAParam.Direction = ParameterDirection.Input;
                    //    sideBParam.Direction = ParameterDirection.Input;
                    //    supplierIdParam.Direction = ParameterDirection.Input;


                    //    recordIdParam.Value = Convert.ToInt32(item.RECORD_ID);
                    //    supplierIdParam.Value = Convert.ToInt32(item.SUPPLIER_ID);
                    //    sideAParam.Value = "A";
                    //    sideBParam.Value = "B";


                    //    var suppName = ent.Database.SqlQuery<string>("BEGIN :result := GETSUPPLIERNAME(:p_RECORD_ID, :p_SUPPLIER_ID); END;",
                    //      new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                    //      recordIdParam, supplierIdParam).ToList();
                    //    recordIt.SupplierNameList = suppName;

                    //    var songsA = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                    //        new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                    //        recordIdParam, sideAParam).ToList();
                    //    recordIt.SongsA.AddRange(songsA);


                    //    var songsB = ent.Database.SqlQuery<string>("BEGIN :result := GETSONGSFORRECORD(:p_RECORD_ID, :p_side); END;",
                    //       new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                    //       recordIdParam, sideBParam).ToList();
                    //    recordIt.SongsB.AddRange(songsB);



                    //    var recordIdParam2 = new OracleParameter("p_RECORD_ID", OracleDbType.Decimal);
                    //    recordIdParam2.Direction = ParameterDirection.Input;
                    //    recordIdParam2.Value = Convert.ToInt32(item.RECORD_ID);
                    //    var genres = ent.Database.SqlQuery<string>("BEGIN :result := GETGENRESFORRECORD(:p_RECORD_ID); END;",
                    //        new OracleParameter("result", OracleDbType.RefCursor, ParameterDirection.Output),
                    //        recordIdParam2).ToList();
                    //    recordIt.Genres.AddRange(genres);

                    //    // Преобразуем списки песен и жанров в строки
                    //    recordIt.SongsAString = string.Join(", ", recordIt.SongsA);
                    //    recordIt.SongsBString = string.Join(", ", recordIt.SongsB);
                    //    recordIt.GenresString = string.Join(", ", recordIt.Genres);
                    //    recordIt.SupplierNameString = string.Join(", ", recordIt.SupplierNameList);


                    //    filteredRecords.Add(recordIt);


                    //}
                    //FilteredRecord.ItemsSource = filteredRecords;
                }
            }



            

            if ((bool)radiobtnYear.IsChecked)
            {
                if (yearFrom.Text != "" && yearTo.Text != "")
                {
                    int i;
                    if (int.TryParse(yearFrom.Text, out i) && int.TryParse(yearTo.Text, out i))
                    {
                        fromYear = Convert.ToInt32(yearFrom.Text);
                        toYear = Convert.ToInt32(yearTo.Text);


                        using (Entities1 ent = new Entities1())
                        {
                            filteredRecords.Clear();

                            foreach (var item in ent.FILTERBYYEAR())
                            {
                                if (item.YEAR >= fromYear && item.YEAR <= toYear && item.IS_DELETED == "n")
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
                                    recordIt.SupplierNameList = suppName;

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
                                    recordIt.SongsAString = string.Join(", ", recordIt.SongsA);
                                    recordIt.SongsBString = string.Join(", ", recordIt.SongsB);
                                    recordIt.GenresString = string.Join(", ", recordIt.Genres);
                                    recordIt.SupplierNameString = string.Join(", ", recordIt.SupplierNameList);





                                    filteredRecords.Add(recordIt);

                                }


                            }
                        }

                        FilteredRecord.ItemsSource = filteredRecords;
                    }
                    else
                    {
                        yearFrom.Text = "";
                        yearTo.Text = "";
                        MessageBox.Show("Please enter a valid year interval");
                    }
                }
                else
                {
                    yearFrom.Text = "";
                    yearTo.Text = "";

                    MessageBox.Show("Enter 'from' and 'to' year interval");
                }


            }
        }

        public void ResetFilterList(object sender, RoutedEventArgs e)
        {
            FilteredRecord.ItemsSource = FilteredRecordList;
        }
    }
}
