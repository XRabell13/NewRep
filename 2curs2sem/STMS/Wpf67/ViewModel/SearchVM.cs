using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf67.Command;
using Wpf67.DataBase;
using Wpf67.Model;
using Wpf67.View;

namespace Wpf67.ViewModel
{
    class SearchVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private MainWindow mainWindow;
        private Search model;
        List<City> cities = new List<City>();
        DataBaseLoad db = new DataBaseLoad();
        public SearchVM(MainWindow win)
        {
            if (win == null) throw new ArgumentNullException(nameof(win));
            mainWindow = win;
        }
        public SearchVM(Search model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            this.model = model;
        }


        public List<City> LoadAllCities()
        {
            cities = db.GetCities();
            var items = from u in cities
                        orderby u.name_city
                        select u;
            return items.ToList();
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
    }
}
