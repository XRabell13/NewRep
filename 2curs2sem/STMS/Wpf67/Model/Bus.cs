using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
  public  class Bus
    {
        public int id_bus { get; set; }
        public string id_transporter { get; set; }
        public string model { get; set; }
        public int count_seats { get; set; }

        public Bus(int id_bus, string id_transporter, string model, int count_seats)
        {
            this.id_bus = id_bus;
            this.id_transporter = id_transporter;
            this.model = model;
            this.count_seats = count_seats;
        }

        public override string ToString()
        {
            return id_bus.ToString() + " " + model;
        }
    }
}
