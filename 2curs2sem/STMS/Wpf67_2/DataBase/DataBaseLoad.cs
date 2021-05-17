using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using Wpf67.Model;

namespace Wpf67.DataBase
{
    class DataBaseLoad : Connect
    {

        #region Add
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
                MessageBox.Show("Ошибка добавления данных");
                return false;
            }
        }

        public bool AddRouteBus(string name_route, int id_bus, string time_departure, string timetable, int id_departure_point, int id_end_city)
        {
            try
            {
                string sql1 = "INSERT INTO `route_bus` (`name_route`, `id_bus`, `time_departure`, `timetable`, `id_departure_point`, `id_end_city`) "+
                    "VALUES (@name_route, '"+id_bus+"', '"+time_departure+"', '"+timetable+"', '"+id_departure_point+"', '"+id_end_city+"'); ";
              
                    MySqlCommand myCommand = new MySqlCommand(sql1, conn);

              
                myCommand.Parameters.AddWithValue("@name_route", name_route);
             
                Open();
                    myCommand.ExecuteNonQuery();
                Close();
               
                return true;
                
            }
            catch(Exception a)
            {
             //   MessageBox.Show(a.Message +"\n"+ a.StackTrace);
               MessageBox.Show("Ошибка добавления данных");
                return false;
            }
        }
        public RouteBus AddRouteBusID(string name_route, int id_bus, string time_departure, string timetable, int id_departure_point, int id_end_city)
        {
            int id = -1;
            try
            {
                string sql1 = "INSERT INTO `route_bus` (`name_route`, `id_bus`, `time_departure`, `timetable`, `id_departure_point`, `id_end_city`) " +
                    "VALUES (@name_route, '" + id_bus + "', '" + time_departure + "', '" + timetable + "', '" + id_departure_point + "', '" + id_end_city + "'); ";
                string sql2 = "select route_bus.id_route from route_bus where id_bus='" +id_bus+ "'and time_departure='"+time_departure+"' and timetable='"+timetable+"' and id_departure_point = '"+id_departure_point+
                    "' and id_end_city='"+id_end_city+"';";
                
                
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlCommand myCommand1 = new MySqlCommand(sql2, conn);
                MySqlDataReader reader;

                myCommand.Parameters.AddWithValue("@name_route", name_route);

                Open();
                myCommand.ExecuteNonQuery();
                reader = myCommand1.ExecuteReader();
                while (reader.Read())
                    id = Convert.ToInt32(reader[0]);
                Close();

                return new RouteBus(id,name_route,id_bus,time_departure,timetable,id_departure_point,id_end_city);

            }
            catch (Exception a)
            {
                //MessageBox.Show(a.Message + "\n" + a.StackTrace);
                  MessageBox.Show("Ошибка добавления данных");
                return null;
            }
        }
        public bool AddTransporter(string named_transporter, string address, string telephone)
        {
            try
            {
                string sql1 = "INSERT INTO `transporters` (`named`, `adress`, `telephone`)"+
                    " VALUES (@named, @address, @tel); ";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);

                myCommand.Parameters.AddWithValue("@named", named_transporter);
                myCommand.Parameters.AddWithValue("@address", address);
                myCommand.Parameters.AddWithValue("@tel", telephone);
                Open();
                myCommand.ExecuteNonQuery();
                Close();
                return true;

            }
            catch (Exception a)
            {
                //MessageBox.Show(a.Message + "\n" + a.StackTrace);
                  MessageBox.Show("Ошибка добавления данных");
                return false;
            }
        }

        public bool AddBuss(string id_transporter, string model_bus, string count_seats)
        {
            try
            {

                string sql1 = "INSERT INTO `bus` (`id_transporter`, `model`, `count_seats`) VALUES (@id_transporter, @model_bus, @count_seats);";
              
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                myCommand.Parameters.AddWithValue("@id_transporter", id_transporter);
                myCommand.Parameters.AddWithValue("@model_bus", model_bus);
                myCommand.Parameters.AddWithValue("@count_seats", count_seats);
             
                Open();
                myCommand.ExecuteNonQuery();
                Close();
                return true;

            }
            catch (Exception a)
            {
              //  MessageBox.Show(a.Message + "\n" + a.StackTrace);
                   MessageBox.Show("Ошибка добавления данных");
                return false;
            }
        }
        public bool AddUserInfo(string first_name, string last_name, string patronymic, string passport)
        {
            try
            {
                string sql1 = "  Update users_info set users_info.first_name='"+first_name+"', users_info.last_name='"+last_name+"',"+
                    " users_info.patronymic = '"+patronymic+"', users_info._passport = '"+passport+"' where users_info.id_user = " + Wpf67.Properties.Settings.Default.UserId;
             
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
         
                Open();
                myCommand.ExecuteNonQuery();
                Close();
                return true;

            }
            catch (Exception a)
            {
                //MessageBox.Show(a.Message + "\n" + a.StackTrace);
                  MessageBox.Show("Ошибка добавления данных");
                return false;
            }
        }
        public bool AddUserTicket(string id_user, string id_ticket, string id_end_point)
        {
            Open();
            MySqlTransaction transaction = conn.BeginTransaction();
            MySqlCommand command = conn.CreateCommand();
            command.Transaction = transaction;
            try
            {
            string sql1 = "select intermediate_point.id_intermediate_point from intermediate_point join cities on intermediate_point.id_city=cities.id_city where cities.name_city = '"+id_end_point+"'";
            MySqlCommand myCommand = new MySqlCommand(sql1, conn);
            MySqlDataReader reader = myCommand.ExecuteReader();
           
                int id_epoint = 0;

                while (reader.Read())
                    id_epoint = Convert.ToInt32(reader[0]);
                reader.Close();

                command.CommandText = "INSERT INTO `user_tickets` (`id_user`, `id_ticket`, `id_end_point`, `date_reserve`) VALUES ('" + id_user + "', '" + id_ticket + "', '" + id_epoint + "', " +
                    "'" + DateTime.Now + "');";
                command.ExecuteNonQuery();

                command.CommandText =  "UPDATE tickets SET `status_seat`= 1 WHERE `id_ticket`='"+id_ticket+"';";
                command.ExecuteNonQuery();

                // подтверждаем транзакцию
                transaction.Commit();

            }
            catch (Exception a)
            {
                transaction.Rollback();
            //    MessageBox.Show(a.Message + "\n" + a.StackTrace);
               MessageBox.Show("Ошибка добавления данных");
                return false;
            }
            Close();
            return true;
        }

        public bool AddIntermediatePoint(string id_city, string id_route, string time_arrive, string cost)
        {
            try
            {
                string sql1 = "INSERT INTO `intermediate_point` (`id_city`, `id_route_bus`, `time_arrive`, `cost`) VALUES( '"+id_city+"', '"+id_route+"', '"+time_arrive+"', '"+cost.Replace(",",".")+"'); ";

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
              
                Open();
                myCommand.ExecuteNonQuery();
                Close();
                return true;

            }
            catch (Exception a)
            {
              //  MessageBox.Show(a.Message + "\n" + a.StackTrace);
                MessageBox.Show("Ошибка добавления данных");
                return false;
            }
        }

        public bool AddTicketsForNewRoute(RouteBus routeBus)
        {
            try
            {

                string sql1 = "INSERT INTO `tickets` (`id_route_bus`, `date_departure`, `num_seat`, `status_seat`) VALUES ";
                string sql2 = "('"+routeBus.id_route+"', '#', '@', '0'),";

                string searchBus = "select bus.count_seats from bus where bus.state_number = " + routeBus.id_bus + ";";
             
                DateTime dateTime;
                int count_seats = 0;
                MySqlCommand myCommand = new MySqlCommand(searchBus, conn), myCommand1;
                MySqlDataReader reader;

                string[] days = routeBus.timetable.Split(new char[] { ' ' });

                Dictionary<int, string> dayOfWeek = new Dictionary<int, string>();
                for (int i = 0; i <= days.Length - 1; i++)
                {
                    if (days[i] == "пн") dayOfWeek.Add(1, "пн");
                    if (days[i] == "вт") dayOfWeek.Add(2, "вт");
                    if (days[i] == "ср") dayOfWeek.Add(3, "ср");
                    if (days[i] == "чт") dayOfWeek.Add(4, "чт");
                    if (days[i] == "пт") dayOfWeek.Add(5, "пт");
                    if (days[i] == "сб") dayOfWeek.Add(6, "сб");
                    if (days[i] == "вс") dayOfWeek.Add(0, "вс");
                }

                Open();
                reader = myCommand.ExecuteReader();
                while(reader.Read())
                count_seats = Convert.ToInt32(reader[0]);
                reader.Close();
           
                for (int j = 0; j <= 7; j++)//загрузка билетов на неделю вперед
                {
                    dateTime = DateTime.Now.AddDays(j+1);//+1 чтобы оно не добавляло билеты на тот день, в который было загружено
                    if (dayOfWeek.ContainsKey(Convert.ToInt32(dateTime.DayOfWeek)))
                        for (int i = 1; i <= count_seats; i++)
                        {
                            sql1 += sql2.Replace("@", i.ToString()).Replace("#", dateTime.Year + "." + dateTime.Month + "." + dateTime.Day);
                        }
                    
                }
              
                sql1 = sql1.Remove(sql1.LastIndexOf(","));
                sql1 += ";";

                myCommand1 = new MySqlCommand(sql1, conn);
                myCommand1.ExecuteNonQuery();

                Close();

                return true;

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message + "\n" + a.StackTrace);
                MessageBox.Show("Ошибка добавления данных");
                return false;
            }
        }

#endregion

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
                    MessageBox.Show("Ошибка:  \n " + ex.Message);
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
        public void UpdateOldTickets()
        {
            Open();

            DateTime dateTime = DateTime.Now, date;
            string sql1 = "update tickets set tickets.date_departure = '@', tickets.status_seat=0 where tickets.id_ticket=#;";
            string sql2 = "select tickets.id_ticket, tickets.date_departure from tickets where tickets.date_departure < CURDATE()";
            string sql3 = "";
           
            List<string> id_tickets = new List<string>();
            List<DateTime> date_departure = new List<DateTime>();
            MySqlDataReader reader;
            MySqlCommand myCommand, myCommand1;
            bool canUpdate = true;
            try
                {
                while (canUpdate)
                {
                    myCommand = new MySqlCommand(sql2, conn);
                    reader = myCommand.ExecuteReader();

                   while (reader.Read())
                    {
                        id_tickets.Add(Convert.ToString(reader[0]));
                        date_departure.Add(Convert.ToDateTime(reader[1]));
                    }
                    reader.Close();
                  
                    if (id_tickets.Count!=0)
                    {
                      
                        if (!string.IsNullOrWhiteSpace(id_tickets[0])) 
                        {
                           
                            for (int i = 0; i < id_tickets.Count; i++)
                            {
                                date = date_departure[i].AddDays(7).Date;
                                sql3 += sql1.Replace("#", id_tickets[i]).Replace("@", date.Year + "." + date.Month + "." + date.Day) + " ";
                            }
                        myCommand1 = new MySqlCommand(sql3, conn);
                        myCommand1.ExecuteNonQuery();

                   
                        id_tickets.Clear();
                        date_departure.Clear();
                        sql3 = "";
                        }
                        else canUpdate = false;
                    }
                    else canUpdate = false;
                  }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка  \n " + ex.Message +"\n"+ ex.StackTrace);
                }
            
            Close();
        }

        #endregion

        #region Delete
        public void DeleteTransporter(Transporter transporters)
        {
            Open();
            string sql1 = "DELETE FROM `transporters` WHERE `id_transporter`='" + transporters.id + "';";

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
        public void DeleteOldUserTickets()
        {
          
            Open();
            DateTime dateTime = DateTime.Now;
            string sql1 = "select user_tickets.id_user_tickets from user_tickets join tickets on user_tickets.id_ticket=tickets.id_ticket join route_bus on tickets.id_route_bus=route_bus.id_route " +
                " where tickets.date_departure <'" + dateTime.Year + "." + dateTime.Month + "." + dateTime.Day + "'";
          
            string sql2 = "DELETE FROM `user_tickets` WHERE `id_user_tickets`=@;", sql3="";
            List<string> id_tickets = new List<string>();
            MySqlDataReader reader;
            try
            {

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlCommand myCommand1;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    id_tickets.Add(Convert.ToString(reader[0]));
                reader.Close();

                if (id_tickets.Count != 0) 
                {
                    for (int i = 0; i < id_tickets.Count; i++)
                    {
                       sql3 += sql2.Replace("@", id_tickets[0])+" ";
                    
                    }
                    myCommand1 = new MySqlCommand(sql3, conn);
                    myCommand1.ExecuteNonQuery();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }
        public void DeleteUserTicket(string id_user_ticket, string id_ticket)
        {
            Open();

           
            MySqlTransaction transaction = conn.BeginTransaction();
         
            MySqlCommand command = conn.CreateCommand();
           
            command.Transaction = transaction;
           
            try
            {
              
                command.CommandText = "DELETE FROM `user_tickets` WHERE `id_user_tickets`='" + id_user_ticket + "';";
       
                command.ExecuteNonQuery();
               
                command.CommandText = "UPDATE tickets SET `status_seat`= 0 WHERE `id_ticket`='" + id_ticket + "';";
                command.ExecuteNonQuery();

                // подтверждаем транзакцию
                transaction.Commit();
               
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Ошибка удаления данных");
                MessageBox.Show("Ошибка  \n " + ex.Message);
            }

            Close();
        }
        #endregion

        #region GetTables
        public List<FindRoute> GetFindRoutes(string bc, string ec,  string date, DateTime dateTime)
        {
           List<FindRoute> findRoutes = new List<FindRoute>();
            if (chekInternet.IsConnected())
            {
                Open();
                try
                {
                    if (status)
                    {
                       
                        string sql1;
                    
                     if (dateTime.Date == DateTime.Now.Date)
                        sql1 = "select route_bus.id_route, intermediate_point.time_arrive, bus.model,  transporters.named,  route_bus.time_departure,  intermediate_point.cost" +
                            " from route_bus join intermediate_point on route_bus.id_route = intermediate_point.id_route_bus" +
                            " and route_bus.timetable like '%" + date + "%' and route_bus.name_route like '%" + bc + "%'" +
                            "join cities on cities.id_city = intermediate_point.id_city and cities.name_city = '" + ec + "'" +
                            "join bus on route_bus.id_bus = bus.state_number join transporters on transporters.id_transporter = bus.id_transporter where route_bus.time_departure >'" +
                           DateTime.Now.ToShortTimeString() + "';";
                      
                        else sql1 = "select route_bus.id_route, intermediate_point.time_arrive, bus.model,  transporters.named,  route_bus.time_departure,  intermediate_point.cost" +
                                " from route_bus join intermediate_point on route_bus.id_route = intermediate_point.id_route_bus" +
                                " and route_bus.timetable like '%" + date + "%' and route_bus.name_route like '%" + bc + "%'" +
                                "join cities on cities.id_city = intermediate_point.id_city and cities.name_city = '" + ec + "'" +
                                "join bus on route_bus.id_bus = bus.state_number join transporters on transporters.id_transporter = bus.id_transporter;";

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
                        MessageBox.Show("Не удалось найти рейсы. Пожалуйста, попробуйте позже.");
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
                string sql1 = "SELECT bus.state_number, bus.id_transporter, bus.model, bus.count_seats,"+
                    " transporters.named from bus join transporters on bus.id_transporter = transporters.id_transporter ;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    buses.Add(new Bus(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()),
                        reader[2].ToString(), Convert.ToInt32(reader[3].ToString()), reader[4].ToString()));
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
            {//SELECT intermediate_point.id_intermediate_point, intermediate_point.id_city, intermediate_point.id_route_bus, intermediate_point.time_arrive, intermediate_point.cost, cities.name_city, route_bus.name_route from intermediate_point join cities on intermediate_point.id_city=cities.id_city join route_bus on intermediate_point.id_route_bus=route_bus.id_departure_point ;
                string sql1 = "SELECT intermediate_point.id_intermediate_point, intermediate_point.id_city,"+
                    " intermediate_point.id_route_bus, intermediate_point.time_arrive, intermediate_point.cost, cities.name_city, "+
                    "route_bus.name_route from intermediate_point join cities on intermediate_point.id_city=cities.id_city join route_bus on"+
                    " intermediate_point.id_route_bus=route_bus.id_route;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();

                while (reader.Read())
                    iPoints.Add(new IntermediatePoint(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()),
                        Convert.ToInt32(reader[2].ToString()), reader[3].ToString(), Convert.ToDecimal(reader[4]), reader[5].ToString(), reader[6].ToString()));

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
                try
                {
                    string sql1 = "select route_bus.id_route, route_bus.name_route, route_bus.id_bus, route_bus.time_departure, " +
                    "route_bus.timetable, route_bus.id_departure_point, route_bus.id_end_city, bus.model, cities.name_city from" +
                    " route_bus join bus on route_bus.id_bus = bus.state_number join cities on route_bus.id_departure_point = cities.id_city;";

                    string sql2 = "select DISTINCT cities.id_city, cities.name_city from cities join route_bus on cities.id_city=route_bus.id_end_city;";
                  
                    Dictionary<int, string> endCities = new Dictionary<int, string>();
                    MySqlCommand myCommand = new MySqlCommand(sql1, conn),
                        myCommand1 = new MySqlCommand(sql2, conn);

                    MySqlDataReader reader, reader1;

                    reader = myCommand.ExecuteReader();
                    while (reader.Read())
                      routeBuses.Add(new RouteBus(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(),
                           Convert.ToInt32(reader[2].ToString()), reader[3].ToString(),
                           reader[4].ToString(), Convert.ToInt32(reader[5].ToString()), Convert.ToInt32(reader[6].ToString()), reader[7].ToString(),
                           reader[8].ToString(), null));
                  
                    reader.Close();

                    reader1 = myCommand1.ExecuteReader();


                    while (reader1.Read())
                        endCities.Add(Convert.ToInt32(reader1[0]), reader1[1].ToString());

                    int count = endCities.Count;
                    foreach (var rb in routeBuses)
                        rb.InsertEndCity(endCities[rb.id_end_city]);

                    Close();

                    reader1.Close();
                }
                catch (Exception a) { MessageBox.Show(a.Message + "\n"+a.StackTrace); }

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
                
                string sql1 = "SELECT tickets.id_ticket, tickets.id_route_bus, tickets.date_departure, tickets.num_seat, tickets.status_seat, route_bus.name_route from tickets join route_bus on tickets.id_route_bus = route_bus.id_route;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    tickets.Add(new Ticket(Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()),
                    reader[2].ToString().Substring(0, 10), Convert.ToInt32(reader[3].ToString()), Convert.ToBoolean(reader[4].ToString().ToLower()), reader[5].ToString()));
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

        public List<Ticket> GetTickets(int id, DateTime date)
        {
            List<Ticket> Tickets = new List<Ticket>();
            Open();
            if (status)
            {

                string sql1 = "select * from tickets where tickets.id_route_bus = '" + id + "' and tickets.date_departure = '" + date.Year + "." + date.Month + "." + date.Day + "'" +
                    "  and tickets.status_seat = 0";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                    Tickets.Add(new Ticket(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]),Convert.ToString(reader[2]),Convert.ToInt32(reader[3]), Convert.ToBoolean(reader[4]), null));
                Close();
                reader.Close();
                return Tickets;
            }
            else
            {
                MessageBox.Show("Не удалось получить таблицу Tickets");
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

          public List<MyTrip> GetUserTrips(string id)
        {
             List<MyTrip> Tickets = new List<MyTrip>();
              Open();
              if (status)
              {
             
                string sql1 = "select route_bus.name_route, cities.name_city, route_bus.time_departure, intermediate_point.time_arrive, intermediate_point.cost,"+
                    " tickets.date_departure, tickets.num_seat, user_tickets.id_user_tickets,  user_tickets.id_ticket from user_tickets join tickets on user_tickets.id_ticket = tickets.id_ticket " +
                    "join route_bus on route_bus.id_route = tickets.id_route_bus join intermediate_point on intermediate_point.id_intermediate_point = user_tickets.id_end_point"+
                    " join cities on cities.id_city = intermediate_point.id_city where user_tickets.id_user="+id;
                  MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                  MySqlDataReader reader;
                  reader = myCommand.ExecuteReader();
                  while (reader.Read())
                      Tickets.Add(new MyTrip(Convert.ToString(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), 
                          Convert.ToDecimal(reader[4]),Convert.ToString(reader[5]).Remove(10), Convert.ToString(reader[6]), Convert.ToString(reader[7]), Convert.ToString(reader[8])));
                  Close();
                  reader.Close();
                  return Tickets;
              }
              else
              {
                  MessageBox.Show("Не удалось получить таблицу Tickets");
                  Close();
                  return null;
              }

    }
      
        #endregion

    }
}
