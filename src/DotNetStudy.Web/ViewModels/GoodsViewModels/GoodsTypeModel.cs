using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.GoodsViewModels
{
    public class GoodsTypeModel
    {
        /// <summary>
        /// 商品分类id
        /// </summary>
        public int GoodsTypeId { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int HigherLevelId { get; set; }
        /// <summary>
        /// 商品类型名
        /// </summary>
        public string GoodsTypeName { get; set; }
    }
}
