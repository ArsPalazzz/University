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
    
    public partial class OrdersAdminView : UserControl
    {
        //public OrdersAdminVM a = new OrdersAdminVM();
        public OrdersAdminVM ViewModel { get; private set; }


        public OrdersAdminView()
        {
            InitializeComponent();
            //DataContext = a;

            // Создаем экземпляр UsersAdminVM
            ViewModel = new OrdersAdminVM();

            // Передаем usersGrid в UsersAdminVM
            ViewModel.OrdersGrid = ordersGrid;

            // Устанавливаем DataContext
            DataContext = ViewModel;
        }
    }
}
