using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Wpf67.Model;

namespace Wpf67.DataBase
{
    class DataBaseLoad:Connect
    {
        public bool AddCities(string name_cities)
        {
            try
            {
                string sql1 = "INSERT INTO cities(`name_city`) VALUES('" + name_cities + "'); ";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                Open();
                myCommand.ExecuteNonQuery();
                Close();
                return true;

            }
            catch
            {
                MessageBox.Show("Ошибка загрузки");
                return false;
            }
        }
        public void UpdateCities(List<City> cities)
        {
            Open();
            foreach (var city in cities)
            {
                string sql1 = "UPDATE cities SET `name_city`='" + city.name_city + "' WHERE `id`='" +  city.id_city.ToString() + "';";
                try
                {
                    MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                    myCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка  \n " + ex.Message);
                }
            }
            Close();

        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from users;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    users.Add(new User(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                        reader[2].ToString(), Convert.ToInt32(reader[3].ToString())));
                Close();
                reader.Close();
                return users;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу Users");
                Close();
                return null;
            }

        }

        public List<UserInfo> GetUsersInfo()
        {
            List<UserInfo> usersInfo = new List<UserInfo>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from users_info;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    usersInfo.Add(new UserInfo(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                        reader[2].ToString(), reader[3].ToString()));
                Close();
                reader.Close();
                return usersInfo;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу users_info");
                Close();
                return null;
            }
        }

        public List<City> GetCities()
        {
            List<City> users = new List<City>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from cities;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    users.Add(new City(Convert.ToInt32(reader[0].ToString()), reader[1].ToString()));
                Close();
                reader.Close();
                return users;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу City");
                Close();
                return null;
            }

        }
        public List<Bus> GetBuses()
        {
            List<Bus> buses = new List<Bus>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from bus;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    buses.Add(new Bus(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), 
                        reader[2].ToString(), Convert.ToInt32(reader[3].ToString())));
                Close();
                reader.Close();
                return buses;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу Bus");
                Close();
                return null;
            }

        }

        public List<IntermediatePoint> GetInterPoints()
        {
            List<IntermediatePoint> iPoints = new List<IntermediatePoint>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from intermediate_point;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    iPoints.Add(new IntermediatePoint(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), 
                        Convert.ToInt32(reader[2].ToString()), reader[3].ToString(), Convert.ToSingle(reader[4])));
                Close();
                reader.Close();
                return iPoints;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу IntermediatePoints");
                Close();
                return null;
            }
        }

        public List<RouteBus> GetRouteBuses()
        {
            List<RouteBus> routeBuses = new List<RouteBus>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from route_bus;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    routeBuses.Add(new RouteBus(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                        Convert.ToInt32(reader[2].ToString()), reader[3].ToString(), 
                        reader[4].ToString(), Convert.ToInt32(reader[5].ToString()),Convert.ToInt32(reader[6].ToString())));
                Close();
                reader.Close();
                return routeBuses;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу route_bus");
                Close();
                return null;
            }
        }

        public List<Ticket> GetTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from tickets;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    tickets.Add(new Ticket(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()),
                    reader[2].ToString(), Convert.ToInt32(reader[3].ToString()), Convert.ToInt32(reader[4].ToString())));
                Close();
                reader.Close();
                return tickets;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу Ticket");
                Close();
                return null;
            }

        }

    }
}
