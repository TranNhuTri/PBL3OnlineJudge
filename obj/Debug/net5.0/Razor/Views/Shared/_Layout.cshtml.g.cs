#pragma checksum "D:\Web\PBL3\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49624410c57db478b2b62bb19c738f6e44f269fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49624410c57db478b2b62bb19c738f6e44f269fa", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac635efc7416b8ad0f0feeab92b905167e22d41e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("AppHeader_Link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("AppHeader_Dropdown_Link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ListProblems", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49624410c57db478b2b62bb19c738f6e44f269fa5595", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
#nullable restore
#line 6 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
    <link rel=""shortcut icon"" type=""image/jpg"" href=""/img/favicon.jpg""/>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/normalize/8.0.1/normalize.min.css"">
    <link rel=""stylesheet"" href=""https://use.fontawesome.com/releases/v5.0.13/css/all.css"">
    <link rel=""stylesheet"" href=""/css/HomePage.css"">
    <link rel=""stylesheet"" href=""/css/ListProblemsPage.css"">
    <link rel=""stylesheet"" href=""/css/ProblemPage.css"">
    <link rel=""stylesheet"" href=""/css/Layout.css"">
    <link rel=""stylesheet"" href=""/css/Create-EditProblemPage.css"">
    <link rel=""stylesheet"" href=""/css/SubmitProblemPage.css"">
    <link rel=""stylesheet"" href=""/css/Base.css"">
    <link rel=""stylesheet"" href=""/css/LoginPage.css"">
    <link rel=""stylesheet"" href=""/css/SignUpPage.css"">
    <link rel=""stylesheet"" href=""/css/SubmissionPage.css"">
    <script type=""text/javascript"" src=""/ckeditor/ckeditor.js"" charset=""utf-8""></script>
    <link rel=""stylesheet"" href=""//cdnjs.cloudflare.com/ajax/libs/highl");
                WriteLiteral(@"ight.js/10.7.1/styles/vs.min.css"">
    <script src=""//cdnjs.cloudflare.com/ajax/libs/highlight.js/10.7.1/highlight.min.js""></script>
    <script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-AMS-MML_HTMLorMML""></script>

    <script src=""/codemirror-5.60.0/lib/codemirror.js""></script>
    <link rel=""stylesheet"" href=""/codemirror-5.60.0/lib/codemirror.css"">
    <script src=""/codemirror-5.60.0/mode/clike/clike.js""></script>
    <script src=""/codemirror-5.60.0/addon/edit/closebrackets.js""></script>
    <script src = ""/codemirror-5.60.0/addon/fold/foldcode.js""></script>
    <script src = ""/codemirror-5.60.0/addon/fold/foldgutter.js""></script>
    <script src = ""/codemirror-5.60.0/addon/fold/brace-fold.js""></script>
    <link rel=""stylesheet"" href=""/codemirror-5.60.0/addon/fold/foldgutter.css"">
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49624410c57db478b2b62bb19c738f6e44f269fa8899", async() => {
                WriteLiteral(@"
    <div class=""AppContainer"">
        <header class = ""AppHeader"">
            <div class=""grid "">
                <div class=""AppHeader_Row grid_row"">
                    <ul class=""AppHeader_List"">
                        <li class=""AppHeader_Item"">
                            <div class=""AppHeader_Logo"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49624410c57db478b2b62bb19c738f6e44f269fa9519", async() => {
                    WriteLiteral("<img src=\"/img/logo.png\"");
                    BeginWriteAttribute("alt", " alt=\"", 2537, "\"", 2543, 0);
                    EndWriteAttribute();
                    WriteLiteral(">");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
                WriteLiteral(@"
                            </div>
                        </li>
                        <li class=""AppHeader_Item"">
                            <div class=""AppHeader_Text"">
                                <a href=""/"" class =""AppHeader_Link"" >Trang Chủ</a>
                            </div>
                        </li>
                        <li class=""AppHeader_Item"">
                            <div class=""AppHeader_Text"">
                                <a href=""/ListProblems"" class =""AppHeader_Link"" >Bài Tập</a>
                            </div>
                        </li>
                        <li class=""AppHeader_Item"">
                            <div class=""AppHeader_Text"">
                                <a href=""/ListSubmissions"" class =""AppHeader_Link"" >Bài nộp</a>
                            </div>
                        </li>
                        <li class=""AppHeader_Item"">
                            <div class=""AppHeader_Text"">
                                <a ");
                WriteLiteral("href=\"/\" class =\"AppHeader_Link\" >Bài viết</a>\r\n                            </div>\r\n                        </li>\r\n                    </ul>\r\n                    <ul class=\"AppHeader_List\">\r\n");
#nullable restore
#line 67 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                         if(string.IsNullOrEmpty(Context.Session.GetString("accountName")) == false)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <li class=""AppHeader_Item"">
                                <div class=""AppHeader_BellIcon"">
                                    <i class=""fas fa-bell""></i>
                                    <div class=""AppHeader_Dropdown"">
                                        <ul class=""AppHeader_Dropdown_List"">
                                            <li class=""AppHeader_Dropdown_Item"">
                                                <a class=""AppHeader_Dropdown_Link""");
                BeginWriteAttribute("href", " href=\"", 4393, "\"", 4400, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                                    <p class=""AppHeader_NotiText"">Alo alo alo alo</p>
                                                </a>
                                            </li>
                                            <li class=""AppHeader_Dropdown_Item"">
                                                <a class=""AppHeader_Dropdown_Link""");
                BeginWriteAttribute("href", " href=\"", 4776, "\"", 4783, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                                    <p class=""AppHeader_NotiText"">Alo alo alo alo</p>
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </li>
                            <li class=""AppHeader_Item"">
                                <div class=""AppHeader_AvarIcon"">
                                    <i class=""fas fa-user-circle""></i>
                                    <div class=""AppHeader_Dropdown"">
                                        <ul class=""AppHeader_Dropdown_List"">
                                            <li class=""AppHeader_Dropdown_Item"">
                                                <a class=""AppHeader_Dropdown_Link"" href=""/"">
                                                    <i class=""AppHeader_Dropdown_Icon fas fa-user""></i>
                       ");
                WriteLiteral("                             ");
#nullable restore
#line 96 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                                               Write(Context.Session.GetString("accountName"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                </a>\r\n                                            </li>\r\n                                            <li class=\"AppHeader_Dropdown_Item\">\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49624410c57db478b2b62bb19c738f6e44f269fa15608", async() => {
                    WriteLiteral("\r\n                                                    <i class=\"AppHeader_Dropdown_Icon far fa-edit\"></i>\r\n                                                    Đăng bài\r\n                                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                            </li>
                                            <li class=""AppHeader_Dropdown_Item"">
                                                <a class=""AppHeader_Dropdown_Link"" href=""/Account/Logout"">
                                                    <i class=""AppHeader_Dropdown_Icon fas fa-sign-out-alt""></i>
                                                    Đăng xuất
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </li>
");
#nullable restore
#line 115 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <li class=""AppHeader_Item"">
                                <a href=""/Account/Login"" class = ""Login_Link"">Đăng nhập</a>
                            </li>
                            <li class=""AppHeader_Item"">
                                <a href=""/Account/SignUp"" class = ""Register_Link"">Đăng ký</a>
                            </li>
");
#nullable restore
#line 124 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n        </header>\r\n        <div class=\"AppBody\">\r\n            ");
#nullable restore
#line 130 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </div>
        <footer>
            <div class=""grid"">
                <div class=""grid_row"">
                    <div class=""grid_column"">
                        <div class=""AppFooter"">
                            <p><a href=""/"" class=""AppFooter_Link"">CodeTop1</a> (c) Based on DOMjudge 5.1.3</p>
                            <p>Developed by Tran Nhu Tri - Phan Dinh Khoi - Le Huynh Nhat Long - Do Tan Truong Sanh</p>
                            <p>University of Science and Technology - University of Danang</p>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    </div>
    <script>
            MathJax.Hub.Config({
              tex2jax: {inlineMath: [['$','$'], ['\\(','\\)']]}
            });
            window.addEventListener('load', (event) => {
                document.querySelectorAll('pre code').forEach((block) => {
                    if(block.classList == """")
                        block.classList.add(""");
                WriteLiteral(@"plaintext"");
                    hljs.highlightBlock(block);
                });
            });
    </script>
    <script>
        var submissionID = document.getElementsByClassName(""SubmissionID"");
        for(let i = 0; i < submissionID.length; i++)
        {
            submissionID[i].addEventListener('click', function()
            {
                var overlay = document.querySelector("".Overlay"");
                overlay.classList.add(""Overlay--active"");
            })
        }
    </script>
    ");
#nullable restore
#line 169 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
Write(await RenderSectionAsync("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
