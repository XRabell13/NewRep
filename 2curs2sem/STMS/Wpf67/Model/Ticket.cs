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
        public int status_seat { get; set; }
        public string date_departure { get; set; }//DateTime

        public Ticket(int id_t, int id_route, string date_departure, int num_seat, int status_seat)
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
