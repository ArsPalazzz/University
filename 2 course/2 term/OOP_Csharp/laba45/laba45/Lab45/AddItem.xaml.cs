using System;
using System.Windows;
using Lab45.Vinyl;
using System.ComponentModel;
using Lab45.Services;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

using System.Text.RegularExpressions;

namespace Lab45
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
        public AddItem(BindingList<Record> RecordList)
        {
            InitializeComponent();
            openFileDialog.Filter = "Фотографии|*.jpg;*.png;*.jpeg;";

            newRecordList = RecordList;
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
        private void Power_TextChanged(object sender, EventArgs e)
        {
            int i, i2;
            var exp = new Regex(@"\d{12}");
            if (!int.TryParse(costInput.Text, out i))
            {
                costInput.Text = "";
                MessageBox.Show("Please enter a valid Cost");
            }
            else if (Convert.ToInt32(costInput.Text) <= 5 || Convert.ToInt32(costInput.Text) > 101)
            {
                costInput.Text = "";
                MessageBox.Show("Please enter Cost between 5 and 100");
            }


            if (!int.TryParse(yearInput.Text, out i2))
            {
                yearInput.Text = "";
                MessageBox.Show("Please enter a valid release year");
            }
            else if (Convert.ToInt32(yearInput.Text) <= 1917 || Convert.ToInt32(yearInput.Text) > 2023)
            {
                yearInput.Text = "";
                MessageBox.Show("Please enter Cost between 1917 and 2023");
            }


            try
            {

                if (ProductsPhoto.Source == null || !ProductsPhoto.Source.ToString().Contains("/Assets/record"))
                {
                    MessageBox.Show("Please enter valid image for the record! Ex. /Assets/recordx.jpg");
                }
            }
            catch
            {
                MessageBox.Show("Enter valid image folder");
            }
            if (titleInput.Text == "")
            {
                titleInput.Text = "";
                MessageBox.Show("Please enter a valid Title");
            }

            if (songsInput.Text == "")
            {
                songsInput.Text = "";
                MessageBox.Show("Please enter a valid songs");
            }


            if (!(exp.IsMatch(articleInput.Text)))
                {
                    articleInput.Text = "";
                    MessageBox.Show("Введите корректный артикул. Пример, 012345678910");

                }

            string alldata;
            using (var streamReader = new StreamReader("alldata3.json"))
            {
                //TODO: better in async way
                alldata = streamReader.ReadToEnd();
            } 
            dynamic dynJson = JsonConvert.DeserializeObject<BindingList<Record>>(alldata);
            foreach (var item in dynJson)
            {
                if (articleInput.Text == "")
                {
                    MessageBox.Show("Введите корректный артикул. Пример, 012345678910");
                }
                else if (item.Article == Convert.ToUInt64(articleInput.Text))
                {
                    articleInput.Text = "";
                    MessageBox.Show("Введите уникальный артикул");
                }
               
            }


            if (titleInput.Text != "" && yearInput.Text != "" && songsInput.Text != "" && articleInput.Text != "" && costInput.Text != "" && ProductsPhoto.Source != null && ProductsPhoto.Source.ToString().Contains("/Assets/record"))
            {
                
                newRecord.Title = titleInput.Text;
                newRecord.Article = Convert.ToUInt64(articleInput.Text);
                newRecord.Year = yearInput.Text;
                newRecord.Songs = songsInput.Text;
                newRecord.Cost = Convert.ToInt32(costInput.Text);
                newRecord.imgPath = ProductsPhoto.Source;
                

                ComboBoxItem typeItem = (ComboBoxItem)comboboxInput.SelectedItem;
                string value = typeItem.Content.ToString();
                newRecord.Genre = value;

                

                newRecordList.Add(newRecord);


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


        //public static Auto ShowNewAuto()
        //{
        //    return newAuto;
        //}
    }
}
