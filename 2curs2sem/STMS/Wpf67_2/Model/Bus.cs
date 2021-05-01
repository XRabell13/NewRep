using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        string _model;

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

                _count = value;
                OnPropertyChanged();
            }
        }
        public Bus(int id_bus, int id_transporter, string model, int count_seats)
        {
            this.id_bus = id_bus;
            this.id_transporter = id_transporter;
            this.model = model;
            this.count_seats = count_seats;
        }

        public override string ToString()
        {
            return id_bus + " id transporter: " + id_transporter + " model: " + model;
        }
    }
}
