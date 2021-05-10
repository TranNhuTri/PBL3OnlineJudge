#pragma checksum "D:\Web\PBL3\Views\Problem\Submissions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c8f7d1999373c690d56b99375d10dcfe3b79f67"
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
using PBL3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c8f7d1999373c690d56b99375d10dcfe3b79f67", @"/Views/Problem/Submissions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac635efc7416b8ad0f0feeab92b905167e22d41e", @"/Views/_ViewImports.cshtml")]
    public class Views_Problem_Submissions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Submission>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Problem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ListProblems", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
  
    ViewData["Title"] = "Danh sách bài nộp";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""SubmissionsPage"">
    <div class=""grid"">
        <div class=""grid_row"">
            <div class=""grid_column"">
                <div class=""SubmissionsContainer"">
                    <h1 class=""Submissions_Header"">Tất cả bài nộp</h1>
                    <table cellspacing=""0"" cellpadding=""0"" class=""Submissions_Table"">
                        <thead class = ""Submissions_Table_Header"">
                            <tr>
                                <th>ID</th>
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
#line 23 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                             for(int i = 0; i < Model.Count; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class = \"link SubmissionID\">");
#nullable restore
#line 26 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                                               Write(Model[i].ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 27 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                   Write(Model[i].TimeCreate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c8f7d1999373c690d56b99375d10dcfe3b79f676308", async() => {
#nullable restore
#line 28 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                                                                                                                                  Write(Model[i].Problem.Title);

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
#line 28 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                                                      WriteLiteral(Model[i].Problem.ID);

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
            WriteLiteral("</td>\r\n                                    <td class = \"SubmissionStatus\">");
#nullable restore
#line 29 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                                              Write(Model[i].Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class = \"SubmissionTime\">?</td>\r\n                                    <td>");
#nullable restore
#line 31 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                                   Write(Model[i].Language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 33 "D:\Web\PBL3\Views\Problem\Submissions.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""Overlay"">
    <div class=""DetailSubmissionContainer"">
        <i class=""fas fa-times DetailSubmissionIcon""></i>
        <div class=""DetailSubmissionContent"">
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
