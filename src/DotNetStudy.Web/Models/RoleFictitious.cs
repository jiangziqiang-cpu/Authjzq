using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Models
{
    public class RoleFictitious
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsGrant { get; set; }
        public int Level { get; set; } = 0;
        public IReadOnlyList<RoleFictitious> Children => _children.ToImmutableList();
        private List<RoleFictitious> _children;

        public RoleFictitious(string name, string displayName = null, string description = null)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            _children = new List<RoleFictitious>();
        }

        public RoleFictitious AddChild(string name, string displayName = null, string description = null)
        {
            var permission = new RoleFictitious(name, displayName, description);
            permission.Level = Level + 1;
            _children.Add(permission);
            return permission;
        }
    }
}
