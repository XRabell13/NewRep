using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLaba10.DataBase
{
    public class UnitOfWork : IDisposable
    {
        private AirplaneContext db = new AirplaneContext();
        private AirplaneRepository bookRepository;
        private ProduserrRepository orderRepository;

        public AirplaneRepository Airplanes
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new AirplaneRepository(db);
                return bookRepository;
            }
        }

        public ProduserrRepository Produsers
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new ProduserrRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
