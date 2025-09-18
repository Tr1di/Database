using FluentNHibernate.Mapping;

namespace Database.Models;

public class Game : Entity
{
    public virtual required string Title { get; set; }
    public virtual Developer Developer { get; set; }

    public virtual IList<Review> Reviews { get; set; }

    public virtual IList<User> Owners { get; set; }
}

public class GameMap : ClassMap<Game>
{
    public GameMap()
    {
        Id(x => x.Id).GeneratedBy.Guid();
        Map(x => x.Title).Length(255);

        References(x => x.Developer)
            .Cascade.All();

        HasMany(x => x.Reviews);

        HasManyToMany(x => x.Owners)
            .Inverse()
            .Table("Library")
            .LazyLoad();
    }
}
