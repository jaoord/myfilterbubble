using MyFilterBubble.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Commands
{
    public class UpdateFeedItemSystemClassificationCommand
    {
        public void Execute(ClassifiedFeedItemDto item)
        {
            using(var db = new MyFilterBubbleContext())
            {
                var feedItem = db.FeedItems.Find(item.Id);
                if (feedItem == null)
                    return;

                feedItem.SystemClassification = item.Classification;
                feedItem.IsSystemTrained = true;

                db.SaveChanges();
            }
        }
    }
}
