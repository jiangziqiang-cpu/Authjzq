using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class GoodsImgaeService
    {
      
            private readonly StudyDbContext _context;
            public GoodsImgaeService(StudyDbContext context)
            {
                _context = context;
            }
            //按Id查找对应的商品图片
            public async Task<GoodsImgae> SelectByIdAsync(int goodsId)
            {
                _context.GoodsImgaes.Select(g => g.GoodsId == goodsId);
                return await _context.GoodsImgaes.FirstOrDefaultAsync(x => x.GoodsId == goodsId);
            }

            // 查看所有商品图片             
            public async Task<List<GoodsImgae>> SelectAllAsync()
            {
                return await _context.GoodsImgaes.ToListAsync();
            }
            //添加商品图片
            public async Task CreateAsync(GoodsImgae goodsImgae)
            {
                _context.GoodsImgaes.Add(goodsImgae);
                await _context.SaveChangesAsync();
            }
            //更新商品图片
            public async Task UpdateAsync(GoodsImgae goodsImgae)
            {

                _context.GoodsImgaes.Update(goodsImgae);
                await _context.SaveChangesAsync();
            }
            //删除商品图片
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



