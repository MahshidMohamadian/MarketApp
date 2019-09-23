using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Entities;

namespace MarketApp.Entities
{
   public class PurchaseOrder : Order
    {
        public virtual ICollection<PurchaseOrderItem> PurcahseOrderItems { get; set; }

        public PurchaseOrder()
        {
            PurcahseOrderItems = new List<PurchaseOrderItem>();
        }
    }
}
