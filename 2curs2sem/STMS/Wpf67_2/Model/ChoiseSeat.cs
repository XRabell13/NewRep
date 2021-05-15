using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
  public  class ChoiseSeat
    {
        int _num_seat;
        bool _status_seat;

        public int NumberSeat
        {
            get => _num_seat; 
            private set 
            { 
                _num_seat = value;
            } 
        }
        public bool StatusSeat
        {
            get => _status_seat;
            private set
            {
                _status_seat = value;
            }
        }
        public ChoiseSeat(int NumberSeat, bool StatusSeat)
        {
            _num_seat = NumberSeat;
            _status_seat = StatusSeat;

        }


    }
}
