using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLaba10.Model;

namespace WpfLaba10.DataBase
{
    public class AirplaneContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Produser> Produsers { get; set; }
    }
}
