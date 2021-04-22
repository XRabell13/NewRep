using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf67.Command;

namespace Wpf67.ViewModel
{
    class SearchVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private MainWindow mainWindow;

        public SearchVM(MainWindow win)
        {
            if (win == null) throw new ArgumentNullException(nameof(win));
            mainWindow = win;
        }

        
        private MyCommand loadSearch;
        public MyCommand LoadSearchPage
        {
            get
            {
                return loadSearch = loadSearch ??
                  new MyCommand(ShowSearchPage, CanLoadSearchPage);
            }
        }
        private bool CanLoadSearchPage()
        {
            return true;
        }
        private void ShowSearchPage()
        {
            mainWindow.LoadView(ViewType.Search);
        }
    }
}
