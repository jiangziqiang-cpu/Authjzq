using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.ViewModels.RolePermissionViewModels
{
    public class RolePermissionViewModels
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsGrant { get; set; }
        public int Level { get; set; } = 0;

       

    }
}
