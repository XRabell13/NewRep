using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Wpf67.Command;

namespace Wpf67.ViewModel
{
    class ReserveTicketVM
    {
        IMMCodeBehind mainWindow;
        DataBase.DataBaseLoad db = new DataBase.DataBaseLoad();
        string _first_name, _last_name, _patronymic, _passport, _select_route_bus, id_ticket, id_end_point;

        public string FirstName
        { get => _first_name; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    if (value.Length < 45) 
                        _first_name = value;
                
            }
        }
        public string LastName
        {
            get => _last_name;
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                if(value.Length<45)
                _last_name = value;
            }
        }
        public string Patronymic
        { get => _patronymic; set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    if (value.Length < 45) _patronymic = value;
            }
        }
        public string Passport
        {
            get => _passport;
            set
            {
               // string pattern = @"^((АВ|ВМ|НВ|КН|МР|МС|КВ|РР|SP|DP)[0-9]{7})?$";//
                string pattern = @"^([A-z]{2}[0-9]{7})?$";//

                if (Regex.IsMatch(value, pattern, RegexOptions.None))
                {
                    _passport = value;

                }
                else
                    MessageBox.Show("Некорректный номер или серия паспорта");
             
            }
        }
        public string SelectRouteBus
        { get => _select_route_bus; set => _select_route_bus = value; }
        public ReserveTicketVM(IMMCodeBehind mainWindow, string beginCity, string endCity, decimal cost, string btime, string etime, int num_seat, string date, string id_ticket, string id_epoint)
        {
            this.mainWindow = mainWindow;
          
            SelectRouteBus = beginCity + " - " + endCity + "\nДата: "+ date +" "+ btime+" - "+etime +"\nМесто: "+num_seat+". Цена: " + cost;
            this.id_ticket = id_ticket;
            id_end_point = id_epoint;
        }


        private MyCommand _nextPage;
        public MyCommand ReserveTicket
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
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(Patronymic) && !string.IsNullOrWhiteSpace(Passport))
            {

                db.AddUserInfo(FirstName,LastName,Patronymic,Passport);
                db.AddUserTicket(Wpf67.Properties.Settings.Default.UserId.ToString(),id_ticket,id_end_point);
                mainWindow.LoadView(ViewType.MyTrips);
            }
            else MessageBox.Show("Заполните все поля");
          

        }


    }
}
