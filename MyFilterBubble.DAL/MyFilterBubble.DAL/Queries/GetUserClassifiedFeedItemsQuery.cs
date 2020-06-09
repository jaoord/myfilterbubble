using AutoMapper.QueryableExtensions;
using MyFilterBubble.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Queries
{
    public class GetUserClassifiedFeedItemsQuery
    {
         public IEnumerable<UserClassifiedFeedItemDto> Execute()
        {
            using(var db = new MyFilterBubbleContext())
            {
                return db.FeedItems.Where(x => x.IsUserTrained == false && x.UserClassification != 0)
                            .ProjectTo<UserClassifiedFeedItemDto>().ToList();
            }
        }

    }
}
