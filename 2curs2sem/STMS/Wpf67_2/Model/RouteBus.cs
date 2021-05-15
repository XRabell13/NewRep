using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
  public  class RouteBus : INotifyPropertyChanged
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

        int _id_route, _id_bus, _id_departure_point, _id_end_city;
        string _name_route, _time_departure, _timetable, _name_end_city, _name_bus, _name_departure_point;

        public string NameBus
        {
            get
            {
                return _name_bus;
            }
            set
            {
                if (value == _name_bus)
                    return;

                _name_bus = value;
                OnPropertyChanged();
            }
        }

        public string NameDeparturePoint
        {
            get
            {
                return _name_departure_point;
            }
            set
            {
                if (value == _name_departure_point)
                    return;

                _name_departure_point = value;
                OnPropertyChanged();
            }
        }
        public string NameEndCity
        {
            get
            {
                return _name_end_city;
            }
            set
            {
                if (value == _name_end_city)
                    return;

                _name_end_city = value;
                OnPropertyChanged();
            }
        }

        public int id_route
        {
            get
            {
                return _id_route;
            }
            set
            {
                if (value == _id_route)
                    return;

                _id_route = value;
                OnPropertyChanged();
            }
        }
        public string name_route
        {
            get
            {
                return _name_route;
            }
            set
            {
                if (value == _name_route)
                    return;

                _name_route = value;
                OnPropertyChanged();
            }
        }
        public int id_bus
        {
            get
            {
                return _id_bus;
            }
            set
            {
                if (value == _id_bus)
                    return;

                _id_bus = value;
                OnPropertyChanged();
            }
        }
        public string time_departure
        {
            get
            {
                return _time_departure;
            }
            set
            {
                if (value == _time_departure)
                    return;

                _time_departure = value;
                OnPropertyChanged();
            }
        }
        public string timetable
        {
            get
            {
                return _timetable;
            }
            set
            {
                if (value == _timetable)
                    return;

                _timetable = value;
                OnPropertyChanged();
            }
        }
        public int id_departure_point
        {
            get
            {
                return _id_departure_point;
            }
            set
            {
                if (value == _id_departure_point)
                    return;

                _id_departure_point = value;
                OnPropertyChanged();
            }
        }
        public int id_end_city
        {
            get
            {
                return _id_end_city;
            }
            set
            {
                if (value == _id_end_city)
                    return;

                _id_end_city = value;
                OnPropertyChanged();
            }
        }

        public RouteBus(int id_route, string name_route, int id_b, string time_departure, string timetable, int id_departure_point, int id_end_city, 
             string _name_bus, string _name_departure_point,string _name_end_city)
        {
            this.id_bus = id_b;
            this.id_route = id_route;
            this.id_departure_point = id_departure_point;
            this.id_end_city = id_end_city;
            this.timetable = timetable;
            this.time_departure = time_departure;
            this.name_route = name_route;
            this._name_departure_point = _name_end_city;
            this._name_bus = _name_bus;
            this._name_departure_point = _name_departure_point;
        }
        public RouteBus(int id_route, string name_route, int id_b, string time_departure, string timetable, int id_departure_point, int id_end_city)
        {
            this.id_bus = id_b;
            this.id_route = id_route;
            this.id_departure_point = id_departure_point;
            this.id_end_city = id_end_city;
            this.timetable = timetable;
            this.time_departure = time_departure;
            this.name_route = name_route;
        
        }
        public void InsertEndCity(string end_city)=>
            _name_end_city = end_city;
        

        public override string ToString()
        {
            return  name_route + ", " + _name_bus;
        }


    }
}
