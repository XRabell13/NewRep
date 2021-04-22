using System;
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

        //Индекс столбца для отображения элемента
        int columnIndex = 0;

        //Индекс ячейки для отображения элемента
        int rowIndex = 0;

        //Создаем comboBox
        ComboBox comboBox = new ComboBox();
        /*
        private void Form1_Load(object sender, EventArgs e)
        {
            //Скрываем элемент
            comboBox.Visible = false;

            //Создаем перечисление значений
            string[] arrayItem = { "Занчение1", "Занчение2", "Занчение3", "Занчение4", "Занчение5", "и.т.д" };
            comboBox.Items.AddRange(arrayItem);

            //Создаем обработчик события(выбор из списка)
            comboBox.SelectedValueChanged += comboBox_SelectedValueChanged;

            //Добавляем элемент
            dataGridView1.Controls.Add(comboBox);

        }

        //Событие происходит всякий раз, при выборе значения из списка
        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //Заносим данные в ячейку
            dataGridView1[columnIndex, rowIndex].Value = comboBox.SelectedItem;

            //Скрываем элемент
            comboBox.Visible = false;
        }

        //Событие происходит всякий раз, при клике по ячейкам
     /*   private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Задаем индекс строки
            rowIndex = e.RowIndex;

            //получаем прямоугольник ячейки
            Rectangle rectangle = dataGridView1.GetCellDisplayRectangle(columnIndex, rowIndex, true);

            //Задаем размеры и месторасположение
            comboBox.Size = new Size(rectangle.Width, rectangle.Height);
            comboBox.Location = new Point(rectangle.X, rectangle.Y);

            //Показываем элемент
            comboBox.Visible = true;
        }*/


        public AdminWindow()
        {
            InitializeComponent();
            if (baseLoad.chekInternet.IsConnected())
            {
                LoadDataBase();
                UpdateDataGrid();
            }
            else MessageBox.Show("Проверьте подключение к интернету.");
          
        }

        void LoadDataBase()
        {
            users = baseLoad.GetUsers();
            cities = baseLoad.GetCities();
            buses = baseLoad.GetBuses();
            intermediatePoints = baseLoad.GetInterPoints();
            routeBuses = baseLoad.GetRouteBuses();
            tickets = baseLoad.GetTickets();
            usersInfo = baseLoad.GetUsersInfo();
            transporters = baseLoad.GetTransporters();
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
           // ((ComboBox)FindName("cb_users")).ItemsSource = users;
            
            dg_cities.ItemsSource = cities;
          //  ((ComboBox)FindName("cb_cities")).ItemsSource = cities;

            dg_buses.ItemsSource = buses;
          //  ((ComboBox)FindName("cb_buses")).ItemsSource = buses;

            dg_intermediate_points.ItemsSource = intermediatePoints;
          //  ((ComboBox)FindName("cb_intermediate_points")).ItemsSource = intermediatePoints;

            dg_route_buses.ItemsSource = routeBuses;
          // ((ComboBox)FindName("cb_route_bus")).ItemsSource = routeBuses;

            dg_tickets.ItemsSource = tickets;

            dg_users_info.ItemsSource = usersInfo;
           // ((ComboBox)FindName("cb_users_info")).ItemsSource = usersInfo;

            dg_transporters.ItemsSource = transporters;
          //  ((ComboBox)FindName("cb_transporters")).ItemsSource = transporters;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Del");
        }
    }
}
