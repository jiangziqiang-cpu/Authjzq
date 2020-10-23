using AuthorityManagement.Web.Models;
using DotNetStudy.Web.Data;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Services
{
    public class RoleSever
    {
        private readonly StudyDbContext _context;
        public RoleSever(StudyDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 根据用户Id查询已经拥有的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Role>> GetRoleByUserId(int userId)
        {
            var query = await _context.Roles.Where(m=>m.Active== RoleEnum.启用).ToListAsync();
            var queryList = from u in query
                            where (from o in _context.UserRole where o.UserId == userId select o.RoleId).Contains(u.Id)
                            select u;
            return queryList.ToList();

        }

        /// <summary>
        /// 得到所有角色
        /// </summary>
        /// <returns></returns>
        public async Task<List<Role>> GetAllRole()
        {
            return await _context.Roles.ToListAsync();
          
        }

        /// <summary>
        /// 得到权限名称
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetRolesAsync()
        {
            List<Role> roles = await _context.Roles.Where(s => s.Active == RoleEnum.启用).ToListAsync();
            return roles.Select(m => m.Name).ToList();
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task AddRole(Role role)
        {
                _context.Roles.Add(role);
               await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 根据Id查询得到角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Role> GetRoleByRoleId(int id)
        {
           return await _context.Roles.Where(m=>m.Id==id).FirstOrDefaultAsync();
        
        }

        /// <summary>
        /// 启用或禁用
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task DisableOrEnable(Role role)
        {
            _context.Roles.Update(role);
             await _context.SaveChangesAsync();        
        }

        public async Task UpdateRole(Role role)
        {            
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 移除角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task RemoveRole(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

      
    }
}
