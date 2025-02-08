using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class MyMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var discipline = values[0] as DISCIPLINE;
            var student = values[1] as Student;

            return Tuple.Create(discipline, student);
        }



        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
