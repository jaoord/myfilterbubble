namespace MyFilterBubble.DAL
{
    using MyFilterBubble.DAL.Entities;
    using MyFilterBubble.DAL.EntityConfig;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyFilterBubbleContext : DbContext
    {
        public MyFilterBubbleContext()
            : base("name=MyFilterBubbleContext")
        {
        }

        public virtual DbSet<Feed> Feeds { get; set; }
        public virtual DbSet<FeedItem> FeedItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FeedConfiguration());
            modelBuilder.Configurations.Add(new FeedItemConfiguration());
            

            base.OnModelCreating(modelBuilder);
        }
    }
}