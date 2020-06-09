using MyFilterBubble.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.Ingest
{
    class Program
    {
        static void Main(string[] args)
        {
            Initializer.InitializeAutoMapper();

            var feedUpdater = new FeedUpdater();
            Task.Run(async () =>
            {
                await feedUpdater.UpdateFeedsAsync();
            }).GetAwaiter().GetResult();
        }
    }
}
