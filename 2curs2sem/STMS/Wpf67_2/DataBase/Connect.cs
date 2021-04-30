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
        //Host=myServerAddress;UserName=myUsername;Password=myPassword;Database=myDataBase;
        string conStr = "Database=9VoWrdVUvt; Data Source=remotemysql.com; User Id=9VoWrdVUvt; Password=b7dvPcjhom; charset=utf8";//"Data Source=db4free.net; User Id = xrabell; Password=XRabell13; charset=utf8";//"SERVER=10.35.250.195;DATABASE=sql11406498;USERID=root;PASSWORD=;"; // "Database=belbusdb; Data Source=db4free.net; User Id=xrabell; Password=XRabell13; charset=utf8";//"Database=sql11406498; Data Source=sql11.freesqldatabase.com; User Id=sql11406498; Password=Tg7M28zuml; charset=utf8"; // "Database=belbusdb; Data Source=db4free.net; User Id=xrabell; Password=XRabell13; charset=utf8";// "Database=sql11402426; Data Source=sql11.freesqldatabase.com; User Id=sql11402426; Password=625TQQ4mMS; charset=utf8";//utf8_unicode_ci
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

        public class InternetConnectionChecker
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
