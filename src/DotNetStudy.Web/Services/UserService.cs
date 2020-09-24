using DotNetStudy.Web.Data;
using DotNetStudy.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class UserService
    {
        private readonly StudyDbContext _context;
        public UserService(StudyDbContext context)
        {
            _context = context;
        }
        //创建用户
        public async Task CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        //判断用户名是否存在
        public async Task<User> FindByNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }
        //通过用户Id查找用户信息 
        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }
        //修改用户信息
        public async Task UpdateProfileAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        //修改用户密码
        public async Task UpdatePasswordAsync(User user)
        { 
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        //用户上传
        public async Task UploadAvatorAsync(User user)
        { 
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        
    }
}
