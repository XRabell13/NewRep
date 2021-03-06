﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Wpf67.Command;
using Wpf67.DataBase;
using Wpf67.Model;

namespace Wpf67.ViewModel
{
   partial class AdminWindowVM : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Impl
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
      
        DataBaseLoad baseLoad = new DataBaseLoad();

        private User _selectUser;
        public User SelectUser { get =>_selectUser; set { _selectUser = value; } }

        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get => _users; 
            set { 
                _users = value; 
                OnPropertyChanged();
            }
        }

        private UserInfo _selectUserInfo;
        public UserInfo SelectUserInfo { get => _selectUserInfo; set { _selectUserInfo = value; } }

        private ObservableCollection<UserInfo> _usersInfo = new ObservableCollection<UserInfo>();
        public ObservableCollection<UserInfo> UsersInfo
        {
            get => _usersInfo;
            set
            {
                _usersInfo = value;
                OnPropertyChanged();
            }
        }

        private City _selectCity;
        public City SelectCity { get => _selectCity; set { _selectCity = value; } }

      

        private ObservableCollection<City> _cities = new ObservableCollection<City>();
        public ObservableCollection<City> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }

        private Bus _selectBus;
        public Bus SelectBus { get => _selectBus; set { _selectBus = value; } }

        private ObservableCollection<Bus> _buses = new ObservableCollection<Bus>();
     
        public ObservableCollection<Bus> Buses
        {
            get => _buses;
            set
            {
                _buses = value;
                OnPropertyChanged();
            }
        }

        private IntermediatePoint _selectIp;
        public IntermediatePoint SelectIp { get => _selectIp; set { _selectIp = value; } }

        private ObservableCollection<IntermediatePoint> _ipoints = new ObservableCollection<IntermediatePoint>();
        public ObservableCollection<IntermediatePoint> IPoints
        {
            get => _ipoints;
            set
            {
                _ipoints = value;
                OnPropertyChanged();
            }
        }

        private RouteBus _selectRouteBus;
        public RouteBus SelectRouteBus { get => _selectRouteBus; set { _selectRouteBus = value; } }

        private ObservableCollection<RouteBus> _routeBuses = new ObservableCollection<RouteBus>();
        public ObservableCollection<RouteBus> RouteBuses
        {
            get => _routeBuses;
            set
            {
                _routeBuses = value;
                OnPropertyChanged();
            }
        }

        private Ticket _selectTicket;
        public Ticket SelectTicket { get => _selectTicket; set { _selectTicket = value; } }

        private ObservableCollection<Ticket> _tickets = new ObservableCollection<Ticket>();
        public ObservableCollection<Ticket> Tickets
        {
            get => _tickets;
            set
            {
                _tickets = value;
                OnPropertyChanged();
            }
        }

        private Transporter _selectTransporter;
        public Transporter SelectTransporter { get => _selectTransporter; set { _selectTransporter = value; } }

        private ObservableCollection<Transporter> _transporter = new ObservableCollection<Transporter>();
        public ObservableCollection<Transporter> Transporters
        {
            get => _transporter;
            set
            {
                _transporter = value;
                OnPropertyChanged();
            }
        }

        List<User> usersUpdate = new List<User>();
        List<UserInfo> usersInfoUpdate = new List<UserInfo>();
        List<City> citiesUpdate = new List<City>();
        List<City> citiesValidate = new List<City>();
        List<Bus> busesUpdate = new List<Bus>();
        List<Bus> busesValidate = new List<Bus>();
        List<IntermediatePoint> intermediatePointsUpdate = new List<IntermediatePoint>();
        List<IntermediatePoint> intermediatePointsValidate = new List<IntermediatePoint>();
        List<RouteBus> routeBusesUpdate = new List<RouteBus>();
        List<RouteBus> routeBusesValidate = new List<RouteBus>();
        List<Ticket> ticketsUpdate = new List<Ticket>();
        List<Transporter> transportersUpdate = new List<Transporter>();

      

        public AdminWindowVM()
        {
           
            AllCollectionChanged();
            baseLoad.DeleteOldUserTickets();
            baseLoad.UpdateOldTickets();
            LoadDataBase();
            

        }
        void AllCollectionChanged()
        {
              _users.CollectionChanged += User_CollectionChanged;
            _usersInfo.CollectionChanged += UserInfo_CollectionChanged;
            _cities.CollectionChanged += City_CollectionChanged;
            _ipoints.CollectionChanged += IPoints_CollectionChanged;
            _buses.CollectionChanged += Bus_CollectionChanged;
            _routeBuses.CollectionChanged += RouteBus_CollectionChanged;
            _tickets.CollectionChanged += Ticket_CollectionChanged;
            _transporter.CollectionChanged += Transporter_CollectionChanged;
        }
        void LoadDataBase()
        {
        
               ClearAllCollection();
                foreach (var u in baseLoad.GetUsers())
                {
                    _users.Add(u);
                }
                foreach (var u in baseLoad.GetBuses())
                {
                    _buses.Add(u);
               
                }
              foreach (var u in baseLoad.GetBuses())
            {
                busesValidate.Add(u);
            }
            foreach (var u in baseLoad.GetCities())
            {
               citiesValidate.Add(u);
            }
            foreach (var u in baseLoad.GetCities())
                {

                  _cities.Add(u);
                }
                foreach (var u in baseLoad.GetInterPoints())
                {
                    _ipoints.Add(u);
                }
            foreach (var u in baseLoad.GetInterPoints())
            {
                intermediatePointsValidate.Add(u);
            }
            foreach (var u in baseLoad.GetRouteBuses())
                {
                    _routeBuses.Add(u);
                }
            foreach (var u in baseLoad.GetRouteBuses())
            {
                routeBusesValidate.Add(u);
            }
            foreach (var u in baseLoad.GetTickets())
                {
                    _tickets.Add(u);
                }
                foreach (var u in baseLoad.GetTransporters())
               {
                    _transporter.Add(u);
                }
                foreach (var u in baseLoad.GetUsersInfo())
                {
                    _usersInfo.Add(u);
                }
         
        }
        void ClearAllCollection()
        {
            _users.Clear();
            _cities.Clear();
            _buses.Clear();
            _ipoints.Clear();
            _routeBuses.Clear();
            _tickets.Clear();
            _usersInfo.Clear();
            _transporter.Clear();
            busesValidate.Clear();
            citiesValidate.Clear();
            intermediatePointsValidate.Clear();
            routeBusesValidate.Clear();
        }

      



        private MyCommand butLoad;
        public MyCommand ButLoad
        {
            get
            {
               
                return butLoad = butLoad ??
                  new MyCommand(Load, CanLoad);
            }
        }
        private bool CanLoad()
        {

            return true;
        }
        private void Load()
        {
           // await Task.Run(() => ShowProgressBar());
          
            // CollapsProgressBar();
            
            if (usersUpdate.Count > 0 || usersInfoUpdate.Count > 0 || citiesUpdate.Count > 0 ||
                  busesUpdate.Count > 0 || transportersUpdate.Count > 0 || intermediatePointsUpdate.Count > 0
                  || ticketsUpdate.Count > 0 || routeBusesUpdate.Count > 0)
            {
                if (usersUpdate.Count > 0)
                {
                    baseLoad.UpdateUsers(usersUpdate);
                    usersUpdate = new List<User>();
                }

                if (transportersUpdate.Count > 0)
                {
                    baseLoad.UpdateTransporters(transportersUpdate);
                    transportersUpdate = new List<Transporter>();
                }
                if (busesUpdate.Count > 0)
                {
                    baseLoad.UpdateBuses(busesUpdate);
                    busesUpdate = new List<Bus>();
                }
                if (intermediatePointsUpdate.Count > 0)
                {
                    baseLoad.UpdateIntermediatePoints(intermediatePointsUpdate);
                    intermediatePointsUpdate = new List<IntermediatePoint>();
                }
                if (ticketsUpdate.Count > 0)
                {
                    baseLoad.UpdateTickets(ticketsUpdate);
                    ticketsUpdate = new List<Ticket>();
                }
                if (routeBusesUpdate.Count > 0)
                {
                    baseLoad.UpdateRouteBuses(routeBusesUpdate);
                    routeBusesUpdate = new List<RouteBus>();
                }
                if (citiesUpdate.Count > 0)
                {
                    baseLoad.UpdateCities(citiesUpdate);
                    routeBusesUpdate = new List<RouteBus>();
                }
                LoadDataBase();
            }
            else
                MessageBox.Show("Изменений не обнаружено.");
           // Thread.Sleep(10000);
         //   CollapsProgressBar();
        }


        #region Delete
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
            if (_selectIp != null)
            {
                baseLoad.DeleteInterPoint(_selectIp);
                LoadDataBase();
            }
            else MessageBox.Show("Выберите элемент из списка для удаления.");
        }
        #endregion

        #region CollectionChanged
        private void User_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += user_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -=  user_PropertyChanged;
                }
            }
        }
        //Property Changed will be called whenever a property of one of the 'Person'
        //objects is changed.
        private void user_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender as User != null)
            {
                User row = sender as User;
                usersUpdate.Add(row);
            }
        }
        private void City_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += city_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= city_PropertyChanged;
                }
            }
        }
        //Property Changed will be called whenever a property of one of the 'Person'
        //objects is changed.
        private void city_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender as City != null)
            {
                City row = sender as City;
                foreach (City c in _cities)
                    if (c.name_city == row.name_city)
                    {
                        MessageBox.Show(row.name_city + " уже существует под id = " + row.id_city);
                        return;
                    }
                citiesUpdate.Add(row);
            }
        }

        private void Bus_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += bus_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= bus_PropertyChanged;
                }
            }
        }
        //Property Changed will be called whenever a property of one of the 'Person'
        //objects is changed.
        private void bus_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender as Bus != null)
            {
                Bus row = sender as Bus;
                int i = 0, j = 0;
                bool isError =true;
                foreach (var rb in _transporter)
                    if (rb.id == row.id_transporter)
                        foreach (var ip in _buses)
                        {
                            if (ip.id_bus == row.id_bus)
                            {
                                _buses[j].NamedTransporter = rb.named;
                                isError = false;
                                break;
                            }
                            j++;
                        }
                  

                if (!isError)
                {
                    busesUpdate.Add(row);
                }
                else 
                { 
                    MessageBox.Show("Неверный ID перевозчика");
                        int k = 0;
                        foreach (var b in busesValidate)
                            if (b.id_bus == row.id_bus)
                            {
                                foreach (var bus in _buses) 
                                {
                                    if (bus.id_bus == row.id_bus)
                                    {
                                  //  MessageBox.Show("IDCity now: " + _buses[k].id_transporter);
                                    _buses[k].id_transporter = b.id_transporter;
                                  //  MessageBox.Show("IDCity after: " + _buses[k].id_transporter);
                                  
                                    }
                                    k++;
                                }
                                break;
                            }
                         
                  //  MessageBox.Show(_buses[0].NamedTransporter);
                   
                }
            }
        }

        private void UserInfo_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += userInfo_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= userInfo_PropertyChanged;
                }
            }
        }
        //Property Changed will be called whenever a property of one of the 'Person'
        //objects is changed.
        private void userInfo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender as UserInfo != null)
            {
                UserInfo row = sender as UserInfo;
                usersInfoUpdate.Add(row);
            }
        }

        private void IPoints_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += ipoints_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= ipoints_PropertyChanged;
                }
            }
        }
        //Property Changed will be called whenever a property of one of the 'Person'
        //objects is changed.
        private void ipoints_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (sender as IntermediatePoint != null)
            {
                IntermediatePoint row = sender as IntermediatePoint;
                int j = 0;
                bool isErrorCity = true, isErrorRouteBus=true;

                foreach (var city in _cities)
                    if (city.id_city == row.id_city)
                        foreach (var ip in _ipoints)
                        {
                            if (ip.id_intermediate_point == row.id_intermediate_point)
                            {
                               // MessageBox.Show("Now city: " + _ipoints[j].NameCity);
                                _ipoints[j].NameCity = city.name_city;
                              //  MessageBox.Show("After city: " + _ipoints[j].NameCity);
                             
                                isErrorCity = false;
                              
                                break;
                            }
                            j++;
                        }
                   

              int  jj = 0;

                foreach (var rb in _routeBuses)
                    if (rb.id_route == row.id_route_bus)
                    {
                        foreach (var ip in _ipoints)
                        {
                            if (ip.id_intermediate_point == row.id_intermediate_point)
                            {
                               // MessageBox.Show("Now r: "+_ipoints[jj].NameRouteBus);
                                _ipoints[jj].NameRouteBus = rb.name_route;
                             //   MessageBox.Show("After r: " + _ipoints[jj].NameRouteBus);
                                isErrorRouteBus = false;
                                break;
                            }
                            jj++;
                        }
                    }

                if (isErrorRouteBus) isErrorCity = false;
                if (isErrorCity) isErrorRouteBus = false;

              
                if (!isErrorCity && !isErrorRouteBus)
                {
                   intermediatePointsUpdate.Add(row);
                }
                else
                {
                    if (isErrorCity)
                    {
                        MessageBox.Show("Неверный ID города");
                        int k = 0;
                        foreach (var b in intermediatePointsValidate)
                            if (b.id_intermediate_point == row.id_intermediate_point)
                            {
                                foreach (var ipoint in _ipoints)
                                {
                                    if (ipoint.id_intermediate_point == row.id_intermediate_point)
                                    {
                                        _ipoints[k].id_city = b.id_city;
                                    }
                                    k++;
                                }
                                break;
                            }
                    }

                    if (isErrorRouteBus)
                    {
                        MessageBox.Show("Неверный ID рейса");
                        int k = 0;
                        foreach (var b in intermediatePointsValidate)
                            if (b.id_intermediate_point == row.id_intermediate_point)
                            {
                                foreach (var ipoint in _ipoints)
                                {
                                    if (ipoint.id_intermediate_point == row.id_intermediate_point)
                                    {
                                        _ipoints[k].id_route_bus = b.id_route_bus;
                                      
                                    }
                                    k++;
                                }
                                break;
                            }
                    }
                }


            }
                
                }

        private void RouteBus_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += routeBus_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= routeBus_PropertyChanged;
                }
            }
        }
        //Property Changed will be called whenever a property of one of the 'Person'
        //objects is changed.
        private void routeBus_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender as RouteBus != null)
            {
                RouteBus row = sender as RouteBus;
                int i = 0;
                bool isErrorBeginCity = true, isErrorEndCity = true, isErrorBus=true;
                string typeError = null;

                foreach (var city in _cities)
                    if (city.id_city == row.id_departure_point)
                        foreach (var ip in _routeBuses)
                        {
                            if (ip.id_route == row.id_route)
                            {
                               _routeBuses[i].NameDeparturePoint = city.name_city;
                                isErrorBeginCity = false;
                                break;
                            }
                            i++;
                        }
                    

                int  j = 0;
                foreach (var city in _cities)
                    if (city.id_city == row.id_end_city)
                        foreach (var ip in _routeBuses)
                        {
                            if (ip.id_route == row.id_route)
                            {
                                _routeBuses[j].NameEndCity = city.name_city;
                                isErrorEndCity = false;
                                break;
                            }
                            j++;
                        }

                int jj = 0;
                foreach (var bus in _buses)
                    if (bus.id_bus == row.id_bus)
                        foreach (var ip in _routeBuses)
                        {
                            if (ip.id_route == row.id_route)
                            {
                                _routeBuses[jj].NameBus = bus.model;
                                isErrorBus = false;
                                break;
                            }
                            jj++;
                        }


                if (isErrorBeginCity) typeError = "ErrorBeginCity";
                if (isErrorBus) typeError = "ErrorBus";
                if (isErrorEndCity) typeError = "ErrorEndCity";


                if (typeError==null)
                {
                   routeBusesUpdate.Add(row);
                }
                else
                {
                    switch (typeError)
                    {
                        case "ErrorBeginCity":
                            {
                                MessageBox.Show("Неверный ID пункта отправления");
                                int k = 0;
                                foreach (var b in routeBusesValidate)
                                    if (b.id_route == row.id_route)
                                    {
                                        foreach (var ipoint in _routeBuses)
                                        {
                                            if (ipoint.id_route == row.id_route)
                                            {
                                                _routeBuses[k].id_departure_point = b.id_departure_point;
                                             
                                            }
                                            k++;
                                        }
                                        break;
                                    }
                                break;
                            }
                        case "ErrorEndCity":
                            {
                                MessageBox.Show("Неверный ID пункта прибытия");
                                int k = 0;
                                foreach (var b in routeBusesValidate)
                                    if (b.id_route == row.id_route)
                                    {
                                        foreach (var ipoint in _routeBuses)
                                        {
                                            if (ipoint.id_route == row.id_route)
                                            {
                                                _routeBuses[k].id_end_city = b.id_end_city;
                                            }
                                            k++;
                                        }
                                        break;
                                    }
                                break;
                            }
                        case "ErrorBus":
                            {
                                MessageBox.Show("Неверный ID автобуса");
                                int k = 0;
                                foreach (var b in routeBusesValidate)
                                    if (b.id_route == row.id_route)
                                    {
                                        foreach (var ipoint in _routeBuses)
                                        {
                                            if (ipoint.id_route == row.id_route)
                                            {
                                                _routeBuses[k].id_bus = b.id_bus;
                                            }
                                            k++;
                                        }
                                        break;
                                    }
                                break;
                            }
                    }
                }
            }
        }

        private void Ticket_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += ticket_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= ticket_PropertyChanged;
                }
            }
        }
        //Property Changed will be called whenever a property of one of the 'Person'
        //objects is changed.
        private void ticket_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender as Ticket != null)
            {
                Ticket row = sender as Ticket;
                ticketsUpdate.Add(row);
            }
        }


        private void Transporter_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += transporter_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= transporter_PropertyChanged;
                }
            }
        }
        //Property Changed will be called whenever a property of one of the 'Person'
        //objects is changed.
        private void transporter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender as Transporter != null)
            {
                Transporter row = sender as Transporter;
                transportersUpdate.Add(row);
            }
        }
        #endregion

      


    }
}
