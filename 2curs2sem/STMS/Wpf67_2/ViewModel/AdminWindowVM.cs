using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf67.Command;
using Wpf67.DataBase;
using Wpf67.Model;

namespace Wpf67.ViewModel
{
    class AdminWindowVM : INotifyPropertyChanged
    {
        public string Svoi { get; set; } = "СВЯЗАНО";

        public event PropertyChangedEventHandler PropertyChanged;

        DataBaseLoad baseLoad = new DataBaseLoad();


        private User _selectUser;
        public User SelectUser { get =>_selectUser; set { _selectUser = value; } }

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users; 
            set { 
                _users = value; 
                OnPropertyChanged(nameof(Users));
            }
        }

        private UserInfo _selectUserInfo;
        public UserInfo SelectUserInfo { get => _selectUserInfo; set { _selectUserInfo = value; } }

        private ObservableCollection<UserInfo> _usersInfo;
        public ObservableCollection<UserInfo> UsersInfo
        {
            get => _usersInfo;
            set
            {
                _usersInfo = value;
                OnPropertyChanged(nameof(UsersInfo));
            }
        }

        private City _selectCity;
        public City SelectCity { get => _selectCity; set { _selectCity = value; } }

        private ObservableCollection<City> _cities;
        public ObservableCollection<City> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged(nameof(Cities));
            }
        }

        private Bus _selectBus;
        public Bus SelectBus { get => _selectBus; set { _selectBus = value; } }

        private ObservableCollection<Bus> _buses;
        public ObservableCollection<Bus> Buses
        {
            get => _buses;
            set
            {
                _buses = value;
                OnPropertyChanged(nameof(Buses));
            }
        }

        private IntermediatePoint _selectIp;
        public IntermediatePoint SelectIp { get => _selectIp; set { _selectIp = value; } }

        private ObservableCollection<IntermediatePoint> _ipoints;
        public ObservableCollection<IntermediatePoint> IPoints
        {
            get => _ipoints;
            set
            {
                _ipoints = value;
                OnPropertyChanged(nameof(IPoints));
            }
        }

        private RouteBus _selectRouteBus;
        public RouteBus SelectRouteBus { get => _selectRouteBus; set { _selectRouteBus = value; } }

        private ObservableCollection<RouteBus> _routeBuses;
        public ObservableCollection<RouteBus> RouteBuses
        {
            get => _routeBuses;
            set
            {
                _routeBuses = value;
                OnPropertyChanged(nameof(RouteBuses));
            }
        }

        private Ticket _selectTicket;
        public Ticket SelectTicket { get => _selectTicket; set { _selectTicket = value; } }

        private ObservableCollection<Ticket> _tickets;
        public ObservableCollection<Ticket> Tickets
        {
            get => _tickets;
            set
            {
                _tickets = value;
                OnPropertyChanged(nameof(Tickets));
            }
        }

        private Transporter _selectTransporter;
        public Transporter SelectTransporter { get => _selectTransporter; set { _selectTransporter = value; } }

        private ObservableCollection<Transporter> _transporter;
        public ObservableCollection<Transporter> Transporters
        {
            get => _transporter;
            set
            {
                _transporter = value;
                OnPropertyChanged(nameof(Transporters));
            }
        }

        List<User> usersUpdate = new List<User>();
        List<UserInfo> usersInfoUpdate = new List<UserInfo>();
        List<City> citiesUpdate = new List<City>();
        List<Bus> busesUpdate = new List<Bus>();
        List<IntermediatePoint> intermediatePointsUpdate = new List<IntermediatePoint>();
        List<RouteBus> routeBusesUpdate = new List<RouteBus>();
        List<Ticket> ticketsUpdate = new List<Ticket>();
        List<Transporter> transportersUpdate = new List<Transporter>();
     
        public AdminWindowVM()
        {
            LoadDataBase();
        }
        void LoadDataBase()
        {
         
            Users = baseLoad.GetUsers();
            Cities = baseLoad.GetCities();
            Buses = baseLoad.GetBuses();
            IPoints = baseLoad.GetInterPoints();
            RouteBuses = baseLoad.GetRouteBuses();
            Tickets = baseLoad.GetTickets();
            UsersInfo = baseLoad.GetUsersInfo();
            Transporters = baseLoad.GetTransporters();
        }
        // public IMMCodeBehind CodeBehind { get; set; }

        void ClearAllCollection()
        {
            Users.Clear();
            Cities.Clear();
            Buses.Clear();
            IPoints.Clear();
            RouteBuses.Clear();
            Tickets.Clear();
            UsersInfo.Clear();
            Transporters.Clear();
        }

        private MyCommand deleteUser;
        public MyCommand DeleteUser
        {
            get
            {
                return deleteUser = deleteUser ??
                  new MyCommand(delUser, CanDeleteUser);
            }
        }
        private bool CanDeleteUser()
        {
            
            return true;
        }
      private void delUser()
        {
            if (_selectUser != null)
            {
                MessageBox.Show(_selectUser.login);
                baseLoad.DeleteUser(_selectUser); 
                LoadDataBase();
            }
            else MessageBox.Show("Выберите элемент из списка для удаления.");
        }

        private MyCommand deleteCity;
        public MyCommand DeleteCity
        {
            get
            {
                return deleteCity = deleteCity ??
                  new MyCommand(delCity, CanDeleteCity);
            }
        }
        private bool CanDeleteCity()
        {

            return true;
        }
        private void delCity()
        {
            if (_selectCity != null)
            {
                baseLoad.DeleteCity(_selectCity);
                LoadDataBase();
            }
            else MessageBox.Show("Выберите элемент из списка для удаления.");
        }

        private MyCommand deleteUsersInfo;
        public MyCommand DeleteUserInfo
        {
            get
            {
                return deleteUsersInfo = deleteUsersInfo ??
                  new MyCommand(delUsersInfo, CanDeleteUsersInfo);
            }
        }
        private bool CanDeleteUsersInfo()
        {

            return true;
        }
        private void delUsersInfo()
        {
            if (_selectUserInfo != null)
            {
                baseLoad.DeleteUserInf(_selectUserInfo);
                LoadDataBase();
            }
            else MessageBox.Show("Выберите элемент из списка для удаления.");
        }

        private MyCommand deleteBuses;
        public MyCommand DeleteBus
        {
            get
            {
                return deleteBuses = deleteBuses ??
                  new MyCommand(delBuses, CanDeleteBuses);
            }
        }
        private bool CanDeleteBuses()
        {

            return true;
        }
        private void delBuses()
        {
            if (_selectBus != null)
            {
                baseLoad.DeleteBus(_selectBus);
                LoadDataBase();
            }
            else MessageBox.Show("Выберите элемент из списка для удаления.");
        }

        private MyCommand deleteTransporter;
        public MyCommand DeleteTransporter
        {
            get
            {
                return deleteTransporter = deleteTransporter ??
                  new MyCommand(delTrans, CanDeleteTrans);
            }
        }
        private bool CanDeleteTrans()
        {

            return true;
        }
        private void delTrans()
        {
            if (_selectTransporter != null)
            {
                baseLoad.DeleteTransporter(_selectTransporter);
                LoadDataBase();
            }
            else MessageBox.Show("Выберите элемент из списка для удаления.");
        }

        private MyCommand deleteRouteBus;
        public MyCommand DeleteRouteBus
        {
            get
            {
                return deleteRouteBus = deleteRouteBus ??
                  new MyCommand(delRouteBus, CanDeleteRouteBus);
            }
        }
        private bool CanDeleteRouteBus()
        {

            return true;
        }
        private void delRouteBus()
        {
            if (_selectRouteBus != null)
            {
                baseLoad.DeleteRouteBus(_selectRouteBus);
                LoadDataBase();
            }
            else MessageBox.Show("Выберите элемент из списка для удаления.");
        }

        private MyCommand deleteIPoint;
        public MyCommand DeleteIPoint
        {
            get
            {
                return deleteIPoint = deleteIPoint ??
                  new MyCommand(delIPoint, CanDeleteIPoint);
            }
        }
        private bool CanDeleteIPoint()
        {

            return true;
        }
        private void delIPoint()
        {
            if (_selectRouteBus != null)
            {
                baseLoad.DeleteRouteBus(_selectRouteBus);
                LoadDataBase();
            }
            else MessageBox.Show("Выберите элемент из списка для удаления.");
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
