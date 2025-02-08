using System;
using System.Windows;
using Lab45.Models;
using System.ComponentModel;
using Lab45.Services;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Lab45
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        BindingList<Auto> newAutoList = new BindingList<Auto>();
        Auto newAuto = new Auto();
        
        OpenFileDialog openFileDialog = new OpenFileDialog();
        //MainWindow window = new MainWindow();
        //private BindingList<Auto> AutoList;
        //private FileIOService _fileOIService;
        private readonly string PathForDate = $"{Environment.CurrentDirectory}\\alldata3.json";
        public AddItem(BindingList<Auto> AutoList)
        {
            InitializeComponent();
            openFileDialog.Filter = "Фотографии|*.jpg;*.png;*.jpeg;";

            newAutoList = AutoList;
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
            int i;
            if (!int.TryParse(powerInput.Text, out i))
            {
                powerInput.Text = "";
                MessageBox.Show("Plaese enter a valid Cost");
            }
            else if (Convert.ToInt32(powerInput.Text) <= 499 || Convert.ToInt32(powerInput.Text) > 10000000)
            {
                powerInput.Text = "";
                MessageBox.Show("Plaese enter Cost between 500 and 10 000 000");
            }
            try
            {

                if (ProductsPhoto.Source == null || !ProductsPhoto.Source.ToString().Contains("/Assets/auto"))
                {
                    MessageBox.Show("Please enter valid image for the car! Ex. /Assets/autox.jpg where x is number between 1 and 7");
                }
            }
            catch
            {
                MessageBox.Show("Enter valid image folder");
            }
            if (titleInput.Text == "")
            {
                titleInput.Text = "";
                MessageBox.Show("Plaese enter a valid Title");
            }
            if (titleInput.Text != "" && powerInput.Text != "" && ProductsPhoto.Source != null && ProductsPhoto.Source.ToString().Contains("/Assets/auto"))
            {
                
                newAuto.Title = titleInput.Text;
                newAuto.Cost = Convert.ToInt32(powerInput.Text);
                newAuto.imgPath = ProductsPhoto.Source;
                //newAuto.ImgPath = "." + ProductsPhoto.Source.ToString().Remove(0, 74);

                ComboBoxItem typeItem = (ComboBoxItem)comboboxInput.SelectedItem;
                string value = typeItem.Content.ToString();
                newAuto.Bodytype = value;

                if ((bool)radiobtn1.IsChecked)
                    newAuto.Rating = "1";
                if ((bool)radiobtn2.IsChecked)
                    newAuto.Rating = "2";
                if ((bool)radiobtn3.IsChecked)
                    newAuto.Rating = "3";
                if ((bool)radiobtn4.IsChecked)
                    newAuto.Rating = "4";
                if ((bool)radiobtn5.IsChecked)
                    newAuto.Rating = "5";

                newAutoList.Add(newAuto);


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
