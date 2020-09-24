using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class GoodTypeService
    {
        private readonly StudyDbContext _context;
        public GoodTypeService(StudyDbContext context)
        {
            _context = context;
        }
        //按Id查找对应的商品分类
        public async Task<GoodsType> SelectByIdAsync(int GoodsTypeId)
        {
            _context.Goods.Select(g => g.GoodsTypeId == GoodsTypeId);
            return await _context.GoodsTypes.FirstOrDefaultAsync(x => x.GoodsTypeId == GoodsTypeId);
        }

        /// <summary>
        ///查看所有商品类型 
        /// </summary>
        /// <returns></returns>        
        public async Task<List<GoodsType>> SelectAllAsync()
        {           
            return await _context.GoodsTypes.ToListAsync();
        }
        /// <summary>
        /// 添加商品类型
        /// </summary>
        /// <param name="goodsType">要添加的分类实体对象</param>
        /// <returns></returns>
        public async Task CreateAsync(GoodsType goodsType)
        {
            _context.GoodsTypes.Add(goodsType);
            await _context.SaveChangesAsync();
        }
        //更新商品类型
        public async Task UpdateAsync(GoodsType goodsType)
        {
            _context.GoodsTypes.Update(goodsType);
            await _context.SaveChangesAsync();
        }
        //删除商品类型
        public async Task DeleteAsync(int goodsTypeId)
        {
            //var goods =await  _context.Goods.Where(x => x.GoodsId == goodsId).ToListAsync();
            //_context.Goods.RemoveRange(goods);
            var id = await _context.GoodsTypes.FindAsync(goodsTypeId);
            _context.GoodsTypes.Remove(id);
            await _context.SaveChangesAsync();
        }

    }
}
