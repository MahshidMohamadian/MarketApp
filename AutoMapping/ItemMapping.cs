using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MarketApp;
using MarketApp.Entities;

namespace AutoMapping
{
    public class ItemMapping : IAutoMappingOverride<Item>
    {
        public void Override(AutoMapping<Item> mapping)
        {
            mapping.Id(x => x.Id).Column("ItemId").Not.GeneratedBy.Assigned();
            mapping.Map(x => x.Unit).Column("Unit");
            mapping.Map(x => x.Name).Column("Name");
        }
    }
}
