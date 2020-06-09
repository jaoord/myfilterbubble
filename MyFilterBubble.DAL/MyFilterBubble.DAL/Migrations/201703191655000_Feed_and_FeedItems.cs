namespace MyFilterBubble.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feed_and_FeedItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FetchDateTimeUtc = c.DateTime(nullable: false),
                        PublishDateTimeUtc = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 1000),
                        Text = c.String(nullable: false),
                        Url = c.String(nullable: false, maxLength: 1000),
                        Feed_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feeds", t => t.Feed_Id)
                .Index(t => t.Feed_Id);
            
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Url = c.String(nullable: false, maxLength: 1000),
                        LastFetchUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedItems", "Feed_Id", "dbo.Feeds");
            DropIndex("dbo.FeedItems", new[] { "Feed_Id" });
            DropTable("dbo.Feeds");
            DropTable("dbo.FeedItems");
        }
    }
}
