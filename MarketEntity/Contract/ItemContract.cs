using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Contract
{
  public  class ItemContract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public int Code { get; set; }
    }
}
