using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf67.Command;

namespace Wpf67.ViewModel
{
    class MyTripsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private MainWindow mainWindow;

        public MyTripsVM(MainWindow win)
        {
            if (win == null) throw new ArgumentNullException(nameof(win));
            mainWindow = win;
        }


        private MyCommand loadMyTrips;
        public MyCommand LoadMyTripsPage
        {
            get
            {
                return loadMyTrips = loadMyTrips ??
                  new MyCommand(ShowLoadMyTripsPage, CanLoadMyTripsPage);
            }
        }
        private bool CanLoadMyTripsPage()
        {
            return true;
        }
        private void ShowLoadMyTripsPage()
        {
            mainWindow.LoadView(ViewType.MyTrips);
        }
    }
}
