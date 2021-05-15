using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf67.Command;
using Wpf67.Model;

namespace Wpf67.ViewModel
{
    class ChoiseSeatVM
    {
        DataBase.DataBaseLoad db = new DataBase.DataBaseLoad();
        List<ChoiseSeat> _listButton;
       public List<ChoiseSeat> ListButtons
        {
            get => _listButton;
            set => _listButton = value;
        }

        ChoiseSeat _selectListButton;
        public ChoiseSeat SelectListButton
        {
            get => _selectListButton;
            set 
            {
                _selectListButton = value;
                MessageBox.Show(value.NumberSeat.ToString());
            }
        }
        IMMCodeBehind mainWindow;

        string _beginCity, _endCity;
        public string BeginCity { get => _beginCity; set { _beginCity = value; } }
        public string EndCity { get => _endCity; set { _endCity = value; } }

           Visibility _showListBox;
        public Visibility ShowListBox { get => _showListBox;
            set 
            {
                _showListBox = value;
            }
        }
        Visibility _showNoRoutes;
        public Visibility ShowNoTickets
        {
            get => _showNoRoutes;
            set
            {
                _showNoRoutes = value;
            }
        }

        public ChoiseSeatVM(IMMCodeBehind mainWindow, int id_route, string beginCity, string endCity, DateTime date)
        {
            this.mainWindow = mainWindow;
            _beginCity = beginCity;
            _endCity = endCity;
            ListButtons = db.GetTickets(id_route, date);
            if (ListButtons.Count == 0)
            {
                ShowListBox = Visibility.Collapsed;
                ShowNoTickets = Visibility.Visible;
            }
            else
            {
                ShowListBox = Visibility.Visible;
                ShowNoTickets = Visibility.Collapsed;
            }
        }

        private MyCommand _nextPage;
        public MyCommand NextPage
        {
            get
            {
                return _nextPage = _nextPage ??
                  new MyCommand(ShowNextPage, CanLoadNextPage);
            }
        }
        private bool CanLoadNextPage()
        {
            return true;
        }
        private void ShowNextPage()
        {

            mainWindow.LoadViewWhithParam(ViewType.ReserveTicket, null, null, null, null);

        }

    }
}
