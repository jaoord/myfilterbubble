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
    internal class Trainer
    {
        FileIndex _dislikeIndex;
        FileIndex _likeIndex;

        public Trainer()
        {
            _dislikeIndex = new FileIndex("XML/dislikes.xml");
            _dislikeIndex.Open();

            _likeIndex = new FileIndex("XML/likes.xml");
            _likeIndex.Open();
        }


        internal void Execute()
        {
            var trainableItems = new GetUserClassifiedFeedItemsQuery().Execute().ToList();
            TrainItems(trainableItems);
            //SaveTrainStatus(trainableItems);
        }

        private void TrainItems(List<UserClassifiedFeedItemDto> items)
        {
            foreach (var item in items)
            {
                string trainString = MatchString.Create(item.Title, item.Text);

                if ((CategorizationResult)item.UserClassification == CategorizationResult.First)
                {
                    // dislike
                    _dislikeIndex.Add(Entry.FromString(trainString));
                }
                else if ((CategorizationResult)item.UserClassification == CategorizationResult.Second)
                {
                    // like
                    _likeIndex.Add(Entry.FromString(trainString));
                }
            }

            _dislikeIndex.Save();
            _likeIndex.Save();
        }
    }
}
