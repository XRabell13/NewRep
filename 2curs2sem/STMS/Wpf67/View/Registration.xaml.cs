using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Registration()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
           Authorization reg = new Authorization();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            mainWindow.OutWin.Content = reg;
        }
        private void But_Regist_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Regist_new_User);
            thread.Start();

        }
        void Regist_new_User()
        {
            if (CheckValidInfo(login, password1, password2, email, telephone))
            {
                if (regist.RegistUser(login, password1, password2) && login.Length >= 4)
                {
                    telephone.Replace(" ", "");
                    email.Replace(" ", "");
                    if (!(telephone.Length == 0 && email.Length == 0))
                    {
                        int id = authoriz.GetUserId(login);


                        if (regist.AddUserInfo(id, null, telephone, email))
                        {
                            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle,
                                        (ThreadStart)delegate ()
                                        {
                                            Wpf67.Properties.Settings.Default.Authoriz = true;
                                            Wpf67.Properties.Settings.Default.UserId = id;
                                        });

                        }
                        else
                            MessageBox.Show("Error ошибка ввода учётных данных");
                    }
                    }

            }
        }

        bool CheckValidInfo(string login, string pas1, string pas2, string mail, string tel)
        {
            if (this.login == null)
            {
                MessageBox.Show("Введите логин");
                return false;
            }
            if (this.login.Length < 4)
            {
                MessageBox.Show("Логин должен быть боллее 4-х символов");
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
                MessageBox.Show("Пароль должен быть боллее 4-х символов");
                return false;
            }
            if (!pas1.Equals(pas2))
            {
                MessageBox.Show("Пароли не совпадают");
                return false;
            }
            if (mail == null)
            {
                MessageBox.Show("Введите email");
                return false;
            }
            if (mail.Length == 0)
            {
                MessageBox.Show("Введите email");
                return false;
            }
            if (!mail.Contains("@") || !mail.Contains("."))
            {
                MessageBox.Show("email введен некорректно");
                return false;
            }
            if (telephone == null || telephone.Length == 0)
            {
                MessageBox.Show("Введите телефон");
                return false;
            }
            if (!(telephone.Length > 13 || (!telephone.Contains(" ") && telephone.Length > 12)))
            {
                MessageBox.Show("Телефон введен некорректно");
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

        /*
    private void box_nick_LostFocus(object sender, RoutedEventArgs e)
    {
        if (login != null)
        {
            if (login.Length < 5)
            {
                SetTBStyleDef(sender);
            }
            else
            {
                bool result = false;
                string nick;

                Thread thread = new Thread(CheckNickValid);
                thread.Start();

                void CheckNickValid()
                {
                    nick = login;
                    result = authoriz.IsTrueLogin(nick);
                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle,
                (ThreadStart)delegate ()
                {
                    if (!result)
                        SetTBStyleValid(sender);
                    else
                        SetTBStyleUnValid(sender);
                });
                }


            }
        }
    }
    void SetTBStyleValid(object sender)
    {
        ((TextBox)sender).Style = (Style)FindResource("TextBoxStyle00_ByRegistration_valid");
    }
    void SetTBStyleUnValid(object sender)
    {
        ((TextBox)sender).Style = (Style)FindResource("TextBoxStyle00_ByRegistration_unvalid");
    }
    void SetTBStyleDef(object sender)
    {
        ((TextBox)sender).Style = (Style)FindResource("TextBoxStyle00_ByRegistration_def");
    }

    void SetPBStyleDef(object sender)
    {
        ((PasswordBox)sender).Style = (Style)FindResource("PasswordBox_def");
    }
    void SetPBStyleValid(object sender)
    {
        ((PasswordBox)sender).Style = (Style)FindResource("PasswordBox_valid");
    }
    void SetPBStyleUnValid(object sender)
    {
        ((PasswordBox)sender).Style = (Style)FindResource("PasswordBox_unvalid");
    }

    private void box_password1_LostFocus(object sender, RoutedEventArgs e)
    {
        if ((password2 != null && password1 != null) && (password1 != null && password1.Length > 0) && (password2 != null && password2.Length > 0))
        {
            //MessageBox.Show("1");
            if (password2.Equals(password1))
            {
                SetPBStyleValid(sender);
                SetPBStyleValid(pasBox2);
            }
            else
            {
                SetPBStyleUnValid(sender);
                SetPBStyleUnValid(pasBox2);
            }
        }
        else
        {
            //MessageBox.Show("2");
            SetPBStyleDef(sender);
            SetPBStyleDef(pasBox2);
        }


    }
    private void box_password2_LostFocus(object sender, RoutedEventArgs e)
    {
        if ((password2 != null && password1 != null) && (password1 != null && password1.Length > 0) && (password2 != null && password2.Length > 0))
        {
            if (password1.Equals(password2))
            {
                SetPBStyleValid(sender);
                SetPBStyleValid(pasBox1);
            }
            else
            {
                SetPBStyleUnValid(sender);
                SetPBStyleUnValid(pasBox1);
            }

        }
        else
        {
            SetPBStyleDef(sender);
            SetPBStyleDef(pasBox1);
        }


    }

    private void box_email_LostFocus(object sender, RoutedEventArgs e)
    {
        if (email.Length > 0 && email.Contains("@") && email.Contains("."))
        {
            SetTBStyleValid(sender);
        }
        else
            if (email.Length > 0)
            SetTBStyleUnValid(sender);
        else
            SetTBStyleDef(sender);
    }
    private void box_telephone_LostFocus(object sender, RoutedEventArgs e)
    {
        if (telephone.Length > 13 || (!telephone.Contains(" ") && telephone.Length > 12))
            SetTBStyleValid(sender);
        else if (telephone.Length > 0)
            SetTBStyleUnValid(sender);
        else
            SetTBStyleDef(sender);
    }*/
    }
}
