using FluentNHibernate.Mapping;

namespace Database.Models;

public class Developer : Entity
{
    public virtual string Name { get; set; }
    public virtual IEnumerable<Game> Games { get; set; }
}

public class DeveloperMap : ClassMap<Developer>
{
    public DeveloperMap()
    {
        Id(x => x.Id).GeneratedBy.Guid();
        Map(x => x.Name).Length(255);

        HasMany(x => x.Games)
            .LazyLoad();
    }
}
