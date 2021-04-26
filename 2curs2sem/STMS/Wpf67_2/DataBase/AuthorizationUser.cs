using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Wpf67.DataBase
{
    class AuthorizationUser : Connect
    {
        public bool CheckLogin(string nick)
        {
            Open();
            if (status)
            {
                string sql1 = "select nick from users where nick='" + nick + "';";
                bool find_user = false;
              

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (nick == reader[0].ToString())
                    {
                        find_user = true;
                        break;
                    }
                }
                base.Close();
                reader.Close();
                if (!find_user)
                {
                    return false;
                }
                else return true;
            }
            else
            {
                MessageBox.Show("Проверьте соединение с сервером");
                base.Close();
                return false;
            }
        }

        public bool IsTrueLogin(string login)
        {
            string s1 = "'", s2 = "\"";
            if (login.IndexOf(s1) == -1 && login.IndexOf(s2) == -1) return true;
            else return false;
        }

        public bool IsTruePassword(string nick, string password)
        {
            Open();
            if (status)
            {
                string sql1 = "select nick, u_password from users where nick='" + nick + "';";
                bool pass_valide = false;

                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (password.GetHashCode().ToString() == (reader[1].ToString()).Replace(" ",""))
                    {
                       
                        pass_valide = true;
                        break;
                    }
                }
                Close();
                reader.Close();
                if (!pass_valide)
                {
                    MessageBox.Show("Пароль не верный");
                    return false;
                }
                else return true;
            }
            else
            {
                MessageBox.Show("Проверьте соединение с сервером");
                base.Close();
                return false;
            }

        }
        public int GetUserId(string login)
        {
            Open();
            if (status)
            {
               // MessageBox.Show("GetUserId");
                string sql1 = "select id_user from users where nick='" + login + "';";
                int id;
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader[0].ToString());
                }
                else id = -1;
                base.Close();
                reader.Close();

                if (id == -1)
                    return -1;
                else return id;

            }
            else
            {
                MessageBox.Show("Проверьте соединение с сервером");
                base.Close();
                return -1;
            }
        }

        public bool UserIsAdmin(string login)
        {
            Open();
            if (status)
            {
               // MessageBox.Show("IsAdmin?");
                string sql1 = "select isAdmin from users where nick='" + login + "';";
                bool isAdmin = false;
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                MySqlDataReader reader;
                reader = myCommand.ExecuteReader();
                if (reader.Read())
                {
                    isAdmin = Convert.ToBoolean(reader[0].ToString());
                }
                else MessageBox.Show("Не удалось получить уровень доступа к приложению");
                base.Close();
                reader.Close();
                return isAdmin;
            }
            else
            {
                MessageBox.Show("Проверьте соединение с сервером");
                base.Close();
                return false;
            }
        }



    }
}
