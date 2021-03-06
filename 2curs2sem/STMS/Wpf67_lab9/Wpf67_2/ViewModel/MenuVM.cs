﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf67.Command;
using Wpf67.DataBase;

namespace Wpf67.ViewModel
{
    class MenuVM
    {
        public MenuVM()
        {

        }

        public IMMCodeBehind CodeBehind { get; set; }
        DataBaseLoad baseLoad = new DataBaseLoad();

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
            CodeBehind.LoadView(ViewType.Contacts);
        }


        private MyCommand loadRegist;
        public MyCommand LoadRegistrationPage
        {
            get
            {
                return loadRegist = loadRegist ??
                  new MyCommand(ShowRegistrationPage, CanLoadRegistrationPage);
            }
        }
        private bool CanLoadRegistrationPage()
        {
            return true;
        }
        private void ShowRegistrationPage()
        {
           CodeBehind.LoadView(ViewType.Registration);
        }


        private MyCommand loadAuthoriz;
        public MyCommand LoadAuthorizationPage
        {
            get
            {
                return loadAuthoriz = loadAuthoriz ??
                  new MyCommand(ShowAuthorizationPage, CanLoadAuthorizationPage);
            }
        }
        private bool CanLoadAuthorizationPage()
        {
            return true;
        }
        private void ShowAuthorizationPage()
        {
            CodeBehind.LoadView(ViewType.Authorization);
        }


        private MyCommand loadSearch;
        public MyCommand LoadSearchPage
        {
            get
            {
                return loadSearch = loadSearch ??
                  new MyCommand(ShowSearchPage, CanLoadSearchPage);
            }
        }
        private bool CanLoadSearchPage()
        {
            return true;
        }
        private void ShowSearchPage()
        {
            CodeBehind.LoadView(ViewType.Search);
        }


        private MyCommand loadMyTripsPage;
        public MyCommand LoadMyTripsPage
        {
            get
            {
                return loadMyTripsPage = loadMyTripsPage ??
                  new MyCommand(ShowMyTripsPage, CanMyTripsPage);
            }
        }
        private bool CanMyTripsPage()
        {
            return true;
        }
        private void ShowMyTripsPage()
        {
            if (Wpf67.Properties.Settings.Default.Authoriz)
                CodeBehind.LoadView(ViewType.MyTrips);
            else
                CodeBehind.LoadView(ViewType.NoAuthorizationTrips);
        }


        private MyCommand loadAdminWin;
        public MyCommand LoadAdminWin
        {
            get
            {
                return loadAdminWin = loadAdminWin ??
                  new MyCommand(ShowAdminWin, CanAdminWin);
            }
        }
        private bool CanAdminWin()
        {
            return true;
        }
        private void ShowAdminWin()
        {
          
            if (baseLoad.chekInternet.IsConnected())
            {
                   CodeBehind.LoadView(ViewType.AdminWin);
            }
            else MessageBox.Show("Проверьте подключение к интернету.");
       
            }


        private MyCommand exitAccount;
        public MyCommand ExitAccount
        {
            get
            {
                return exitAccount = exitAccount ??
                  new MyCommand(OnExitAccount, CanExitAccount);
            }
        }
        private bool CanExitAccount()
        {
            return true;
        }
        private void OnExitAccount()
        {
            var Result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Wpf67.Properties.Settings.Default.UserId = 0;
            Wpf67.Properties.Settings.Default.Authoriz = false;
            Wpf67.Properties.Settings.Default.IsAdmin = false;
            Wpf67.Properties.Settings.Default.Save();
            CodeBehind.ButExitAccount();
            CodeBehind.LoadView(ViewType.Authorization);
            }
            else if (Result == MessageBoxResult.No)
            {
                
            }
        }
    }
}
