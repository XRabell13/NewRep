using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfLaba10.DataBase;
using WpfLaba10.Model;

namespace WpfLaba10.ViewModel
{
    class PictureVM : INotifyPropertyChanged
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
     
        DB db = new DB();
        private Picture image;
        private ImageSource imageSource;
        private List<Produser> _produsers = new List<Produser>();
        public List<Produser> Produsers
        {
            get => _produsers;
            set
            {
                _produsers = value;
            }
        }

        Produser selectProd;
        public Produser SelectProduser
        {
            get => selectProd;
            set
            {
                selectProd = value;
                OnPropertyChanged();
            }

        }

        int count_seats, id_airpl;
        string type, model;
        public int CountSeats
        {
            get { return count_seats; }
            set
            {
                count_seats = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }
        public Picture Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged();
            }
        } // Картинка 

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged();
            }
        }


        public PictureVM(object airplan)
        {
            Airplane airplane = airplan as Model.Airplane;
            ImageSource = airplane.ImageSource;

            foreach (var u in db.GetProdusersList())
            {
                _produsers.Add(u);
            }
            id_airpl = airplane.ID_airplane;
           selectProd = _produsers.Where(id => id.ID_produser == airplane.ID_produser).First();
            type = airplane.Type;
            model = airplane.Model;
            count_seats = airplane.Count_seats;
        }





        bool IsValidImage(string filename)
        {
            try
            {
                BitmapImage newImage = new BitmapImage(new Uri(filename));
            }
            catch (NotSupportedException)
            {
                return false;
            }
            return true;
        }

        private RelayCommand _addInfoCommand;
        public RelayCommand AddPhoto
        {
            get
            {
                return _addInfoCommand = _addInfoCommand ??
                  new RelayCommand(AddPhotoButton, CanAddPhoto);
            }
        }
        private bool CanAddPhoto()
        {
            return true;
        }

        private void AddPhotoButton()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true && IsValidImage(openFileDialog.FileName))
            {
                    ImageSource = new BitmapImage(new Uri((openFileDialog.FileName)));
            }
            else
            {
                MessageBox.Show("Вы должны выбрать картинку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private RelayCommand _addInfCommand;
        public RelayCommand UpdateAirplane
        {
            get
            {
                return _addInfCommand = _addInfCommand ??
                  new RelayCommand(CreateAdButton, CanAddAirplane);
            }
        }
        private bool CanAddAirplane()
        {
            return true;
        }
        private void CreateAdButton()
        {
            try
            {
                try
                {
                    Image = new Picture(ImageConverter.ConvertToBitmap(ImageSource as BitmapImage));
                }
                catch (Exception)
                {
                    db.UpdateAirplane(selectProd.ID_produser, type, model, count_seats, id_airpl);
                    MessageBox.Show(
                        "Обьект обновлен!",
                        "Успех!",
                        MessageBoxButton.OK,
                        MessageBoxImage.None
                    );
                    return;
                }
                Image = new Picture(ImageConverter.ConvertToBitmap(ImageSource as BitmapImage));
                db.UpdateAirplane(selectProd.ID_produser, type, model, count_seats, Image.PictureByteArray, id_airpl);
                MessageBox.Show(
                    "Обьект обновлен!",
                    "Успех!",
                    MessageBoxButton.OK,
                    MessageBoxImage.None
                );
            }
            catch (Exception) { MessageBox.Show("Ошибка обновления данных"); }

        }


    }
}
