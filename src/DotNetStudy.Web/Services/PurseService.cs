using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.ViewModels.PurseViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class PurseService
    {
        private readonly StudyDbContext _context;
        public PurseService(StudyDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Purse purse)
        {
            if (purse == null)
                throw new ArgumentNullException(nameof(purse));
            _context.Purses.Add(purse);
            await _context.SaveChangesAsync();
        }
        //根据用户Id查询出该用户的钱包信息 
        public async Task<Purse> GetInfoByUserIdAsync(int userId)
        {
            return await _context.Purses.Where(w => w.UserId == userId).FirstOrDefaultAsync();
        }
        //根据用户Id进行充值
        public async Task RechargeByUserIdAsync(Purse purse)
        { 
            if (purse == null)
                throw new ArgumentNullException(nameof(purse));
            await _context.Purses.AddAsync(purse);
            await _context.SaveChangesAsync();
        }
        //根据用户Id查找出钱包余额
        public async Task<Purse> GetBlanaceByUserIdAsync(int userId)
        {
            return  await _context.Purses.Where(w => w.UserId == userId).FirstOrDefaultAsync();
        }
        public async Task UpdatePurseAsync(Purse purse)
        {
            _context.Purses.Update(purse);
            await _context.SaveChangesAsync();
        }
    }
}
