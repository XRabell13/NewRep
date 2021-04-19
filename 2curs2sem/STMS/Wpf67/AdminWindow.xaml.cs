using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Wpf67.DataBase;
using Wpf67.Model;
using Wpf67.View;

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        DataBaseLoad baseLoad = new DataBaseLoad();
      //  DBFillAdmin dbf = new DBFillAdmin();

        List<User> users = new List<User>();
        List<User> usersUpdate = new List<User>();

        List<UserInfo> usersInfo = new List<UserInfo>();
        List<UserInfo> usersInfoUpdate = new List<UserInfo>();

        List<City> cities = new List<City>();
        List<City> citiesUpdate = new List<City>();

        List<Bus> buses = new List<Bus>();
        List<Bus> busesUpdate = new List<Bus>();

        List<IntermediatePoint> intermediatePoints = new List<IntermediatePoint>();
        List<IntermediatePoint> intermediatePointsUpdate = new List<IntermediatePoint>();

        List<RouteBus> routeBuses = new List<RouteBus>();
        List<RouteBus> routeBusesUpdate = new List<RouteBus>();

        List<Ticket> tickets = new List<Ticket>();
        List<Ticket> ticketsUpdate = new List<Ticket>();

        List<Transporter> transporters = new List<Transporter>();
        List<Transporter> transportersUpdate = new List<Transporter>();

        List<UserTicket> userTickets = new List<UserTicket>();
        List<UserTicket> userTicketsUpdate = new List<UserTicket>();



        public AdminWindow()
        {
            InitializeComponent();
            LoadDataBase();
            UpdateDataGrid();
        }
        void LoadDataBase()
        {
            users = baseLoad.GetUsers();
            cities = baseLoad.GetCities();
            buses = baseLoad.GetBuses();
            intermediatePoints = baseLoad.GetInterPoints();
            routeBuses = baseLoad.GetRouteBuses();
            tickets = baseLoad.GetTickets();
        }

        /*
        void LoadUsers()
        {
            users = baseLoad.GetUsers();
        }
        void LoadUsersInfo()
        {
            usersInfo = baseLoad.GetUsersInfo();
        }
        void LoadCities()
        {
            cities = baseLoad.GetCities();
        }
        void LoadBuses()
        {
            buses = baseLoad.GetBuses();
        }
        void LoadInterPoints()
        {
            intermediatePoints = baseLoad.GetInterPoints();
        }
        void LoadRouteBuses()
        {
            routeBuses = baseLoad.GetRouteBuses();
        }
        void LoadTickets()
        {
            tickets = baseLoad.GetTickets();
        }
        */

        void UpdateDataGrid()
        {
            dg_users.ItemsSource = users;
            ((ComboBox)FindName("cb_users")).ItemsSource = users;

            dg_users_info.ItemsSource = usersInfo;



        }
    
    }
}
