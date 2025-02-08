using System;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Net.NetworkInformation;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;
using Image = System.Windows.Controls.Image;


namespace lab_8
{
    enum Tables { Authors, Books };
    enum PrimaryColumn { ID, Id };



    public partial class MainWindow : Window
    {
        int pageSize = 5;
        int pageNumber = 0;

        string currentTableName;
        string currentPrimaryColumnName;
        string connectionString;


        DataSet ds;                     ///предст.полный набор д-х, включая таблицы и связи между ними
        SqlDataAdapter adapter;         ///чтобы заполнить DataSet
        SqlCommandBuilder commandBuilder;
        DataGrid currentGrid = new DataGrid();        ///ЭУ, позв. отобр и ред д-е из различ.источников(БД SQL)
        List<Image> images;

        public DataGrid accountsGrid { get; private set; }

        string createTables()
        {
            return "if not exists(select * from sysobjects where name='Authors' and xtype='U') "+
                "begin "+
                "use University " +
                "create table Authors( " +
                    "ID int primary key identity(100, 1), " +
                    "NAME nvarchar(100) not null, " +
                    "AGE int check(AGE between 17 and 40) not null, " +
                    "BIRTHDAY date not null, " +
                    "SEX nchar(1) check(SEX in ('м', 'ж')) not null, " +
                    "FOTO varbinary(max) default null " +
                ") " +
                " end "+
                "if not exists(select * from sysobjects where name='Books' and xtype='U') " +
                "begin "+
                "use University "+
                "create table [Books]( " +
                    "ID int primary key identity(1,1), " +
                    "AuthorId int foreign key references[Authors](ID), " +
                      "NameBook nvarchar(20) not null, " +
                    "[Index] int check([Index] between 100000 and 999999) not null " +
               ") "+
               "end";
        }
        string createDB()
        {
            return
                " IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'University') \r\n" +
                "begin" +
                " create database University " +
                "end ";
        }
 
        //string Insert()
        //{
        //    return
        //       "use University; " +
        //        "insert into Authors(NAME, AGE, BIRTHDAY, SEX, FOTO) values " +
        //            "('Картузов Данила Александрович',  23, '04-06-2000', 'м',  null), " +
        //            "('Седенкова Анастасия Максимовна', 20, '10-07-1998',  'ж',  null), " +
        //            "('Богословский Артем Михайлович', 19, '12-07-1997',  'м',  null), " +
        //            "('Пименов Максим Евгеньевич', 18, '12-02-2000', 'ж',  null) " +

        //        "insert into[Books](AuthorId, NameBook, [Index]) values" +
        //            "(100, 'first book', 220026)," +
        //            "(100, 'second book', 220306)," +
        //            "(101, 'third book', 220072)," +
        //            "(103, 'fourth book', 220306)";

        //}
        //string Procedure1()
        //{
        //    return
        //        "CREATE PROCEDURE if not exists [dbo].[sp_InsertAuthor] " +
        //            "@NAME nvarchar(100), " +
        //            "@AGE int, " +
        //            "@BIRTHDAY date, " +
        //            "@SEX nchar(1) " +
        //        "AS insert " +
        //        "into Authors(NAME, AGE, BIRTHDAY, SEX) " +
        //        "VALUES(@NAME, @AGE, @BIRTHDAY, @SEX) " +
        //        "SELECT SCOPE_IDENTITY() " +
        //        "GO ";

        //}
        //string Procedure2()
        //{
        //    return
        //        "CREATE PROCEDURE if not exists [dbo].[sp_InsertBook] " +
        //            "@AuthorId int, " +
        //            "@NameBook nvarchar(20), " +
        //            "@Index int " +
        //        "AS insert " +
        //        "into Books(AuthorId, NameBook, [Index]) " +
        //        "VALUES(@AuthorId, @NameBook, @Index) " +
        //        "SELECT SCOPE_IDENTITY() " +
        //        "GO";
        //}

        public MainWindow()
        {
            InitializeComponent();
            this.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            SqlConnection sqlConnection0 = new SqlConnection("Data Source=WIN-OLMAANRL9OB;Initial Catalog=University;Persist Security Info=True ");
            SqlCommand myCommand1 = new SqlCommand(createDB(), sqlConnection0);
            SqlCommand myCommand2 = new SqlCommand(createTables(), sqlConnection0);
            //SqlCommand myCommand3 = new SqlCommand(Insert(), sqlConnection0);
            //SqlCommand myCommand4 = new SqlCommand(Procedure1(), sqlConnection0);
            //SqlCommand myCommand5 = new SqlCommand(Procedure2(), sqlConnection0);
            sqlConnection0.Open();
            myCommand1.ExecuteNonQuery();
            myCommand2.ExecuteNonQuery();
            //myCommand3.ExecuteNonQuery();
            //myCommand4.ExecuteNonQuery();
            //myCommand5.ExecuteNonQuery();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            FillCurrentGrid();
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            //if ()
            //{
                try
                {

                    using (SqlConnection connection = new SqlConnection("Data Source=WIN-OLMAANRL9OB;Initial Catalog=University;Persist Security Info=True"))
                    {
                        connection.Open();
                        ///заполн.DataSet (ядро автономн.доступа к данным)
                        this.adapter = new SqlDataAdapter(GetSql(), connection);
                        this.commandBuilder = new SqlCommandBuilder(this.adapter);

                        if (this.currentTableName == Tables.Authors.ToString())
                        {
                            ///упр источником д-х с пом SQL
                            this.adapter.InsertCommand = new SqlCommand("sp_InsertAuthor", connection)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@NAME", SqlDbType.NVarChar, 100, "NAME"));
                            this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@AGE", SqlDbType.Int, 0, "AGE"));
                            this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@BIRTHDAY", SqlDbType.Date, 0, "BIRTHDAY"));
                            this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@SEX", SqlDbType.Char, 1, "SEX"));
                        }

                        if (this.currentTableName == Tables.Books.ToString())
                        {
                            this.adapter.InsertCommand = new SqlCommand("sp_InsertBook", connection)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@AuthorId", SqlDbType.Int, 0, "AuthorId"));
                            this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@NameBook", SqlDbType.NVarChar, 20, "NameBook"));
                            this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Index", SqlDbType.BigInt, 0, "Index"));
                        }

                        this.currentGrid.CanUserAddRows = false;
                        this.adapter.Update(this.ds);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
            //}
            //else
            //{
            //    MessageBox.Show("Введите возраст >0");
            //}
        }


        //ОБНОВЛЕНИЕ ЗАПИСЕЙ
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            FillCurrentGrid();
            this.currentGrid.CanUserAddRows = false;
        }


        //КНОПКА НАЗАД
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.pageNumber == 0)
                return;
            this.currentGrid.CanUserAddRows = false;
            this.pageNumber--;
            GetPage();
        }
        //КНОПКА ВПЕРЕД
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ds.Tables[0].Rows.Count < this.pageSize)
                return;
            this.currentGrid.CanUserAddRows = false;
            this.pageNumber++;
            GetPage();
        }


        //УДАЛЕНИЕ ЗАПИСЕЙ
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentGrid.SelectedItems != null)
            {
                for (int i = this.currentGrid.SelectedItems.Count - 1; i >= 0; i--)
                {
                    if (this.currentGrid.SelectedItems[i] is DataRowView datarowView)
                    {
                        DataRow dataRow = datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
        }

        //ДОБАВЛЕНИЕ ЗАПИСЕЙ
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            while (!(this.ds.Tables[0].Rows.Count < this.pageSize))
            {
                this.pageNumber++;
                GetPage();
            }
            currentGrid.CanUserAddRows = true;
        }



        //ИЗМЕНЕНИЕ ПОЛЕЙ
        private void MainTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TabItem item = (TabItem)this.mainTab.SelectedItem;
                if (this.currentTableName != item.Header.ToString())
                {
                    this.currentTableName = item.Header.ToString();

                    if (this.currentTableName == Tables.Authors.ToString())
                    {
                        AuthorGrid = this.AuthorGrid;
                        this.currentPrimaryColumnName = PrimaryColumn.ID.ToString();
                    }
                    if (this.currentTableName == Tables.Books.ToString())
                    {
                        AuthorGrid = this.AuthorGrid;
                        this.currentPrimaryColumnName = PrimaryColumn.ID.ToString();
                    }
                    this.pageNumber = 0;
                    FillCurrentGrid();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private string GetSql()
        {
            return "SELECT * FROM " + this.currentTableName
                + " ORDER BY " + this.currentPrimaryColumnName
                  + " OFFSET ((" + this.pageNumber + ") * " + this.pageSize + ") "
                  + "ROWS FETCH NEXT " + this.pageSize + " ROWS ONLY";
        }

        private void GetPage()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=WIN-OLMAANRL9OB;Initial Catalog=University;Persist Security Info=True"))
                {
                    this.adapter = new SqlDataAdapter(GetSql(), connection);
                    this.ds.Tables[0].Rows.Clear();
                    this.adapter.Fill(this.ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        //ЗАПОЛНЕНИЕ ТЕКУЩЕГО GRID
        private void FillCurrentGrid()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=WIN-OLMAANRL9OB;Initial Catalog=University;Persist Security Info=True"))
            {
                connection.Open();
                this.adapter = new SqlDataAdapter(GetSql(), connection);                //GET SQL_

                this.ds = new DataSet();    ///предст.полн.набор д-х
                this.adapter.Fill(this.ds);
                currentGrid.ItemsSource = this.ds.Tables[0].DefaultView;

                /// транзакция - набор операций, либо все вып./нет  -> д-е всегда в коррект сост.

                SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "select * from Authors";
                    //command.CommandText = "select * from Authors"+"select * from Bookkks";
                    command.ExecuteNonQuery();///для оп-ров sql без рез (update, insert)
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }

        //ЗАГРУЗКА ДАННЫХ ИЗ БД
        private void ReadFileFromDatabase()
        {
            images = new List<Image>();

            using (SqlConnection connection = new SqlConnection("Data Source=WIN-OLMAANRL9OB;Initial Catalog=University;Persist Security Info=True"))
            {
                connection.Open();
                string sql = "SELECT Id, Surname, Photo FROM Books";      ///запрос для команды
                SqlCommand command = new SqlCommand(sql, connection);       ///вып команду
                SqlDataReader reader = command.ExecuteReader();             ///получ.д-е

                while (reader.Read())   ///пока есть строки для чтения
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    byte[] data = (byte[])reader.GetValue(2);

                    Image im = new Image();
                    images.Add(im);
                }
            }
        }



        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem item = (TabItem)sender;
            currentTableName = item.Header.ToString();

            if (currentTableName == Tables.Authors.ToString())
            {
                currentGrid = AuthorGrid;
                currentPrimaryColumnName = PrimaryColumn.ID.ToString();
            }
            if (currentTableName == Tables.Books.ToString())
            {
                currentGrid = BooksGrid;
                currentPrimaryColumnName = PrimaryColumn.ID.ToString();
            }

            FillCurrentGrid();
        }

        private void StudentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("https://cdn-icons-png.flaticon.com/512/21/21104.png", UriKind.Relative));

        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                object rows = AuthorGrid.SelectedItem;
                DataRowView rowview = AuthorGrid.SelectedItem as DataRowView;
                if(rowview != null)
                {
                    string id = rowview.Row[0].ToString();
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.ShowDialog();

                    byte[] image_bytes;
                    try
                    {
                        image_bytes = File.ReadAllBytes(openFileDialog.FileName);


                        using (SqlConnection connection = new SqlConnection("Data Source=WIN-OLMAANRL9OB;Initial Catalog=University;Persist Security Info=True")) // создаем подключение
                        {
                            connection.Open(); // откроем подключение
                            SqlCommand command = new SqlCommand(); // создадим запрос
                            command.Connection = connection; // дадим запросу подключение
                            command.CommandText = @"UPDATE Authors set FOTO = @ImageData where id = @AuthorId"; // пропишем запрос
                            command.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);
                            command.Parameters.Add("@AuthorId", SqlDbType.Int, 0);
                            command.Parameters["@ImageData"].Value = image_bytes;// скалярной переменной ImageData присвоем массив байтов

                            command.Parameters["@AuthorId"].Value = id;
                            command.ExecuteNonQuery(); // запустим
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Выберите не пустой путь до фото");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите элемент");
                }
                
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Выберите элемент");
            }
            
        }



    //    public override System.Windows.Controls.ValidationResult Validate(object value,
    //System.Globalization.CultureInfo cultureInfo)
    //    {
    //        int myInt = 0;

    //        try
    //        {
    //            if (((string)value).Length > 0)
    //                myInt = int.Parse((String)value);
    //        }
    //        catch (Exception e)
    //        {
    //            return new ValidationResult(false, "Illegal characters or " + e.Message);
    //        }

    //        if (myInt < 0 || myInt > 20)
    //        {
    //            return new ValidationResult(false,
    //              "Please enter a number in the range: 0 - 20");
    //        }
    //        else
    //        {
    //            return new ValidationResult(true, null);
    //        }
    //    }

    }
}
