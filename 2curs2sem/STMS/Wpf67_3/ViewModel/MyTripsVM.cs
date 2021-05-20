using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf67.Command;
using Wpf67.Model;

namespace Wpf67.ViewModel
{
    class MyTripsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        DataBase.DataBaseLoad db = new DataBase.DataBaseLoad();
        private IMMCodeBehind mainWindow;

        List<MyTrip> _myTrips;
        public List<MyTrip> MyTrips
        {
            get => _myTrips;
            set => _myTrips = value;
        }
        MyTrip _selectTrip;
        public MyTrip SelectTrip
        {
            get => _selectTrip;
            set => _selectTrip = value;
        }
        Visibility _showListBox;
        public Visibility ShowListBox
        {
            get => _showListBox;
            set
            {
                _showListBox = value;
            }
        }
        Visibility _showNoRoutes;
        public Visibility ShowNoRoutes
        {
            get => _showNoRoutes;
            set
            {
                _showNoRoutes = value;
            }
        }
        public MyTripsVM(IMMCodeBehind win)
        {
            if (win == null) throw new ArgumentNullException(nameof(win));
            mainWindow = win;

           db.DeleteOldUserTickets();
           MyTrips = db.GetUserTrips(Wpf67.Properties.Settings.Default.UserId.ToString());
            if (MyTrips.Count == 0)
            {
                ShowListBox = Visibility.Collapsed;
                ShowNoRoutes = Visibility.Visible;
            }
            else
            {
                ShowListBox = Visibility.Visible;
                ShowNoRoutes = Visibility.Collapsed;
            }


        }


        private MyCommand _cancelTrip;
        public MyCommand CancelTrip
        {
            get
            {
                return _cancelTrip = _cancelTrip ??
                  new MyCommand(cancelTrip, CanCancelTrip);
            }
        }
        private bool CanCancelTrip()
        {
            return true;
        }
        private void cancelTrip()
        {
             db.DeleteUserTicket(SelectTrip._id_user_ticket, SelectTrip._id_ticket);
             mainWindow.LoadView(ViewType.MyTrips);
        }
    }
}
