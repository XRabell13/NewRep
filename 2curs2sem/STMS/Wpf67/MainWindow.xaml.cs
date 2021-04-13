using System;
using System.Collections.Generic;
using System.IO;
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
using Wpf67.View;

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            this.OutWin.Content = reg;

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Search reg = new Search();
            this.OutWin.Content = reg;

        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Settings reg = new Settings();
            this.OutWin.Content = reg;

        }
    }
}
