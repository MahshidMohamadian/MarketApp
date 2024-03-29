﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Entities;

namespace MarketApp.Contract
{
   public class PurchaseOrderContract
    {
        public PurchaseOrderContract()
        {
            PurchaseOrderItems=new List<PurchaseOrderItemContract>();
        }
        public Guid Id { get; set; }
        public int Code { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public List<PurchaseOrderItemContract> PurchaseOrderItems { get; set; }
    }
}
