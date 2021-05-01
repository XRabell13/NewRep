﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using Wpf67.ViewModel;

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        DataBaseLoad baseLoad = new DataBaseLoad();

       // List<User> users = new List<User>();
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

       // List<UserTicket> userTickets = new List<UserTicket>();
        // List<UserTicket> userTicketsUpdate = new List<UserTicket>();

        public AdminWindow()
        {
            InitializeComponent();
            this.DataContext = new AdminWindowVM();
            // LoadDataBase();
            //   UpdateDataGrid();
        }

        void LoadDataBase()
        {
         //users = baseLoad.GetUsers();
           // cities = baseLoad.GetCities();
          /*  buses = baseLoad.GetBuses();
            intermediatePoints = baseLoad.GetInterPoints();
            routeBuses = baseLoad.GetRouteBuses();
            tickets = baseLoad.GetTickets();
            usersInfo = baseLoad.GetUsersInfo();
            transporters = baseLoad.GetTransporters();*/
        }

        void UpdateDataGrid()
        {
         //  dg_users.ItemsSource = users;
          // ((ComboBox)FindName("cb_users")).ItemsSource = users;

            dg_cities.ItemsSource = cities;
            ((ComboBox)FindName("cb_cities")).ItemsSource = cities;

            dg_buses.ItemsSource = buses;
            ((ComboBox)FindName("cb_buses")).ItemsSource = buses;

            dg_intermediate_points.ItemsSource = intermediatePoints;
            ((ComboBox)FindName("cb_intermediate_points")).ItemsSource = intermediatePoints;

            dg_route_buses.ItemsSource = routeBuses;
            ((ComboBox)FindName("cb_route_bus")).ItemsSource = routeBuses;

            dg_tickets.ItemsSource = tickets;

            dg_users_info.ItemsSource = usersInfo;
            ((ComboBox)FindName("cb_users_info")).ItemsSource = usersInfo;

            dg_transporters.ItemsSource = transporters;
            ((ComboBox)FindName("cb_transporters")).ItemsSource = transporters;


        }
        /*
        private void dg_users_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            usersUpdate.Add((User)(dg_users.SelectedItem));
          
        }
        private void dg_cities_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            citiesUpdate.Add((City)(dg_cities.SelectedItem));
           
        }
        private void dg_transporters_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            transportersUpdate.Add((Transporter)(dg_transporters.SelectedItem));
        }
        private void dg_buses_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            busesUpdate.Add((Bus)(dg_buses.SelectedItem));
          
        }
        private void dg_ipoints_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            intermediatePointsUpdate.Add((IntermediatePoint)(dg_intermediate_points.SelectedItem));
           
        }
        private void dg_route_bus_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            routeBusesUpdate.Add((RouteBus)(dg_route_buses.SelectedItem));
        }
        private void dg_tickets_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ticketsUpdate.Add((Ticket)(dg_tickets.SelectedItem));
          
        }

        private void But_UpLoad(object sender, RoutedEventArgs e)
        {
            if (usersUpdate.Count > 0 || usersInfoUpdate.Count > 0 || citiesUpdate.Count > 0 ||
                busesUpdate.Count > 0 || transportersUpdate.Count > 0 || intermediatePoints.Count > 0
                || ticketsUpdate.Count > 0 || routeBusesUpdate.Count > 0)
            {
                if (usersUpdate.Count > 0)
                {
                    baseLoad.UpdateUsers(usersUpdate);
                    usersUpdate = new List<User>();
                }

                if (transportersUpdate.Count > 0)
                {
                    baseLoad.UpdateTransporters(transportersUpdate);
                    transportersUpdate = new List<Transporter>();
                }
                if (busesUpdate.Count > 0)
                {
                    baseLoad.UpdateBuses(busesUpdate);
                    busesUpdate = new List<Bus>();
                }
                if (intermediatePointsUpdate.Count > 0)
                {
                    baseLoad.UpdateIntermediatePoints(intermediatePointsUpdate);
                    intermediatePointsUpdate = new List<IntermediatePoint>();
                }
                if (ticketsUpdate.Count > 0)
                {
                    baseLoad.UpdateTickets(ticketsUpdate);
                    ticketsUpdate = new List<Ticket>();
                }
                if (routeBusesUpdate.Count > 0)
                {
                    baseLoad.UpdateRouteBuses(routeBusesUpdate);
                    routeBusesUpdate = new List<RouteBus>();
                }
                if (citiesUpdate.Count > 0)
                {
                    baseLoad.UpdateCities(citiesUpdate);
                    routeBusesUpdate = new List<RouteBus>();
                }
                LoadDataBase();
                UpdateDataGrid();
            }
            else
                MessageBox.Show("Изменений не обнаружено.");

        }
     
        private void DeleteTransporter(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)FindName("cb_transporters")).SelectedItem != null)
            {
                baseLoad.DeleteTransporter((Transporter)(((ComboBox)FindName("cb_transporters")).SelectedItem));
                LoadDataBase();
                UpdateDataGrid();
            }
        }
        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)FindName("cb_users")).SelectedItem != null)
            {
                MessageBox.Show(cb_users.SelectedItem.ToString());
            }
          
        }
        private void DeleteBus(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)FindName("cb_buses")).SelectedItem != null)
            {
                baseLoad.DeleteBus((Bus)(((ComboBox)FindName("cb_buses")).SelectedItem));
                LoadDataBase();
                UpdateDataGrid();
            }
        }
        private void DeleteCity(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)FindName("cb_cities")).SelectedItem != null)
            {
                baseLoad.DeleteCity((City)(((ComboBox)FindName("cb_cities")).SelectedItem));
                LoadDataBase();
                UpdateDataGrid();
            }
        }
        private void DeleteIntermediatePoint(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)FindName("cb_intermediate_points")).SelectedItem != null)
            {
                baseLoad.DeleteInterPoint((IntermediatePoint)(((ComboBox)FindName("cb_intermediate_points")).SelectedItem));
                LoadDataBase();
                UpdateDataGrid();
            }
        }
        private void DeleteUserInfo(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)FindName("cb_users_info")).SelectedItem != null)
            {
                baseLoad.DeleteUserInf((UserInfo)(((ComboBox)FindName("cb_users_info")).SelectedItem));
                LoadDataBase();
                UpdateDataGrid();
            }
        }
        private void DeleteRouteBus(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)FindName("cb_route_bus")).SelectedItem != null)
            {
                baseLoad.DeleteRouteBus((RouteBus)(((ComboBox)FindName("cb_route_bus")).SelectedItem));
                LoadDataBase();
                UpdateDataGrid();
            }
        }*/
    }
}
