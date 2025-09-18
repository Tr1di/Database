using FluentNHibernate.Mapping;

namespace Database.Models;

public class Review : Entity
{
    public virtual Game Game { get; set; }
    public virtual User User { get; set; }

    public virtual string Text { get; set; }
    public virtual int Rating { get; set; }
}

public class ReviewMap : ClassMap<Review>
{
    public ReviewMap() 
    {
        Id(x => x.Id).GeneratedBy.Guid();


        References(x => x.Game).UniqueKey("game_user");
        References(x => x.User).UniqueKey("game_user");

        Map(x => x.Text);
        Map(x => x.Rating);
    }
}
