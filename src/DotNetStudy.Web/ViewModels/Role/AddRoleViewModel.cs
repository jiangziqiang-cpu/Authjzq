using AuthorityManagement.Web.Models;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.ViewModels.Role
{
    public class AddAndEditRoleViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string DisPlayName { get; set; }

        public string Description { get; set; }
        public RoleEnum Active { get; set; }

        public List<RoleFictitious> RolePermissions{ get; set; }

    }
}
