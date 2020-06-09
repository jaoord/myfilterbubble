using AutoMapper.QueryableExtensions;
using MyFilterBubble.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Queries
{
    public class GetSystemUnclassifiedFeedItemsQuery
    {
         public IEnumerable<UnclassifiedFeedItemDto> Execute()
        {
            using(var db = new MyFilterBubbleContext())
            {
                return db.FeedItems.Where(x => x.IsSystemTrained == false)
                            .ProjectTo<UnclassifiedFeedItemDto>().ToList();
            }
        }

    }
}
