using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
   public class Ticket : INotifyPropertyChanged
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
        int _id_ticket, _id_route, _num_seat;
        bool _status_seat;
        string _date_departure;//DateTime
     
        public int id_ticket
        {
            get
            {
                return _id_ticket;
            }
            set
            {
                if (value == _id_ticket)
                    return;

                _id_ticket = value;
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
        public int num_seat
        {
            get
            {
                return _num_seat;
            }
            set
            {
                if (value == _num_seat)
                    return;

                _num_seat = value;
                OnPropertyChanged();
            }
        }
        public bool status_seat
        {
            get
            {
                return _status_seat;
            }
            set
            {
                if (value == _status_seat)
                    return;

                _status_seat = value;
                OnPropertyChanged();
            }
        }
        public string date_departure
        {
            get
            {
                return _date_departure;
            }
            set
            {
                if (value == _date_departure)
                    return;

                _date_departure = value;
                OnPropertyChanged();
            }
        }//DateTime

        public Ticket(int id_t, int id_route, string date_departure, int num_seat, bool status_seat)
        {
            this.id_ticket = id_t;
            this.id_route = id_route;
            this.num_seat = num_seat;
            this.status_seat = status_seat;
            this.date_departure = date_departure;
        }

        public override string ToString()
        {
            return id_ticket.ToString() + " " + id_route;
        }
    }
}
