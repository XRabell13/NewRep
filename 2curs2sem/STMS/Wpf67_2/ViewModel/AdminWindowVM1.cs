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

        private Bus _selectAddBus;
        public Bus SelectAddBus { get => _selectAddBus; set { _selectAddBus = value; } }

        string _time_departure;
      public string TimeDeparture { get => _time_departure; 
            set 
            {
                string pattern = @"^(([0,1][0-9])|(2[0-3])):[0-5][0-9]$";
                
                    if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                    {
                        _time_departure = value;
                    }
                    else
                    {
                        Console.WriteLine("Некорректное время");
                    }
            } 
        }

        string _newCity;
        string _textCompany, _textTelephone, _textAddress;

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
                _textTelephone = value;
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
                _name_route_bus = value;//.Replace("'","\"").Replace("`","\"");
            }
        }

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
                timetable = NameRouteBus  = TimeDeparture = null;
                SelectBeginCity = SelectEndCity = null;
                SelectAddBus = null; 
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
        //Сокращения дней недели: пн, вт, ср, чт, пт, сб, вс.

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
