using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Contract
{
    public class PurchaseOrderItemContract
    {
        public Guid RackId { get; set; }
        public Guid ItemId { get; set; }
        public Guid Id { get; set; }
        public int NetPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int UnitPrice { get; set; }

    }
}
