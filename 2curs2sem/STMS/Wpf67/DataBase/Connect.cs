using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Wpf67.DataBase
{
    class Connect
    {
        string conStr = "Database=belbusdb; Data Source=db4free.net; User Id=xrabell; Password=XRabell13; charset=utf8";// "Database=sql11402426; Data Source=sql11.freesqldatabase.com; User Id=sql11402426; Password=625TQQ4mMS; charset=utf8";//utf8_unicode_ci
        public bool status = false;

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
                    MessageBox.Show(@"Ошибка соединения с сервером");
                }
            if (conn.State.ToString() == "Open")
            {
                status = true;
             
            }
            else
            {
                MessageBox.Show(@"Сервер не открыт");
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
    }
}
