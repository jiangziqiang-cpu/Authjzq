using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetStudy.Web.Services
{
    public class GoodsService
    {
        private readonly StudyDbContext _context;
        public GoodsService(StudyDbContext context)
        {
            _context = context;
        }
        //按Id查找对应的商品
        public async Task<Goods> SelectByIdAsync(int goodsId)
        {
            _context.Goods.Select(g=>g.GoodsId== goodsId);
            return await _context.Goods.FirstOrDefaultAsync(x => x.GoodsId == goodsId);          
        }
        
        // 查看所有商品             
        public async Task<List<Goods>> SelectAllAsync()
        {          
             return await _context.Goods.ToListAsync();
        }
        //添加商品
        public async Task CreateAsync(Goods goods)
        {
                  _context.Goods.Add(goods);
            await _context.SaveChangesAsync();
        }
        //更新商品
        public async Task UpdateAsync(Goods goods)
        {

            _context.Goods.Update(goods);
            await _context.SaveChangesAsync();
        }
        //删除商品
        public async Task DeleteAsync(int goodsId)
        {
            //var goods =await  _context.Goods.Where(x => x.GoodsId == goodsId).ToListAsync();
            //_context.Goods.RemoveRange(goods);
            var goods = await _context.Goods.FindAsync(goodsId);
            _context.Goods.Remove(goods);
            await _context.SaveChangesAsync();
        }


    }
}
