using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
    public class Transporter
    {
        public int id { get; set; }
        public string named { get; set; }
        public string adress { get; set; }
        public string telephone { get; set; }

        public Transporter(int id, string login, string password, string telephone)
        {
            this.id = id;
            this.named = login;
            this.adress = password;
            this.telephone = telephone;
        }

        public override string ToString()
        {
            return id.ToString() + " " + named;
        }
    }
}
