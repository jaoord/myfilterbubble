using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Entities
{
    public class FeedItem
    {
        public int Id { get; set; }
        public string SourceId { get; set; }
        public virtual Feed Feed { get; set; }
        public DateTime FetchDateTimeUtc { get; set; }
        public DateTime PublishDateTimeUtc { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        // Todo: add categorization attributes (Categorization Status, Score and user score)

    }
}
