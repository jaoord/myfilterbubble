using AutoMapper.QueryableExtensions;
using MyFilterBubble.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Queries
{
    public class GetFeedItemsForOverviewQuery
    {
        public List<FeedItemOverviewDto> Execute()
        {
            using(var db = new MyFilterBubbleContext())
            {
                return db.FeedItems
                            .OrderByDescending(x => x.PublishDateTimeUtc)
                            .ProjectTo<FeedItemOverviewDto>().ToList();

            }
        }
    }
}
