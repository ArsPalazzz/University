using System;
using System.Windows;
using CourseProject.Vinyl;
using System.ComponentModel;
//using CourseProject.Services;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using System.Data;

using System.Text.RegularExpressions;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        BindingList<Record> newRecordList = new BindingList<Record>();
        Record newRecord = new Record();

        OpenFileDialog openFileDialog = new OpenFileDialog();
        //MainWindow window = new MainWindow();
        //private BindingList<Auto> AutoList;
        //private FileIOService _fileOIService;
        private readonly string PathForDate = $"{Environment.CurrentDirectory}\\alldata3.json";
        public AddItem()
        {
            InitializeComponent();
            //openFileDialog.Filter = "Фотографии|*.jpg;*.png;*.jpeg;";

            //newRecordList = RecordList;
        }


        private void OpenExplorer(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    ProductsPhoto.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                }
                catch
                {
                    MessageBox.Show("Выберите файл формата", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }


        private void AddItem_Loaded(object sender, RoutedEventArgs e)
        {
            //newAuto.Title = "";
            //newAuto.Cost = Convert.ToInt32(0);
            //newAuto.ImgPath = "";
            //newAuto.imgPath = null;
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar2.SelectedDate;

            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
        }

        private void SubmitAddPage_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("bruh");

            float f;
            int i;
            //var exp = new Regex(@"\d{12}");

            string newChangedCostInputAdd;

            if (costInputAdd.Text.Contains(".")) {
                newChangedCostInputAdd = costInputAdd.Text.Replace('.', ',');
            }
            else
            {
                newChangedCostInputAdd = costInputAdd.Text;
            }

            

            if (!float.TryParse(newChangedCostInputAdd, out f))
            {
                newChangedCostInputAdd = "";
                MessageBox.Show("Please enter a valid Cost");
            }
            else if (float.Parse(newChangedCostInputAdd) < 5.0 || float.Parse(newChangedCostInputAdd) > 100.0)
            {
                newChangedCostInputAdd = "";
                MessageBox.Show("Please enter Cost between 5 and 100");
            }



            if (!int.TryParse(yearInputAdd.Text, out i))
            {
                yearInputAdd.Text = "";
                MessageBox.Show("Please enter a valid release year");
            }
            else if (Convert.ToInt32(yearInputAdd.Text) <= 1917 || Convert.ToInt32(yearInputAdd.Text) > 2023)
            {
                yearInputAdd.Text = "";
                MessageBox.Show("Please enter release year between 1917 and 2023");
            }



           

            if (!int.TryParse(amountInputAdd.Text, out i))
            {
                amountInputAdd.Text = "";
                MessageBox.Show("Please enter a valid amount of records");
            }
            else if (Convert.ToInt32(amountInputAdd.Text) < 1 || Convert.ToInt32(amountInputAdd.Text) > 1000)
            {
                amountInputAdd.Text = "";
                MessageBox.Show("Please enter amount fo records between 1 and 1000");
            }



            

            if (ProductsPhoto.Source == null)
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


            if (artistInputAdd.Text != "" && albumInputAdd.Text != "" && costInputAdd.Text != "" && yearInputAdd.Text != "" &&
                ProductsPhoto.Source != null && songsAInputAdd.Text != "" && songsBInputAdd.Text != "" && descriptionInputAdd.Text != "" && calendar2.SelectedDate != null &&
                amountInputAdd.Text != "" && genresInputAdd.Text != "")
            {
                MessageBox.Show("It's allright");

                using (Entities1 ent = new Entities1())
                {
                    //Обрезать строку до пробела
                    string str = Convert.ToString(comboboxInput.Text);
                    String word = str.Substring(0, str.IndexOf(' '));
                    word = word.TrimEnd(' ');
                   
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

               

                    ent.Database.ExecuteSqlCommand("BEGIN ADD_NEW_RECORD(:p_year, :p_cost, :p_amount, :p_supplier_id, :p_description, :p_artist_name, :p_album_name, :p_picture, :p_status, :p_date); END;",
                        new OracleParameter("p_year", int.Parse(yearInputAdd.Text)),
                        new OracleParameter("p_cost", float.Parse(newChangedCostInputAdd)),
                        new OracleParameter("p_amount", int.Parse(amountInputAdd.Text)),
                        new OracleParameter("p_supplier_id", Global.USER_ID),
                        new OracleParameter("p_description", descriptionInputAdd.Text),
                        new OracleParameter("p_artist_name", artistInputAdd.Text),
                        new OracleParameter("p_album_name", albumInputAdd.Text),
                        new OracleParameter("p_picture", Convert.ToString(ProductsPhoto.Source)),
                        new OracleParameter("p_status", word),
                        new OracleParameter("p_date", calendar2.SelectedDate)
                        );


                   
                    string songsA = songsAInputAdd.Text;
                    ent.Database.ExecuteSqlCommand("BEGIN INSERT_SONGS(:p_songs, :p_artist_name, :p_album_name, :p_side); END;", 
                        new OracleParameter("p_songs", songsA), 
                        new OracleParameter("p_artist_name", artistInputAdd.Text), 
                        new OracleParameter("p_album_name", albumInputAdd.Text), 
                        new OracleParameter("p_side", "A"));


                   
                    string songsB = songsBInputAdd.Text;
                    ent.Database.ExecuteSqlCommand("BEGIN INSERT_SONGS(:p_songs, :p_artist_name, :p_album_name, :p_side); END;", 
                        new OracleParameter("p_songs", songsB), 
                        new OracleParameter("p_artist_name", artistInputAdd.Text), 
                        new OracleParameter("p_album_name", albumInputAdd.Text), 
                        new OracleParameter("p_side", "B"));



                  
                    string genres = genresInputAdd.Text;
                    ent.Database.ExecuteSqlCommand("BEGIN INSERT_GENRES(:p_genres); END;",
                        new OracleParameter("p_genres", genres));


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


      
    

