using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Wpf67.DataBase
{
    class DataBaseLoad:Connect
    {
        public bool CreateCities(string name_cities)
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

    }
}
