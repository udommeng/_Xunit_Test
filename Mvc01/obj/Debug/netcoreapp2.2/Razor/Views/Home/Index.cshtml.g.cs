#pragma checksum "E:\_Learn_Net_CORE_API\Mvc01\Mvc01\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d319243ac8147936e0b10db7d755f5cadaa71e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "E:\_Learn_Net_CORE_API\Mvc01\Mvc01\Views\_ViewImports.cshtml"
using Mvc01;

#line default
#line hidden
#line 2 "E:\_Learn_Net_CORE_API\Mvc01\Mvc01\Views\_ViewImports.cshtml"
using Mvc01.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d319243ac8147936e0b10db7d755f5cadaa71e3", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e770e29cf36364e6d093ef11e6408df062999dd1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 21, true);
            WriteLiteral("<h2>Home</h2>\r\n\r\n<h3>");
            EndContext();
            BeginContext(22, 13, false);
#line 3 "E:\_Learn_Net_CORE_API\Mvc01\Mvc01\Views\Home\Index.cshtml"
Write(ViewBag.Count);

#line default
#line hidden
            EndContext();
            BeginContext(35, 12, true);
            WriteLiteral("</h3>\r\n<pre>");
            EndContext();
            BeginContext(48, 14, false);
#line 4 "E:\_Learn_Net_CORE_API\Mvc01\Mvc01\Views\Home\Index.cshtml"
Write(ViewBag.Orders);

#line default
#line hidden
            EndContext();
            BeginContext(62, 6, true);
            WriteLiteral("</pre>");
            EndContext();
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
