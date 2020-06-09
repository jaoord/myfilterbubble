using AngleSharp;
using AngleSharp.Parser.Html;
using MyFilterBubble.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            var itms = document.All.Where(x => x.LocalName == "item");

            foreach (var item in items)
            {
                var guidEl = item.QuerySelector("guid");
                var linkEl = item.QuerySelector("link");
                var titleEl = item.QuerySelector("title");
                var descriptionEl = item.QuerySelector("description");
                    
                var pubDateEl = item.QuerySelector("pubDate");
                DateTime.TryParse(pubDateEl.TextContent, out DateTime pubDate);

                string descriptionText = FixContent(descriptionEl.TextContent);
                if (String.IsNullOrEmpty(descriptionText)) {
                    descriptionText = FixContent(descriptionEl.InnerHtml);
                }

                output.Add(new RawFeedItemDto()
                {
                    FeedId = feed.Id,
                    Guid = guidEl.TextContent,
                    Title = FixContent(titleEl.TextContent),
                    Description = descriptionText,
                    PublicationDate = pubDate == DateTime.MinValue ? DateTime.Today : pubDate,
                    Link = linkEl.TextContent
                });
            }
            return output;
        }

        private string FixContent(string content)
        {
            content = content.Replace("\n", String.Empty); // NRC
            content = content.Replace("\t", String.Empty); // NRC
            content = content.Replace("<![CDATA[", String.Empty); // NRC
            content = content.Replace("<!--[CDATA[", String.Empty); // NRC
            content = content.Replace("]]-->", String.Empty); // NRC
            content = content.Replace("]]>", String.Empty); // NRC
            content = content.Replace("&lt;p&gt;", String.Empty); // NRC
            content = content.Replace("&lt;/p&gt;", String.Empty); // NRC
            content = content.Replace("<p>", String.Empty); // NOS
            content = content.Replace("</p>", String.Empty); // NOS
            return content;
        }
    }
}
