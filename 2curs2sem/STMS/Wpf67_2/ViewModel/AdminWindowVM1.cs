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

        string _newCity;

        public string NewCity { get => _newCity;
            set
            {
                _newCity = value;//.Replace("'","\"").Replace("`","\"");
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
    }
}
