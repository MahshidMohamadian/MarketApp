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
  public class RackMapping : IAutoMappingOverride<Rack>
    {

        public void Override(FluentNHibernate.Automapping.AutoMapping<Rack> mapping)
        {
            mapping.Id(x=>x.Id).Column("RackId").Not.GeneratedBy.Assigned();
            mapping.Map(x => x.Limit).Column("Limit");
            mapping.Map(x => x.Location).Column("Location");
            mapping.Map(x => x.Name).Column("Name");
            mapping.References(x => x.RackParent).Unique();
        }
    }
}
