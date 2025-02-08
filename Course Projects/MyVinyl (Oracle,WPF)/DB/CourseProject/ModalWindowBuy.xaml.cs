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
using System.Windows.Shapes;

namespace CourseProject
{
    /// <summary>
    /// Логика взаимодействия для ModalWindowBuy.xaml
    /// </summary>
    public partial class ModalWindowBuy : Window
    {
        public static RecordDisplay currentRecord;

        public ModalWindowBuy(RecordDisplay chosenRecord)
        {
            currentRecord = chosenRecord;
            InitializeComponent();
        }

        public void ModalWindowBuy_Loaded(object sender, RoutedEventArgs e)
        {
            amountModalTextBlock.Text = currentRecord.AMOUNT.ToString();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
