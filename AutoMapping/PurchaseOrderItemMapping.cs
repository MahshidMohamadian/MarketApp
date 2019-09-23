using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping.Alterations;
using MarketApp.Entities;

namespace AutoMapping
{
   public class PurchaseOrderItemMapping : IAutoMappingOverride<PurchaseOrderItem>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<PurchaseOrderItem> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            mapping.Map(x => x.NetPrice);
            mapping.Map(x => x.Quantity);
            mapping.Map(x => x.TotalPrice);
            mapping.Map(x => x.UnitPrice);
            mapping.References(x => x.Item).Unique();
            mapping.References(x => x.Rack).Unique();
        }
    }
}
