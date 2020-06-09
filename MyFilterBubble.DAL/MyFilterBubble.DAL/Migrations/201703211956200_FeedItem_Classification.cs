namespace MyFilterBubble.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedItem_Classification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedItems", "SystemClassification", c => c.Int(nullable: false));
            AddColumn("dbo.FeedItems", "UserClassification", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedItems", "UserClassification");
            DropColumn("dbo.FeedItems", "SystemClassification");
        }
    }
}
