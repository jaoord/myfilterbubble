using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL.Entities
{
    public class Feed
    {
        public Feed()
        {
            this.LastFetchUtc = DateTime.MinValue;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime LastFetchUtc { get; set; }
    }
}
