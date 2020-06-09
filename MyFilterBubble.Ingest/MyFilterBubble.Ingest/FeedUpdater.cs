using MyFilterBubble.DAL.Commands;
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
            _feeds = new GetStaleFeedsQuery().Execute();
        }


        public async Task UpdateFeedsAsync()
        {
            var reader = new FeedReader();
            foreach (var feed in _feeds)
            {
                var rawFeedItems = await reader.RetrieveFeed(feed);

                // save fetched data into database
                await SaveFeedItems(rawFeedItems);
            }

            // update last fetch date for feeds
            await SaveLastFetchDate();
        }
        
        async Task SaveFeedItems(List<RawFeedItemDto> rawFeedItems)
        {
            foreach(var rawFeedItem in rawFeedItems)
            {
                await new SaveFeedItemCommand().ExecuteAsync(rawFeedItem);
            }
        }

        
        async Task SaveLastFetchDate()
        {
            foreach(var feed in _feeds)
            {
                await new SaveLastFetchDateCommand().ExecuteAsync(feed.Id);
            }
        }
    }
}