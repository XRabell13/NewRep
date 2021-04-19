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

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public interface IMainWindow
        {
            void ShowMessage(string message);
            void LoadView(ViewType typeView);
            //        void UpUserId();
            void Check_Autorization();
            void ShowLoadIndicator();
            void CollapseLoadIndicator();
            void HeadButAuthorization();
            void ButExitAccount();
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
        }
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
        }
        public void LoadView(ViewType typeView)
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
                        F viewF = new Forum_main();
                        Forum_mainViewModel vmF = new Forum_mainViewModel(this);
                        viewF.DataContext = vmF;
                        this.OutWin.Content = viewF;
                        break;

                    }
                case ViewType.Forum_topic:
                    {
                        Forum_topic viewF = new Forum_topic();
                        Forum_topicViewModel vmF = new Forum_topicViewModel(this);
                        viewF.DataContext = vmF;
                        this.OutputView.Content = viewF;
                        break;
                    }
                case ViewType.User_room:
                    {
                        User_Room viewF = new User_Room();
                        User_RoomViewModel vmF = new User_RoomViewModel(this);
                        viewF.DataContext = vmF;
                        this.OutputView.Content = viewF;
                        break;
                    }
                case ViewType.AutoPark:
                    {
                        AutoPark viewF = new AutoPark();
                        AutoParkViewModel vmF = new AutoParkViewModel(this);
                        viewF.DataContext = vmF;
                        this.OutputView.Content = viewF;
                        break;
                    }
                case ViewType.AddCar:
                    {
                        AddCar viewF = new AddCar();
                        AddCarViewModel vmF = new AddCarViewModel(this);
                        viewF.DataContext = vmF;
                        this.OutputView.Content = viewF;
                        break;
                    }
                case ViewType.Auctions:
                    {
                        Auctions viewF = new Auctions();
                        AuctionsViewModel vmF = new AuctionsViewModel(this);
                        viewF.DataContext = vmF;
                        this.OutputView.Content = viewF;
                        break;
                    }
                case ViewType.Auction:
                    {
                        ver03.Views.Auction viewF = new ver03.Views.Auction();
                        AuctionViewModel vmF = new AuctionViewModel(this);
                        viewF.DataContext = vmF;
                        this.OutputView.Content = viewF;
                        break;
                    }
                case ViewType.AddAuction:
                    {
                        AddAuction viewF = new ver03.Views.AddAuction();
                        AddAuctionViewModel vmF = new AddAuctionViewModel(this);
                        viewF.DataContext = vmF;
                        this.OutputView.Content = viewF;
                        break;
                    }
                case ViewType.Info:
                    {
                        Info viewF = new ver03.Views.Info();
                        InfoViewModel vmF = new InfoViewModel(this);
                        viewF.DataContext = vmF;
                        this.OutputView.Content = viewF;
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



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            this.OutWin.Content = reg;

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Search reg = new Search();
            this.OutWin.Content = reg;

        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            View.Settings reg = new View.Settings();
            this.OutWin.Content = reg;

        }
    }
}
