using AuthorityManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.ViewModels.MyOrdersModels
{
    public class ShowRole
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string DisPlayName { get; set; }

        public string Description { get; set; }
        public RoleEnum Active { get; set; }

        public List<Role>  ShowRoles{ get; set; }

        public Role UpdateRoles { get; set; }
        /// <summary>
        /// 权限集合
        /// </summary>
        public List<RoleFictitious> RolePermission { get; set; }
    }
}
