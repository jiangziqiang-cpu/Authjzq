using AuthorityManagement.Web.Models;
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
        public async Task CreateAsync(User user, List<string> roleNames)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            _context.Users.Add(user);
            List<UserRole> userRoles = new List<UserRole>();
            foreach (var roleName in roleNames)
            {
                UserRole userRole = new UserRole();
                var role = await _context.Roles.FirstOrDefaultAsync(f => f.Name == roleName);
                userRole.RoleId = role.Id;
                userRoles.Add(userRole);
                user.UserRole = userRoles;
                foreach (var item in user.UserRole)
                {
                    _context.UserRole.Add(item);
                }
           
            }
            await _context.SaveChangesAsync();
        }
        //判断用户名是否存在
        public async Task<User> FindByNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName&&x.Active==1);
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
        public async Task UploadAvatorAsync(User user, List<string> roleNames=null)
        {
                   
            if (roleNames!=null)
            {
                var userroles = _context.UserRole.Where(m => m.UserId == user.Id);
                foreach (var item in userroles)
                {
                    _context.UserRole.Remove(item);
                }
                List<UserRole> userRoles = new List<UserRole>();
                foreach (var roleName in roleNames)
                {
                    UserRole userRole = new UserRole();
                    var role = await _context.Roles.FirstOrDefaultAsync(f => f.Name == roleName);
                    userRole.RoleId = role.Id;
                    userRoles.Add(userRole);
                    user.UserRole = userRoles;
                    foreach (var item in user.UserRole)
                    {
                        _context.UserRole.Add(item);
                    }
                }
            }          
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 得到所有的用户
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();                     
        }

        public async Task<int> ReMoveUserById(int Id)
        {
              var user= await GetByIdAsync(Id);
                _context.Remove(user);
         int isok = await _context.SaveChangesAsync();
            return isok;
        }
    }
}
