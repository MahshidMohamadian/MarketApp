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
    public class SaleOrderService 
    {
        public ISaleOrderRepository SaleOrderRepository { get; set; }
        public IItemRepository ItemRepository { get; set; }
        public IRackRepository RackRepository { get; set; }
        public void CreateOrUpdate(SaleOrderContract saleOrderContract)
        {
            var saleorder = SaleOrderRepository.Get(saleOrderContract.Id);
            if (saleorder != null)
            {
                saleorder.Code = saleOrderContract.Code;
                //saleorder.CreationDate = saleOrderContract.CreationDate;
                saleorder.Title = saleOrderContract.Title;
                for (int i = 0; i < saleOrderContract.SaleOrderItems.Count; i++)
                {
                    var temp = saleOrderContract.SaleOrderItems[i];
                    if (saleorder.SaleOrderItems.Any(s => s.Id == temp.Id))
                    {
                        var indatabaesaleorder = saleorder.SaleOrderItems.FirstOrDefault(s => s.Id == temp.Id);
                        indatabaesaleorder.NetPrice = temp.NetPrice;
                        indatabaesaleorder.Quantity = temp.Quantity;
                        indatabaesaleorder.TotalPrice = temp.TotalPrice;
                        indatabaesaleorder.UnitPrice = temp.UnitPrice;
                        indatabaesaleorder.Item = ItemRepository.Get(temp.ItemId);
                        indatabaesaleorder.Rack = RackRepository.Get(temp.RackId);
                    }
                    else
                    {
                        var saleorderitem = new SaleOrderItem();
                        saleorderitem.NetPrice = temp.NetPrice;
                        saleorderitem.Quantity = temp.Quantity;
                        saleorderitem.TotalPrice = temp.TotalPrice;
                        saleorderitem.UnitPrice = temp.UnitPrice;
                        saleorderitem.Item = ItemRepository.Get(temp.ItemId);
                        saleorderitem.Rack = RackRepository.Get(temp.RackId);

                        saleorder.SaleOrderItems.Add(saleorderitem);
                    }
                }
                for (int i = 0; i < saleorder.SaleOrderItems.Count; i++)
                {
                    var temp = saleorder.SaleOrderItems.ToArray()[i];
                    if (!saleOrderContract.SaleOrderItems.Any(s => s.Id == temp.Id))
                    {
                        saleorder.SaleOrderItems.Remove(temp);
                    }
                   
                }

                SaleOrderRepository.Update(saleorder);
            }
            else
            {
                saleorder = new SaleOrder();
                saleorder.Code = saleOrderContract.Code;
                saleorder.CreationDate = saleOrderContract.CreationDate;
                saleorder.Title = saleOrderContract.Title;
                for (int i = 0; i < saleOrderContract.SaleOrderItems.Count; i++)
                {
                    var temp = saleOrderContract.SaleOrderItems[i];
                   
                        var indatabaesaleorder = saleorder.SaleOrderItems.FirstOrDefault(s => s.Id == temp.Id);
                        indatabaesaleorder.NetPrice = temp.NetPrice;
                        indatabaesaleorder.Quantity = temp.Quantity;
                        indatabaesaleorder.TotalPrice = temp.TotalPrice;
                        indatabaesaleorder.UnitPrice = temp.UnitPrice;
                        indatabaesaleorder.Item = ItemRepository.Get(temp.ItemId);
                        indatabaesaleorder.Rack = RackRepository.Get(temp.RackId);
                    
                }

                SaleOrderRepository.Insert(saleorder);
            }
        }

        public void Delete(SaleOrderContract saleOrderContract)
        {
            var saleorder = SaleOrderRepository.Get(saleOrderContract.Id);
            SaleOrderRepository.Delete(saleorder);
        }
    }
}
