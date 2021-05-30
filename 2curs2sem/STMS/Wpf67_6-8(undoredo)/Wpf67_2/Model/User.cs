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
    public class User : INotifyPropertyChanged
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
        string _login, _password;
        bool _isAdmin;
        public int id {
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
        public string login
        {
            get
            {
                return _login;
            }
            set
            {
                if (value == _login)
                    return;

                _login = value;
                OnPropertyChanged();
            }
        }
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value == _password)
                    return;
                _password = value;
                OnPropertyChanged();
            }
        }
        public bool isAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                if (value == _isAdmin)
                    return;
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        public User(int id, string login, string password, bool isAdmin)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.isAdmin = isAdmin;
        }

        public override string ToString()
        {
            return id.ToString() + " " + login;
        }
    }
}
