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
using Wpf67.View;
using Wpf67.ViewModel;

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : UserControl
    {
        IMainWindowsCodeBehind codeBehind { get; set; }

        public Authorization()
        {
            InitializeComponent();

            AuthorizationVM vm = new AuthorizationVM(this);
            codeBehind = (MainWindow)Application.Current.MainWindow;
            this.DataContext = vm;

        }

        private void AuthorizationClick(object sender, RoutedEventArgs e)
        {
            DataBaseLoad baseLoad = new DataBaseLoad();
            if (baseLoad.chekInternet.IsConnected())
            {
                Thread thread = new Thread(Authoriz);
            thread.Start();
            }
            else MessageBox.Show("Проверьте подключение к интернету.");
        }

        void Authoriz()
        {
           
                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle,
                (ThreadStart)delegate ()
                {
                    AuthorizationUser autUser = new AuthorizationUser();
                    if (autUser.IsTrueLogin(tb_login.Text))
                    {
                       
                        if (autUser.IsTruePassword(tb_login.Text, box_password1.Password))
                        {
                            int id = autUser.GetUserId(tb_login.Text);

                            Wpf67.Properties.Settings.Default.Authoriz = true;
                            Wpf67.Properties.Settings.Default.IsAdmin = autUser.UserIsAdmin(tb_login.Text);
                            Wpf67.Properties.Settings.Default.UserId = id;
                            codeBehind.LoadView(ViewType.Search);
                            codeBehind.ButEnterAccount();
                            Wpf67.Properties.Settings.Default.Save();
                        }
                        else
                            MessageBox.Show("Проверьте пароль");
                    }
                    else
                        MessageBox.Show("Проверьте логин");
                });
           
        }
    }
}
