using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using MarketApp.Entities;

namespace AutoMapping
{
   public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            //return type.Namespace == "MarketApp.Entities";
            //return type.BaseType == typeof(BaseEntity);

            return typeof(BaseEntity).IsAssignableFrom(type);
        }
    }
}
