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
using MySql.Data.MySqlClient;
using Wpf67.DataBase;

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public void ClickAddCities(object sender, EventArgs e)
        {
            DataBase.DataBaseLoad a = new DataBase.DataBaseLoad();
            a.CreateCities("НарочьНАРОЧЬ");
        }
        public void Click1(object sender, EventArgs e)
        {
            DataBase.DataBaseLoad a = new DataBase.DataBaseLoad();
            a.Get_user_nick();
        }
    }
    class DataBaseLoad : Connect
    {
        string nick;
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

        public string GetCity()
        { 
        
        }
        public string Get_user_nick()
        {
            Open();
            if (status)
            {
                string sql1 = "select name_city from cities;";
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                if (reader.Read())
                    nick = reader[0].ToString();
                else
                    //MessageBox.Show("Error: Nickname не найден");
                    base.Close();
                reader.Close();
               
                return nick;
            }
            else
            {
                MessageBox.Show("Проверьте соединение с сервером: ошибка получения nick");
                base.Close();
                return null;
            }
        }
    }
}
