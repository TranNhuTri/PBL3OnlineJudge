#pragma checksum "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5145c47a6646c5a8159aeede6970125351892008"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Problems_Problem), @"mvc.1.0.view", @"/Views/Problems/Problem.cshtml")]
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
#line 1 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using PBL3.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\_ViewImports.cshtml"
using PBL3.General;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5145c47a6646c5a8159aeede6970125351892008", @"/Views/Problems/Problem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Problems_Problem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Problem>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Problem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Submit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("problemMenu_Link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Submissions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("CUDProblem mySubmissions"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:  #1dbfaf29"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #ff000021"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("CUDProblem"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Problems", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditProblem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteProblem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
  
    ViewData["Title"] = Model.title;
    var listAuthors = Model.problemAuthors.Where(p => p.isDeleted == false).Select(p => p.author);
    var listCategories = Model.problemClassifications.Where(p => p.isDeleted == false && p.category.isDeleted == false).Select(p => p.category);
    var listSubmissions = Model.submissions.ToList();
    var listComments = (List<Comment>)ViewData["ListComments"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"problemPage\">\r\n    <div class=\"grid\">\r\n        <div class=\"grid_row\">\r\n            <div class=\"grid_column-9\">\r\n                <div class=\"problemContent\">\r\n                    <h1 class=\"problemPageHeader\">");
#nullable restore
#line 17 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                             Write(Model.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    ");
#nullable restore
#line 18 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
               Write(Html.Raw(@Model.content));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    <div class=""comments"">
                        <div class=""comments_header"">
                            <i class=""far fa-comments""></i>
                            <h1>Bình luận</h1>
                        </div>
                        <div class=""listComments"">
");
#nullable restore
#line 25 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                             if(listComments != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                           Write(await Html.PartialAsync("_ListComments", listComments));

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                                                       
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <div class=\"comment_box\" style=\"display: block;\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5145c47a6646c5a8159aeede697012535189200810298", async() => {
                WriteLiteral("\r\n                                <textarea name=\"content\" id=\"editor\" data-first = \"1\" cols=\"30\" rows=\"10\"></textarea>\r\n                                <button class=\"button comment_button\">Gửi</button>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onsubmit", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1418, "return", 1418, 6, true);
            AddHtmlAttributeValue(" ", 1424, "PostRootComment(\'", 1425, 18, true);
#nullable restore
#line 31 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
AddHtmlAttributeValue("", 1442, Model.ID, 1442, 9, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 1451, "\')", 1451, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
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
            <div class=""grid_column-3"">
                <div class=""problemMenu"">
                    <div class=""problemMenu_Buttons"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5145c47a6646c5a8159aeede697012535189200812731", async() => {
                WriteLiteral("\r\n                            <div class=\"problemSubmitButton button\">\r\n                                <i class=\"fas fa-upload\"> </i>\r\n                                Nộp bài\r\n                            </div>\r\n                        ");
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
#line 42 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                                                WriteLiteral(Model.ID);

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
            WriteLiteral("\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2339, "\"", 2346, 0);
            EndWriteAttribute();
            WriteLiteral(@" class = ""problemMenu_Link"">
                            <div class=""problemStatistictButton button"">
                                <i class=""fas fa-chart-pie""> </i>
                                Thống kê
                            </div>
                        </a>
                    </div>
                    <div class=""problemPropertyContainer"">

");
#nullable restore
#line 57 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                         if(Context.User.Identity.IsAuthenticated)
                        {
                            var parms = new Dictionary<string, string>
                            {
                                {"problemID", Convert.ToString(Model.ID)},
                                {"accountName", Context.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value},
                            };
                            var accountID = Convert.ToInt32(Context.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

                            if(listSubmissions.Where(s => s.accountID == accountID).Select(s => s).ToList().Count > 0)
                            {
                                if(listSubmissions.Where(s => s.accountID == accountID && s.status == "Accepted").Select(s => s).ToList().Count > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5145c47a6646c5a8159aeede697012535189200817117", async() => {
                WriteLiteral("Lời giải của tôi");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 70 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues = parms;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-all-route-data", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 71 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5145c47a6646c5a8159aeede697012535189200819461", async() => {
                WriteLiteral("Lời giải của tôi");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 74 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues = parms;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-all-route-data", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 75 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                }
                            }


#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5145c47a6646c5a8159aeede697012535189200821757", async() => {
                WriteLiteral("Tất cả bài nộp");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-problemID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                                                                WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["problemID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-problemID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["problemID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 79 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"

                            if(Context.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "Admin" || Context.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "Author")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5145c47a6646c5a8159aeede697012535189200824730", async() => {
                WriteLiteral("Sửa đề bài");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                                                              WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5145c47a6646c5a8159aeede697012535189200827259", async() => {
                WriteLiteral("Xóa đề bài");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                                                                WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 84 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        \r\n                        <p class = \"problemProperty\"><b>Mã bài: </b>");
#nullable restore
#line 87 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                               Write(Model.code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class = \"problemProperty\"><b>Thời gian giới hạn: </b>");
#nullable restore
#line 88 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                                           Write(Model.timeLimit);

#line default
#line hidden
#nullable disable
            WriteLiteral(" s</p>\r\n                        <p class = \"problemProperty\"><b>Bộ nhớ giới hạn: </b>");
#nullable restore
#line 89 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                                        Write(Model.memoryLimit);

#line default
#line hidden
#nullable disable
            WriteLiteral(" M</p>\r\n                        <p class = \"problemProperty\"><b>Độ khó: </b>");
#nullable restore
#line 90 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                               Write(Model.difficulty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class = \"problemProperty\"><b>Tác giả: </b>\r\n");
#nullable restore
#line 92 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                             foreach (var author in listAuthors)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span style=\"font-size: 16rem; font-weight: bold; color: #989898\">");
#nullable restore
#line 94 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                                                             Write(author.accountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </span>\r\n");
#nullable restore
#line 95 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </p>\r\n                    </div>\r\n                </div>\r\n                <div class=\"problemCategory\">\r\n                    <p style=\"margin: 0; margin-bottom: 5px;\">Dạng bài</p>\r\n");
#nullable restore
#line 101 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                     if(listCategories != null)
                    {
                        foreach(Category cate in listCategories)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"CategoryBox\">");
#nullable restore
#line 105 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                                                Write(cate.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 106 "C:\Users\Asus\Desktop\Htap\PBL3\PBL3OnlineJudge\Views\Problems\Problem.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        CKEDITOR.replace('editor', {
            height: '200px',
        });
    </script>
    <script>
        function PostRootComment(postId)
        {
            console.log(""Submit"");
            for ( instance in CKEDITOR.instances)
                CKEDITOR.instances[instance].updateElement();

            var content = document.getElementById(""editor"").value;

            let data = new URLSearchParams();
            data.append(""postID"", postId);
            data.append(""content"", content);

            CKEDITOR.instances[""editor""].setData('');

            fetch(""https://localhost:5001/Comment/PostComment"", {
                method :'post',
                body : data
            })
            .then(res => {
                if(res.ok)
                {
                    return res.text();
                }
            })
            .then(data => {
                $("".listComments"").append(data);
            })
            .catch(err => console.log");
                WriteLiteral("(err));\r\n\r\n            return false;\r\n        }\r\n    </script>\r\n");
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
