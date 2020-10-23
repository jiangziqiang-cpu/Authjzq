using AuthorityManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Help
{
    public interface IPermissionProvider
    {

        IEnumerable<RolePermission> GetPermissions();
    }
}
