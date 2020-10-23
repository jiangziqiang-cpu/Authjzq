using AuthorityManagement.Web.Models;
using DotNetStudy.Web.Data;
using Poseidon.Web.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Services
{
    public class MenuSever
    {
        private readonly StudyDbContext _context;
        public MenuSever(StudyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 得到所有菜单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleNavigation> GetNavigations()
        {
            Pages page = new Pages();
            return page.GetNavigations();
        }
    }
}
