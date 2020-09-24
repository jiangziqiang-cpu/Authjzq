using AutoMapper;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.ViewModels.GoodsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.MappingProfiles
{
    public class GoodsImgaeMappingProfile:Profile
    {
        public GoodsImgaeMappingProfile()
        {
            CreateMap<List<GoodsTypeModel>, List<GoodsType>>();
            CreateMap<List<GoodsType>, List<GoodsTypeModel>>();
            CreateMap<GoodsType, GoodsTypeModel>();
            CreateMap<GoodsTypeModel, GoodsType>();
            CreateMap<Goods, ShowGoodsModel>();
            CreateMap<ShowGoodsModel, Goods>();
        }
    }
}
