using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf67.Command;
using Wpf67.View;

namespace Wpf67.ViewModel
{
    class AuthorizationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private MainWindow mainWindow;
        private UserControl authorizControl;
        public AuthorizationVM(MainWindow win)
        {
            if (win == null) throw new ArgumentNullException(nameof(win));
            mainWindow = win;
        }
        public AuthorizationVM(UserControl uc)
        {
            if (uc == null) throw new ArgumentNullException(nameof(uc));
            authorizControl = uc;
          
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
            Registration reg = new Registration();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            mainWindow.OutWin.Content = reg;
        }



    }
}
