using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Entities;

namespace MarketApp
{
   public abstract class Order :BaseEntity
   {
       public virtual int Code { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string Title { get; set; }
      

       public Order()
       {

       }

        
    }
}
