using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Models
{
    public class Goods
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品类型Id
        /// </summary>
        public int GoodsTypeId { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 库存量
        /// </summary>
        public int inventory { get; set; }

        public GoodsType GoodsType { get; set; }

        public ICollection<GoodsImgae> GoodsImgae { get; set; }

        
    }
}
