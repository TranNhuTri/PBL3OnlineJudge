#pragma checksum "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09187450d08e2269a237f358f244584040cf40de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Problems_Index), @"mvc.1.0.view", @"/Views/Problems/Index.cshtml")]
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
#line 1 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
using PBL3.General;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09187450d08e2269a237f358f244584040cf40de", @"/Views/Problems/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Problems_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Problem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Problems", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Problem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("problemTitle_link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
  
    ViewData["Title"] = "Danh sách bài tập";
    var problemSubmissions = (List<int>)ViewData["ProblemSubmissions"];
    var problemACSubmissionsByAccount = (List<int>)ViewData["ProblemACSubmissionsByAccount"];
    var problemSubmissionsByAccount = (List<int>)ViewData["ProblemSubmissionsByAccount"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""listProblemsPage"">
    <div class=""grid"">
        <div class=""grid_row"">
            <div class=""grid_column-9"">
                <div class=""listProblems_container"">
                    <div class=""listProblems_header"">
                        <h1>Danh sách bài tập</h1>
                    </div>
                    <table cellspacing=""0"" cellpadding=""0"" class=""table listProblems_table"">
                        <thead>
                            <tr>
                                <th></th>
                                <th class = ""number"">#</th>
                                <th class = ""title"">
                                    Tên Bài
                                </th>
                                <th class = ""points"">
                                    Độ Khó
                                </th>
                                <th class = ""successRate"">
                                    Tỉ Lệ AC
                                </th>
                    ");
            WriteLiteral("        </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 35 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                 for (int i = 0; i < Model.Count; i++)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class= \"listProblemRow\">\r\n");
#nullable restore
#line 38 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                         if(Context.User.Identity.IsAuthenticated)
                                        {
                                            if(problemSubmissionsByAccount[i] > 0)
                                            {
                                                if(problemACSubmissionsByAccount[i] > 0)
                                                {
                                                    if(Model[i].isPublic == false)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td class = \"icon\" style=\"color: #00bb00;\"><i class=\"fas fa-lock\"></i></td>\r\n");
#nullable restore
#line 47 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td class = \"icon\" style=\"color: #00bb00;\"><i class=\"fas fa-check\"></i></td>\r\n");
#nullable restore
#line 51 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                    }
                                                }
                                                else
                                                {
                                                    if(Model[i].isPublic == false)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td class = \"icon\" style=\"color: #ff0000ba;\"><i class=\"fas fa-lock\"></i></td>\r\n");
#nullable restore
#line 58 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td class = \"icon\" style=\"color: #ff0000ba;\"><i class=\"fas fa-times\"></i></td>\r\n");
#nullable restore
#line 62 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if(Model[i].isPublic == false)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td class = \"icon\" style=\"color: #0000006b;\"><i class=\"fas fa-lock\"></i></td>\r\n");
#nullable restore
#line 70 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td></td>\r\n");
#nullable restore
#line 74 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                }
                                            }
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td></td>\r\n");
#nullable restore
#line 80 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td class = \"problemNumber\">");
#nullable restore
#line 81 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                                Write((ViewBag.currentPage - 1)*Utility.limitData + i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td class = \"problemTitle\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09187450d08e2269a237f358f244584040cf40de11231", async() => {
#nullable restore
#line 83 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                                                                                                                       Write(Model[i].title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                                                                      WriteLiteral(Model[i].ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n");
#nullable restore
#line 85 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                          
                                            float successRate = 0;
                                            if(Model[i].submissions.ToList().Count != 0)
                                            {
                                                successRate = (float)Model[i].submissions.Where(s => s.status == "Accepted").Select(s => s).ToList().Count / Model[i].submissions.ToList().Count*100;
                                            }
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td class = \"problemDifficullity\">");
#nullable restore
#line 92 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                                     Write(Model[i].difficulty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td class = \"problemSuccessRate\">");
#nullable restore
#line 93 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                                                    Write(successRate.ToString("n2"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 95 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n");
#nullable restore
#line 99 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
                  
                    string[] param = {"Index", "Problems"};
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
#nullable restore
#line 102 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
           Write(await Html.PartialAsync("_Pagination", param));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"grid_column-3\">\r\n                ");
#nullable restore
#line 105 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\Index.cshtml"
           Write(await Html.PartialAsync("_SearchProblemForm1", ViewData["SearchProblemInfor"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        new SlimSelect({
            select: '#CategoryIds',
            placeholder: 'Chọn dạng bài',
            searchText: 'Không thể tìm thấy',
        })
    </script>
    <script>
        var submitButton = document.querySelector("".problemFillterSubmit_button"");
        var hideSolvedCheckBox = document.querySelector(""#hideSolvedProblem"");
        if(hideSolvedCheckBox != null)
        {
            hideSolvedCheckBox.addEventListener('change', function()
            {
                submitButton.click();
            });
        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Problem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
