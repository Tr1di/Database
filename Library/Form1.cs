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
            .Database(PostgreSQLConfiguration.PostgreSQL82
                .ConnectionString("host=pibikidokos.beget.app;port=5432;sslmode=disable;database=steam;username=tridi;password=v3k&dKVn5vAm")
            )
            .Mappings(x => x.FluentMappings
                .AddFromAssemblyOf<GameMap>()
            )
            .BuildConfiguration()
            .BuildSessionFactory();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        new GameCreateForm(Session).Show();
    }
}
