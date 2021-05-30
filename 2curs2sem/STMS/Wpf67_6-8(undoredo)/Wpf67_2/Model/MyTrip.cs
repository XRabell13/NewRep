using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
    class MyTrip
    {
        string _beginCity, _endCity;
        string _beginTime, _endTime, _date, _numSeat;
       public string _id_user_ticket,_id_ticket;
        public string BeginCity { get => _beginCity; set { _beginCity = value; } }
        public string EndCity { get => _endCity; set { _endCity = value; } }
        public string BeginTime { get => _beginTime; set { _beginTime = value; } }
        public string EndTime { get => _endTime; set { _endTime = value; } }
        public string DateArrive { get => _date; set { _date = value; } }
        public string NumberSeat { get => _numSeat; set { _numSeat = value; } }

        decimal _cost;
        public decimal Cost
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
            }
        }

   
        public MyTrip(string bcity, string ecity, string btime, string etime, decimal cost, string date, string numSeat, string id_ut, string id_ticket)
        {
            //можно брать первое слово из начала до пробела и в bcity тавлять
            // номер места, дату
            _cost = cost;
            _beginCity = bcity;
            _endCity = ecity;
            _beginTime = btime;
            _endTime = etime;
            _date = date;
            _numSeat = numSeat;
            _id_user_ticket = id_ut;
            _id_ticket = id_ticket;
        }

    
    }
}

