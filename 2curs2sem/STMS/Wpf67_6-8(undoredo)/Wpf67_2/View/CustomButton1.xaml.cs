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

namespace Wpf67.View
{
    /// <summary>
    /// Логика взаимодействия для CustomButton1.xaml
    /// </summary>
    public partial class CustomButton1 : ContentControl
    {  
        public static readonly RoutedEvent MyEvent;

        public CustomButton1()
        {
            InitializeComponent();

        }
        static CustomButton1()
        {
            MyEvent = EventManager.RegisterRoutedEvent("ClickBubble",
    RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(CustomButton1));
           
        }

        public event RoutedEventHandler ClickBubble
        {
            add { AddHandler(CustomButton1.MyEvent, value);}
            remove { RemoveHandler(CustomButton1.MyEvent, value);}
        }

    }
}
