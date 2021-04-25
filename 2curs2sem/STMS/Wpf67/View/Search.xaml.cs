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
using Wpf67.ViewModel;

namespace Wpf67.View
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        SearchVM vm = new SearchVM();
        public Search()
        {
            InitializeComponent();
            dpDate.DisplayDateStart = dpDate.SelectedDate = DateTime.Today;
            dpDate.DisplayDateEnd = DateTime.Today.AddDays(14);
            LoadCities();
        }

        private void LoadCities()
        {
            ((ComboBox)FindName("cb_begin_city")).ItemsSource = ((ComboBox)FindName("cb_end_city")).ItemsSource = vm.LoadAllCities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
