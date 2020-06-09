using MyFilterBubble.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Commands
{
    public class SaveLastFetchDateCommand
    {
        public async Task ExecuteAsync(int feedId)
        {
            using(var db = new MyFilterBubbleContext())
            {
                Feed feed = db.Feeds.Find(feedId);

                if (feed != null)
                {
                    feed.LastFetchUtc = DateTime.UtcNow;
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
