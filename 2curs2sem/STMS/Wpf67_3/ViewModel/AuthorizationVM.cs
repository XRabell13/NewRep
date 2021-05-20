using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf67.Command;

namespace Wpf67.ViewModel
{
    class AuthorizationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private IMMCodeBehind mainWindow;
        
        public AuthorizationVM(IMMCodeBehind win)
        {
            if (win == null) throw new ArgumentNullException(nameof(win));
            mainWindow = win;
        }
       

        private MyCommand loadRegist;
        public MyCommand MoveRegistrationPage
        {
            get
            {
                return loadRegist = loadRegist ??
                  new MyCommand(ShowAuthorizPage, CanLoadAuthorizationPage);
            }
        }
        private bool CanLoadAuthorizationPage()
        {
            return true;
        }
        private void ShowAuthorizPage()
        {
            mainWindow.LoadView(ViewType.Registration);
        }



    }
}
