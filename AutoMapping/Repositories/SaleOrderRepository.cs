using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Entities;
using MarketApp.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace AutoMapping.Repositories
{
   public class SaleOrderRepository : ISaleOrderRepository
   {
       private ISession session;
        public IQueryable<MarketApp.Entities.SaleOrder> GetAll()
        {
            return session.Query<SaleOrder>();
        }

        public MarketApp.Entities.SaleOrder Get(Guid id)
        {
            return session.Get<SaleOrder>(id);
        }

        public void Insert(MarketApp.Entities.SaleOrder obj)
        {
            session.Save(obj);
        }

        public void Update(MarketApp.Entities.SaleOrder obj)
        {
            session.Update(obj);
        }

        public void Delete(MarketApp.Entities.SaleOrder obj)
        {
            session.Delete(obj);
        }
    }
}
