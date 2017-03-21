using AngleSharp;
using MyFilterBubble.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MyFilterBubble.Ingest
{
    class FeedReader
    {
        public FeedReader()
        {

        }

        public async Task<List<RawFeedItemDto>> RetrieveFeed(FeedDto feed)
        {
            Console.WriteLine($"Fetching feed {feed.Url}");

            List<RawFeedItemDto> output = new List<RawFeedItemDto>();

            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(feed.Url);
            var items = document.QuerySelectorAll("item");

            foreach(var item in items)
            {
                var guidEl = item.QuerySelector("guid");
                var linkEl = item.QuerySelector("link");
                var titleEl = item.QuerySelector("title");
                var descriptionEl = item.QuerySelector("description");
                    
                var pubDateEl = item.QuerySelector("pubDate");
                DateTime.TryParse(pubDateEl.TextContent, out DateTime pubDate);

                output.Add(new RawFeedItemDto()
                {
                    FeedId = feed.Id,
                    Guid = guidEl.TextContent,
                    Title = titleEl.TextContent,
                    Description = descriptionEl.TextContent,
                    PublicationDate = pubDate == DateTime.MinValue ? DateTime.Today : pubDate,
                    Link = linkEl.TextContent
                });
            }
            return output;
        }
    }
}
