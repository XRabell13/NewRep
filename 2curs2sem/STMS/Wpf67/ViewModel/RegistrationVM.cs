using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Wpf67.Command;

namespace Wpf67
{
    public class RegistrationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /*DispatcherTimer timer = new DispatcherTimer();

        private IMainWindowsCodeBehind _MainCodeBehind;

        public RegistrationVM(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));
            _MainCodeBehind = codeBehind;
            Initial_Timer();
        }*/


        private MyCommand _but_regist;
        public MyCommand but_regist
        {
            get
            {
                return _but_regist = _but_regist ??
                  new MyCommand(OnShowMessage, CanShowMessage);
            }
        }
        private bool CanShowMessage()
        {
            return true;
        }
        private void OnShowMessage()
        {
            MessageBox.Show("New User");
        }
      /*  void Initial_Timer()
        {
            timer.Tick += new EventHandler(Try_Log_in);
            timer.Interval = new TimeSpan(0, 0, 1);
        }
        void Try_Log_in(object sender, EventArgs e)
        {
            _MainCodeBehind.Check_Autorization();
            if (ver03.Properties.Settings.Default.Autoriz)
            {
                ((DispatcherTimer)sender).Stop();
            }
        }*/
    }
}
