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
  public  class SaleOrderMapping :IAutoMappingOverride<SaleOrder>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<SaleOrder> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
            mapping.Map(x => x.CreationDate);
            mapping.Map(x => x.Title);
            mapping.HasMany(x => x.SaleOrderItems).Cascade.AllDeleteOrphan();
        }
    }
}
