using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Entities;

namespace MarketApp.Entities
{
 public   class RackItemLevel :BaseEntity
    {
        public RackItemLevel()
        {
           
        }
       
        public virtual int CurrentQuantity { get; set; }
        public virtual int InQuantity { get; set; }
        public virtual int OutQuantity { get; set; }
        public virtual Item Item { get; set; }
        public virtual Rack Rack { get; set; }
    }
}
