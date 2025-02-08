using CourseWork.Models;
using CourseWork.ViewModels.AdminViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork.Views.AdminViews
{
    /// <summary>
    /// Логика взаимодействия для AdminUsersView.xaml
    /// </summary>
    public partial class UsersAdminView : UserControl
    {


        public UsersAdminVM ViewModel { get; private set; }
        public UsersAdminView()
        {
            InitializeComponent();
            // Создаем экземпляр UsersAdminVM
            ViewModel = new UsersAdminVM();

            // Передаем usersGrid в UsersAdminVM
            ViewModel.UsersGrid = usersGrid;

            // Устанавливаем DataContext
            DataContext = ViewModel;
        }

        private void FindLogin_Change(object sender, RoutedEventArgs e)
        {
            // Получаем текст из TextBox
            string filterText = ((TextBox)sender).Text;

            // Вызываем метод фильтрации в UsersAdminVM, передавая текст фильтрации
            ViewModel.FilterUsers(filterText);
        }


        

    }
}
