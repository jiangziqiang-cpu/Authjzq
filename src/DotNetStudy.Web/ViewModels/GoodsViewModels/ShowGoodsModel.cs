using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.GoodsViewModels
{
    public class ShowGoodsModel
    {
        //商品Id
        public int GoodsId { get; set; }
        //商品名
        public string GoodsName { get; set; }
        //价格
        public decimal Price { get; set; }
        //商品类型Id
        public int GoodsTypeId { get; set; }
        //商品介绍
        public string Desc { get; set; }
        //库存量
        public int inventory { get; set; }
        //商品属性名
        public int GoodsAttributeName { get; set; }
        //商品属性值
        public int GoodsAttributeValue { get; set; }
        //商品图片名
        public int GoodsImgaeName { get; set; }
        //图片大小
        public int Size { get; set; }
        //商品类型名
        public string GoodsTypeName { get; set; }

    }
}
