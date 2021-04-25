using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf67.Command;

namespace Wpf67.ViewModel
{
    class AdminWindowVM
    {
        public AdminWindowVM()
        {

        }

        public IMMCodeBehind CodeBehind { get; set; }

        private MyCommand deleteRowTable;
        public MyCommand LoadContactsPage
        {
            get
            {
                
                return deleteRowTable = deleteRowTable ??
                  new MyCommand(DeleteRowTable, CanDeleteRowTable);
            }
        }
        private bool CanDeleteRowTable()
        {
            
            return true;
        }
        private void DeleteRowTable()
        {
            CodeBehind.LoadView(ViewType.Contacts);
        }
    }
}
