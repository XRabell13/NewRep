using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf67.Command;

namespace Wpf67.ViewModel
{
    class ContactsVM
    {
       public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private IMMCodeBehind mainWindow;

        public ContactsVM(IMMCodeBehind win)
        {
            if (win == null) throw new ArgumentNullException(nameof(win));
            mainWindow = win;
        }

        
        private MyCommand loadContacts;
        public MyCommand LoadContactsPage
        {
            get
            {
                return loadContacts = loadContacts ??
                  new MyCommand(ShowContactsPage, CanLoadContactsPage);
            }
        }
        private bool CanLoadContactsPage()
        {
            return true;
        }
        private void ShowContactsPage()
        {
           mainWindow.LoadView(ViewType.Contacts);
        }
    }
}
