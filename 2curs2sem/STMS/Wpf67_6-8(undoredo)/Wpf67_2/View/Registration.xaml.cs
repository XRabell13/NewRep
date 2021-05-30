using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf67.DataBase;

namespace Wpf67.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        string login = null;
        string password1 = null;
        string password2 = null;
        string telephone = null;
        string email;

       
        RegistrationUser regist = new RegistrationUser();
        AuthorizationUser authoriz = new AuthorizationUser();
        IMMCodeBehind codeBehind { get; set; }

        public Registration()
        {
            try
            {
                InitializeComponent();
                codeBehind = (MainWindow)Application.Current.MainWindow;
            }
            catch (Exception a) { MessageBox.Show(a.Message + "\n"+a.StackTrace); }
            }

        private void But_Regist_Click(object sender, RoutedEventArgs e)
        {
            DataBaseLoad baseLoad = new DataBaseLoad();
            if (baseLoad.chekInternet.IsConnected())
            {
                Thread thread = new Thread(Regist_new_User);
            thread.Start();
            }
            else MessageBox.Show("Проверьте подключение к интернету.");

        }
        void Regist_new_User()
        {
           
                if (CheckValidInfo(login, password1, password2, email, telephone))
            {
                if (regist.RegistUser(login, password1, password2) && login.Length >= 2)
                {
                    if (!(telephone.Length == 0 && email.Length == 0))
                    {
                        int id = authoriz.GetUserId(login);

                        if (regist.AddUserInfo(id, null, telephone, email))
                        {
                            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle,
                                        (ThreadStart)delegate ()
                                        {
                                            Wpf67.Properties.Settings.Default.Authoriz = true;
                                            Wpf67.Properties.Settings.Default.IsAdmin = false;
                                            Wpf67.Properties.Settings.Default.UserId = id;
                                            Wpf67.Properties.Settings.Default.Save();
                                            codeBehind.LoadView(ViewType.Search);
                                            codeBehind.ButEnterAccount();
                                        });
                        }
                        else
                            MessageBox.Show("Ошибка ввода учётных данных");
                    }
                }
              

            }
        }

        bool CheckValidInfo(string login, string pas1, string pas2, string mail, string tel)
        {
            string pattern = @"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$";
           
            if (login == null)
            {
                MessageBox.Show("Введите логин");
                return false;
            }
            if (login.Length < 4)
            {
                MessageBox.Show("Логин должен быть более 4-х символов");
                return false;
            }
            if (login.Length > 44)
            {
                MessageBox.Show("Логин должен быть меньше 44-х символов");
                return false;
            }
            if (pas1 == null)
            {
                MessageBox.Show("Введите пароль");
                return false;
            }
            if (pas2 == null)
            {
                MessageBox.Show("Введите подтверждение пароля");
                return false;
            }
            if (pas1.Length < 4 || pas2.Length < 4)
            {
                MessageBox.Show("Пароль должен быть более 4-х символов");
                return false;
            }
            if (!pas1.Equals(pas2))
            {
                MessageBox.Show("Пароли не совпадают");
                return false;
            }
            try
            {
                MailAddress m = new MailAddress(mail);
            }
            catch (FormatException)
            {
                MessageBox.Show("email введен некорректно");
                return false;
            }
            if (email.Length > 100)
            {
                MessageBox.Show("email введен некорректно");
                return false;
            }
                if (!Regex.IsMatch(tel, pattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Некорректный телефон");
                return false;
            }
         
            return true;
        }
    
        private void tbLogin_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tb_login.Text.Length > 0)
                login = tb_login.Text;
        }
        private void tbPass1_PasswordChanged(object sender, RoutedEventArgs e)
        {
          
            password1 = ((PasswordBox)sender).Password;
        }
        private void tbPass2_PasswordChanged(object sender, RoutedEventArgs e)
        {
          
                password2 = ((PasswordBox)sender).Password;
        }
        private void tbEmail_SelectionChanged(object sender, RoutedEventArgs e)
        {
          
            email = ((TextBox)sender).Text;
        }
        private void tbTelephone_TextChanged(object sender, RoutedEventArgs e)
        {
                telephone = ((TextBox)sender).Text;
        }

       
    }
}
