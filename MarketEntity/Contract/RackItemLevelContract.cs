using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Contract
{
    public class RackItemLevelContract
    {
        public Guid Id { get; set; }
        public Guid RackId { get; set; }
        public Guid ItemId { get; set; }
        public int CurrentQuantity { get; set; }
        public int InQuantity { get; set; }
        public int OutQuantity { get; set; }
    }
}
