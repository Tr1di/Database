using FluentNHibernate.Mapping;

namespace Database.Models;

public class User
{
    public virtual Guid Id { get; set; }
    public virtual string Login { get; set; }

    public virtual IList<Review> Reviews { get; set; }

    public virtual IList<Game> Library {  get; set; }
}

public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        Id(x => x.Id).GeneratedBy.Guid();
        Map(x => x.Login).Length(255);

        HasMany(x => x.Reviews);

        HasManyToMany(x => x.Library)
            .Table("Library")
            .LazyLoad();
    }
}