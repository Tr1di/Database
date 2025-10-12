using FluentMigrator;

namespace Library.Migrations;

[Migration(202510091937)]
internal class Initial : Migration
{
    public override void Up()
    {
        Create.Table("Game")
            .WithColumn("Id").AsGuid().PrimaryKey().Identity()
            .WithColumn("Title")
                .AsString()
            .WithColumn("Price")
                .AsFloat()
            .WithColumn("Developer_Id")
                .AsGuid();

        Create.Table("User")
            .WithColumn("login").AsString().PrimaryKey()
            .WithColumn("email").AsString().Unique().Nullable();

        Create.Table("GameMedia")
            .WithColumn("Game_Id").AsGuid()
            .WithColumn("Media_Id").AsGuid()
            .WithColumn("Position").AsInt32().WithDefaultValue(0);

        Create.ForeignKey()
            .FromTable("GameMedia").ForeignColumn("Game_Id")
            .ToTable("Game").PrimaryColumn("Id");

        Create.PrimaryKey()
            .OnTable("GameMedia")
            .Columns(["Game_Id", "Media_Id"]);
    }

    public override void Down()
    {
        Delete.Table("Game").IfExists();
        Delete.Table("User").IfExists();
        Delete.Table("GameMedia").IfExists();
    }
}
