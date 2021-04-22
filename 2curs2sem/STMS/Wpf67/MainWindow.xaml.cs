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
using Wpf67.View;
using Wpf67.ViewModel;

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public interface IMainWindowsCodeBehind
    {
       // void ShowMessage(string message);
        void LoadView(ViewType typeView);
        void ButExitAccount();
        void ButEnterAccount();
    }

    public enum ViewType
    {
        Contacts,
        Authorization,
        Registration,
        Search,
        FindReise,
        BookInf,
        MyTrips,
        NoAuthorizationTrips,
    }
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
       
        public MainWindow()
        {
            InitializeComponent();

            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }

            this.Loaded += MainWindow_Loaded;

            if (Wpf67.Properties.Settings.Default.Authoriz)
            {
                ButEnterAccount();
            }
          
          
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
                        this.OutWin.Content = view;
                        break;
                    }
                case ViewType.Registration:
                    {
                      
                        Registration view = new Registration();
                        this.OutWin.Content = view;
                        break;
                    }
                case ViewType.Authorization:
                    {
                        Authorization view = new Authorization();
                        this.OutWin.Content = view;
                        break;

                    }
                    case ViewType.Search:
                        {
                            Search view = new Search();
                            this.OutWin.Content = view;
                            break;
                        }
                    case ViewType.MyTrips:
                        {
                            MyTrips view = new MyTrips();
                            this.OutWin.Content = view;
                            break;
                        }
                case ViewType.NoAuthorizationTrips:
                    {
                        NoAuthorizationTrips view = new NoAuthorizationTrips();
                        this.OutWin.Content = view;
                        break;
                    }
            }
        }
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

        }
     
       
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
