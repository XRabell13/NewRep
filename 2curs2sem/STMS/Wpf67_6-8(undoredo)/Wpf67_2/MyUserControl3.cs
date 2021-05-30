using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf67
{
    class MyUserControl3 : FrameworkElement
    {
        public static DependencyProperty LengthDataProperty;
        public static DependencyProperty TextDataProperty;

        static MyUserControl3()
        {
            var metadata = new FrameworkPropertyMetadata
            {
                CoerceValueCallback = new CoerceValueCallback(LengthDataCoercer)
            };
            LengthDataProperty = DependencyProperty.Register("LengthData",
                                                       typeof(int),
                                                       typeof(MyUserControl3),
                                                       metadata,
                                                       new ValidateValueCallback(LengthDataValidator));
            TextDataProperty = DependencyProperty.Register("TextData",
                                                    typeof(string),
                                                    typeof(MyUserControl3));
        }

        public int LengthData
        {
            get => (int)GetValue(LengthDataProperty);
            set => SetValue(LengthDataProperty, value);
        }
        public string TextData
        {
            get => (string)GetValue(TextDataProperty);
            set => SetValue(TextDataProperty, value);
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
            else return -1;
        }
    }
}
