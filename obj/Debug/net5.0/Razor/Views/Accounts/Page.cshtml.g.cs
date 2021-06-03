#pragma checksum "D:\Web\PBL3\Views\Accounts\Page.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d723955253aae408e2888661b36bd001a560f3f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Accounts_Page), @"mvc.1.0.view", @"/Views/Accounts/Page.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d723955253aae408e2888661b36bd001a560f3f4", @"/Views/Accounts/Page.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Accounts_Page : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Account>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Accounts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: #008eff; text-decoration: none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
  
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"listObjectsPage\">\r\n    <div class=\"grid_row\">\r\n        <div class=\"grid_column\">\r\n            <div class=\"listObjectsPage_header\">\r\n                <h1>Danh sách tất cả tài khoản</h1>\r\n            </div>\r\n            ");
#nullable restore
#line 11 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
       Write(await Html.PartialAsync("_SearchAccountForm", ViewData[""]));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <table cellspacing=""0"" cellpadding=""0"" class=""table"">
                <thead>
                    <tr>
                        <th>#</th>
                        <th style=""text-align: left;"">
                            Tên tài khoản
                        </th>
                        <th style=""text-align: left;"">
                            Email
                        </th>
                        <th style=""text-align: left;"">
                            Họ và tên
                        </th>
                        <th>
                            Loại tài khoản
                        </th>
                        <th>Kích hoạt</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 32 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                     for(int i = 0; i < Model.Count; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 35 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                            Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"text-align: left;\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d723955253aae408e2888661b36bd001a560f3f46475", async() => {
#nullable restore
#line 37 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                                                                                                                                                                 Write(Model[i].accountName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
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
            WriteLiteral("\r\n                            </td>\r\n                            <td style=\"text-align: left;\">");
#nullable restore
#line 39 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                                                     Write(Model[i].email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"text-align: left;\">");
#nullable restore
#line 40 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                                                      Write(Model[i].lastName + " " + Model[i].firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 41 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                             if(@Model[i].typeAccount == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Admin</td>\r\n");
#nullable restore
#line 44 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                            }
                            else{
                                if(@Model[i].typeAccount == 2)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>Tác giả</td>\r\n");
#nullable restore
#line 49 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>Người dùng</td>\r\n");
#nullable restore
#line 53 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                             if(@Model[i].isActived)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td style=\"color: #00bb00;\"><i class=\"fas fa-check-circle\"></i></td>\r\n");
#nullable restore
#line 58 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td style=\"color: #ff0000ba;\"><i class=\"fas fa-times-circle\"></i></td>\r\n");
#nullable restore
#line 62 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 64 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"grid_row\">\r\n    <div class=\"grid_column\">\r\n");
#nullable restore
#line 72 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
          
            string[] param = {"Page", "Accounts"};
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
#nullable restore
#line 75 "D:\Web\PBL3\Views\Accounts\Page.cshtml"
   Write(await Html.PartialAsync("_Pagination", param));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        new SlimSelect({
            select: '#typeAccount',
            showSearch: false,
        })
        new SlimSelect({
            select: '#isActived',
            showSearch: false,
        })
        var typeAccountSelect = document.querySelector(""#typeAccount"");
        var isActived = document.querySelector('#isActived');
        var submitButton = document.querySelector("".searchForm_submit"");

        typeAccountSelect.addEventListener('change', function()
        {
            submitButton.click();
        });
        isActived.addEventListener('change', function()
        {
            submitButton.click();
        });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Account>> Html { get; private set; }
    }
}
#pragma warning restore 1591
