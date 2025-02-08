using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab45
{
    public class WindowCommands
    {
        static WindowCommands()
        {
            EngSelect = new RoutedCommand("EngSelect", typeof(MainWindow));
            RusSelect = new RoutedCommand("RusSelect", typeof(MainWindow));
        }
        public static RoutedCommand EngSelect { get; set; }
        public static RoutedCommand RusSelect { get; set; }

    }
}
