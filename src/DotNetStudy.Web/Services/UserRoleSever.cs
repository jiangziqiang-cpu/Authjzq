using AuthorityManagement.Web.Models;
using DotNetStudy.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Services
{
    public class UserRoleSever
    {
        private readonly StudyDbContext _context;

        public UserRoleSever(StudyDbContext context)
        {
            _context = context;

        }

        /// <summary>
        /// 根据用户Id查询用户权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<UserRole>> GetUserRoleByUserId(int id)
        {
          return await _context.UserRole.Where(m => m.UserId == id).ToListAsync() ;
        }

        /// <summary>
        /// 删除角色时删除当前角色下的所有用户挂靠信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task RemoveUserRoleByRoleId(int Id)
        {
          var userRoles =await _context.UserRole.Where(m=>m.RoleId==Id).ToListAsync();
             _context.UserRole.RemoveRange(userRoles);
            await _context.SaveChangesAsync();

        }
    }
}
