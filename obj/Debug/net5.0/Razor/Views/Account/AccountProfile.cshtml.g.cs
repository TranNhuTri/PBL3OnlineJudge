#pragma checksum "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbd1f1cf773172e2c966c09aa424bee65169115e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_AccountProfile), @"mvc.1.0.view", @"/Views/Account/AccountProfile.cshtml")]
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
#line 1 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbd1f1cf773172e2c966c09aa424bee65169115e", @"/Views/Account/AccountProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AccountProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Account>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Problem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Problems", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditSubmission", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Submissions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("submissionEdit_link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
  
    ViewData["Title"] = "Tài khoản " + Model.accountName; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"grid\">\r\n    <div class=\"postPage-layout\">\r\n        <div class=\"grid_row\">\r\n            <div class=\"grid_column-2\">\r\n                <div class=\"inforUser\">\r\n");
#nullable restore
#line 12 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                     if(!string.IsNullOrEmpty(Model.avar))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"inforUser__avatar\"");
            BeginWriteAttribute("style", " style=\"", 412, "\"", 455, 4);
            WriteAttributeValue("", 420, "background-image:", 420, 17, true);
            WriteAttributeValue(" ", 437, "url(", 438, 5, true);
#nullable restore
#line 14 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
WriteAttributeValue("", 442, Model.avar, 442, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 453, ");", 453, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n");
#nullable restore
#line 15 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"inforUser__avatar\"></div>\r\n");
#nullable restore
#line 19 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"inforUser__name\">\r\n                        <h3 class=\"inforUser__name-title\">Tên tài khoản</h3>\r\n                        <p style=\"color: #444444b5; font-weight: bold;\">");
#nullable restore
#line 22 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                                                   Write(Model.accountName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                    </div>
                </div>
            </div>
            <div class=""grid_column-8"">
                <div class=""listProblemOfUser"">
                    <div class=""listProblems_header"">
                        <h1>Danh sách bài nộp</h1>
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
");
#nullable restore
#line 40 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                 if(Context.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "Admin" && Model.submissions.Count > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <th></th>\r\n");
#nullable restore
#line 43 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 47 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                              
                                Model.submissions = Model.submissions.OrderByDescending(p => p.timeCreate).ToList();
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                             for(int i = 0; i < Model.submissions.Count; i++)
                            {
                                string color = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class = \"link submissionID\" style=\"text-decoration: underline;\" data-id=\"");
#nullable restore
#line 54 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                                                                                            Write(Model.submissions[i].ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 54 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                                                                                                                       Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 55 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                   Write(Model.submissions[i].timeCreate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbd1f1cf773172e2c966c09aa424bee65169115e11206", async() => {
#nullable restore
#line 56 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                                                                                                                                          Write(Model.submissions[i].problem.title);

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
#line 56 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                                                      WriteLiteral(Model.submissions[i].problem.ID);

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
#line 57 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                     if(Model.submissions[i].status == "Accepted")
                                    {
                                        color = "#00bb00";
                                    }
                                    else
                                        if(Model.submissions[i].status == "Wrong Answer")
                                        {
                                            color = "#ff0000ba";
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class = \"submissionStatus\"");
            BeginWriteAttribute("style", " style= \"", 3394, "\"", 3416, 2);
            WriteAttributeValue("", 3403, "color:", 3403, 6, true);
#nullable restore
#line 66 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
WriteAttributeValue(" ", 3409, color, 3410, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 66 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                                                                     Write(Model.submissions[i].status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class = \"submissionTime\">");
#nullable restore
#line 67 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                                            Write(Model.submissions[i].time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 68 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                   Write(Model.submissions[i].language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 69 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                     if(Context.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "Admin" && Model.submissions.Count > 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td class = \"submissionEdit\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbd1f1cf773172e2c966c09aa424bee65169115e16543", async() => {
                WriteLiteral("<i class=\"far fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                                                                                                                         WriteLiteral(Model.submissions[i].ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n");
#nullable restore
#line 72 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tr>\r\n");
#nullable restore
#line 74 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\AccountProfile.cshtml"
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
<div class=""overlay"">
    <div class=""detailSubmissionContainer"">
        <i class=""fas fa-times detailSubmissionIcon""></i>
        <div class=""detailSubmissionContent"">
        </div>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\"/js/Submission.js\"></script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Account> Html { get; private set; }
    }
}
#pragma warning restore 1591
