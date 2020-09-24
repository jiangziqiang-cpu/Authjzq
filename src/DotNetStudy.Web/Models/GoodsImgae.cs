using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Models
{
    public class GoodsImgae
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 商品图片名
        /// </summary>
        public string GoodsImgaeName { get; set; }
        /// <summary>
        /// 图片大小
        /// </summary>
        public decimal Size { get; set; }

        public Goods Goods { get; set; }
    }
}
