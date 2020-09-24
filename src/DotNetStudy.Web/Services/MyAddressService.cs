using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class MyAddressService
    {
        private readonly StudyDbContext _context;
        public MyAddressService(StudyDbContext context)
        {
            _context = context;
        }
        public async Task<List<MyAddress>> GetAllByUserIdAsync(int userId)
        {
            return await _context.MyAddresses.Where(w => w.UserId == userId).ToListAsync();
        }
        //根据Id删除单条收货地址信息
        public async Task RemoveByIdAsync(int myAddressId)
        {
            var addressItems = await _context.MyAddresses.FirstOrDefaultAsync(w => w.Id == myAddressId);
            if (addressItems != null)
                _context.MyAddresses.Remove(addressItems);
            await _context.SaveChangesAsync();
        }
        //根据用户id添加新地址
        public async Task AddNewAddressAsync(MyAddress myAddress)
        {
            if (myAddress == null)
                throw new ArgumentNullException(nameof(myAddress));
            await _context.MyAddresses.AddAsync(myAddress);
            await _context.SaveChangesAsync();
        }
        //编辑收货地址信息
        public async Task UpdateMyAddressAsync(MyAddress myAddress)
        {
            _context.MyAddresses.Update(myAddress);
            await _context.SaveChangesAsync();
        }
        //通过Id进入编辑收货地址界面
        public async Task<MyAddress> GetByIdAsync(int myAddressId)
        {
            return await _context.MyAddresses.FirstOrDefaultAsync(x => x.Id == myAddressId);
        }
        //通过Id进行修改收货地址信息
        public async Task<MyAddress> EditByIdAsync(int myAddressId)
        { 
            return await _context.MyAddresses.FirstOrDefaultAsync(x => x.Id == myAddressId);
        }
    }
}
