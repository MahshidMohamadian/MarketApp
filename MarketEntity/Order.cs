using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp
{
   public abstract class Order
   {
       public virtual Guid Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string Title { get; set; }
      

       public Order()
       {
           Id = Guid.NewGuid();
          
           
       }

        
    }
}
