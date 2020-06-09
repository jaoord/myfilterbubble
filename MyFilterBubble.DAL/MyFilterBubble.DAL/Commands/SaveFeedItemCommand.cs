using MyFilterBubble.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Commands
{
    public class SaveFeedItemCommand
    {
        public async Task ExecuteAsync(RawFeedItemDto rawFeedItem)
        {
            using(var db = new MyFilterBubbleContext())
            {
                // check if item is already in database
                bool exists = db.FeedItems.Any(x => x.SourceId == rawFeedItem.Guid);
                if (exists)
                    return;

                // otherwise, add to database and save.
                db.FeedItems.Add(new Entities.FeedItem()
                {
                    Feed = db.Feeds.Find(rawFeedItem.FeedId),
                    FetchDateTimeUtc = DateTime.UtcNow,
                    PublishDateTimeUtc = rawFeedItem.PublicationDate.ToUniversalTime(),
                    SourceId = rawFeedItem.Guid,
                    Title = rawFeedItem.Title,
                    Text = rawFeedItem.Description,
                    Url = rawFeedItem.Link
                });

                await db.SaveChangesAsync();
            }
        }
    }
}
