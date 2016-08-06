using AutoMapper;
using LKTShop.Model.Models;
using LKTShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKTShop.Web.Mappings
{
    public class AutomaperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>().ReverseMap();
            Mapper.CreateMap<PostTag, PostTagViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}