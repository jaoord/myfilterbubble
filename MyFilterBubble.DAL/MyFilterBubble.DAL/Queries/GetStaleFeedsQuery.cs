using AutoMapper.QueryableExtensions;
using MyFilterBubble.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Queries
{
    public class GetStaleFeedsQuery
    {
        public GetStaleFeedsQuery()
        {

        }

        public IEnumerable<FeedDto> Execute()
        {
            var staleTime = DateTime.UtcNow.AddMinutes(-15);
            using (var db = new MyFilterBubbleContext())
            {
                return db.Feeds
                            .Where(x => x.LastFetchUtc <= staleTime)
                            .OrderByDescending(x => x.LastFetchUtc)
                            .ProjectTo<FeedDto>().ToList();
            }
        }
    }
}
