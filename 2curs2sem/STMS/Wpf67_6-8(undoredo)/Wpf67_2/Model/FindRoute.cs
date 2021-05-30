using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf67.Model
{
   public class FindRoute
    {
        string _beginCity, _endCity;
        string _beginTime, _endTime;
       
        public string BeginCity { get => _beginCity; set { _beginCity = value; } }
        public string EndCity { get => _endCity; set { _endCity = value; } }
        public string BeginTime { get => _beginTime; set { _beginTime = value; } }
        public string EndTime { get => _endTime; set { _endTime = value; } }


        decimal _cost;
        int _id_route;
        string _model_bus, _named_tr;

        public int IdRoute
        {
            get => _id_route;
            set
            {
                if (value == _id_route)
                    return;

                _id_route = value;
              
            }
        }
        public string NamedTransporter
        {
            get => _named_tr;
            set
            {
                if (value == _named_tr)
                    return;

                _named_tr = value;
             
            }
        }
        public decimal Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value == _cost)
                    return;

                _cost = value;
            }
        }

        public string ModelBus
        {
            get
            {
                return _model_bus;
            }
            set
            {
                if (value == _model_bus)
                    return;

                _model_bus = value;
            }
        }
        public FindRoute(int idRoute, string bcity, string ecity, string etime, string modelBus, string namedTransporter, string btime, decimal cost)
        {
            _id_route = idRoute;
            _model_bus = modelBus;
            _named_tr = namedTransporter;
            _cost = cost;
            _beginCity = bcity;
            _endCity = ecity;
            _beginTime = btime;
            _endTime = etime;
           
        }

        public override string ToString()
        {
            return IdRoute + " " + NamedTransporter;
        }
    }
}
