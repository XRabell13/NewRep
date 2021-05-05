using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using Wpf67.Model;

namespace Wpf67.DataBase
{
    /*
      select *
   from route_bus 
   join intermediate_point on route_bus.id_route = intermediate_point.id_route_bus
   and route_bus.timetable like '%1%'
   and route_bus.name_route like '%Минск%' 
   join cities on cities.id_city = intermediate_point.id_city and cities.name_city LIKE '%Радошковичи%' 
   join bus on route_bus.id_bus = bus.state_number 
   join transporters on transporters.id_transporter = bus.id_transporter
 
    select *
   from route_bus 
   join intermediate_point on route_bus.id_route = intermediate_point.id_route_bus
   and route_bus.timetable like '%1%'
   and route_bus.name_route like '%Минск АВ-Центральный%' 
   join cities on cities.id_city = intermediate_point.id_city and cities.name_city LIKE '%Радошковичи%' 
   join bus on route_bus.id_bus = bus.state_number 
   join transporters on transporters.id_transporter = bus.id_transporter
     */
    class DataBaseLoad : Connect
    {
        public bool AddCities(string name_cities)
        {
            try
            {
                string sql1 = "INSERT INTO cities(`name_city`) VALUES(@city); ";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.Parameters.AddWithValue("@city", name_cities);
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

        public bool AddRouteBus(string name_city_begin, string name_city_end, DateTime date)
        {
            try
            {/*
                string sql1 = "INSERT INTO cities(`name_city`) VALUES(@city); ";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.Parameters.AddWithValue("@city", name_cities);
                Open();
                myCommand.ExecuteNonQuery();
                Close();*/


                return true;
                
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки");
                return false;
            }
        }

        #region Update
        public void UpdateCities(List<City> cities)
        {
            Open();
            foreach (var city in cities)
            {
                string sql1 = "UPDATE cities SET `name_city`='" + city.name_city + "' WHERE `id_city`='" + city.id_city + "';";
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
        public void UpdateUsers(List<User> users)
        {
            Open();
            foreach (var us in users)
            {
                MessageBox.Show(us.isAdmin.ToString());
                string sql1 = "UPDATE users SET `isAdmin`='" + Convert.ToInt32(us.isAdmin) + "' WHERE `id_user`='" + us.id + "';";
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

        public void UpdateTransporters(List<Transporter> transporters)
        {
            Open();
            foreach (var tr in transporters)
            {
                string sql1 = "UPDATE transporters SET `named`='" + tr.named + "',`adress`='" + tr.adress + "', `telephone`='" + tr.telephone + "'  WHERE `id_transporter`='" + tr.id + "';";
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

        public void UpdateBuses(List<Bus> buses)
        {
            Open();
            foreach (var b in buses)
            {
                string sql1 = "UPDATE bus SET `id_transporter`='" + b.id_transporter + "',`model`='" + b.model + "', `count_seats`='" + b.count_seats + "'  WHERE `state_number`='" + b.id_bus + "';";
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

        public void UpdateIntermediatePoints(List<IntermediatePoint> points)
        {
            Open();
            foreach (var ip in points)
            {

                string sql1 = "UPDATE intermediate_point SET `id_city`='" + ip.id_city + "',`id_route_bus`='" + ip.id_route_bus +
                    "', `time_arrive`='" + ip.time_arrive + "', `cost`='" + Convert.ToString(ip.cost).Replace(",", ".") + "'  WHERE `id_intermediate_point`='" + ip.id_intermediate_point + "';";
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
        public void UpdateRouteBuses(List<RouteBus> route)
        {
            Open();
            foreach (var rou in route)
            {
                string sql1 = "UPDATE route_bus SET `id_bus`='" + rou.id_bus + "',`name_route`='" + rou.name_route +
                    "', `time_departure`='" + rou.time_departure + "', `timetable`='" + rou.timetable +
                    "', `id_departure_point`='" + rou.id_departure_point + "', `id_end_city`='" + rou.id_end_city
                    + "'  WHERE `id_route`='" + rou.id_route + "';";
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
        public void UpdateTickets(List<Ticket> tickets)
        {
            Open();
            foreach (var t in tickets)
            {
                string sql1 = "UPDATE `tickets` SET `status_seat` = '" + Convert.ToInt32(t.status_seat) + "' WHERE `tickets`.`id_ticket` = " + t.id_ticket + ";";
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
        #endregion

        #region Delete
        public void DeleteTransporter(Transporter transporters)
        {
            Open();
            string sql1 = "DELETE FROM `users` WHERE `id_user`='" + transporters.id + "';";

            try
            {

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }
        public void DeleteUser(User user)
        {
            Open();

            string sql1 = "DELETE FROM `users` WHERE `id_user`='" + user.id + "';";
            try
            {

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }
        public void DeleteBus(Bus bus)
        {
            Open();

            string sql1 = "DELETE FROM `bus` WHERE `state_number`='" + bus.id_bus + "';";
            try
            {

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }
        public void DeleteCity(City city)
        {
            Open();

            string sql1 = "DELETE FROM `cities` WHERE `id_city`='" + city.id_city + "';";
            try
            {

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }
        public void DeleteInterPoint(IntermediatePoint ipoint)
        {
            Open();

            string sql1 = "DELETE FROM `intermediate_point` WHERE `id_intermediate_point`='" + ipoint.id_intermediate_point + "';";
            try
            {

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }

        public void DeleteUserInf(UserInfo uinf)
        {
            Open();

            string sql1 = "DELETE FROM `users_info` WHERE `id_user`='" + uinf.id_user + "' and `_passport`='" + uinf.passport + "';";
            try
            {

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }
        public void DeleteRouteBus(RouteBus rb)
        {
            Open();
            string sql1 = "DELETE FROM `route_bus` WHERE `id_route`='" + rb.id_route + "';";
            try
            {

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }
        #endregion

        #region GetTables
        public List<FindRoute> GetFindRoutes(string bc, string ec, DateTime date)
        {
           List<FindRoute> findRoutes = new List<FindRoute>();
            if (chekInternet.IsConnected())
            {
                Open();
                try
                {
                    if (status)
                    {

                        //Convert.ToString(ip.cost).Replace(",", ".")
                        string sql1 = "select route_bus.id_route, intermediate_point.time_arrive, bus.model,  transporters.named,  route_bus.time_departure,  intermediate_point.cost" +
                            " from route_bus join intermediate_point on route_bus.id_route = intermediate_point.id_route_bus" +
                            " and route_bus.timetable like '%" + Convert.ToInt32(date.DayOfWeek) + "%' and route_bus.name_route like '%" + bc + "%'" +
                            "join cities on cities.id_city = intermediate_point.id_city and cities.name_city LIKE '%" + ec + "%'" +
                            "join bus on route_bus.id_bus = bus.state_number join transporters on transporters.id_transporter = bus.id_transporter";
                        MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                        MySqlDataReader reader;

                        reader = myCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            findRoutes.Add(new FindRoute(Convert.ToInt32(reader[0]), bc, ec, reader[1].ToString().Remove(5, 3),
                                reader[2].ToString(), reader[3].ToString(), reader[4].ToString().Remove(5, 3), Convert.ToDecimal(reader[5])));

                        }
                        //    MessageBox.Show(reader[4].ToString() + " " );
                        Close();
                        reader.Close();
                        // MessageBox.Show(findRoutes[0].cost.ToString());
                        return findRoutes;
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти рейсы. Пожалкйста, попробуйте позже.");
                        Close();
                        return null;
                    }
                }
                catch (Exception a) { MessageBox.Show(a.Message + " " + a.StackTrace); }
            }
            else MessageBox.Show("Проверьте подключение к интернету");
            return new List<FindRoute>();
        }

        public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();
            Open();
            if (status)
            {

                string sql1 = "SELECT * from users;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;

                reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    //  MessageBox.Show(reader[2].ToString() + reader[3].ToString());
                    users.Add(new User(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                      reader[2].ToString(), Convert.ToBoolean(reader[3].ToString().ToLower())));

                }
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

        public ObservableCollection<UserInfo> GetUsersInfo()
        {
            ObservableCollection<UserInfo> usersInfo = new ObservableCollection<UserInfo>();
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

        public ObservableCollection<City> GetCities()
        {
            ObservableCollection<City> cities = new ObservableCollection<City>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from cities;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    cities.Add(new City(Convert.ToInt32(reader[0].ToString()), reader[1].ToString()));
                Close();
                reader.Close();
                return cities;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу City");
                Close();
                return null;
            }

        }
       
        public ObservableCollection<Bus> GetBuses()
        {
            ObservableCollection<Bus> buses = new ObservableCollection<Bus>();
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

        public ObservableCollection<IntermediatePoint> GetInterPoints()
        {
            ObservableCollection<IntermediatePoint> iPoints = new ObservableCollection<IntermediatePoint>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from intermediate_point;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();

                while (reader.Read())
                    iPoints.Add(new IntermediatePoint(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()),
                        Convert.ToInt32(reader[2].ToString()), reader[3].ToString(), Convert.ToDecimal(reader[4])));

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

        public ObservableCollection<RouteBus> GetRouteBuses()
        {
            ObservableCollection<RouteBus> routeBuses = new ObservableCollection<RouteBus>();
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
                        reader[4].ToString(), Convert.ToInt32(reader[5].ToString()), Convert.ToInt32(reader[6].ToString())));
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

        public ObservableCollection<Ticket> GetTickets()
        {
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from tickets;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    tickets.Add(new Ticket(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()),
                    reader[2].ToString().Substring(0, 10), Convert.ToInt32(reader[3].ToString()), Convert.ToBoolean(reader[4].ToString().ToLower())));
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

        public ObservableCollection<Transporter> GetTransporters()
        {
            ObservableCollection<Transporter> tickets = new ObservableCollection<Transporter>();
            Open();
            if (status)
            {
                string sql1 = "SELECT * from transporters;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    tickets.Add(new Transporter(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                    reader[2].ToString(), reader[3].ToString()));
                Close();
                reader.Close();
                return tickets;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу Transporter");
                Close();
                return null;
            }

        }
        #endregion 

    }
}
