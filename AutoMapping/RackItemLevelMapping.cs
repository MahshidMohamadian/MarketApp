using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping.Alterations;
using MarketApp;
using MarketApp.Entities;
using FluentNHibernate.Automapping;

namespace AutoMapping
{
    public class RackItemLevelMapping :IAutoMappingOverride<RackItemLevel>
    {
        public void Override(AutoMapping<RackItemLevel> mapping)
        {
             mapping.Id(x => x.Id).Column("RackItemLevelId").GeneratedBy.Assigned();
            mapping.Map(x => x.CurrentQuantity).Column("CurrentQuantity");
            mapping.Map(x => x.InQuantity).Column("InQuantuty");
            mapping.Map(x => x.OutQuantity).Column("OutQuantity");
            mapping.References(x => x.Item);
            mapping.References(x => x.Rack);
        }
    }
}
