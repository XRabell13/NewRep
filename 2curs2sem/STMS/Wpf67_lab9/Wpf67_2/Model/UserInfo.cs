using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
   public class UserInfo : INotifyPropertyChanged
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
        int _id_user;
        string _passport, _email, _telephone;
        public int id_user
        {
            get
            {
                return _id_user;
            }
            set
            {
                if (value == _id_user)
                    return;

                _id_user = value;
                OnPropertyChanged();
            }
        }
        public string passport
        {
            get
            {
                return _passport;
            }
            set
            {
                if (value == _passport)
                    return;

                _passport = value;
                OnPropertyChanged();
            }
        }
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value == _email)
                    return;

                _email = value;
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

        public UserInfo(int id_user, string passport, string email, string telephone)
        {
            this.id_user = id_user;
            this.passport = passport;
            this.email = email;
            this.telephone = telephone;
        }

        public override string ToString()
        {
            return id_user.ToString() + " " + passport;
        }
    }
}
