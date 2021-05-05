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

        //  Visibility _findRoute = Visibility.Visible;
        // public Visibility FindRouteVisibility { get => _findRoute; set { _findRoute = Visibility; OnPropertyChanged();} };
      
        DateTime _dateTime;
        DateTime Date { get => _dateTime; set { _dateTime = value; } }
       

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
           _cities = LoadAllCities();
        }
        public SearchVM()
        {
            _cities = LoadAllCities();
        }

        public ObservableCollection<City> LoadAllCities()
        {
                var items = from u in db.GetCities()
                            orderby u.name_city 
                            select u;
               
            return new ObservableCollection<City>(items);
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


        private MyCommand loadFindRoutes;
        public MyCommand LoadFindRoutes
        {
            get
            {
                return loadFindRoutes = loadFindRoutes ??
                  new MyCommand(ShowFindRoutesPage, CanLoadFindRoutesPagePage);
            }
        }
        private bool CanLoadFindRoutesPagePage()
        {
            return true;
        }
        private void ShowFindRoutesPage()
        {
            try
            {
                if (_selectCityFrom!=null && SelectCityIn!=null && _dateTime != null)
                    mainWindow.LoadViewWhithParam(ViewType.FindRoutes, _selectCityFrom.name_city, _selectCityIn.name_city, _dateTime);
                else MessageBox.Show("Введите данные");
            }
            catch (Exception a) { MessageBox.Show(a.Message + "" + a.StackTrace); }
        }


    }
}
