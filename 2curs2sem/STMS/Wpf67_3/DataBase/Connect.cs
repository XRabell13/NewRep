using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using NETWORKLIST;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Wpf67.DataBase
{
   public class Connect
    {
        string conStr = "Database=9VoWrdVUvt; Data Source=remotemysql.com; User Id=9VoWrdVUvt; Password=b7dvPcjhom; charset=utf8";
        public bool status = false;
        public InternetConnectionChecker chekInternet = new InternetConnectionChecker();
        public MySqlConnection conn;

        public Connect()
        {
            conn = new MySqlConnection(conStr);
        }
        public void Open()
        {
          
                if (conn.State != System.Data.ConnectionState.Open)
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка соединения с сервером");
                    }
                if (conn.State.ToString() == "Open")
                {
                    status = true;

                }
                else
                {
                    MessageBox.Show("Сервер не открыт");
                }
          
        }
        public void Close()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                status = false;
               
            }
        }

        public class InternetConnectionChecker//проверка наличия интернета
        {
            private readonly INetworkListManager _networkListManager;

            public InternetConnectionChecker()
            {
                _networkListManager = new NetworkListManager();
            }

            public bool IsConnected()
            {
                return _networkListManager.IsConnectedToInternet;
            }

        }
    
}
}
