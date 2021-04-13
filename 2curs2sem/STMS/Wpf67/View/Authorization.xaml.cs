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
using Wpf67.View;

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : UserControl
    {
        public Authorization()
        {
            InitializeComponent();
        }
        public void Click_Author(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            mainWindow.OutWin.Content = reg;
        }
    }
}
