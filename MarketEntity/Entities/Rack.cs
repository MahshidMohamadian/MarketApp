﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Entities
{
   public class Rack : BaseEntity
   {
       

       public Rack()
       {
           
       }

       public virtual int Code { get; set; }
        public virtual int Limit { get; set; }
        public virtual string Location { get; set; }
        public virtual string Name { get; set; }
       public virtual Rack RackParent { get; set; }


    }
}
