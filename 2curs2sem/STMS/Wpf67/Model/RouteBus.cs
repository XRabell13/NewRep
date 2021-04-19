using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
  public  class RouteBus
    {
        public int id_route { get; set; }
        public string name_route { get; set; }
        public int id_bus { get; set; }
        public string time_departure { get; set; }
        public string timetable { get; set; }
        public int id_departure_point { get; set; }
        public int id_end_city { get; set; }

        public RouteBus(int id_route, string name_route, int id_b, string time_departure, string timetable, int id_departure_point, int id_end_city)
        {
            this.id_bus = id_b;
            this.id_route = id_route;
            this.id_departure_point = id_departure_point;
            this.id_end_city = id_end_city;
            this.timetable = timetable;
            this.time_departure = time_departure;
            this.name_route = name_route;
        }

        public override string ToString()
        {
            return id_bus.ToString();
        }


    }
}
