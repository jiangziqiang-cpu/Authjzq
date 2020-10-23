using AuthorityManagement.Web.Models;
using DotNetStudy.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Services
{
    public class RoleClaimsSever
    {
        private readonly StudyDbContext _context;

        public RoleClaimsSever(StudyDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 拿到角色的权限
        /// </summary>
        /// <param name="RoleIds"></param>
        /// <returns></returns>
        public List<RoleClaims> GetRoleClaims(List<int> RoleIds)
        {
            List<RoleClaims> listClaims = new List<RoleClaims>();
            foreach (var item in RoleIds)
            {
                var list = _context.RoleClaims.Where(m => m.RoleId == item).ToList();
                listClaims.AddRange(list);
            }
            return listClaims;
        }

        /// <summary>
        /// 移除权限
        /// </summary>
        /// <param name="roleClaims"></param>
        public async Task Removes(List<RoleClaims> roleClaims)
        {
            _context.RoleClaims.RemoveRange(roleClaims);
           await _context.SaveChangesAsync();
        
        }

        /// <summary>
        /// 添加角色的权限
        /// </summary>
        /// <param name="roleClaims"></param>
        public async Task<int> AddRoleClaims(List<RoleClaims> roleClaims)
        {
            _context.RoleClaims.AddRange(roleClaims);
             return  await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 级联删除 当移除角色的时候所有挂靠这个角色的权限全部移除
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task RemoveClaimsByRoleId(int roleId)
        {
          var roleClaims= await _context.RoleClaims.Where(m=>m.RoleId==roleId).ToListAsync();
          _context.RoleClaims.RemoveRange(roleClaims);
          await _context.SaveChangesAsync();
        }
    }
}
