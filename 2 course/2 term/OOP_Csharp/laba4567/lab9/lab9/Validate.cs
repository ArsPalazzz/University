using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab9
{
    public class Validate: DependencyObject
    {
        public static readonly DependencyProperty NumberProperty;

        static Validate()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);

            NumberProperty = DependencyProperty.Register("Number", typeof(int), typeof(Validate), metadata, new ValidateValueCallback(ValidateValue));
        }

        private static object CorrectValue(DependencyObject dependencyObject, object value)
        {
            int currentValue = (int)value;

            if (currentValue > 10000)
                return 10000;
            else
                return currentValue;
        }

        public static bool ValidateValue(object value)
        {
            int currentValue = (int)value;
            if (currentValue >= 0)
                return true;
            return false;
        }

        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
    }
}
