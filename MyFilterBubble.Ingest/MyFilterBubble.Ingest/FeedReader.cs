using AngleSharp;
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

        public async Task<List<RawFeedItem>> RetrieveFeed(string url)
        {
            Console.WriteLine($"Fetching feed {url}");

            List<RawFeedItem> output = new List<RawFeedItem>();

            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(url);
            var items = document.QuerySelectorAll("item");

            foreach(var item in items)
            {
                var guidEl = item.QuerySelector("guid");
                var linkEl = item.QuerySelector("link");
                var titleEl = item.QuerySelector("title");
                var descriptionEl = item.QuerySelector("description");
                    
                var pubDateEl = item.QuerySelector("pubDate");
                DateTime.TryParse(pubDateEl.TextContent, out DateTime pubDate);

                output.Add(new RawFeedItem()
                {
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
