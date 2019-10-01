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
    public class PurchaseOrderService
    {
        public IPurchaseOrderRepository PurchaseOrderRepository { get; set; }
        public IItemRepository ItemRepository { get; set; }
        public IRackRepository RackRepository { get; set; }

        public void CreateOrUpdate(PurchaseOrderContract purchaseOrderContract)
        {
            var purchaseorder = PurchaseOrderRepository.Get(purchaseOrderContract.Id);
            if (purchaseorder != null)
            {
                purchaseorder.Code = purchaseOrderContract.Code;
                //purchaseorder.CreationDate = purchaseOrderContract.CreationDate;
                purchaseorder.Title = purchaseOrderContract.Title;
                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItems.Count; i++)
                {
                    var temp = purchaseOrderContract.PurchaseOrderItems[i];
                    if (purchaseorder.PurcahseOrderItems.Any(p => p.Id == temp.Id))
                    {
                        var indatabasepurchaseorder = purchaseorder.PurcahseOrderItems.FirstOrDefault(p => p.Id == temp.Id);
                        indatabasepurchaseorder.NetPrice = temp.NetPrice;
                        indatabasepurchaseorder.Quantity = temp.Quantity;
                        indatabasepurchaseorder.TotalPrice = temp.TotalPrice;
                        indatabasepurchaseorder.UnitPrice = temp.UnitPrice;
                        indatabasepurchaseorder.Item = ItemRepository.Get(temp.ItemId);
                        indatabasepurchaseorder.Rack = RackRepository.Get(temp.RackId);

                    }
                    else
                    {

                        var purchaseorderitem = new PurchaseOrderItem();
                        purchaseorderitem.NetPrice = temp.NetPrice;
                        purchaseorderitem.Quantity = temp.Quantity;
                        purchaseorderitem.TotalPrice = temp.TotalPrice;
                        purchaseorderitem.UnitPrice = temp.UnitPrice;
                        purchaseorderitem.Item = ItemRepository.Get(temp.ItemId);
                        purchaseorderitem.Rack = RackRepository.Get(temp.RackId);


                        purchaseorder.PurcahseOrderItems.Add(purchaseorderitem);
                    }

                }
                for (int i = 0; i < purchaseorder.PurcahseOrderItems.Count; i++)
                {
                    var temp = purchaseorder.PurcahseOrderItems.ToArray()[i];
                    if (!purchaseOrderContract.PurchaseOrderItems.Any(p => p.Id == temp.Id))
                    {
                        purchaseorder.PurcahseOrderItems.Remove(temp);
                    }
                   

                }

                PurchaseOrderRepository.Update(purchaseorder);
            }
            else
            {
                purchaseorder = new PurchaseOrder();
                purchaseorder.Code = purchaseOrderContract.Code;
                purchaseorder.CreationDate = purchaseOrderContract.CreationDate;
                purchaseorder.Title = purchaseOrderContract.Title;
                for (int i = 0; i < purchaseOrderContract.PurchaseOrderItems.Count; i++)
                {
                    var temp = purchaseOrderContract.PurchaseOrderItems[i];
                   
                    var indatabaepurchaseorder = purchaseorder.PurcahseOrderItems.FirstOrDefault(p => p.Id == temp.Id);
                    indatabaepurchaseorder.NetPrice = temp.NetPrice;
                    indatabaepurchaseorder.Quantity = temp.Quantity;
                    indatabaepurchaseorder.TotalPrice = temp.TotalPrice;
                    indatabaepurchaseorder.UnitPrice = temp.UnitPrice;
                    indatabaepurchaseorder.Item = ItemRepository.Get(temp.ItemId);
                    indatabaepurchaseorder.Rack = RackRepository.Get(temp.RackId);
                    
                }

                PurchaseOrderRepository.Insert(purchaseorder);
            }
        }

        public void Delete(PurchaseOrderContract purchaseOrderContract)
        {
            var purchaseorder = PurchaseOrderRepository.Get(purchaseOrderContract.Id);
            PurchaseOrderRepository.Delete(purchaseorder);
        }
    }
}
