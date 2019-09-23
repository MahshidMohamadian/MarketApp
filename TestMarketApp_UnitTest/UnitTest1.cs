using System;
using System.Security.Cryptography.X509Certificates;
using AutoMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketApp;
using MarketApp.Entities;
using NHibernate;

namespace TestMarketApp_UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Item()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    var ItemId = GetItemId();
                    Item item = session.Get<Item>(ItemId);
                    session.Save(item);
                    var result =session.Get<Item>(item.Id);
                    Assert.IsNotNull(result);


                }
            }
        }


        public Guid GetItemId()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    Item item = new Item
                    {
                        Name = "Onion",
                        Unit = Unit.Kilo
                    };
                    session.Save(item);
                    transaction.Commit();
                    item = session.Get<Item>(item.Id);
                    return item.Id;
                }
            }
        }

        public Guid GetRackId()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Rack rack = new Rack
                    {
                        Limit = 10,
                        Location = "row2",
                        Name = "Pen"
                    };
                    rack.RackParent = rack;
                    session.Save(rack);
                    transaction.Commit();
                    rack = session.Get<Rack>(rack.Id);
                    return rack.Id;
                }
            }
        }


        [TestMethod]
        public void Rack()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    var RackId = GetRackId();
                    Rack rack = session.Get<Rack>(RackId);

                    session.Save(rack);
                    
                    transaction.Commit();
                    var result = session.Get<Rack>(rack.Id);
                    
                   
                    Assert.IsNotNull(result);

                }
            }
        }


        public Guid GetRackItemLevelId()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var ItemId = GetItemId();
                    Item item = session.Get<Item>(ItemId);

                    var RackId = GetRackId();
                    Rack rack = session.Get<Rack>(RackId);

                    RackItemLevel rackItemLevel = new RackItemLevel
                    {
                        CurrentQuantity = 10,
                        InQuantity = 5,
                        OutQuantity = 10,
                        Rack = rack,
                        Item = item
                    };

                    session.Save(rackItemLevel);
                    transaction.Commit();

                    rackItemLevel = session.Get<RackItemLevel>(rackItemLevel.Id);
                    return rackItemLevel.Id;
                }
            }
        }

        [TestMethod]
        public void RackItemLevel()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    var RackItemLevelId = GetRackItemLevelId();
                    RackItemLevel rackItemLevel = session.Get<RackItemLevel>(RackItemLevelId);
                     transaction.Commit();

                    var result = session.Get<RackItemLevel>(rackItemLevel.Id);
                    Assert.IsNotNull(result);


                }
            }
        }
        [TestMethod]
        public void PurchaseOrder()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var ItemId = GetItemId();
                    Item item = session.Get<Item>(ItemId);

                    var RackId = GetRackId();
                    Rack rack = session.Get<Rack>(RackId);


                    PurchaseOrder purchaseOrder = new PurchaseOrder
                    {
                          CreationDate = DateTime.Now,
                        Title  = "Kharid"
                    };
                    PurchaseOrderItem purchaseOrderItem = new PurchaseOrderItem
                    {
                        Item = item,
                        Rack = rack,
                         NetPrice = 100,
                         Quantity = 10,
                         TotalPrice = 50,
                         UnitPrice = 150
                    };

                    purchaseOrder.PurcahseOrderItems.Add(purchaseOrderItem);

                    session.Save(purchaseOrder);
                    transaction.Commit();

                    Assert.IsNotNull(session.Get<PurchaseOrderItem>(purchaseOrderItem.Id));
                }
            }
        }

        [TestMethod]
        public void SaleOrder()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var ItemId = GetItemId();
                    Item item = session.Get<Item>(ItemId);

                    var RackId = GetRackId();
                    Rack rack = session.Get<Rack>(RackId);

                    SaleOrder saleOrder = new SaleOrder
                    {
                          CreationDate = DateTime.Now,
                          Title = "Forush"
                    };

                    SaleOrderItem saleOrderItem = new SaleOrderItem
                    {
                        Item = item,
                        Rack = rack,
                         NetPrice = 50,
                         Quantity = 90,
                         TotalPrice = 36,
                         UnitPrice = 60
                    };

                    saleOrder.SaleOrderItems.Add(saleOrderItem);
                    session.Save(saleOrder);
                    transaction.Commit();

                    Assert.IsNotNull(session.Get<SaleOrderItem>(saleOrderItem.Id));
                }
            }
        }
    }
}
