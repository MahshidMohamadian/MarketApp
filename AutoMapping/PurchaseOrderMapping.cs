using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping.Alterations;
using MarketApp;
using MarketApp.Entities;

namespace AutoMapping
{
    public class PurchaseOrderMapping : IAutoMappingOverride<PurchaseOrder>
    {

        public void Override(FluentNHibernate.Automapping.AutoMapping<PurchaseOrder> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            mapping.Map(x => x.CreationDate).Column("CreationDate");
            mapping.Map(x => x.Title).Column("Title");
            mapping.HasMany(x => x.PurcahseOrderItems).Cascade.AllDeleteOrphan();
        }
    }
}
