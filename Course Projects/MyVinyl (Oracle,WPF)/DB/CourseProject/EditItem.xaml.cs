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


namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        BindingList<Record> newRecordList = new BindingList<Record>();
        Record newRecord = new Record();

        public static RecordDisplay currentRecord;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        //MainWindow window = new MainWindow();
        //private BindingList<Auto> AutoList;
        //private FileIOService _fileOIService;
        //private readonly string PathForDate = $"{Environment.CurrentDirectory}\\alldata3.json";
        public EditItem(RecordDisplay editedRecord)
        {
            currentRecord = editedRecord;
            InitializeComponent();
            openFileDialog.Filter = "Фотографии|*.jpg;*.png;*.jpeg;";

            //newRecordList = RecordList;
        }


        private void OpenExplorer(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    ProductsPhotoEdit.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                }
                catch
                {
                    MessageBox.Show("Выберите файл формата", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }


        private void EditItem_Loaded(object sender, RoutedEventArgs e)
        {
            artistInputEdit.Text = currentRecord.ARTIST_NAME;
            albumInputEdit.Text = currentRecord.ALBUM_NAME;
            costInputEdit.Text = Convert.ToString(currentRecord.COST);
            yearInputEdit.Text = Convert.ToString(currentRecord.YEAR);
            albumInputEdit.Text = currentRecord.ALBUM_NAME;
            ProductsPhotoEdit.Source = null;
            amountInputEdit.Text = Convert.ToString(currentRecord.AMOUNT);
            descriptionInputEdit.Text = Convert.ToString(currentRecord.DESCRIPTION);

            if (currentRecord.STATUS == "M ")
                comboboxInputEdit.SelectedIndex = 0;
            if (currentRecord.STATUS == "EX ")
                comboboxInputEdit.SelectedIndex = 1;
            if (currentRecord.STATUS == "VG ")
                comboboxInputEdit.SelectedIndex = 2;
            if (currentRecord.STATUS == "G ")
                comboboxInputEdit.SelectedIndex = 3;
            if (currentRecord.STATUS == "F ")
                comboboxInputEdit.SelectedIndex = 4;
            if (currentRecord.STATUS == "B ")
                comboboxInputEdit.SelectedIndex = 5;


            foreach(var song in currentRecord.SongsA)
            {
                songsAInputEdit.Text += song + ';';
            }

            foreach (var song in currentRecord.SongsB)
            {
                songsBInputEdit.Text += song + ';';
            }

            foreach (var genre in currentRecord.Genres)
            {
                genresInputEdit.Text += genre + ';';
            }


           


            calendarEdit.SelectedDate = currentRecord.DATE_OF_DELIV_TO_WAREHOUSE;

           
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendarEdit.SelectedDate;

            //MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
        }

        private void SubmitEditPage_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("bruh");

            float f;
            int i;
            //var exp = new Regex(@"\d{12}");

            string newChangedCostInputEdit;

            if (costInputEdit.Text.Contains("."))
            {
                newChangedCostInputEdit = costInputEdit.Text.Replace('.', ',');
            }
            else
            {
                newChangedCostInputEdit = costInputEdit.Text;
            }



            if (!float.TryParse(newChangedCostInputEdit, out f))
            {
                newChangedCostInputEdit = "";
                MessageBox.Show("Please enter a valid Cost");
            }
            else if (float.Parse(newChangedCostInputEdit) < 5.0 || float.Parse(newChangedCostInputEdit) > 100.0)
            {
                newChangedCostInputEdit = "";
                MessageBox.Show("Please enter Cost between 5 and 100");
            }



            if (!int.TryParse(yearInputEdit.Text, out i))
            {
                yearInputEdit.Text = "";
                MessageBox.Show("Please enter a valid release year");
            }
            else if (Convert.ToInt32(yearInputEdit.Text) <= 1917 || Convert.ToInt32(yearInputEdit.Text) > 2023)
            {
                yearInputEdit.Text = "";
                MessageBox.Show("Please enter release year between 1917 and 2023");
            }





            if (!int.TryParse(amountInputEdit.Text, out i))
            {
                amountInputEdit.Text = "";
                MessageBox.Show("Please enter a valid amount of records");
            }
            else if (Convert.ToInt32(amountInputEdit.Text) < 1 || Convert.ToInt32(amountInputEdit.Text) > 1000)
            {
                amountInputEdit.Text = "";
                MessageBox.Show("Please enter amount fo records between 1 and 1000");
            }





            if (ProductsPhotoEdit.Source == null)
            {
                MessageBox.Show("Enter a path image for the record!");
            }


            //if (titleInput.Text == "")
            //{
            //    titleInput.Text = "";
            //    MessageBox.Show("Please enter a valid Title");
            //}

            //if (songsInput.Text == "")
            //{
            //    songsInput.Text = "";
            //    MessageBox.Show("Please enter a valid songs");
            //}




            string alldata;
            //using (var streamReader = new StreamReader("alldata3.json"))
            //{
            //    //TODO: better in async way
            //    alldata = streamReader.ReadToEnd();
            //}
            //dynamic dynJson = JsonConvert.DeserializeObject<BindingList<Record>>(alldata);
            //foreach (var item in dynJson)
            //{
            //    if (articleInput.Text == "")
            //    {
            //        MessageBox.Show("Введите корректный артикул. Пример, 012345678910");
            //    }
            //    else if (item.Article == Convert.ToUInt64(articleInput.Text))
            //    {
            //        articleInput.Text = "";
            //        MessageBox.Show("Введите уникальный артикул");
            //    }

            //}


            if (artistInputEdit.Text != "" && albumInputEdit.Text != "" && costInputEdit.Text != "" && yearInputEdit.Text != "" &&
                ProductsPhotoEdit.Source != null && songsAInputEdit.Text != "" && songsBInputEdit.Text != "" && descriptionInputEdit.Text != "" && calendarEdit.SelectedDate != null &&
                amountInputEdit.Text != "" && genresInputEdit.Text != "")
            {
                MessageBox.Show("It's allright");

                using (Entities1 ent = new Entities1())
                {
                    //Обрезать строку до пробела
                    string str = Convert.ToString(comboboxInputEdit.Text);
                    String word = str.Substring(0, str.IndexOf(' '));

                    //MessageBox.Show(calendar2.SelectedDate.ToString());
                    //string oldDate = calendar2.SelectedDate.ToString();
                    //string day = oldDate.Substring(0, 2);
                    //MessageBox.Show(day);
                    //string month = oldDate.Substring(3, 2);
                    //MessageBox.Show(month);
                    //string year = oldDate.Substring(6, 4);
                    //MessageBox.Show(year);
                    //string newDate = year + '.' + month + '.' + day + " 00:00:00";
                    //MessageBox.Show(newDate);
                    string strUpd = Convert.ToString(comboboxInputEdit.Text);
                    String wordUpd = strUpd.Substring(0, strUpd.IndexOf(' '));
                    wordUpd = wordUpd.TrimEnd(' ');
                    ent.UPDATE_RECORD(currentRecord.RECORD_ID, Convert.ToInt32(yearInputEdit.Text), decimal.Parse(costInputEdit.Text), Convert.ToInt32(amountInputEdit.Text), descriptionInputEdit.Text, artistInputEdit.Text, albumInputEdit.Text, Convert.ToString(ProductsPhotoEdit.Source), wordUpd, calendarEdit.SelectedDate);

                    //ent.Database.ExecuteSqlCommand("BEGIN ADD_NEW_RECORD(:p_year, :p_cost, :p_amount, :p_supplier_id, :p_description, :p_artist_name, :p_album_name, :p_picture, :p_status, :p_date); END;",
                    //    new OracleParameter("p_year", int.Parse(yearInputEdit.Text)),
                    //    new OracleParameter("p_cost", float.Parse(newChangedCostInputEdit)),
                    //    new OracleParameter("p_amount", int.Parse(amountInputEdit.Text)),
                    //    new OracleParameter("p_supplier_id", Global.USER_ID),
                    //    new OracleParameter("p_description", descriptionInputEdit.Text),
                    //    new OracleParameter("p_artist_name", artistInputEdit.Text),
                    //    new OracleParameter("p_album_name", albumInputEdit.Text),
                    //    new OracleParameter("p_picture", Convert.ToString(ProductsPhotoEdit.Source)),
                    //    new OracleParameter("p_status", word),
                    //    new OracleParameter("p_date", calendarEdit.SelectedDate)
                    //    );

                    string songsA = songsAInputEdit.Text;
                    ent.UPDATE_SONGS(currentRecord.RECORD_ID, songsA, artistInputEdit.Text, albumInputEdit.Text, "A");

                    //ent.Database.ExecuteSqlCommand("BEGIN INSERT_SONGS(:p_songs, :p_artist_name, :p_album_name, :p_side); END;",
                    //    new OracleParameter("p_songs", songsA),
                    //    new OracleParameter("p_artist_name", artistInputEdit.Text),
                    //    new OracleParameter("p_album_name", albumInputEdit.Text),
                    //    new OracleParameter("p_side", "A"));

                    string songsB = songsBInputEdit.Text;
                    ent.UPDATE_SONGS(currentRecord.RECORD_ID, songsB, artistInputEdit.Text, albumInputEdit.Text, "B");
                    //ent.Database.ExecuteSqlCommand("BEGIN INSERT_SONGS(:p_songs, :p_artist_name, :p_album_name, :p_side); END;",
                    //    new OracleParameter("p_songs", songsB),
                    //    new OracleParameter("p_artist_name", artistInputEdit.Text),
                    //    new OracleParameter("p_album_name", albumInputEdit.Text),
                    //    new OracleParameter("p_side", "B"));


                    string genres = genresInputEdit.Text;
                    ent.UPDATE_GENRES(currentRecord.RECORD_ID, genres);

                    //ent.Database.ExecuteSqlCommand("BEGIN INSERT_GENRES(:p_genres); END;",
                    //    new OracleParameter("p_genres", genres));


                }
                //    using (Entities9 ent = new Entities9())
                //{
                //    var picture = ProductsPhoto.Source != null ? ProductsPhoto.Source.ToString() : null; // проверяем, что картинка не равна null
                //    ent.ADD_NEW_RECORD(int.Parse(yearInputAdd.Text), 
                //        decimal.Parse(costInputAdd.Text), 
                //        int.Parse(amountInputAdd.Text), 
                //        descriptionInputAdd.Text, 
                //        artistInputAdd.Text, 
                //        albumInputAdd.Text, 
                //        picture, 
                //        comboboxInput.Text, 
                //        calendar2.SelectedDate
                //        ); 
                //    ent.INSERT_SONGS((string)songsAInputAdd.Text, artistInputAdd.Text, albumInputAdd.Text, "A"); 
                //    ent.INSERT_SONGS((string)songsBInputAdd.Text, artistInputAdd.Text, albumInputAdd.Text, "B"); 
                //}



                //using (OracleCommand command = connection.CreateCommand())
                //{
                //    command.CommandText = "INSERT_SONGS";
                //    command.CommandType = CommandType.StoredProcedure;
                //    command.Parameters.Add("p_songs", OracleDbType.Varchar2).Value = songs;
                //    command.ExecuteNonQuery();
                //}

                //newRecord.Title = titleInput.Text;
                //newRecord.Article = Convert.ToUInt64(articleInput.Text);
                //newRecord.Year = yearInput.Text;
                //newRecord.Songs = songsInput.Text;
                //newRecord.Cost = Convert.ToInt32(costInput.Text);
                //newRecord.imgPath = ProductsPhoto.Source;


                //ComboBoxItem typeItem = (ComboBoxItem)comboboxInput.SelectedItem;
                //string value = typeItem.Content.ToString();
                //newRecord.Genre = value;



                //newRecordList.Add(newRecord);


                //MainWindow window = new MainWindow();
                ////window.AddItemToList();

                //try
                //{

                //    window.AutoList = window._fileOIService.LoadDate();

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show($"Что-то не так с загрузкой данных из файла. Ошибка: {ex}");
                //    Close();
                //}


                //window.AutoList.Add(newAuto);
                //MessageBox.Show("Item has been added!");



                //try
                //{
                //    window._fileOIService.SaveData(window.AutoList);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");

                //}



                //window.Autos.ItemsSource = window.AutoList;

                //titleInput.Text = "";
                //powerInput.Text = "";
                //imgInput.Text = "";
            }




        }


        //public static Record ShowNewAuto()
        //{
        //    return newRecord;
        //}

    }

}
