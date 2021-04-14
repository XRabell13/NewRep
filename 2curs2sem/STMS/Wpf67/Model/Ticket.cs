using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
   public class Ticket
    {
        public int id_ticket { get; set; }
        public int id_route { get; set; }
        public int num_seat { get; set; }
        public bool status_seat { get; set; }
        public DateTime date_departure { get; set; }

        public Ticket(int id_t, int id_user, int num_ticket, bool status_seat, DateTime date_reserve)
        {
            this.id_ticket = id_t;
            this.id_route = id_user;
            this.num_seat = num_ticket;
            this.status_seat = status_seat;
            this.date_departure = date_reserve;
        }

        public override string ToString()
        {
            return id_ticket.ToString() + " " + id_route;
        }
    }
}
