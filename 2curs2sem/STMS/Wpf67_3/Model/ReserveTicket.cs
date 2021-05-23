using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf67.Model
{
    class ReserveTicket
    {
  
       public string id_ut, id_epoint;
        public ReserveTicket(string id_epoint, string id_ut)
        {
            this.id_epoint = id_epoint;
            this.id_ut = id_ut;
         
        }


    }
}
