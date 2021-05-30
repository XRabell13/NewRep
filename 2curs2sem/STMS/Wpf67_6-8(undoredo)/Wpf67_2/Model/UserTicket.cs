using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
   public class UserTicket
    {
        public int id_user_t { get; set; }
        public int id_user { get; set; }
        public int  num_ticket { get; set; }
        public int id_departure_point { get; set; }
        public DateTime date_reserve { get; set; }

        public UserTicket(int id_ut, int id_user, int num_ticket, int id_departure_point, DateTime date_reserve)
        {
            this.id_user_t = id_ut;
            this.id_user = id_user;
            this.num_ticket = num_ticket;
            this.id_departure_point = id_departure_point;
            this.date_reserve = date_reserve;
        }

        public override string ToString()
        {
            return id_user_t.ToString() + " " + id_user;
        }
    }
}
