#pragma checksum "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\ProblemHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fc0c87daf16bf2f86f8fe42dc797c9b04aca4fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Problems_ProblemHistory), @"mvc.1.0.view", @"/Views/Problems/ProblemHistory.cshtml")]
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
#line 1 "D:\Web\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using PBL3.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Web\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Web\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Web\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Web\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using PBL3.General;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Web\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fc0c87daf16bf2f86f8fe42dc797c9b04aca4fc", @"/Views/Problems/ProblemHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6c73b5a47a9f7d80dcfeec09fe1a2be92916370", @"/Views/_ViewImports.cshtml")]
    public class Views_Problems_ProblemHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PBL3.Models.Action>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\ProblemHistory.cshtml"
  
    Layout = "_Adminlayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"listObjectsPage\" style=\"padding: 0;\">\r\n    <div class=\"grid_row\">\r\n        <div class=\"grid_column\">\r\n            <div class=\"listObjectsPage_header\">\r\n                    <h1>Lịch sử chỉnh sửa bài tập</h1>\r\n            </div>\r\n            ");
#nullable restore
#line 11 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\ProblemHistory.cshtml"
       Write(await Html.PartialAsync("_Actions", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PBL3.Models.Action>> Html { get; private set; }
    }
}
#pragma warning restore 1591
