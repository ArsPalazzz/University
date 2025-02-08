using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Linq;
using System.Windows.Input;
using Lab45.Models;
using Lab45.Services;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;

namespace Lab45
{
    public partial class MainWindow : Window
    {
        
        private static string PathForDate = $"{Environment.CurrentDirectory}\\alldata3.json";
        public FileIOService _fileOIService = new FileIOService(PathForDate);

        public BindingList<Auto> AutoList = new BindingList<Auto>();

        Cursor Geom, Pix;
        public MainWindow()
        {
            InitializeComponent();
            string cursorDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\MyCursors";
            Geom = new Cursor($"{cursorDir}\\cursor_1.cur");
            Pix = new Cursor($"{cursorDir}\\cursor_2.ani");
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileOIService = new FileIOService(PathForDate);
            
            try
            {
                
                AutoList = _fileOIService.LoadDate();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то не так с загрузкой данных из файла. Ошибка: {ex}");
                Close();
            }

            Autos.ItemsSource = AutoList;
            //Database.ItemsSource = AutoList;
            AutoList.ListChanged += AutoList_ListChanged1;


        }

        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (SearchBox.Text != string.Empty)
            {
                var SearchResult = AutoList.Where(t => t.Title.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
                BindingList<Auto> List = new BindingList<Auto>(SearchResult);
                Autos.ItemsSource = SearchResult;
                //Database.ItemsSource = SearchResult;
            }
            else
            {
                Autos.ItemsSource = AutoList;
                //Database.ItemsSource = AutoList;
            }
        }

        private void Light_Selected(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources/Light_mode.xaml", UriKind.Relative);                           // определяем путь к файлу ресурсов
            ResourceDictionary resourseDict = Application.LoadComponent(uri) as ResourceDictionary;     // загружаем словарь ресурсов
            Application.Current.Resources.Clear();                                                      // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.MergedDictionaries.Add(resourseDict);                         // добавляем загруженный словарь ресурсов
        }

        private void Dark_Selected(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources/Dark_mode.xaml", UriKind.Relative);
            ResourceDictionary resourseDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourseDict);
        }

        private void Orange_Selected(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources/Orange_mode.xaml", UriKind.Relative);
            ResourceDictionary resourseDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourseDict);
        }

        private void AutoList_ListChanged1(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileOIService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");
                    Close();
                }
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void RusLocal_Selected(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources/rusLang.xaml", UriKind.Relative);
            ResourceDictionary resourseDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourseDict);
        }

        private void EngLocal_Selected(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources/engLang.xaml", UriKind.Relative);
            ResourceDictionary resourseDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourseDict);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void btnGeometric_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnGeometric)
            {
                this.Cursor = Geom;
            }
            else if (sender == btnPixel)
            {
                this.Cursor = Pix;
            }
        }

        public void AddItem_func(object sender, RoutedEventArgs e)
        {
            new AddItem(AutoList).Show();
        }


        //public void AddItem_func(object sender, RoutedEventArgs e)
        //{
        //    new AddItem().Show();

        //    Auto newAuto = new Auto();
        //    newAuto = AddItem.ShowNewAuto();
        //    AutoList.Add(newAuto);

        //    try
        //    {
        //        _fileOIService.SaveData(AutoList);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");

        //    }
        //    Autos.ItemsSource = AutoList;

        //}

        public void FilterWin_Open(object sender, RoutedEventArgs e)
        {
            new FilterItems(AutoList, Autos).Show();
        }
            //public void AddItemToList()
            //{
            //    Auto newAuto = AddItem.ShowNewAuto();

            //    AutoList.Add(newAuto);

            //    try
            //    {
            //        _fileOIService.SaveData(AutoList);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");

            //    }
            //}




            private void Refresh_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                AutoList = _fileOIService.LoadDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то не так с загрузкой данных из файла. Ошибка: {ex}");
                Close();
            }
            Autos.ItemsSource = AutoList;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Image;
            if (button != null)
            {
                var deletedAuto = button.DataContext as Auto;

                AutoList.Remove(deletedAuto);
            }
            else
            {
                return;
            }

            try
            {
                _fileOIService.SaveData(AutoList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");
                Close();
            }


        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Image;
            if (button != null)
            {
                var editedAuto = button.DataContext as Auto;

                new EditItem(editedAuto).Show();

                editedAuto = EditItem.ShowEditedAuto();

            }
            else
            {
                return;
            }

          
            try
            {
                _fileOIService.SaveData(AutoList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");
                Close();
            }

            Autos.ItemsSource = AutoList;
        }

        

    }
}
