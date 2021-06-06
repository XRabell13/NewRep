using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using WpfLaba10.Model;
using GalaSoft.MvvmLight.Command;
using WpfLaba10.DataBase;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WpfLaba10.ViewModel
{
    public class AddInfoVM : INotifyPropertyChanged
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

        private MainWindow mainWindow;

        private Picture image;
        private ImageSource imageSource;
        DB db = new DB();

        private ObservableCollection<Produser> _produsers = new ObservableCollection<Produser>();
        public ObservableCollection<Produser> Produsers
        {
            get => _produsers;
            set
            {
                _produsers = value;
                OnPropertyChanged();
            }
        }

        Produser selectProd;
        public Produser SelectProduser
        {
            get => selectProd;
            set
            {
              
                selectProd = value;
            }

        }

        int count_seats;
        string type, model, name,land;
        public int CountSeats 
        {
            get { return  count_seats; }
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

        public string Land 
        {
            get { return land; }
            set
            {
                land = value;
                OnPropertyChanged();
            }
        }
        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }



        public AddInfoVM(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            try
            {
                foreach (var u in db.GetProdusers())
                {
                    _produsers.Add(u);
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message + "\n" + a.StackTrace); }
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
                if (ImageSource == null)
                {
                    ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                
                }
                else
                {
                    MessageBox.Show("Вы не можете добавить более 1 фотографии!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Вы должны выбрать картинку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private RelayCommand _addInfCommand;
        public RelayCommand AddAirplane
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
                    Image = new Picture(ImageConverter.ConvertToBitmap(ImageSource as BitmapImage));
                    db.CreateAirplane(selectProd.ID_produser, type, model, count_seats, Image.PictureByteArray);
                    MessageBox.Show(
                        "Обьект добавлен!",
                        "Успех!",
                        MessageBoxButton.OK,
                        MessageBoxImage.None
                    );
                }
                catch (Exception) { MessageBox.Show("Ошибка добавления данных"); }
            
           
        }


        private RelayCommand _addProdCommand;
        public RelayCommand AddProduser
        {
            get
            {
                return _addProdCommand = _addProdCommand ??
                  new RelayCommand(CreateProduserButton, CanAddProduser);
            }
        }
        private bool CanAddProduser()
        {
            return true;
        }
        private void CreateProduserButton()
        {
            try
            {
              
                db.CreateProduser(name, land);
                MessageBox.Show(
                    "Обьект добавлен!",
                    "Успех!",
                    MessageBoxButton.OK,
                    MessageBoxImage.None
                );
            }
            catch (Exception) { MessageBox.Show("Ошибка добавления данных"); }

        }




    }
}
