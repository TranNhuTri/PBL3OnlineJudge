#pragma checksum "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_LoginHeader.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ffdbaaae1bb0c26b7af83a4cc00d270c0a97a5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoginHeader), @"mvc.1.0.view", @"/Views/Shared/_LoginHeader.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ffdbaaae1bb0c26b7af83a4cc00d270c0a97a5a", @"/Views/Shared/_LoginHeader.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoginHeader : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditAccountProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("appHeader_dropdown_link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<ul class=\"appHeader_list\">\r\n");
#nullable restore
#line 2 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_LoginHeader.cshtml"
     if(Context.User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <li class=""appHeader_item"">
            <div class=""appHeader_bellIcon"" onclick=""showNotifications()"">
                <i class=""fas fa-bell""></i>
                <div class=""appHeader_notifications_dropdown"">
                    <ul class=""appHeader_dropdown_list"" id = ""notification-list"">
                    </ul>
                </div>
                <div class=""number_notifi""></div>
            </div>
        </li>
        <li class=""appHeader_item"">
            <div class=""appHeader_avarIcon"" onclick=""showUserTool()"">
                <i class=""fas fa-user-circle""></i>
                <div class=""appHeader_dropdown"">
                    <ul class=""appHeader_dropdown_list"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ffdbaaae1bb0c26b7af83a4cc00d270c0a97a5a5627", async() => {
                WriteLiteral("\r\n                            <li class=\"appHeader_dropdown_item\">\r\n                                <i class=\"appHeader_dropdown_icon fas fa-user\"></i>\r\n                                ");
#nullable restore
#line 22 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_LoginHeader.cshtml"
                           Write(Context.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </li>\r\n                        ");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-name", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_LoginHeader.cshtml"
                                                                                              WriteLiteral(Context.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["name"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-name", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["name"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 25 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_LoginHeader.cshtml"
                         if(Context.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "Admin" || Context.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "Author")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <a class=""appHeader_dropdown_link"" href=""/Admin"">
                                <li class=""appHeader_dropdown_item"">
                                    <i class=""appHeader_dropdown_icon fas fa-cogs""></i>
                                    Qu???n l??
                                </li>
                            </a>
");
#nullable restore
#line 33 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_LoginHeader.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <a class=""appHeader_dropdown_link"" href=""/Logout"">
                            <li class=""appHeader_dropdown_item"">
                                <i class=""appHeader_dropdown_icon fas fa-sign-out-alt""></i>
                                ????ng xu???t
                            </li>
                        </a>
                    </ul>
                </div>
            </div>
        </li>
");
#nullable restore
#line 44 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_LoginHeader.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"appHeader_item\">\r\n            <a href=\"/Login/UserLogin\" class = \"login_link\">????ng nh???p</a>\r\n        </li>\r\n        <li class=\"appHeader_item\">\r\n            <a href=\"/Account/SignUp\" class = \"register_link\">????ng k??</a>\r\n        </li>\r\n");
#nullable restore
#line 53 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_LoginHeader.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
