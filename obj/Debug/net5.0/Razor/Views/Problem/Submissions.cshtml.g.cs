#pragma checksum "D:\Web\PBL3\Views\Problem\Submissions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d0b1a032f5ce06e5c8b801d265c26b250fb6df5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Problem_Submissions), @"mvc.1.0.view", @"/Views/Problem/Submissions.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d0b1a032f5ce06e5c8b801d265c26b250fb6df5", @"/Views/Problem/Submissions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Problem_Submissions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Submission>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Problem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Problems", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
  
    ViewData["Title"] = "Bài nộp của tôi";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""grid"">
    <div class=""grid_row"">
        <div class=""grid_column"">
            <div class=""listObjectsPage"" style=""margin-top: 30px;"">
                <div class=""listObjectsPage_header"">
                    <h1 class=""submissions_header"">Tất cả bài nộp</h1>
                </div>
                <table cellspacing=""0"" cellpadding=""0"" class=""table submissions_table"">
                    <thead>
                        <tr>
                            <th class = ""submissionID"">ID</th>
                            <th>Ngày nộp</th>
                            <th style=""width: 35%"">Bài</th>
                            <th>Trạng thái</th>
                            <th>CPU</th>
                            <th>Ngôn ngữ</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 24 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                         for(int i = 0; i < Model.Count; i++)
                        {
                            string color = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td class = \"link submissionID\" style=\"text-decoration: underline;\">");
#nullable restore
#line 28 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                                                                                Write(ViewBag.currentPage + i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 29 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                               Write(Model[i].timeCreate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d0b1a032f5ce06e5c8b801d265c26b250fb6df56548", async() => {
#nullable restore
#line 30 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                                                                                                                          Write(Model[i].problem.title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                                                  WriteLiteral(Model[i].problem.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n");
#nullable restore
#line 31 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                 if(Model[i].status == "Accepted")
                                {
                                    color = "#00bb00";
                                }
                                else
                                    if(@Model[i].status == "Wrong Answer")
                                    {
                                        color = "#ff0000ba";
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class = \"submissionStatus\"");
            BeginWriteAttribute("style", " style= \"", 1981, "\"", 2003, 2);
            WriteAttributeValue("", 1990, "color:", 1990, 6, true);
#nullable restore
#line 40 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
WriteAttributeValue(" ", 1996, color, 1997, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 40 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                                                                 Write(Model[i].status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class = \"submissionTime\">");
#nullable restore
#line 41 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                                        Write(Model[i].time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 42 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                               Write(Model[i].language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 44 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<div class=""overlay"">
    <div class=""detailSubmissionContainer"">
        <i class=""fas fa-times detailSubmissionIcon""></i>
        <div class=""detailSubmissionContent"">
        </div>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src = \"/js/Submission.js\"></script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Submission>> Html { get; private set; }
    }
}
#pragma warning restore 1591
