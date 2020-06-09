using MyFilterBubble.DAL.Enums;
using System;

namespace MyFilterBubble.DAL.DTO
{
    public class FeedItemOverviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public DateTime PublishDateTimeUtc { get; set; }
        public Classification UserClassification { get; set; }
        public bool IsUserTrained { get; set; }
    }
}