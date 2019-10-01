using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Contract;
using MarketApp.Entities;
using MarketApp.Interfaces;

namespace Market.Servises
{
   public class RackItemLevelService 
    {
        public IRackItemLevelRepository RackItemLevelRepository { get; set; }
        public IItemRepository ItemRepository { get; set; }
        public IRackRepository RackRepository { get; set; }
        public void CreateOrUpdate(RackItemLevelContract rackItemLevelContract)
        {
            var rackItemLevel = RackItemLevelRepository.Get(rackItemLevelContract.Id);
            if (rackItemLevel != null)
            {
                rackItemLevel.Item = ItemRepository.Get(rackItemLevelContract.ItemId);
                rackItemLevel.Rack = RackRepository.Get(rackItemLevelContract.RackId);
                rackItemLevel.CurrentQuantity = rackItemLevel.CurrentQuantity;
                rackItemLevel.InQuantity = rackItemLevel.InQuantity;
                rackItemLevel.OutQuantity = rackItemLevel.OutQuantity;

                RackItemLevelRepository.Update(rackItemLevel);
            }
            else
            {
                rackItemLevel = new RackItemLevel();
                rackItemLevel.Item = ItemRepository.Get(rackItemLevelContract.ItemId);
                rackItemLevel.Rack = RackRepository.Get(rackItemLevelContract.RackId);
                rackItemLevel.CurrentQuantity = rackItemLevel.CurrentQuantity;
                rackItemLevel.InQuantity = rackItemLevel.InQuantity;
                rackItemLevel.OutQuantity = rackItemLevel.OutQuantity;

                RackItemLevelRepository.Insert(rackItemLevel);
            }

        }

        public void Delete(RackItemLevelContract rackItemLevelContract)
        {
            var rackItemLevel = RackItemLevelRepository.Get(rackItemLevelContract.Id);
            RackItemLevelRepository.Delete(rackItemLevel);
        }

    }
}
