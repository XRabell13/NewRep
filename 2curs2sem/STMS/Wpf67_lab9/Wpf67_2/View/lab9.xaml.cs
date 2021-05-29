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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf67.View;

namespace Wpf67.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для lab9.xaml
    /// </summary>
    public partial class lab9 : UserControl
    {
        public lab9()
        {
            InitializeComponent();
        }

        private void Control_MouseDown(object sender, RoutedEventArgs e)
        {
           
            textBlock1.Text = textBlock1.Text + sender.ToString() + "\n";
         
        }

        private void Control_MouseDown1(object sender, RoutedEventArgs e)
        {

            textBlock2.Text = textBlock2.Text + sender.ToString() + "\n";

        }



        private void Control_MouseEnter(object sender, RoutedEventArgs e)
        {
         //   textBlock3.Text = textBlock2.Text + "sender: " + sender.ToString() + "\n";

        }


        private void CustomButton1_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = textBlock1.Text + "sender: " + sender.ToString() + "\n";
        
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("F");
            textBlock1.Text = textBlock1.Text + "sender: " + sender.ToString() + "\n";
        }

        public class WindowCommands
        {
            static WindowCommands()
            {

                InputGestureCollection inputs = new InputGestureCollection();
                inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl + R"));
                exit = new RoutedUICommand("Exit", "Exit", typeof(MainWindow), inputs);
            }
            // Создание команды requery
            private static RoutedUICommand exit;

            public static RoutedUICommand Exit
            {
                get { return exit; }
            }
        }
    }
}
