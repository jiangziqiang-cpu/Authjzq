#pragma checksum "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9cfea644b0538eafa742f5d013d443addeed586"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GoodsType_UpdateGoodsType), @"mvc.1.0.view", @"/Views/GoodsType/UpdateGoodsType.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9cfea644b0538eafa742f5d013d443addeed586", @"/Views/GoodsType/UpdateGoodsType.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a9fa861c4a860259ce380361bad65ec99c1710f", @"/Views/_ViewImports.cshtml")]
    public class Views_GoodsType_UpdateGoodsType : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DotNetStudy.Web.Models.GoodsType>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
  
    ViewData["Title"] = "UpdateGoodsType";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
 using (Html.BeginForm("UpdateGoodsType", "GoodsType", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <h4>更新分类</h4>\r\n        <hr />\r\n        ");
#nullable restore
#line 14 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 16 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
       Write(Html.LabelFor(model => model.GoodsTypeId, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 18 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
           Write(Html.EditorFor(model => model.GoodsTypeId, new { htmlAttributes = new { @class = "form-control", name = "GoodsId" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 19 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
           Write(Html.ValidationMessageFor(model => model.GoodsTypeId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 24 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
       Write(Html.LabelFor(model => model.HigherLevelId, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 26 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
           Write(Html.EditorFor(model => model.HigherLevelId, new { htmlAttributes = new { @class = "form-control", name = "HigherLevelId" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 27 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
           Write(Html.ValidationMessageFor(model => model.HigherLevelId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 32 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
       Write(Html.LabelFor(model => model.GoodsTypeName, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n");
            WriteLiteral("                ");
#nullable restore
#line 35 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
           Write(Html.EditorFor(model => model.GoodsTypeName, new { htmlAttributes = new { @class = "form-control", name = "GoodsTypeName" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 36 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
           Write(Html.ValidationMessageFor(model => model.GoodsTypeName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"确定\" class=\"btn btn-default\" />");
#nullable restore
#line 41 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
                                                                     Write(Html.ActionLink("返回", "ShowGoodsType"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 45 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsType\UpdateGoodsType.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DotNetStudy.Web.Models.GoodsType> Html { get; private set; }
    }
}
#pragma warning restore 1591
