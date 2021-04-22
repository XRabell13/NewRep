using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Wpf67.DataBase
{
    public class RegistrationUser : Connect
    {
        AuthorizationUser check = new AuthorizationUser();

        public bool RegistUser(string login, string password1, string password2)
        {
            if (check.IsTrueLogin(login))
            {
                if (!check.CheckLogin(login))
                {
                    if (password1.Equals(password2))
                    {
                        if (password1.Length >= 4)
                        {
                            string sql1 = "INSERT INTO `users` (`nick`, `u_password`,`isAdmin`) VALUES ('" + login + "', '" + password1.GetHashCode() + "','" + 0 + "');";
                            MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                            Open();
                            myCommand.ExecuteNonQuery();
                            Close();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Пароль должен быть длиннее 4-х символов");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                        return false;
                    }
                }
                else MessageBox.Show("Данный логин используется другим пользователем");
            }
            else MessageBox.Show("Введены недопустимые символы");
            return false;
        }
        public bool AddUserInfo(int id, string passport, string telephone, string email)
        {
            string sql1 = "INSERT INTO `users_info` (`id_user`,`_passport`, `email`, `telephone`) VALUES ('" + id + "', '"  + passport + "','" + email + "', '" + telephone.Replace(" ", "") + "');";
            try
            {
                MySqlCommand myCommand = new MySqlCommand(sql1, conn);
                Open();
                myCommand.ExecuteNonQuery();
                Close();
                MessageBox.Show("Add New UserInfo");
                return true;
            }
            catch
            {
                MessageBox.Show("Error: Ошибка добавления учётных данных");
                return false;
            }
        }
    }
}
