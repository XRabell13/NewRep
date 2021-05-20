using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf67.DataBase;
using Wpf67.View;
using Wpf67.ViewModel;

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public interface IMMCodeBehind
    {
       // void ShowMessage(string message);
        void LoadView(ViewType typeView);
        void LoadViewWhithParam(ViewType typeView, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9);
        void ButExitAccount();
        void ButEnterAccount();
    }

    public enum ViewType
    {
        Contacts,
        Authorization,
        Registration,
        Search,
        FindRoutes,
        MyTrips,
        NoAuthorizationTrips,
        AdminWin,
        ChoiseSeat,
        ReserveTicket
    }
    public partial class MainWindow : Window, IMMCodeBehind
    {
       
        public MainWindow()
        {

            InitializeComponent();

            //  App.LanguageChanged += LanguageChanged;

            //  CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            /*menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }*/
            DataBaseLoad db = new DataBaseLoad();

            if (db.chekInternet.IsConnected())
            {
                this.Loaded += MainWindow_Loaded;

                if (Wpf67.Properties.Settings.Default.Authoriz)
                {
                    ButEnterAccount();
                }
            }
            else MessageBox.Show("Проверьте подключение к интернету");
          
          
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MenuVM vm = new MenuVM();
            vm.CodeBehind = this;
            this.DataContext = vm;//привязка данных к окну, из этой модели берутся даннные
            
            LoadView(ViewType.Search);
        }

        public void LoadView(ViewType typeView)//привязка view к viewModel и отображение
        {
            switch (typeView)
            {
                case ViewType.Contacts:
                    {
                        Contacts view = new Contacts();
                        ContactsVM vm = new ContactsVM(this);
                        view.DataContext = vm;
                        this.OutWin.Content = view;
                        break;
                    }
                case ViewType.Registration:
                    {
                      
                        Registration view = new Registration();
                        RegistrationVM vm = new RegistrationVM(this);
                        view.DataContext = vm;
                        this.OutWin.Content = view;
                        break;
                    }
                case ViewType.Authorization:
                    {
                        Authorization view = new Authorization();
                        AuthorizationVM vm = new AuthorizationVM(this);
                        view.DataContext = vm;
                        this.OutWin.Content = view;
                        break;

                    }
                    case ViewType.Search:
                        {
                        SearchVM vm = new SearchVM(this);
                            Search view = new Search();
                          view.DataContext = vm;
                            this.OutWin.Content = view;
                            break;
                        }
                    case ViewType.MyTrips:
                        {
                        MyTripsVM vm = new MyTripsVM(this);
                            MyTrips view = new MyTrips();
                         view.DataContext = vm;
                            this.OutWin.Content = view;
                            break;
                        }
                case ViewType.NoAuthorizationTrips:
                    {
                        NoAuthorizationTripsVM vm = new NoAuthorizationTripsVM(this);
                        NoAuthorizationTrips view = new NoAuthorizationTrips();
                        view.DataContext = vm;
                        this.OutWin.Content = view;
                        break;
                    }
                case ViewType.AdminWin:
                    {
                        AdminControl view = new AdminControl();
                        AdminWindowVM vm = new AdminWindowVM();
                        view.DataContext = vm;
                        this.OutWin.Content = view;
                        break;
                    }
              
            }
        }

      public void LoadViewWhithParam(ViewType typeView, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9)
        {
            switch (typeView)
            {
                case ViewType.FindRoutes:
                    {
                        FindRoutes view = new FindRoutes();
                        FindRoutesVM vm = new FindRoutesVM(this, Convert.ToString(param1),Convert.ToString(param2), (DateTime)param3);
                        view.DataContext = vm;
                        this.OutWin.Content = view;
                        break;
                    }
                case ViewType.ChoiseSeat:
                    {
                        try
                        {
                            ChoiseSeat view = new ChoiseSeat();
                            ChoiseSeatVM vm = new ChoiseSeatVM(this, Convert.ToInt32(param1), Convert.ToString(param2), Convert.ToString(param3), (DateTime)param4, Convert.ToDecimal(param5), 
                                Convert.ToString(param6), Convert.ToString(param7));
                            view.DataContext = vm;
                            this.OutWin.Content = view;
                        }
                        catch (Exception a) { MessageBox.Show(a.Message +"\n\n"+a.StackTrace); }
                        break;
                    }
                case ViewType.ReserveTicket:
                    {
                        try
                        {
                            ReserveTicket view = new ReserveTicket();
                            ReserveTicketVM vm = new ReserveTicketVM(this, Convert.ToString(param1), Convert.ToString(param2), Convert.ToDecimal(param3), 
                                Convert.ToString(param4), Convert.ToString(param5), Convert.ToInt32(param6), Convert.ToString(param7), Convert.ToString(param8), Convert.ToString(param9));
                            view.DataContext = vm;
                            this.OutWin.Content = view;
                        }
                        catch (Exception a) { MessageBox.Show(a.Message + "\n\n" + a.StackTrace); }
                        break;
                    }

            }

        }


        /*
        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }*/


        public void ButExitAccount()
        {
                Collapse_AuthorizationButtons();
                Show_RegistrationButtons();
        }

        public void ButEnterAccount()
        {
     
            Show_AuthorizationButtons();
            Collapse_RegistrationButtons();
        }

        public void Collapse_AuthorizationButtons()
        {
            butExit.Visibility = Visibility.Collapsed;
            butAdminWin.Visibility = Visibility.Collapsed;
        }
        public void Show_AuthorizationButtons()
        {
            butExit.Visibility = Visibility.Visible;
            if (Wpf67.Properties.Settings.Default.IsAdmin)
            {
                butTrips.Visibility = Visibility.Collapsed;
                butAdminWin.Visibility = Visibility.Visible;
            }
            else
            {
                butTrips.Visibility = Visibility.Visible;
                butAdminWin.Visibility = Visibility.Collapsed;
            }
        }

        public void Show_RegistrationButtons()
        {
            butLogin.Visibility = Visibility.Visible;
            butTrips.Visibility = Visibility.Visible;

        }
        public void Collapse_RegistrationButtons()
        {
            butLogin.Visibility = Visibility.Collapsed;
        }
     

    }
}
