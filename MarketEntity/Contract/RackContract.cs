﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Contract
{
  public  class RackContract
    {
        public Guid RackId { get; set; }
        public Guid Id { get; set; }
        public int Limit { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
