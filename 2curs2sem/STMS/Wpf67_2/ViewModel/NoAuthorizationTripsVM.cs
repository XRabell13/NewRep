using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf67.Command;


namespace Wpf67.ViewModel
{
    class NoAuthorizationTripsVM
    {
        IMMCodeBehind codeBehind { get; set; }
      
       public NoAuthorizationTripsVM(IMMCodeBehind nat)
        {
            if (nat == null) throw new ArgumentNullException(nameof(nat));
           codeBehind = nat;
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
            codeBehind.LoadView(ViewType.Registration);
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
            codeBehind.LoadView(ViewType.Authorization);
        }

    }
}
