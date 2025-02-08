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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding binding = new CommandBinding(Commands.Visible);
            binding.Executed += CommandBinding_Executed;

            this.CommandBindings.Add(binding);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (stackHide.Visibility == Visibility.Collapsed)
                stackHide.Visibility = Visibility.Visible;
            else
                stackHide.Visibility = Visibility.Collapsed;
        }


        //private void Button_MouseDown(object sender, RoutedEventArgs e)
        //{
        //    bubbleTextBlock.Text += "sender: " + sender.ToString() + "\n";
        //    bubbleTextBlock.Text += "source: " + e.Source.ToString() + "\n";
        //}

        //private void Button_PreviewMouseDown(object sender, RoutedEventArgs e)
        //{
        //    tunnelingTextBlock.Text += "sender: " + sender.ToString() + "\n";
        //    tunnelingTextBlock.Text += "source: " + e.Source.ToString() + "\n";
        //}


        //private void Button_MouseDownDirect(object sender, RoutedEventArgs e)
        //{
        //    directTextBlock.Text += "sender: " + sender.ToString() + "\n";
        //    directTextBlock.Text += "source: " + e.Source.ToString() + "\n";
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text = "Сработало событие Button Click";
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            txt2.Text = "Событие Click поднялось к Stack Panel";
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            txt3.Text = "Событие Click поднялось к  Grid";
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock1.Text = textBlock1.Text + "Событие отработало на элементе: " + sender.ToString() + "\n";
            textBlock1.Text = textBlock1.Text + "Элемент вызвавший событие: " + e.Source.ToString() + "\n\n";
        }
    }
}
