using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab45.Vinyl;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab45.Services;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

using System.ComponentModel;

namespace Lab45
{
    /// <summary>
    /// Логика взаимодействия для EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        public static Record currentRecord;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public EditItem()
        {
            InitializeComponent();
            openFileDialog.Filter = "Фотографии|*.jpg;*.png;*.jpeg;";
        }

        public EditItem(Record editedRecord)
        {
            currentRecord = editedRecord;
            InitializeComponent();
            openFileDialog.Filter = "Фотографии|*.jpg;*.png;*.jpeg;";
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

        private void EditItem_Loaded(object sender, RoutedEventArgs e)
        {
            
            titleInput.Text = currentRecord.Title;
            articleInput.Text = Convert.ToString(currentRecord.Article);
            costInput.Text = Convert.ToString(currentRecord.Cost);
            ProductsPhoto.Source = currentRecord.imgPath;
            songsInput.Text = currentRecord.Songs;

            if (currentRecord.Songs == "Pop" || currentRecord.Songs == "Pop")
                comboboxInput.SelectedIndex = 0;
            if (currentRecord.Songs == "Rock" || currentRecord.Songs == "Rock")
                comboboxInput.SelectedIndex = 1;
            if (currentRecord.Songs == "Alternative rock" || currentRecord.Songs == "Alternative rock")
                comboboxInput.SelectedIndex = 2;
            if (currentRecord.Songs == "Hip hop" || currentRecord.Songs == "Hip hop")
                comboboxInput.SelectedIndex = 3;
            if (currentRecord.Songs == "Comedy-rock" || currentRecord.Songs == "Comedy-rock")
                comboboxInput.SelectedIndex = 4;
            if (currentRecord.Songs == "Horror-punk" || currentRecord.Songs == "Horror-punk")
                comboboxInput.SelectedIndex = 5;
            if (currentRecord.Songs == "Russian bard" || currentRecord.Songs == "Russian bard")
                comboboxInput.SelectedIndex = 6;

            yearInput.Text = Convert.ToString(currentRecord.Year);
        }

        private void Power_TextChanged(object sender, EventArgs e)
        {
            bool flagArticle = false;
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

            if (!int.TryParse(yearInput.Text, out i))
            {
                yearInput.Text = "";
                MessageBox.Show("Please enter a valid release year");
            }
            else if (Convert.ToInt32(yearInput.Text) <= 1917 || Convert.ToInt32(yearInput.Text) > 2023)
            {
                yearInput.Text = "";
                MessageBox.Show("Please enter release year between 1917 and 2023");
            }

            if (ProductsPhoto.Source.ToString() == "" || !ProductsPhoto.Source.ToString().Contains("/Assets/record"))
            {
                MessageBox.Show("Please enter valid image for the record! Ex. /Assets/recordx.jpg");
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
                flagArticle = true;
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

            if (articleInput.Text != "")
            {
                foreach (var item in dynJson)
                {
                    if (item.Article == Convert.ToUInt64(articleInput.Text))
                    {
                        flagArticle = true;
                        articleInput.Text = Convert.ToString(item.Article);
                        MessageBox.Show("Введите уникальный артикул");
                    }

                }
            }
           


            if (!flagArticle && titleInput.Text != "" && yearInput.Text != "" && songsInput.Text != "" && articleInput.Text != "" && costInput.Text != "" && ProductsPhoto.Source.ToString() != "" || ProductsPhoto.Source.ToString().Contains("/Assets/record"))
            {
                currentRecord.Title = titleInput.Text;
                try
                {
                    currentRecord.Article = Convert.ToUInt64(articleInput.Text);
                    currentRecord.Cost = Convert.ToInt32(costInput.Text);
                }
                catch(Exception ex)
                {

                }
               
                currentRecord.imgPath = ProductsPhoto.Source;
                currentRecord.Songs = songsInput.Text;

                ComboBoxItem typeItem = (ComboBoxItem)comboboxInput.SelectedItem;
                string value = typeItem.Content.ToString();
                currentRecord.Genre = value;

                currentRecord.Year = yearInput.Text;

                
            }
        }

        public static Record ShowEditedRecord()
        {
            return currentRecord;
        }
    }
}
