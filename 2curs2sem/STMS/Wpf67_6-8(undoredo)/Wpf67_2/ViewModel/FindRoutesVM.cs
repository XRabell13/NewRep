﻿using System;
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

        Visibility _showListBox;
        public Visibility ShowListBox { get => _showListBox;
            set 
            {
                _showListBox = value;
            }
        }
        Visibility _showNoRoutes;
        public Visibility ShowNoRoutes
        {
            get => _showNoRoutes;
            set
            {
                _showNoRoutes = value;
            }
        }

        private IMMCodeBehind mainWindow;

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

        public FindRoutesVM(IMMCodeBehind mainWindow, string beginCity, string endCity, DateTime date)
        {
            this.mainWindow = mainWindow;
            _beginCity = beginCity;
            _endCity = endCity;
            _dateTime = date;

            db.UpdateOldTickets();
           FindRoutes = db.GetFindRoutes(beginCity,endCity,GetDay(date), date);
            if (FindRoutes.Count == 0)
            {
                ShowListBox = Visibility.Collapsed;
                ShowNoRoutes = Visibility.Visible;
            }
            else
            {
                ShowListBox = Visibility.Visible;
                ShowNoRoutes = Visibility.Collapsed;
            }

        }

        private string GetDay(DateTime date)
        {
            string timetable = "";
            int day = Convert.ToInt32(date.DayOfWeek);
            if (day == 1) timetable = "пн";
            if (day == 2) timetable = "вт";
            if (day == 3) timetable = "ср";
            if (day == 4) timetable = "чт";
            if (day == 5) timetable = "пт";
            if (day == 6) timetable = "сб";
            if (day == 0) timetable = "вс";

            if (timetable == "")
                return "";
            else return timetable;
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
            if (Wpf67.Properties.Settings.Default.Authoriz)
                //int id_route, string beginCity, string endCity, DateTime date, int cost, string btime, string etime
                //    mainWindow.LoadViewWhithParam(ViewType.ReserveTicket, _beginCity, _endCity, _selectRoute.Cost, _selectRoute.EndTime, _selectRoute.BeginTime, null, null);
                mainWindow.LoadViewWhithParam(ViewType.ChoiseSeat, SelectRoute.IdRoute, BeginCity, EndCity, Date, _selectRoute.Cost, _selectRoute.BeginTime, _selectRoute.EndTime,null,null);
            else MessageBox.Show("Для бронирования билета необходимо зарегистрироваться.");
          
        }
    }
}
