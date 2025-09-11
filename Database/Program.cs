using Database.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

using var sessionFactory = Fluently.Configure()
    .Database(SQLiteConfiguration.Standard
        .ConnectionString("Data Source=Library.sqlite")
    )
    .Mappings(x => x.FluentMappings
        .AddFromAssemblyOf<GameMap>()
    )
    .ExposeConfiguration(
        cfg => new SchemaExport(cfg)
            .Create(false, true)
    )
    .BuildConfiguration()
    .BuildSessionFactory();

using var session = sessionFactory.OpenSession();

session.Save(new Game
{
    Title = "123"
});

session.Flush();