using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Entities
{
    public class FeedItem
    {
        public FeedItem()
        {
            this.SystemClassification = 0; // = unclassified
            this.UserClassification = 0;   // = unclassified
            this.IsSystemTrained = false;  
            this.IsUserTrained = false;    // = classification is not yet stored
        }
        public int Id { get; set; }
        public string SourceId { get; set; }
        public virtual Feed Feed { get; set; }
        public DateTime FetchDateTimeUtc { get; set; }
        public DateTime PublishDateTimeUtc { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public int SystemClassification { get; set; }
        /// <summary>
        /// Has the system already classified this item?
        /// </summary>
        public bool IsSystemTrained { get; set; }
        public int UserClassification { get; set; }
        /// <summary>
        /// Is the user classification added to the training file?
        /// </summary>
        public bool IsUserTrained { get; set; }

    }
}
