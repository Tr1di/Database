using Database.Models;
using Database.Repository;

namespace Library;

public partial class GameCreateForm : Form
{
    private readonly IRepository<Game> repository;
    private readonly IUnitOfWork unitOfWork;

    public GameCreateForm(
        IRepository<Game> repository,
        IUnitOfWork unitOfWork
    )
    {
        InitializeComponent();
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    private void label1_Click(object sender, EventArgs e)
    {
        try
        {
            unitOfWork.Begin();

            repository.SaveOrUpdate(new Game
            {
                Title = "123"
            });

            unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
        }
    }
}
