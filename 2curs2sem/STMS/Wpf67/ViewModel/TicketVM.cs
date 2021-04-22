using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf67.Model;

namespace Wpf67.ViewModel
{
    public class TicketVM
    {
        Ticket ticket;

        TicketVM(Ticket ticket, string date)
        {
            this.ticket = ticket;
        }

    }
}
