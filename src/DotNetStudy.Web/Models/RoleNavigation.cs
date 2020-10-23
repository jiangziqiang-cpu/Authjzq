using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagement.Web.Models
{
    public class RoleNavigation
    {
        public string Text { get; set; }
        public string LinkUrl { get; set; }
        public string Icon { get; set; }
        public string PermissionName { get; set; }
        public IReadOnlyList<RoleNavigation> Children => _children.ToImmutableList();
        private List<RoleNavigation> _children;

        public RoleNavigation(string text, string linkUrl, string icon = null, string permissionName = null)
        {
            Text = text;
            LinkUrl = linkUrl;
            Icon = icon;
            PermissionName = permissionName;
            _children = new List<RoleNavigation>();
        }
        public RoleNavigation AddChild(string text, string linkUrl, string icon = null, string permissionName = null)
        {
            var navigation = new RoleNavigation(text, linkUrl, icon, permissionName);
            _children.Add(navigation);
            return navigation;
        }


    }
}
