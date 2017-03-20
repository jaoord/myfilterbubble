using MyFilterBubble.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MyFilterBubble.DAL.EntityConfig
{
    class FeedItemConfiguration : EntityTypeConfiguration<FeedItem>
    {
        public FeedItemConfiguration()
        {
            ToTable("FeedItems");
            Property(p => p.SourceId)
                .HasMaxLength(1000);
            Property(p => p.Title)
                .HasMaxLength(1000)
                .IsRequired();
            Property(p => p.Text)
                .IsRequired();
            Property(p => p.Url)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
