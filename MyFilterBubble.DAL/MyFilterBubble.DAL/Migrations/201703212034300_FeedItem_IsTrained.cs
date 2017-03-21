namespace MyFilterBubble.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedItem_IsTrained : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedItems", "IsSystemTrained", c => c.Boolean(nullable: false));
            AddColumn("dbo.FeedItems", "IsUserTrained", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedItems", "IsUserTrained");
            DropColumn("dbo.FeedItems", "IsSystemTrained");
        }
    }
}
