using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfLaba10.DataBase;

namespace WpfLaba10.Model
{
   public class Airplane : INotifyPropertyChanged
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

        int id_air, id_prod, count_s;
        string type, model;
        public int ID_airplane { get=>id_air; set { id_air = value; OnPropertyChanged(); } }
        public int ID_produser { get=>id_prod; set { id_prod = value; OnPropertyChanged(); } }
        public string Type { get=>type; set { type = value; OnPropertyChanged(); } }
        public string Model { get=>model; set { model = value; OnPropertyChanged(); } }
        public int Count_seats { get=>count_s; set { count_s = value; OnPropertyChanged(); } }
        DateTime date;
        public DateTime Date_release
        {
            get => date.Date;
            set { date = value; }
        }
        Picture image;
        ImageSource imageSource;
        public Picture Image // Картинка к объявлению
        {
            get { return image; }
            set { image = value; }
        }
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }

        public Airplane(int ID_airplane,int ID_produser, string Type, string Model, int Count_seats, Picture image)
        {
            this.ID_airplane = ID_airplane;
            this.ID_produser = ID_produser;
            this.Type = Type;
            this.Model = Model;
            this.Count_seats = Count_seats;
          
            this.image = image;
            ImageSource = ImageConverter.ImageSourceFromBitmap(image.Source);
        }
        public override string ToString()
        {
            return Type + ", " + Model +", "+count_s;
        }

    }
}
