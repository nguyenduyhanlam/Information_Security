#pragma checksum "C:\Users\Admin\source\repos\QR\QR\Views\Home\Checkin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "837418f92cd1b011db4e3348197d3eca2eb89f6e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Checkin), @"mvc.1.0.view", @"/Views/Home/Checkin.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\QR\QR\Views\_ViewImports.cshtml"
using QR;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\QR\QR\Views\_ViewImports.cshtml"
using QR.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"837418f92cd1b011db4e3348197d3eca2eb89f6e", @"/Views/Home/Checkin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd627a3018b2e0b5d820ffd9c6c02764fb1986bc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Checkin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Admin\source\repos\QR\QR\Views\Home\Checkin.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Current user</h3>\r\n<div class=\"text-center\">\r\n    <div class=\"col-md-6 login-form-2\">\r\n        <div class=\"form-group\">\r\n            <label>");
#nullable restore
#line 10 "C:\Users\Admin\source\repos\QR\QR\Views\Home\Checkin.cshtml"
              Write(Model.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label>");
#nullable restore
#line 13 "C:\Users\Admin\source\repos\QR\QR\Views\Home\Checkin.cshtml"
              Write(Model.username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label>");
#nullable restore
#line 16 "C:\Users\Admin\source\repos\QR\QR\Views\Home\Checkin.cshtml"
              Write(Model.lastcheckedin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
