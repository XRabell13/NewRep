using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
    public class City
    {
        public int id_city { get; set; }
        public string name_city { get; set; }

        public City(int id_city, string name_city)
        {
            this.id_city = id_city;
            this.name_city = name_city;
        }
        public override string ToString()
        {
            return id_city.ToString();
        }
    }
}
