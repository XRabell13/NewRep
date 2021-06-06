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

namespace WpfLaba10
{
    public interface IMainWindowsCodeBehind
    {
        void ShowMessage(string message);
        void LoadView(ViewType typeView);
        void LoadView(ViewType typeView, object ob);
    }

    public enum ViewType
    {
        ViewInfo,
        AddInfo,
        DeleteInfo,
        Search,
        PictureView
        
    }
 
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        public MainWindow()
        {
           
            InitializeComponent();
          
            MainWindow_Loaded();
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.ViewInfo:
                    
                    View.ViewInfo view = new View.ViewInfo();
                    ViewModel.ViewInfoVM vm = new ViewModel.ViewInfoVM(this);
                    view.DataContext = vm;
                    this.OutputView.Content = view;
                    break;

                case ViewType.AddInfo:
                    View.AddInfo viewAdd = new View.AddInfo();
                    ViewModel.AddInfoVM vmCreateAd = new ViewModel.AddInfoVM(this);
                    viewAdd.DataContext = vmCreateAd;
                    this.OutputView.Content = viewAdd;
                    break;

                case ViewType.DeleteInfo:
                    View.DeleteInfo viewDel = new View.DeleteInfo();
                    ViewModel.DeleteInfoVM vmDel = new ViewModel.DeleteInfoVM(this);
                    viewDel.DataContext = vmDel;
                    this.OutputView.Content = viewDel;
                    break;
                case ViewType.Search:
                    View.SearchInfo viewS = new View.SearchInfo();
                    ViewModel.SearchVM vmS = new ViewModel.SearchVM();
                    viewS.DataContext = vmS;
                    this.OutputView.Content = viewS;
                    break;
            }
        }
        public void LoadView(ViewType typeView, object ob)
        {
            switch (typeView)
            {
                case ViewType.PictureView:

                    View.PictureView view = new View.PictureView();
                    ViewModel.PictureVM vm = new ViewModel.PictureVM(ob);
                    view.DataContext = vm;
                    this.OutputView.Content = view;
                    break;

              
            }
        }
        private void MainWindow_Loaded()
        {
           
            ViewModel.MainWindowVM vm = new ViewModel.MainWindowVM();
            vm.CodeBehind = this;
            this.DataContext = vm;
            LoadView(ViewType.ViewInfo);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
