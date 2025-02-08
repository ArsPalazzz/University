using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Linq;
using System.Windows.Input;
using Lab45.Vinyl;
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

        public BindingList<Record> RecordsList = new BindingList<Record>();

        Cursor Diamond, Latte;
        public MainWindow()
        {
            InitializeComponent();
            string cursorDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\MyCursors";
            Diamond = new Cursor($"{cursorDir}\\diamond.cur");
            Latte = new Cursor($"{cursorDir}\\cursor2.cur");
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileOIService = new FileIOService(PathForDate);
            
            try
            {

                RecordsList = _fileOIService.LoadDate();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то не так с загрузкой данных из файла. Ошибка: {ex}");
                Close();
            }

            Records.ItemsSource = RecordsList;
           
            RecordsList.ListChanged += RecordsList_ListChanged1;


        }

        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (SearchBox.Text != string.Empty)
            {
                var SearchResult = RecordsList.Where(t => t.Title.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
                BindingList<Record> List = new BindingList<Record>(SearchResult);
                Records.ItemsSource = SearchResult;
                //Database.ItemsSource = SearchResult;
            }
            else
            {
                Records.ItemsSource = RecordsList;
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

        private void RecordsList_ListChanged1(object sender, ListChangedEventArgs e)
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
                this.Cursor = Diamond;
            }
            else if (sender == btnPixel)
            {
                this.Cursor = Latte;
            }
        }

        public void AddItem_func(object sender, RoutedEventArgs e)
        {
            new AddItem(RecordsList).Show();
        }


       

        public void FilterWin_Open(object sender, RoutedEventArgs e)
        {
            new FilterItems(RecordsList, Records).Show();
        }
           




            private void Refresh_Click(object sender, RoutedEventArgs e)
            {

            try
            {
                RecordsList = _fileOIService.LoadDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то не так с загрузкой данных из файла. Ошибка: {ex}");
                Close();
            }
            Records.ItemsSource = RecordsList;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Image;
            if (button != null)
            {
                var deletedRecord = button.DataContext as Record;

                RecordsList.Remove(deletedRecord);
            }
            else
            {
                return;
            }

            try
            {
                _fileOIService.SaveData(RecordsList);
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
                var editedAuto = button.DataContext as Record;

                new EditItem(editedAuto).Show();

                editedAuto = EditItem.ShowEditedRecord();

            }
            else
            {
                return;
            }

          
            try
            {
                _fileOIService.SaveData(RecordsList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проблема с сохранением данных. Ошибка: {ex}");
                Close();
            }

            Records.ItemsSource = RecordsList;
        }

        

    }
}
