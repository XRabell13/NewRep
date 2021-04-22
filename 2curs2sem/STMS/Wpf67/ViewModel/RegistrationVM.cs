using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Wpf67.Command;
using System.Windows.Controls;
using System.Threading;
using Wpf67.DataBase;

namespace Wpf67
{
    public class RegistrationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private UserControl registControl;
        private MainWindow mainWin;

        RegistrationUser regist = new RegistrationUser();
        AuthorizationUser authoriz = new AuthorizationUser();

        public RegistrationVM(UserControl uc)
        {
            if (uc == null) throw new ArgumentNullException(nameof(uc));
            registControl = uc;
        }

        public RegistrationVM(MainWindow mw)
        {
            if (mw == null) throw new ArgumentNullException(nameof(mw));
           mainWin = mw;
        }

        private MyCommand moveAuthoriz;
        public MyCommand MoveAuthorizationPage
        {
            get
            {
                return moveAuthoriz = moveAuthoriz ??
                  new MyCommand(ShowAuthoriz, CanShowAuthoriz);
            }
        }
        private bool CanShowAuthoriz()
        {
            return true;
        }
        private void ShowAuthoriz()
        {
            Authorization reg = new Authorization();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            
            mainWindow.OutWin.Content = reg;
        }

        private MyCommand RegistNewUser;
        public MyCommand RegistrarionNewUser
        {
            get
            {
                return RegistNewUser = RegistNewUser ??
                  new MyCommand(RegNewUser, CanRegNewUser);
            }
        }

        private bool CanRegNewUser()
        {
            return true;
        }
        private void RegNewUser()
        {
          //  Thread thread = new Thread(Regist_new_User);
            //thread.Start();
            
        }


    }
}
