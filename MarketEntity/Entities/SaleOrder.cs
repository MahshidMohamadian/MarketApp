using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Entities;

namespace MarketApp.Entities
{
   public class SaleOrder : Order
    {
        public virtual ICollection<SaleOrderItem> SaleOrderItems { get; set; }

        public SaleOrder()
        {
            SaleOrderItems = new List<SaleOrderItem>();
        }
    }
}
