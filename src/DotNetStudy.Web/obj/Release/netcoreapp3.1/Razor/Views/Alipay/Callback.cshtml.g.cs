#pragma checksum "D:\MyProjects\DotNetStudy\src\DotNetStudy.Web\Views\Alipay\Callback.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "604ce6814f3879b088c4ccfbaa70f61c4c4c1a59"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Alipay_Callback), @"mvc.1.0.view", @"/Views/Alipay/Callback.cshtml")]
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
#line 1 "D:\MyProjects\DotNetStudy\src\DotNetStudy.Web\Views\_ViewImports.cshtml"
using DotNetStudy.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyProjects\DotNetStudy\src\DotNetStudy.Web\Views\_ViewImports.cshtml"
using DotNetStudy.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"604ce6814f3879b088c4ccfbaa70f61c4c4c1a59", @"/Views/Alipay/Callback.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a9fa861c4a860259ce380361bad65ec99c1710f", @"/Views/_ViewImports.cshtml")]
    public class Views_Alipay_Callback : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\MyProjects\DotNetStudy\src\DotNetStudy.Web\Views\Alipay\Callback.cshtml"
   ViewData["Title"] = "支付结果"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>支付结果</h2>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-sm-12\">\r\n        <h3 class=\"text-center text-success\">");
#nullable restore
#line 7 "D:\MyProjects\DotNetStudy\src\DotNetStudy.Web\Views\Alipay\Callback.cshtml"
                                        Write(ViewData["PayResult"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
