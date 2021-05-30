using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

        private MyCommand _saveTrip;
        public MyCommand SaveTrip
        {
            get
            {
                return _saveTrip = _saveTrip ??
                  new MyCommand(saveTrip, CanSaveTrip);
            }
        }
        private bool CanSaveTrip()
        {
            return true;
        }
        private void saveTrip()
        {
            string writePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\Bilet.txt";
            string text = "---------------------------------------БИЛЕТ---------------------------------------" +
                "\n\n Дата отправления: " + SelectTrip.DateArrive +
                 "\n Время отправления: " + SelectTrip.BeginTime +
                 "\n Время прибытия: " + SelectTrip.EndTime +
                 "\n Станция отправления: " + SelectTrip.BeginCity +
                 "\n До станции: " + SelectTrip.EndCity +
                 "\n Место: " + SelectTrip.NumberSeat +
                 "\n Цена: " + SelectTrip.Cost+
                 "\n\n-----------------------------------------------------------------------------------";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }

            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }

            MessageBox.Show("Билет сохранен на рабочий стол"); 
        }
    }
}
