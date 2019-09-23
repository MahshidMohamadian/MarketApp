using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using MarketApp.Entities;

namespace AutoMapping
{

    public class NhibernateHelper : DefaultAutomappingConfiguration
    {
        private static ISessionFactory _factory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_factory == null)
                {
                    var connectionString = String.Empty;

                    var cfgi = new StoreConfiguration();

                    var fluentConfiguration = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(@"Data Source=.;Initial Catalog=MarketApp;User ID=sa;Password=s@123456")
                            .ShowSql()
                        );

                    var configuration =
                        fluentConfiguration.Mappings(m =>
                            m.AutoMappings.Add(AutoMap.AssemblyOf<Item>(cfgi)
                                .UseOverridesFromAssemblyOf<ItemMapping>())
                        );
                    var buildSessionFactory = configuration.ExposeConfiguration(cfg =>
                        {
                            new SchemaUpdate(cfg).Execute(false, true);
                            new SchemaExport(cfg)
                                .Create(false, false);
                        })
                        .BuildSessionFactory();



                    _factory = buildSessionFactory;
                }

                return _factory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


        

    }
}
