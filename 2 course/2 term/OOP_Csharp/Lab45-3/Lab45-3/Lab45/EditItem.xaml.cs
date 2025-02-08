using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab45.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab45.Services;
using Microsoft.Win32;

namespace Lab45
{
    /// <summary>
    /// Логика взаимодействия для EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        public static Auto currentAuto;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public EditItem()
        {
            InitializeComponent();
            openFileDialog.Filter = "Фотографии|*.jpg;*.png;*.jpeg;";
        }

        public EditItem(Auto editedAuto)
        {
            currentAuto = editedAuto;
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
            titleInput.Text = currentAuto.Title;
            powerInput.Text = Convert.ToString(currentAuto.Cost);
            ProductsPhoto.Source = currentAuto.imgPath;

            if (currentAuto.Bodytype == "Sedan" || currentAuto.Bodytype == "Sedan")
                comboboxInput.SelectedIndex = 0;
            if (currentAuto.Bodytype == "Universal" || currentAuto.Bodytype == "Universal")
                comboboxInput.SelectedIndex = 1;
            if (currentAuto.Bodytype == "Convertible" || currentAuto.Bodytype == "Roofless")
                comboboxInput.SelectedIndex = 2;
            if (currentAuto.Bodytype == "Coupe" || currentAuto.Bodytype == "Coupe")
                comboboxInput.SelectedIndex = 3;

            if (currentAuto.Rating == "1")
                radiobtn1.IsChecked = true;
            if (currentAuto.Rating == "2")
                radiobtn2.IsChecked = true;
            if (currentAuto.Rating == "3")
                radiobtn3.IsChecked = true;
            if (currentAuto.Rating == "4")
                radiobtn4.IsChecked = true;
            if (currentAuto.Rating == "5")
                radiobtn5.IsChecked = true;
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
            if (ProductsPhoto.Source.ToString() == "" || !ProductsPhoto.Source.ToString().Contains("/Assets/auto"))
            {
                MessageBox.Show("Plaese enter valid image for the car! Ex. /Assets/autox.jpg where x is number between 1 and 7");
            }

            if (titleInput.Text != "" && powerInput.Text != "" && ProductsPhoto.Source.ToString() != "" || ProductsPhoto.Source.ToString().Contains("/Assets/auto"))
            {
                currentAuto.Title = titleInput.Text;
                try
                {
                    currentAuto.Cost = Convert.ToInt32(powerInput.Text);
                }
                catch (Exception)
                {

                }
               
                currentAuto.imgPath = ProductsPhoto.Source;

                ComboBoxItem typeItem = (ComboBoxItem)comboboxInput.SelectedItem;
                string value = typeItem.Content.ToString();
                currentAuto.Bodytype = value;

                if ((bool)radiobtn1.IsChecked)
                    currentAuto.Rating = "1";
                if ((bool)radiobtn2.IsChecked)
                    currentAuto.Rating = "2";
                if ((bool)radiobtn3.IsChecked)
                    currentAuto.Rating = "3";
                if ((bool)radiobtn4.IsChecked)
                    currentAuto.Rating = "4";
                if ((bool)radiobtn5.IsChecked)
                    currentAuto.Rating = "5";
            }
        }

        public static Auto ShowEditedAuto()
        {
            return currentAuto;
        }
    }
}
