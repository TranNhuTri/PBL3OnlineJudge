#pragma checksum "D:\Web\PBL3\Views\Comment\GetComment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fa27a0057d42b1a1065b8569e7b99ce00d8ce12"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Comment_GetComment), @"mvc.1.0.view", @"/Views/Comment/GetComment.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using PBL3.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using PBL3.General;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fa27a0057d42b1a1065b8569e7b99ce00d8ce12", @"/Views/Comment/GetComment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Comment_GetComment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Comment>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Web\PBL3\Views\Comment\GetComment.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Web\PBL3\Views\Comment\GetComment.cshtml"
Write(await Html.PartialAsync("_Comment", @Model));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Comment> Html { get; private set; }
    }
}
#pragma warning restore 1591
