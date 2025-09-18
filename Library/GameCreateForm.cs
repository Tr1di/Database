using NHibernate;

namespace Library;

public partial class GameCreateForm : Form
{
    private readonly ISession session;

    public GameCreateForm(ISession session)
    {
        InitializeComponent();
        this.session = session;
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
}
