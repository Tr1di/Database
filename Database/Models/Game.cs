using FluentNHibernate.Mapping;

namespace Database.Models;

public class Game
{
    public virtual Guid Id { get; set; }
    public virtual required string Title { get; set; }
}

public class GameMap : ClassMap<Game>
{
    public GameMap()
    {
        Id(x => x.Id).GeneratedBy.Guid();
        Map(x => x.Title).Length(255);
    }
}
