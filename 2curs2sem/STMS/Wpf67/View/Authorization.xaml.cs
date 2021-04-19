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

namespace Wpf67
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : UserControl
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void AuthorizationClick(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Authoriz);
            thread.Start();
        }

        void Authoriz()
        {
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle,
                (ThreadStart)delegate ()
                {
                    AuthorizationUser log = new AuthorizationUser();
                    if (log.IsTrueLogin(tb_login.Text))
                    {
                       
                        if (log.IsTruePassword(tb_login.Text, box_password1.Password))
                        {
                            int id = log.GetUserId(tb_login.Text);
                            Wpf67.Properties.Settings.Default.Authoriz = true;
                            Wpf67.Properties.Settings.Default.UserId = id;
                            MessageBox.Show("Вы зашли!");
                        }
                        else
                            MessageBox.Show("Проверьте пароль");
                    }
                    else
                        MessageBox.Show("Проверьте логин");
                });
        }
        public void Click_Author(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            mainWindow.OutWin.Content = reg;
        }
    }

    

    
}
