using MyFilterBubble.DAL.Commands;
using MyFilterBubble.DAL.DTO;
using MyFilterBubble.DAL.Queries;
using nBayes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.Classification
{

    /// <summary>
    /// performs classification for new feed items 
    /// </summary>
    internal class Classifier
    {
        List<UnclassifiedFeedItemDto> _newFeedItems { get; set; }
        FileIndex _dislikeIndex;
        FileIndex _likeIndex;

        public Classifier()
        {
            _dislikeIndex = new FileIndex("XML/dislikes.xml");
            _dislikeIndex.Open();

            _likeIndex = new FileIndex("XML/likes.xml");
            _likeIndex.Open();
        }

        internal void Execute()
        {
            _newFeedItems = new GetSystemUnclassifiedFeedItemsQuery().Execute().ToList();

            var result = ClassifyFeedItems();

            UpdateSystemClassification(result);
        }

        private List<ClassifiedFeedItemDto> ClassifyFeedItems()
        {
            List<ClassifiedFeedItemDto> classifiedFeedItems = new List<ClassifiedFeedItemDto>();
            Analyzer analyzer = new Analyzer();

            foreach (var item in _newFeedItems)
            {
                // combine title and text into one string
                string analyzeText = MatchString.Create(item.Title, item.Text);

                CategorizationResult result = analyzer.Categorize(
                    Entry.FromString(analyzeText),
                     _dislikeIndex,
                     _likeIndex);

                classifiedFeedItems.Add(new ClassifiedFeedItemDto()
                {
                    Id = item.Id,
                    Classification = (int)result
                });
            }

            return classifiedFeedItems;
        }

        private void UpdateSystemClassification(List<ClassifiedFeedItemDto> items)
        {
            foreach (var item in items)
            {
                new UpdateFeedItemSystemClassificationCommand().Execute(item);
            }
        }
    }
}
