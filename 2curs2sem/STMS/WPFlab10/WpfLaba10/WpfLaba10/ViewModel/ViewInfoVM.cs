using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WpfLaba10.DataBase;
using WpfLaba10.Model;

namespace WpfLaba10.ViewModel
{
    public class ViewInfoVM : INotifyPropertyChanged
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
        public string Text { get; set; } = "Connect";
        IMainWindowsCodeBehind codeBehind;

        public DataTable dateAirplane;

        int pageSize = 3; // размер страницы
        int pageNumberProd = 0; // текущая страница дисциплин
        int pageNumberAirp = 0; // текущая страница лекторов

        List<Produser> produserUpdate = new List<Produser>(); 

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
            set {
               
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
                codeBehind.LoadView(ViewType.PictureView, _selectAirs);
            }

        }
     

        public ViewInfoVM(IMainWindowsCodeBehind codeBehind)
        {
            this.codeBehind = codeBehind;
            _produsers.CollectionChanged += Produser_CollectionChanged;
            _airplanes.CollectionChanged += Airplane_CollectionChanged;

            if (db.DataBaseIdNull())
            {
                string path = @"C:\Users\hp\Project\NewRep\2curs2sem\STMS\WPFlab10\WpfLaba10\SQLQueryWPF10.txt";
                string sql = "";
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                     sql = sr.ReadToEnd();
                    }

                    db.ExecuteSQL(sql);
                  
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
                try
                {
                    foreach (var u in db.GetProdusers(pageNumberProd, pageSize))
                    {
                        _produsers.Add(u);
                    }

                    foreach (var u in db.GetAirplanes(pageNumberAirp, pageSize))
                    {
                        _airplanes.Add(u);
                    }

                }
                catch (Exception a) { MessageBox.Show(a.Message + "\n" + a.StackTrace); }
            

        }

        private RelayCommand _saveProd;
        public RelayCommand SaveProduser
        {
            get
            {
                return _saveProd = _saveProd ??
                  new RelayCommand(SaveProd, CanSaveProd);
            }
        }
        private bool CanSaveProd()
        {
            return true;
        }
        private void SaveProd()
        {
            try
            {
                if (produserUpdate.Count > 0)
                {

                    db.UpdateProdusers(produserUpdate);
                    codeBehind.LoadView(ViewType.ViewInfo);
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка сохранения данных"); }

        }
        
        private RelayCommand _nextProd;
        public RelayCommand NextProduser
        {
            get
            {
                return _nextProd = _nextProd ??
                  new RelayCommand(NextProd, CanNextProd);
            }
        }
        private bool CanNextProd()
        {
            return true;
        }
        private void NextProd()
        {
            try
            {
                pageNumberProd++;
                _produsers.Clear();
                foreach (var u in db.GetProdusers(pageNumberProd, pageSize))
                {
                    _produsers.Add(u);
                }

            }
            catch (Exception) { MessageBox.Show("Ошибка сохранения данных"); }

        }


        private RelayCommand _backProd;
        public RelayCommand BackProduser
        {
            get
            {
                return _backProd = _backProd ??
                  new RelayCommand(BackProd, CanBackProd);
            }
        }
        private bool CanBackProd()
        {
            return true;
        }
        private void BackProd()
        {
            try
            {
                if (pageNumberProd == 0) return;
                else
                pageNumberProd--;

                _produsers.Clear();
                foreach (var u in db.GetProdusers(pageNumberProd, pageSize))
                {
                    _produsers.Add(u);
                }

            }
            catch (Exception) { MessageBox.Show("Ошибка сохранения данных"); }

        }


        private RelayCommand _nextAirp;
        public RelayCommand NextAirplane
        {
            get
            {
                return _nextAirp = _nextAirp ??
                  new RelayCommand(NextAirpl, CanNextAirpl);
            }
        }
        private bool CanNextAirpl()
        {
            return true;
        }
        private void NextAirpl()
        {
            try
            {
               pageNumberAirp++;
                _airplanes.Clear();
                foreach (var u in db.GetAirplanes(pageNumberAirp, pageSize))
                {
                    _airplanes.Add(u);
                 
                }

            }
            catch (Exception) { MessageBox.Show("Ошибка сохранения данных"); }

        }


        private RelayCommand _backAirpl;
        public RelayCommand BackAirplane
        {
            get
            {
                return _backAirpl = _backAirpl ??
                  new RelayCommand(BackAirp, CanBackAirp);
            }
        }
        private bool CanBackAirp()
        {
            return true;
        }
        private void BackAirp()
        {
            try
            {
                if (pageNumberAirp == 0) return;
                else
                    pageNumberAirp--;

                _airplanes.Clear();
                foreach (var u in db.GetAirplanes(pageNumberAirp, pageSize))
                {
                    _airplanes.Add(u);
                }

            }
            catch (Exception) { MessageBox.Show("Ошибка сохранения данных"); }

        }


        private RelayCommand _sortAirpl;
        public RelayCommand SortAirplane
        {
            get
            {
                return _sortAirpl = _sortAirpl ??
                  new RelayCommand(SortAirp, CanSortAirp);
            }
        }
        private bool CanSortAirp()
        {
            return true;
        }
        private void SortAirp()
        {
            try
            {
                ObservableCollection<Airplane> ai = db.GetAirplanes(pageNumberAirp, pageSize);
                List<Airplane> air = ai.OrderBy(a => a.Count_seats).ToList();
                _airplanes.Clear();
                foreach (var a in air)
                {
                    _airplanes.Add(a);
                }

            }
            catch (Exception) { MessageBox.Show("Ошибка сохранения данных"); }

        }


        private RelayCommand _sortProd;
        public RelayCommand SortProduser
        {
            get
            {
                return _sortProd = _sortProd ??
                  new RelayCommand(SortProd, CanSortProd);
            }
        }
        private bool CanSortProd()
        {
            return true;
        }
        private void SortProd()
        {
            try
            {
                ObservableCollection<Produser> ai = db.GetProdusers(pageNumberAirp, pageSize);
                List<Produser> air = ai.OrderBy(a => a.Land).ToList();
                _produsers.Clear();
                foreach (var a in air)
                {
                    _produsers.Add(a);
                }

            }
            catch (Exception) { MessageBox.Show("Ошибка сохранения данных"); }

        }



        private void Produser_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += produser_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= produser_PropertyChanged;
                }
            }
        }
       
        private void produser_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender as Produser != null)
            {
                Produser row = sender as Produser;
                produserUpdate.Add(row);
            }
        }

        private void Airplane_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += airplane_PropertyChanged;
                }
            }
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= airplane_PropertyChanged;
                }
            }
        }
       
        private void airplane_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender as Airplane != null)
            {
                Airplane row = sender as Airplane;
                
            }
        }
    }
}
