﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
    class IntermediatePoint : INotifyPropertyChanged
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

        int _id_intermediate_point, _id_city, _id_route_bus;
        decimal _cost;
        string _time_arrive;


        public int id_intermediate_point
        {
            get
            {
                return _id_intermediate_point;
            }
            set
            {
                if (value == _id_intermediate_point)
                    return;

                _id_intermediate_point = value;
                OnPropertyChanged();
            }
        }
        public int id_city
        {
            get
            {
                return _id_city;
            }
            set
            {
                if (value == _id_city)
                    return;

                _id_city = value;
                OnPropertyChanged();
            }
        }
        public int id_route_bus
        {
            get
            {
                return _id_route_bus;
            }
            set
            {
                if (value == _id_route_bus)
                    return;

                _id_route_bus = value;
                OnPropertyChanged();
            }
        }
        public decimal cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value == _cost)
                    return;

                _cost = value;
                OnPropertyChanged();
            }
        }
        public string time_arrive
        {
            get
            {
                return _time_arrive;
            }
            set
            {
                if (value == _time_arrive)
                    return;

                _time_arrive = value;
                OnPropertyChanged();
            }
        }
        public IntermediatePoint(int id_intermediate_point, int id_city, int id_route_bus, string time_arrive, decimal cost)
        {
            this.id_intermediate_point = id_intermediate_point;
            this.id_city = id_city;
            this.id_route_bus = id_route_bus;
            this.cost = cost;
            this.time_arrive = time_arrive;
        }

        public override string ToString()
        {
            return id_intermediate_point.ToString() + " id city: " + id_city;
        }
    }
}