namespace MyFilterBubble.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedItemSourceId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedItems", "SourceId", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedItems", "SourceId");
        }
    }
}
