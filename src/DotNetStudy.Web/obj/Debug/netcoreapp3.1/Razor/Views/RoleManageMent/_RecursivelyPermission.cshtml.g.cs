#pragma checksum "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "122474b87f7efffbe73134f1ecd82a5ca3e94d03"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoleManageMent__RecursivelyPermission), @"mvc.1.0.view", @"/Views/RoleManageMent/_RecursivelyPermission.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"122474b87f7efffbe73134f1ecd82a5ca3e94d03", @"/Views/RoleManageMent/_RecursivelyPermission.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a9fa861c4a860259ce380361bad65ec99c1710f", @"/Views/_ViewImports.cshtml")]
    public class Views_RoleManageMent__RecursivelyPermission : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AuthorityManagement.Web.Models.RoleFictitious>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
 foreach (var item in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"list-group-item\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-4\">\r\n");
#nullable restore
#line 10 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
                 for (int i = 0; i < item.Level; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"indent\"></span>\r\n");
#nullable restore
#line 13 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"form-check d-inline\">\r\n");
#nullable restore
#line 15 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
                     if (item.IsGrant)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input");
            BeginWriteAttribute("id", " id=\"", 491, "\"", 517, 2);
            WriteAttributeValue("", 496, "Permission.", 496, 11, true);
#nullable restore
#line 17 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
WriteAttributeValue("", 507, item.Name, 507, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-check-input permission\" type=\"checkbox\"");
            BeginWriteAttribute("name", " name=\"", 570, "\"", 598, 2);
            WriteAttributeValue("", 577, "Permission.", 577, 11, true);
#nullable restore
#line 17 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
WriteAttributeValue("", 588, item.Name, 588, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" checked />\r\n");
#nullable restore
#line 18 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input");
            BeginWriteAttribute("id", " id=\"", 714, "\"", 740, 2);
            WriteAttributeValue("", 719, "Permission.", 719, 11, true);
#nullable restore
#line 21 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
WriteAttributeValue("", 730, item.Name, 730, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-check-input permission\" type=\"checkbox\"");
            BeginWriteAttribute("name", " name=\"", 793, "\"", 821, 2);
            WriteAttributeValue("", 800, "Permission.", 800, 11, true);
#nullable restore
#line 21 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
WriteAttributeValue("", 811, item.Name, 811, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 22 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <label class=\"form-check-label\"");
            BeginWriteAttribute("for", " for=\"", 901, "\"", 928, 2);
            WriteAttributeValue("", 907, "Permission.", 907, 11, true);
#nullable restore
#line 23 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
WriteAttributeValue("", 918, item.Name, 918, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
#nullable restore
#line 24 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
                   Write(item.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </label>\r\n                </span>\r\n            </div>\r\n            <div class=\"col-md-8\">\r\n                <small class=\"text-secondary ml-3\">");
#nullable restore
#line 29 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
                                              Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n            </div>\r\n        </div>\r\n    </li>\r\n");
#nullable restore
#line 33 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
     if (item.Children.Any())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
   Write(await Html.PartialAsync("_RecursivelyPermission", item.Children));

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
                                                                         
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\RoleManageMent\_RecursivelyPermission.cshtml"
     
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AuthorityManagement.Web.Models.RoleFictitious>> Html { get; private set; }
    }
}
#pragma warning restore 1591
