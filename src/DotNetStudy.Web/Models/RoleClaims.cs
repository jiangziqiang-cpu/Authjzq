using DotNetStudy.Web.ViewModels.MyOrdersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Models
{
    public class RoleClaims
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public Role  Role { get; set; }
    }
}
