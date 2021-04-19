using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
    class IntermediatePoint
    {
        public int id_intermediate_point { get; set; }
        public int id_city { get; set; }
        public int id_route_bus { get; set; }
        public float cost { get; set; }
        public string time_arrive { get; set; }

        public IntermediatePoint(int id_intermediate_point, int id_city, int id_route_bus, string time_arrive, float cost)
        {
            this.id_intermediate_point = id_intermediate_point;
            this.id_city = id_city;
            this.id_route_bus = id_route_bus;
            this.cost = cost;
            this.time_arrive = time_arrive;
        }

        public override string ToString()
        {
            return id_intermediate_point.ToString() + " " + id_city;
        }
    }
}
