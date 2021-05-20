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
        List<Ticket> _listButton;
       public List<Ticket> ListTickets
        {
            get => _listButton;
            set => _listButton = value;
        }

        Ticket _selectListButton;
        public Ticket SelectTicket
        {
            get => _selectListButton;
            set 
            {
                _selectListButton = value;
            }
        }
        IMMCodeBehind mainWindow;

        string _beginCity, _endCity, _btime, _etime, _date;
        decimal _cost;
       
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

        public ChoiseSeatVM(IMMCodeBehind mainWindow, int id_route, string beginCity, string endCity, DateTime date, decimal cost, string btime, string etime)
        {
            this.mainWindow = mainWindow;
            _beginCity = beginCity;
            _endCity = endCity;
            _cost = cost;
            _btime = btime;
            _etime = etime;
            _date = date.ToString().Remove(10);
            ListTickets = db.GetTickets(id_route, date);

            if (ListTickets.Count == 0)
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
            if (SelectTicket != null)
                mainWindow.LoadViewWhithParam(ViewType.ReserveTicket, _beginCity, _endCity, _cost, _btime, _etime, SelectTicket.num_seat, _date, SelectTicket.id_ticket, EndCity);
            else MessageBox.Show("Выберите место для поездки");

        }

    }
}
