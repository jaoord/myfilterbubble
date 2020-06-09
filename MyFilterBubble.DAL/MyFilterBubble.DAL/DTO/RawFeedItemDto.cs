using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.DTO
{
    public class RawFeedItemDto
    {
        public int FeedId { get; set; }
        public string Guid { get; set; }
        public string Title { get; set;}
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Link { get; set; }
    }
}
