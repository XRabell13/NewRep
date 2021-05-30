using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wpf67
{
   class LenghtText: FrameworkElement
    {
        public static DependencyProperty LengthDataProperty;

        static LenghtText()
        {
            var metadata = new FrameworkPropertyMetadata
            {
                CoerceValueCallback = new CoerceValueCallback(LengthDataCoercer)
            };
            LengthDataProperty = DependencyProperty.Register("LengthData",
                                                       typeof(int),
                                                       typeof(LenghtText),
                                                       metadata,
                                                       new ValidateValueCallback(LengthDataValidator));
        }

        public int LengthData
        {
            get => (int)GetValue(LengthDataProperty);
            set => SetValue(LengthDataProperty, value);
        }

        private static bool LengthDataValidator(object value)
        {
            var currentValue = (int)value;
            return currentValue < 30;
        }

        private static object LengthDataCoercer(DependencyObject d, object value)
        {
            var currentValue = (int)value;
            if (currentValue > 0 && currentValue < 30) return currentValue;
            else return 0;
        }
    }
}
