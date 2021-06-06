using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfLaba10.Model
{
    public class Produser : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Impl
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        int id_prod;
        string name, land;
     
        public int ID_produser { get =>id_prod; set { id_prod = value; OnPropertyChanged(); } }
        public string Named { get=>name; set{ name = value; OnPropertyChanged(); } }
        public string Land { get=>land; set { land = value; OnPropertyChanged(); } }
        DateTime date;
        public DateTime Year_release 
        {
            get =>date.Date;
            set { date = value; OnPropertyChanged(); }
        }

        public Produser(int ID_produser, string Named, string Land)
        {
            this.ID_produser = ID_produser;
            this.Named = Named;
            this.Land = Land;
          
        }

        public override string ToString()
        {
            return Named +", "+ Land;
        }
    }
}
