using MyFilterBubble.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MyFilterBubble.DAL.EntityConfig
{
    class FeedConfiguration : EntityTypeConfiguration<Feed>
    {
        public FeedConfiguration()
        {
            ToTable("Feeds");
            Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();
            Property(p => p.Url)
                .HasMaxLength(1000)
                .IsRequired();
            Property(p => p.LastFetchUtc);
        }
    }
}
