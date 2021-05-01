using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
    public class City : INotifyPropertyChanged
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
        int _id_city;
        string _name_city;
        public int id_city
        {
            get => _id_city;
            set
            {
                if (value == _id_city)
                    return;

                _id_city = value;
                OnPropertyChanged();
            }
        }
        public string name_city
        {
            get => _name_city;
            set
            {
                if (value == _name_city)
                    return;

                _name_city = value;
                OnPropertyChanged();
            }
        }
        public City(int id_city, string name_city)
        {
            this.id_city = id_city;
            this.name_city = name_city;
        }
       
        public override string ToString()
        {
            return  id_city + " " + name_city;
        }
    }
}
