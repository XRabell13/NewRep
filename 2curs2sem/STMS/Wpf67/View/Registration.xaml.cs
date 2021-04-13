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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        string login = null;
        string password1 = null;
        string password2 = null;
        string name = null;
        string telephone = null;
        string email;
        PasswordBox pasBox1;
        PasswordBox pasBox2;

        public Registration()
        {
            InitializeComponent();
            pasBox1 = box_password1;
            pasBox2 = box_password2;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
           Authorization reg = new Authorization();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            mainWindow.OutWin.Content = reg;
        }
    }
}
