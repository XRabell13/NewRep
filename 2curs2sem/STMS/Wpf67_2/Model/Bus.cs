using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf67.Model
{
  public  class Bus : INotifyPropertyChanged
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
        int _id_bus, _id_tr, _count;
        string _model, _named_transporter;

        public int id_bus
        {
            get => _id_bus;
            set 
            {
                    if (value == _id_bus)
                        return;

                    _id_bus = value;
                    OnPropertyChanged();
            }
        }
        public int id_transporter
        {
            get => _id_tr;
            set
            {
                if (value == _id_tr)
                    return;

                _id_tr = value;
                OnPropertyChanged();
            }
        }
        public string NamedTransporter
        {
            get => _named_transporter;
            set
            {
                if (value == _named_transporter)
                    return;

                _named_transporter = value;
                OnPropertyChanged();
            }
        }
        public string model
        {
            get => _model;
            set
            {
                if (value == _model)
                    return;

                _model = value;
                OnPropertyChanged();
            }
        }
        public int count_seats
        {
            get => _count;
            set
            {
               
                if (value == _count)
                    return;
                if (value > 0 && value < 101)
                {
                    _count = value;
                    OnPropertyChanged();
                }
                else MessageBox.Show("Количество мест должно находится в диапазоне от 1 до 100 включительно");
            }
        }
        public Bus(int id_bus, int id_transporter, string model, int count_seats, string named_tr)
        {
            _id_bus = id_bus;
            _id_tr= id_transporter;
            _model = model;
            _count = count_seats;
            _named_transporter = named_tr;
        }

        public override string ToString()
        {
            return id_bus + " id transporter: " + id_transporter + " model: " + model;
        }
    }
}
