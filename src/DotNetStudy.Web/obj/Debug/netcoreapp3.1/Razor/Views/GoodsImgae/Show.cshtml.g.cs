#pragma checksum "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsImgae\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60e2886374eb6ac5fbab3bdd4fb349b562ee5360"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GoodsImgae_Show), @"mvc.1.0.view", @"/Views/GoodsImgae/Show.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60e2886374eb6ac5fbab3bdd4fb349b562ee5360", @"/Views/GoodsImgae/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a9fa861c4a860259ce380361bad65ec99c1710f", @"/Views/_ViewImports.cshtml")]
    public class Views_GoodsImgae_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DotNetStudy.Web.Models.GoodsImgae>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsImgae\Show.cshtml"
  
    ViewData["Title"] = "Show";
    Layout = "~/Views/Shared/_Layout1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
            WriteLiteral(@"<h5>商品图片管理</h5>
<a class=""btn btn-primary"" href=""/GoodsImgae/AddGoodsImg"" role=""button"">添加图片</a>
<table class=""table table-striped"">
    <thead>
        <tr>
            <th scope=""col"">编号ID</th>
            <th scope=""col"">商品ID</th>
            <th scope=""col"">图片名称</th>
            <th scope=""col"">图片大少</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 23 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsImgae\Show.cshtml"
          
            foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td scope=\"row\">");
#nullable restore
#line 27 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsImgae\Show.cshtml"
                               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsImgae\Show.cshtml"
                   Write(item.GoodsId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsImgae\Show.cshtml"
                   Write(item.GoodsImgaeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsImgae\Show.cshtml"
                   Write(item.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsImgae\Show.cshtml"
                   Write(Html.ActionLink("更新分类", "UpdateGoodsType", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "D:\MyNewProject\AuthorityManagement\src\DotNetStudy.Web\Views\GoodsImgae\Show.cshtml"
            }

        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<div>\r\n    <a href=\"/Goods/ShowGoods\">返回</a>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DotNetStudy.Web.Models.GoodsImgae>> Html { get; private set; }
    }
}
#pragma warning restore 1591