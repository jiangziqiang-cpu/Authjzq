using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Models
{
    public class RolePermission
    {
        public int Id { get; set; }

        public string RoleId { get; set; }
        public string PermissionName { get; set; }
        public string DisplayName { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public string Description { get; set; }
        public bool IsGrant { get; set; }

        public IReadOnlyList<RolePermission> Children => _children.ToImmutableList();
        private List<RolePermission> _children;

    }
}
