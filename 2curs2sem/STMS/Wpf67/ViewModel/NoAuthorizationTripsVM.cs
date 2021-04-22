using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf67.Command;
using Wpf67.View;

namespace Wpf67.ViewModel
{
    class NoAuthorizationTripsVM
    {
        IMainWindowsCodeBehind codeBehind { get; set; }
        NoAuthorizationTrips nat;
       public NoAuthorizationTripsVM(NoAuthorizationTrips nat)
        {
            this.codeBehind = (MainWindow)Application.Current.MainWindow;
            this.nat = nat;
        }

        private MyCommand loadRegist;
        public MyCommand MoveRegistrationPage
        {
            get
            {
                return loadRegist = loadRegist ??
                      new MyCommand(ShowRegistPage, CanLoadRegistrationPage);
                

            }
        }
        private bool CanLoadRegistrationPage()
        {
            return true;
        }
        private void ShowRegistPage()
        {
            Registration reg = new Registration();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            mainWindow.OutWin.Content = reg;
        }

        private MyCommand loadAuthorization;
        public MyCommand MoveAuthorizationPage
        {
            get
            {
                return loadAuthorization = loadAuthorization ??
                new MyCommand(ShowAuthorizPage, CanLoadAuthorizationPage);
            }
        }
    
        private bool CanLoadAuthorizationPage()
        {
            return true;
        }
        private void ShowAuthorizPage()
        {
            Authorization reg = new Authorization();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            mainWindow.OutWin.Content = reg;
        }

    }
}
