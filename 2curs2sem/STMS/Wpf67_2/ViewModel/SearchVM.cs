using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf67.Command;
using Wpf67.DataBase;
using Wpf67.Model;


namespace Wpf67.ViewModel
{
    class SearchVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public string str { get; set; } = "Hello tlen";

        public DateTime Now { get; set; } = DateTime.Today;

        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(7);

        /*
          dpDate.DisplayDateStart = dpDate.SelectedDate = DateTime.Today;
            dpDate.DisplayDateEnd = DateTime.Today.AddDays(7);
         */

        private IMMCodeBehind mainWindow;
        private City _selectCityFrom;
        private City _selectCityIn;
        public City SelectCityFrom { get=>_selectCityFrom; set { _selectCityFrom = value; } }
        public City SelectCityIn { get=>_selectCityIn; set { _selectCityIn = value; } }

        private ObservableCollection<City> _cities;
        public ObservableCollection<City> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged(nameof(City));
            }
        }

        //  List<City> cities = new List<City>();
        DataBaseLoad db = new DataBaseLoad();

        public SearchVM(IMMCodeBehind win)
        {
            if (win == null) throw new ArgumentNullException(nameof(win));
            mainWindow = win;
            Cities = db.GetCities();
        }
        public SearchVM()
        {
            // _cities = LoadAllCities();
            Cities = db.GetCities();
        }

        public ObservableCollection<City> LoadAllCities()
        {
            _cities = db.GetCities();
            var items = from u in _cities
                        orderby u.name_city
                        select u;
            return (ObservableCollection<City>)items;
        }

       
        private MyCommand loadSearch;
        public MyCommand LoadSearchPage
        {
            get
            {
                return loadSearch = loadSearch ??
                  new MyCommand(ShowSearchPage, CanLoadSearchPage);
            }
        }
        private bool CanLoadSearchPage()
        {
            return true;
        }
        private void ShowSearchPage()
        {
            mainWindow.LoadView(ViewType.Search);
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
