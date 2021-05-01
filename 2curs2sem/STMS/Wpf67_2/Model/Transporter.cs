using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
    public class Transporter : INotifyPropertyChanged
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
        int _id;
        string _named, _adress, _telephone;

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value == _id)
                    return;

                _id = value;
                OnPropertyChanged();
            }
        }
        public string named
        {
            get
            {
                return _named;
            }
            set
            {
                if (value == _named)
                    return;

                _named = value;
                OnPropertyChanged();
            }
        }
        public string adress
        {
            get
            {
                return _adress;
            }
            set
            {
                if (value == _adress)
                    return;

                _adress = value;
                OnPropertyChanged();
            }
        }
        public string telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                if (value == _telephone)
                    return;

                _telephone = value;
                OnPropertyChanged();
            }
        }

        public Transporter(int id, string named, string adress, string telephone)
        {
            this.id = id;
            this.named = named;
            this.adress = adress;
            this.telephone = telephone;
        }

        public override string ToString()
        {
            return id.ToString() + " " + named;
        }
    }
}
