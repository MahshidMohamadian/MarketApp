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
    public class ItemService
    {
        public IItemRepository ItemRepository { get; set; }

       
        public void CreateOrUpdate(ItemContract itemContract)
        {

            
            var item =ItemRepository.Get(itemContract.Id);
            if (item!=null)
            {
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.Unit;

                ItemRepository.Update(item);
            }
            else
            {
                
                item=new Item();
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.Unit;
   
                ItemRepository.Insert(item);
            }
            
        }

        public void Delete(ItemContract itemContract)
        {
            var item = ItemRepository.Get(itemContract.Id);
            ItemRepository.Delete(item);
        }

    }
}
