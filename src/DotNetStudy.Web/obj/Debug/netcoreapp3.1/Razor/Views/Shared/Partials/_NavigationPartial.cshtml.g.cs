#pragma checksum "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "151f0add7fe82a7b7459cd0913b9367b49444017"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Partials__NavigationPartial), @"mvc.1.0.view", @"/Views/Shared/Partials/_NavigationPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\_ViewImports.cshtml"
using DotNetStudy.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\_ViewImports.cshtml"
using DotNetStudy.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
using DotNetStudy.Web.ViewModels.MyOrdersModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"151f0add7fe82a7b7459cd0913b9367b49444017", @"/Views/Shared/Partials/_NavigationPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a9fa861c4a860259ce380361bad65ec99c1710f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Partials__NavigationPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AuthorityManagement.Web.Models.RoleNavigation>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
  
    var path = Context.Request.Path.ToString();
    var user = User;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
 foreach (var item in Model)
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
     if (!item.PermissionName.IsNullOrEmpty() && !user.HasClaim(Poseidon.Infrastructure.AppConstants.RoleClaims, item.PermissionName))
    {
        continue;
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
     
    if (item.Children.Count > 0)
    {
        bool isCurrent = item.Children.FirstOrDefault(f => f.LinkUrl.ComparePath(path, 3)) != null;
        if (isCurrent)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"nav-item has-treeview menu-open\">\r\n                <a href=\"javascript:void(0)\" class=\"nav-link active\">\r\n                    <i");
            BeginWriteAttribute("class", " class=\"", 729, "\"", 756, 2);
            WriteAttributeValue("", 737, "nav-icon", 737, 8, true);
#nullable restore
#line 21 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
WriteAttributeValue(" ", 745, item.Icon, 746, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                    <p>\r\n                        ");
#nullable restore
#line 23 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <i class=\"right fas fa-angle-left\"></i>\r\n                    </p>\r\n                </a>\r\n                <ul class=\"nav nav-treeview\">\r\n                    ");
#nullable restore
#line 28 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
               Write(await Html.PartialAsync("Partials/_NavigationPartial", item.Children));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n            </li>\r\n");
#nullable restore
#line 31 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"nav-item has-treeview\">\r\n                <a href=\"javascript:void(0)\" class=\"nav-link\">\r\n                    <i");
            BeginWriteAttribute("class", " class=\"", 1289, "\"", 1316, 2);
            WriteAttributeValue("", 1297, "nav-icon", 1297, 8, true);
#nullable restore
#line 36 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
WriteAttributeValue(" ", 1305, item.Icon, 1306, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                    <p>\r\n                        ");
#nullable restore
#line 38 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <i class=\"right fas fa-angle-left\"></i>\r\n                    </p>\r\n                </a>\r\n                <ul class=\"nav nav-treeview\">\r\n                    ");
#nullable restore
#line 43 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
               Write(await Html.PartialAsync("Partials/_NavigationPartial", item.Children));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n            </li>\r\n");
#nullable restore
#line 46 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
        }

    }
    else
    {
        bool isCurrent = item.LinkUrl.ComparePath(path, 3);
        if (isCurrent)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"nav-item\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1865, "\"", 1885, 1);
#nullable restore
#line 55 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
WriteAttributeValue("", 1872, item.LinkUrl, 1872, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link active\">\r\n                    <i");
            BeginWriteAttribute("class", " class=\"", 1935, "\"", 1962, 2);
            WriteAttributeValue("", 1943, "nav-icon", 1943, 8, true);
#nullable restore
#line 56 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
WriteAttributeValue(" ", 1951, item.Icon, 1952, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                    <p>\r\n                        ");
#nullable restore
#line 58 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </a>\r\n            </li>\r\n");
#nullable restore
#line 62 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"nav-item\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 2187, "\"", 2207, 1);
#nullable restore
#line 66 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
WriteAttributeValue("", 2194, item.LinkUrl, 2194, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link \">\r\n                    <i");
            BeginWriteAttribute("class", " class=\"", 2251, "\"", 2278, 2);
            WriteAttributeValue("", 2259, "nav-icon", 2259, 8, true);
#nullable restore
#line 67 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
WriteAttributeValue(" ", 2267, item.Icon, 2268, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                    <p>\r\n                        ");
#nullable restore
#line 69 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
                   Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </a>\r\n            </li>\r\n");
#nullable restore
#line 73 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\Shared\Partials\_NavigationPartial.cshtml"
        }

    }

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AuthorityManagement.Web.Models.RoleNavigation>> Html { get; private set; }
    }
}
#pragma warning restore 1591