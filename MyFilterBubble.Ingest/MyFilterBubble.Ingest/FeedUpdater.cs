using MyFilterBubble.DAL.DTO;
using MyFilterBubble.DAL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.Ingest
{
    
    class FeedUpdater
    {
        IEnumerable<FeedDto> _feeds { get; set; }

        public FeedUpdater()
        {
            // get stale feeds
            _feeds = new GetFeedsQuery().GetStaleFeeds();
        }

        
        public async Task UpdateFeedsAsync()
        {
            var reader = new FeedReader();
            foreach(var feed in _feeds)
            {
                await reader.RetrieveFeed(feed.Url);
            }
        }

        // fetch items from feed

        // save fetched data into database

        
    }
}