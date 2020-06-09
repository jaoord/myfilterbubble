using AutoMapper;
using MyFilterBubble.DAL.DTO;
using MyFilterBubble.DAL.Entities;
using MyFilterBubble.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.DAL
{
    public static class Initializer
    {
        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Feed, FeedDto>();
                cfg.CreateMap<FeedItem, UnclassifiedFeedItemDto>();
                cfg.CreateMap<FeedItem, UserClassifiedFeedItemDto>();
                cfg.CreateMap<FeedItem, FeedItemOverviewDto>().ForMember(destination => destination.UserClassification,
                        opt => opt.MapFrom(source => (Classification)source.UserClassification));
            });
        }
    }
}
