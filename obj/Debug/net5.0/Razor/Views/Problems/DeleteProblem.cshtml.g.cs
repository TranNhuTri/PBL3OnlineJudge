#pragma checksum "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd62c4d790d2fcf8d67f9e2a5272291a211dd20a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Problems_DeleteProblem), @"mvc.1.0.view", @"/Views/Problems/DeleteProblem.cshtml")]
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
#line 5 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd62c4d790d2fcf8d67f9e2a5272291a211dd20a", @"/Views/Problems/DeleteProblem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Problems_DeleteProblem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Problem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteProblem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
  
    Layout = "_AdminLayout";
    ViewData["Title"] = "X??a b??i t???p";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"grow\">\r\n    <div class=\"grid_row\">\r\n        <div class=\"grid_column\">\r\n            <div class=\"deletePage\">\r\n                <div class=\"deletePage_header\">\r\n                    <h1>X??c nh???n x??a b??i ");
#nullable restore
#line 12 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                                    Write(Model.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </div>\r\n                <div class=\"deletePage_input\">\r\n                    <div class=\"formGroup\">\r\n                        <label for=\"code\">M?? b??i :</label>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fd62c4d790d2fcf8d67f9e2a5272291a211dd20a5434", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 17 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.code);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"formGroup\">\r\n                        <label for=\"tilte\">T??n b??i :</label>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fd62c4d790d2fcf8d67f9e2a5272291a211dd20a7223", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 21 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.title);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <p class=""deletePage_warning"">
                        Vi???c x??a b??i t???p c?? th??? d???n t???i m???t c??c d??? li???u sau !!!
                    </p>
                    <p>C??c b??i n???p :</p>
                    <table cellspacing=""0"" cellpadding=""0"" class=""table submissions_table"">
                        <thead>
                            <tr>
                                <th class=""submissionID"">ID</th>
                                <th>Ng??y n???p</th>
                                <th>Ng?????i n???p</th>
                                <th>Tr???ng th??i</th>
                                <th>CPU</th>
                                <th>Ng??n ng???</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 39 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                             foreach (var item in Model.submissions)
                            {
                                string color = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class = \"link submissionID\" style=\"text-decoration: underline;\" data-id=\"");
#nullable restore
#line 43 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                                                                                                            Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 43 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                                                                                                                      Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 44 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                                   Write(item.timeCreate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2024, "\"", 2031, 0);
            EndWriteAttribute();
            WriteLiteral(" class = \"link\">");
#nullable restore
#line 45 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                                                             Write(item.account.accountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n");
#nullable restore
#line 46 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                                     if(item.status == "Accepted")
                                    {
                                        color = "#00bb00";
                                    }
                                    else
                                        if(@item.status == "Wrong Answer")
                                        {
                                            color = "#ff0000ba";
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class = \"submissionStatus\"");
            BeginWriteAttribute("style", " style= \"", 2626, "\"", 2648, 2);
            WriteAttributeValue("", 2635, "color:", 2635, 6, true);
#nullable restore
#line 55 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
WriteAttributeValue(" ", 2641, color, 2642, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 55 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                                                                                     Write(item.status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class = \"submissionTime\">");
#nullable restore
#line 56 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                                                            Write(item.time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 57 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                                   Write(item.language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 59 "D:\Web\PBL3\PBL3OnlineJudge\Views\Problems\DeleteProblem.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd62c4d790d2fcf8d67f9e2a5272291a211dd20a13918", async() => {
                WriteLiteral(@"
                        <div class=""formSubmitGroup"" style=""position: sticky; bottom: 0; background-color: #fff"">
                            <div class=""formSubmit"">
                                <button type=""submit"" class=""submitButton button"" style=""background-color: #dc3545"">
                                    <i class=""fas fa-trash-alt""></i>
                                    <p>X??a b??i t???p</p>
                                </button>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Problem> Html { get; private set; }
    }
}
#pragma warning restore 1591
