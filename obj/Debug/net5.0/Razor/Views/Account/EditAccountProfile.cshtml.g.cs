#pragma checksum "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\EditAccountProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1097e466c0ab89597569eb946b2d9214b82b8253"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_EditAccountProfile), @"mvc.1.0.view", @"/Views/Account/EditAccountProfile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1097e466c0ab89597569eb946b2d9214b82b8253", @"/Views/Account/EditAccountProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_EditAccountProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Account>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("infor__content"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""grid"">
    <div class=""postPage-layout"">
        <div class=""grid_row"">
            <div class=""grid_column-6 postPage"">
                <div class=""infor"">
                    <h3 class=""infor__title"">Thông tin người dùng</h3>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1097e466c0ab89597569eb946b2d9214b82b82534442", async() => {
                WriteLiteral(@"
                        <div class=""infor__content--avatar"" style=""background-image: url(https://codelearn.io/Themes/TheCodeCampPro/Resources/Images/code-learn/img-preview-bg.png);""></div>
                        <div class=""infor__content--input"">
                            <div class=""input-row"">
                                <label");
                BeginWriteAttribute("for", " for=\"", 692, "\"", 698, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"input__title\" >Tên tài khoản</label>\r\n                                <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 795, "\"", 809, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 810, "\"", 836, 1);
#nullable restore
#line 15 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\EditAccountProfile.cshtml"
WriteAttributeValue("", 818, Model.accountName, 818, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"input-row\">\r\n                                <label");
                BeginWriteAttribute("for", " for=\"", 967, "\"", 973, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"input__title\">Họ</label>\r\n                                <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1058, "\"", 1072, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1073, "\"", 1096, 1);
#nullable restore
#line 19 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\EditAccountProfile.cshtml"
WriteAttributeValue("", 1081, Model.lastName, 1081, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"input-row\">\r\n                                <label");
                BeginWriteAttribute("for", " for=\"", 1227, "\"", 1233, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"input__title\">Tên</label>\r\n                                <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1319, "\"", 1333, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1334, "\"", 1358, 1);
#nullable restore
#line 23 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\EditAccountProfile.cshtml"
WriteAttributeValue("", 1342, Model.firstName, 1342, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">                                   \r\n                            </div>\r\n                            <div class=\"input-row\">\r\n                                <label");
                BeginWriteAttribute("for", " for=\"", 1524, "\"", 1530, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"input__title\">Email</label>\r\n                                <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1618, "\"", 1632, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1633, "\"", 1653, 1);
#nullable restore
#line 27 "D:\Web\PBL3\PBL3OnlineJudge\Views\Account\EditAccountProfile.cshtml"
WriteAttributeValue("", 1641, Model.email, 1641, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">                                 \r\n                            </div>\r\n                            <div class=\"infor__function\">\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 1819, "\"", 1826, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""infor__function--link password"">Đổi mật khẩu</a>
                            </div>
                            <div class=""infor__save"">
                                <button class=""infor__save--button"">Lưu thay đổi</button>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        var inputElement = document.querySelectorAll(\'.input-row input\');\r\n        var btnEdit = document.querySelector(\'.infor__save .infor-btn.edit\');\r\n");
                WriteLiteral(@"        function enableReadOnly(){
            Array.from(inputElement).forEach(element => {
                element.removeAttribute('readonly');
                element.style.border  = '1px solid #cdcdcd';
            });
            return false;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Account> Html { get; private set; }
    }
}
#pragma warning restore 1591