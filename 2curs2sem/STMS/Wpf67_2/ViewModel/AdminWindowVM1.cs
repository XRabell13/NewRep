using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf67.Command;
using Wpf67.DataBase;
using Wpf67.Model;


namespace Wpf67.ViewModel
{
    partial class AdminWindowVM
    {
        private City _selectBeginCity;
        public City SelectBeginCity { get => _selectBeginCity; set { _selectBeginCity = value; } }

        private City _selectEndCity;
        public City SelectEndCity { get => _selectEndCity; set { _selectEndCity = value; } }

        private City _selectIPCity;
        public City SelectIPCity { get => _selectIPCity; set { _selectIPCity = value; } }

        private IntermediatePoint _selectAddIp;
        public IntermediatePoint SelectAddIp { get => _selectAddIp; set { _selectAddIp = value; } }

        private RouteBus _selectRouteBusForIp;
        public RouteBus SelectRouteBusIp { get => _selectRouteBusForIp; set { _selectRouteBusForIp = value; } }

        private Transporter _selectAddTransporter;
        public Transporter SelectAddTransporter { get => _selectAddTransporter; set { _selectAddTransporter = value; } }

        private Bus _selectAddBus;
        public Bus SelectAddBus { get => _selectAddBus; set { _selectAddBus = value; } }

        string _time_departure;
      public string TimeDeparture { get => _time_departure; 
            set 
            {
                string pattern = @"^(([0,1][0-9])|(2[0-3])):[0-5][0-9]$";
                
                    if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase) || value==null)
                        _time_departure = value;
                    else
                        MessageBox.Show("Некорректное время");
            } 
        }

        string _newCity;
        string _textCompany, _textTelephone, _textAddress, _modelBus;
        int _countSeats;

        public int CountSeats
        {
            get => _countSeats;
            set
            {
                _countSeats = value;
            }
        }
        public string ModelBus
        {
            get => _modelBus;
            set
            {
                _modelBus = value;
            }
        }
        public string TextCompany
        {
            get => _textCompany;
            set
            {
                _textCompany = value;
            }
        }
        public string TextTelephone
        {
            get => _textTelephone;
            set
            {
                string pattern = @"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$";

                if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase) || value == null)
                   _textTelephone = value;
                else
                    MessageBox.Show("Некорректный телефон");
            }
        }
        public string TextAddress
        {
            get => _textAddress;
            set
            {
                _textAddress= value;
            }
        }
        public string NewCity { get => _newCity;
            set
            {
                _newCity = value;
            }
        }
        string _name_route_bus;

        public string NameRouteBus
        {
            get => _name_route_bus;
            set
            {
                _name_route_bus = value;
            }
        }

        #region Days
        bool _check_monday;
        public bool CheckMonday
        {
            get => _check_monday;
            set
            {
               _check_monday = value;
             
            }
        }

        bool _check_tuesday;
        public bool CheckThuesday
        {
            get => _check_tuesday;
            set
            {
               _check_tuesday = value;
            }
        }
        bool _check_wednesday;
       public bool CheckWednesday
        {
            get => _check_wednesday;
            set
            {
                _check_wednesday = value;
              
            }
        }
        bool _check_thursday;
        public bool CheckThursday
        {
            get => _check_thursday;
            set
            {
                _check_thursday = value;
               
            }
        }
        bool _check_friday;
        public bool CheckFriday
        {
            get => _check_friday;
            set
            {
                _check_friday = value;
              
            }
        }
        bool _check_saturday;
        public bool CheckSaturday
        {
            get => _check_saturday;
            set
            {
                _check_saturday = value;
               
            }
        }
        bool _check_sunday;
        public bool CheckSunday
        {
            get => _check_sunday;
            set
            {
                _check_sunday = value;
              
            }
        }
        #endregion

        private Visibility _visibility = Visibility.Collapsed;
        public Visibility VisibilityProgressBar
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////// COMMANDS ////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private MyCommand addCity;
        public MyCommand AddCity
        {
            get
            {
                return addCity = addCity ??
                  new MyCommand(adCity, CanAddCity);
            }
        }
        private bool CanAddCity()
        {

            return true;
        }
        private void adCity()
        {
            if (_newCity != null && _newCity != "")
            {
                foreach (var a in _cities)
                    if (a.name_city == _newCity)
                    {
                        MessageBox.Show(_newCity + " уже существует в базе данных под id_city = " + a.id_city);
                        return;
                    }
            }
            else
                return;
            baseLoad.AddCities(_newCity);
            LoadDataBase();
        }

        private MyCommand addRouteBus;
        public MyCommand AddRouteBus
        {
            get
            {
                return addRouteBus = addRouteBus ??
                  new MyCommand(adRouteBus, CanAddRouteBus);
            }
        }
        private bool CanAddRouteBus()
        {

            return true;
        }
        private void adRouteBus()
        {
            string timetable = GetTimetable();
            if (timetable != "" && NameRouteBus!=null && SelectAddBus!=null && TimeDeparture!=null && SelectBeginCity!=null && SelectEndCity!=null)
            {
                baseLoad.AddRouteBus(NameRouteBus,SelectAddBus.id_bus, TimeDeparture,timetable,SelectBeginCity.id_city, SelectEndCity.id_city);
                NameRouteBus = TimeDeparture = null;
                SelectBeginCity = SelectEndCity = null;
                LoadDataBase();
              
            }
            else
                return;
           
        }

        private MyCommand addTransporter;
        public MyCommand AddTransporter
        {
            get
            {
                return addTransporter = addTransporter ??
                  new MyCommand(adTransporter, CanAddTransporter);
            }
        }
        private bool CanAddTransporter()
        {

            return true;
        }
        private void adTransporter()
        {
                if (TextAddress!=null && TextTelephone!=null&&TextCompany!=null)
            {
                baseLoad.AddTransporter(TextCompany, TextAddress, TextTelephone);
                TextTelephone = TextAddress = TextCompany = null;
                LoadDataBase();
            
            }
            else
                return;

        }

        private MyCommand addBus;
        public MyCommand AddBus
        {
            get
            {
                return addBus = addBus ??
                  new MyCommand(adBus, CanAddBus);
            }
        }
        private bool CanAddBus()
        {

            return true;
        }
        private void adBus()
        {
            if (SelectAddTransporter!=null && ModelBus!=null && CountSeats > 0 && CountSeats <101)
            {
                baseLoad.AddBuss(SelectAddTransporter.id.ToString(), ModelBus, CountSeats.ToString());
                SelectAddTransporter = null;
                ModelBus = null;
                CountSeats = 0;
                LoadDataBase();
              
            }
            else
                return;

        }

        private string GetTimetable()
        {
            string timetable = "";
            if (CheckMonday) timetable += "пн ";
            if (CheckThuesday) timetable += "вт ";
            if (CheckWednesday) timetable += "ср ";
            if (CheckThursday) timetable += "чт ";
            if (CheckFriday) timetable += "пт ";
            if (CheckSaturday) timetable += "сб ";
            if (CheckSunday) timetable += "вс ";

            if (timetable == "")
                return "";
            else return timetable;
        }

    }
}
