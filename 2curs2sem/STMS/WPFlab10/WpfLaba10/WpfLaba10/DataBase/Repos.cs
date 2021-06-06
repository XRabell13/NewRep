using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLaba10.Model;

namespace WpfLaba10.DataBase
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public class AirplaneRepository : IRepository<Airplane>
    {
        private AirplaneContext db;

        public AirplaneRepository(AirplaneContext context)
        {
            this.db = context;
        }

        public IEnumerable<Airplane> GetAll()
        {
            return db.Airplanes;
        }

        public Airplane Get(int id)
        {
            return db.Airplanes.Find(id);
        }

        public void Create(Airplane airp)
        {
            db.Airplanes.Add(airp);
        }

        public void Update(Airplane book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Airplane airs = db.Airplanes.Find(id);
            if (airs != null)
                db.Airplanes.Remove(airs);
        }
    }

    public class ProduserrRepository : IRepository<Produser>
    {
        private AirplaneContext db;

        public ProduserrRepository(AirplaneContext context)
        {
            this.db = context;
        }

        public IEnumerable<Produser> GetAll()
        {
            return db.Produsers;
        }

        public Produser Get(int id)
        {
            return db.Produsers.Find(id);
        }

        public void Create(Produser order)
        {
            db.Produsers.Add(order);
        }

        public void Update(Produser order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Produser order = db.Produsers.Find(id);
            if (order != null)
                db.Produsers.Remove(order);
        }
    }
}
