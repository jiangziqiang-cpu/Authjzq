using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Models
{
    public class GoodsAttribute
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 商品属性Id
        /// </summary>
        public int GoodsAttributeId { get; set; }
        /// <summary>
        /// 商品属性名
        /// </summary>
        public string GoodsAttributeName { get; set; }
        /// <summary>
        /// 商品属性值
        /// </summary>
        public string GoodsAttributeValue { get; set; }
    }
}
