using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfLaba10.DataBase;
using WpfLaba10.Model;

namespace WpfLaba10.ViewModel
{
  public class DeleteInfoVM : INotifyPropertyChanged
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
        IMainWindowsCodeBehind CodeBehind;
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

        private ObservableCollection<Airplane> _airplanes = new ObservableCollection<Airplane>();
        public ObservableCollection<Airplane> Airplanes
        {
            get => _airplanes;
            set
            {
                _airplanes = value;
                OnPropertyChanged();
            }
        }

        Airplane _selectAirs;
        public Airplane SelectAirplane
        {
            get => _selectAirs;
            set
            {
               
                _selectAirs = value;
            }

        }

        public DeleteInfoVM(IMainWindowsCodeBehind codeBehind)
        {
            CodeBehind = codeBehind;
            try
            {
                foreach (var u in db.GetProdusers())
                {
                    _produsers.Add(u);
                }
                foreach (var u in db.GetAirplanes())
                {
                    _airplanes.Add(u);
                }

            }
            catch (Exception a) { MessageBox.Show(a.Message + "\n" + a.StackTrace); }


        }


        private RelayCommand _addProdCommand;
        public RelayCommand DeleteProduser
        {
            get
            {
                return _addProdCommand = _addProdCommand ??
                  new RelayCommand(DelProduserButton, CanDelProduser);
            }
        }
        private bool CanDelProduser()
        {
            return true;
        }
        private void DelProduserButton()
        {
            try
            {
                MessageBox.Show(selectProd.ToString());
                db.DeleteProduser(selectProd.ID_produser);
                MessageBox.Show(
                    "Обьект удален",
                    "Успех!",
                    MessageBoxButton.OK,
                    MessageBoxImage.None
                );
                CodeBehind.LoadView(ViewType.DeleteInfo);
            }
            catch (Exception a) { MessageBox.Show(a.Message +"\n"+a.StackTrace); }
        }

        private RelayCommand _delAirplaneCommand;
        public RelayCommand DeleteAirplane
        {
            get
            {
                return _delAirplaneCommand = _delAirplaneCommand ??
                  new RelayCommand(DelAirplane, CanDelAirplane);
            }
        }
        private bool CanDelAirplane()
        {
            return true;
        }
        private void DelAirplane()
        {
            try
            {
               // MessageBox.Show(SelectAirplane.ID_airplane.ToString());
                db.DeleteAirplane(SelectAirplane.ID_airplane);
                MessageBox.Show(
                    "Обьект удален",
                    "Успех!",
                    MessageBoxButton.OK,
                    MessageBoxImage.None
                );
                CodeBehind.LoadView(ViewType.DeleteInfo);
            }
            catch (Exception a) { MessageBox.Show(a.Message + "\n" + a.StackTrace); }
        }


    }
}
