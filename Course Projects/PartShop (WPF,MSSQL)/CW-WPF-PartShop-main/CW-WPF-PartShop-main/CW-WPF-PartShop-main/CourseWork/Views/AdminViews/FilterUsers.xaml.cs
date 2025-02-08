using CourseWork.Models;
using CourseWork.Services;
using CourseWork.ViewModels.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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

namespace CourseWork.Views.AdminViews
{
    /// <summary>
    /// Логика взаимодействия для FilterUsers.xaml
    /// </summary>
    public partial class FilterUsers : Window, INotifyPropertyChanged
    {
        // Список пользователей из вашего основного окна
        private ObservableCollection<User> mainUsers;
        private DataGrid myDataGrid;

        int fromId = 1;
        int toId = 5;

        // Список, который будет использоваться для отображения в DataGrid
        // Список, который будет использоваться для отображения в DataGrid
        private ObservableCollection<User> filteredUsers;

        public ObservableCollection<User> FilteredUsers
        {
            get { return filteredUsers; }
            set
            {
                if (filteredUsers != value)
                {
                    filteredUsers = value;
                    OnPropertyChanged(nameof(FilteredUsers));
                }
            }
        }

        public FilterUsers(ObservableCollection<User> myUsers)
        {
            InitializeComponent();
            mainUsers = myUsers;
            FilteredUsers = new ObservableCollection<User>(mainUsers);
            //myDataGrid = dataGrid;
            //dataGrid.ItemsSource = FilteredUsers;
        }

        private void FilterUsers_Click(object sender, RoutedEventArgs e)
        {
            // Логика фильтрации
            // ...

            // Применение фильтрации к FilteredUsers
            // Пример: Фильтрация по Id
            FilteredUsers = new ObservableCollection<User>(mainUsers.Where(user => user.Id >= fromId && user.Id <= toId));
            myDataGrid.ItemsSource = FilteredUsers;

            // Оповещение об изменениях в привязанных данных
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void ResetFilterUsers_Click(object sender, EventArgs e)
        {

        }
    }
}
