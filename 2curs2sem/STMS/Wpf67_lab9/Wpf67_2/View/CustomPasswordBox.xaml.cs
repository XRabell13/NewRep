using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
    /// Логика взаимодействия для CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {
        public CustomPasswordBox()
        {
            InitializeComponent();

            PBox.PasswordChanged += (sender, args) => {
                Password = ((PasswordBox)sender).Password;
            };
        }

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password", typeof(String), typeof(CustomPasswordBox), new PropertyMetadata(default(String)));

        public String Password
        {
            get => (String)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(StreamGeometry), typeof(CustomPasswordBox), new PropertyMetadata(default(StreamGeometry)));

        public StreamGeometry Icon
        {
            get => (StreamGeometry)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
    }
}
