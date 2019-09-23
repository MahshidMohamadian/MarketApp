using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Entities;

namespace MarketApp
{
     public abstract class OrderItem
    {
        public OrderItem()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
        public virtual int NetPrice { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int TotalPrice { get; set; }
        public virtual int UnitPrice { get; set; }
        public virtual Item Item { get; set; }
        public virtual Rack Rack { get; set; }
       
    }
}
