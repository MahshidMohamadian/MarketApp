using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Entities
{
    
    
  public  class Item : BaseEntity
  {
      

      public Item()
      {
         
      }

        public virtual string Name { get; set; }
        public virtual Unit Unit { get; set; }
      //..
        
      
    }
}
