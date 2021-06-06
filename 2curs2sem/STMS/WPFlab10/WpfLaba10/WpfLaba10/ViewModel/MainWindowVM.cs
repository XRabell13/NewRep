using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLaba10.ViewModel
{
    class MainWindowVM 
    {
        public IMainWindowsCodeBehind CodeBehind { get; set; }

        private RelayCommand _LoadCreateAdPageCommand;
        public RelayCommand LoadAddInfo
        {
            get
            {
                return _LoadCreateAdPageCommand = _LoadCreateAdPageCommand ??
                  new RelayCommand(OnLoadCreateAdPage, CanLoadCreateAdPage);
            }
        }
        private bool CanLoadCreateAdPage()
        {
            return true;
        }
        private void OnLoadCreateAdPage()
        {
            CodeBehind.LoadView(ViewType.AddInfo);
        }

        // Возвращение к главной вьюшке
        private RelayCommand _LoadMainCommand;
        public RelayCommand LoadViewInfo
        {
            get
            {
                return _LoadMainCommand = _LoadMainCommand ??
                  new RelayCommand(OnLoadMain, CanLoadMain);
            }
        }
        private bool CanLoadMain()
        {
            return true;
        }
        private void OnLoadMain()
        {
            CodeBehind.LoadView(ViewType.ViewInfo);
        }

        private RelayCommand _LoadDeleteInfo;
        public RelayCommand LoadDeleteInfo
        {
            get
            {
                return _LoadDeleteInfo = _LoadDeleteInfo ??
                  new RelayCommand(OnLoadDeleteInfo, CanLoadDeleteInfo);
            }
        }
        private bool CanLoadDeleteInfo()
        {
            return true;
        }
        private void OnLoadDeleteInfo()
        {
            CodeBehind.LoadView(ViewType.DeleteInfo);
        }

        private RelayCommand _LoadSearchInfo;
        public RelayCommand LoadSearchInfo
        {
            get
            {
                return _LoadSearchInfo = _LoadSearchInfo ??
                  new RelayCommand(OnLoadSearchInfo, CanLoadSearchInfo);
            }
        }
        private bool CanLoadSearchInfo()
        {
            return true;
        }
        private void OnLoadSearchInfo()
        {
            CodeBehind.LoadView(ViewType.Search);
        }
    }
}
