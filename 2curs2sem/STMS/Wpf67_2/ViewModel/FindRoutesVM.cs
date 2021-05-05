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
    public class FindRoutesVM
    {
        string _beginCity, _endCity;
        DateTime _dateTime;
      
        DateTime Date { get => _dateTime; set { _dateTime = value; } }
        public string BeginCity { get => _beginCity; set { _beginCity = value; } }
        public string EndCity { get => _endCity; set { _endCity = value; } }

        private FindRoute _selectRoute;
        public FindRoute SelectRoute { get => _selectRoute; set { _selectRoute = value; } }

        List<FindRoute> _findRoutes = new List<FindRoute>();
       public List<FindRoute> FindRoutes
        {
            get => _findRoutes;
            set
            {
                _findRoutes = value;
            }
        }
       

        DataBase.DataBaseLoad db = new DataBase.DataBaseLoad();

        public FindRoutesVM(string beginCity, string endCity, DateTime date)
        {
            _beginCity = beginCity;
            _endCity = endCity;
            _dateTime = date;

           FindRoutes = db.GetFindRoutes(beginCity,endCity,date);
        
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
            if (_selectRoute != null)
                MessageBox.Show(_selectRoute.ToString());
            else MessageBox.Show("Выберите рейс");
        }
    }
}
