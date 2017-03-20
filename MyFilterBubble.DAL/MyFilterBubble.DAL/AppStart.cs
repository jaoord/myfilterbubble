using AutoMapper;
using MyFilterBubble.DAL.DTO;
using MyFilterBubble.DAL.Entities;
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
            });
        }
    }
}
