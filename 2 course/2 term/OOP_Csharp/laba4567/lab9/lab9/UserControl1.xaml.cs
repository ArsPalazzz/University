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

namespace lab9
{
    public partial class UserControl1 : UserControl
    {
        public int CurrentNumber
        {
            get { return (int)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register("CurrentNumber", typeof(int), typeof(UserControl1), 
                                        new PropertyMetadata(10, new PropertyChangedCallback(CurrentNumberChanged)), //конечной целью внутри метода CurrentNumberChanged() является изменение свойства Content объекта Label на новое значение, присвоенное свойством CurrentNumber. 
                                        new ValidateValueCallback(ValidateCurrentNumber)); //ValidateValueCallback — это делегат, который может только указывать на методы, возвращающие bool и принимающие object в качестве единственного аргумента.

        public static bool ValidateCurrentNumber(object value)
        {
            if (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 500)
                return true;
            else
                return false;
        }
        private static void CurrentNumberChanged(DependencyObject depObj,
            DependencyPropertyChangedEventArgs args)
        {
            UserControl1 s = (UserControl1)depObj;
            Label theLabel = s.numberDisplay;
            theLabel.Content = args.NewValue.ToString();
        }
        public UserControl1()
        {
            InitializeComponent();
        }
    }
}
