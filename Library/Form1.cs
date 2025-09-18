using Database.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Library;

public partial class Form1 : Form
{
    private readonly ISessionFactory sessionFactory;

    private ISession? _session;

    private ISession Session
    {
        get
        {
            _session ??= sessionFactory.OpenSession();
            return _session;
        }
    }

    public Form1()
    {
        InitializeComponent();

        sessionFactory = Fluently.Configure()
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
    }

    private void button1_Click(object sender, EventArgs e)
    {
        new GameCreateForm(Session).Show();
    }
}
