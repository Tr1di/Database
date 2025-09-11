using FluentNHibernate.Mapping;

namespace Database.Models;

public class Review
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
        CompositeId()
            .KeyReference(x => x.Game)
            .KeyReference(x => x.User);

        Map(x => x.Text);
        Map(x => x.Rating);
    }
}
