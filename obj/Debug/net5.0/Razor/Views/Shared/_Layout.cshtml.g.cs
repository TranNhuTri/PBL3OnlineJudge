#pragma checksum "D:\Web\PBL3\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d569e9927bed943b6d18b49efa8e1e8c34a5de0"
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
using PBL3.DTO;

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
#nullable restore
#line 6 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using PBL3.General;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d569e9927bed943b6d18b49efa8e1e8c34a5de0", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58fbd7b8abab6ff8cf758a0fa310e6c6feef7956", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("appHeader_link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
  
    var accountName = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d569e9927bed943b6d18b49efa8e1e8c34a5de05045", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
#nullable restore
#line 9 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
    <link rel=""shortcut icon"" type=""image/jpg"" href=""/img/favicon.jpg""/>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/normalize/8.0.1/normalize.min.css"">
    <link rel=""stylesheet"" href=""https://use.fontawesome.com/releases/v5.0.13/css/all.css"">
    <link rel=""stylesheet"" href=""/css/Home.css"">
    <link rel=""stylesheet"" href=""/css/ListProblems.css"">
    <link rel=""stylesheet"" href=""/css/Problem.css"">
    <link rel=""stylesheet"" href=""/css/Layout.css"">
    <link rel=""stylesheet"" href=""/css/SubmitProblem.css"">
    <link rel=""stylesheet"" href=""/css/Base.css"">
    <link rel=""stylesheet"" href=""/css/Login.css"">
    <link rel=""stylesheet"" href=""/css/SignUp.css"">
    <link rel=""stylesheet"" href=""/css/ListSubmissions.css"">
    <link rel=""stylesheet"" href=""/css/ListObjects.css"">
    <link rel=""stylesheet"" href=""/css/General.css"">
    
    <script type=""text/javascript"" src=""/ckeditor/ckeditor.js"" charset=""utf-8""></script>
    
    <link rel=""stylesheet"" href=""//cdnjs");
                WriteLiteral(@".cloudflare.com/ajax/libs/highlight.js/10.7.1/styles/vs.min.css"">
    <script src=""//cdnjs.cloudflare.com/ajax/libs/highlight.js/10.7.1/highlight.min.js""></script>

    <script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-AMS-MML_HTMLorMML""></script>

    <script src=""/codemirror-5.60.0/lib/codemirror.js""></script>
    <link rel=""stylesheet"" href=""/codemirror-5.60.0/lib/codemirror.css"">
    <script src=""/codemirror-5.60.0/mode/clike/clike.js""></script>
    <script src=""/codemirror-5.60.0/mode/python/python.js""></script>

    <script src=""/codemirror-5.60.0/addon/edit/closebrackets.js""></script>
    <script src = ""/codemirror-5.60.0/addon/fold/foldcode.js""></script>
    <script src = ""/codemirror-5.60.0/addon/fold/foldgutter.js""></script>
    <script src = ""/codemirror-5.60.0/addon/fold/brace-fold.js""></script>
    <link rel=""stylesheet"" href=""/codemirror-5.60.0/addon/fold/foldgutter.css"">
    <script src=""https://cdnjs.cloudflare.com/aja");
                WriteLiteral(@"x/libs/jquery/3.6.0/jquery.min.js""></script>
    
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/slim-select/1.27.0/slimselect.min.js""></script>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/slim-select/1.27.0/slimselect.min.css""/>

    <script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.2.1/chart.min.js""></script>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d569e9927bed943b6d18b49efa8e1e8c34a5de08924", async() => {
                WriteLiteral(@"
    <div class=""appContainer"">
        <header class = ""appHeader"">
            <div class=""grid "">
                <div class=""appHeader_row grid_row"">
                    <div class=""grid_column"" style=""display: flex; justify-content: space-between;"">
                        <ul class=""appHeader_list"">
                            <li class=""appHeader_item"">
                                <div class=""appHeader_logo"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d569e9927bed943b6d18b49efa8e1e8c34a5de09666", async() => {
                    WriteLiteral("<img src=\"/img/logo.png\"");
                    BeginWriteAttribute("alt", " alt=\"", 3212, "\"", 3218, 0);
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
                WriteLiteral("\r\n                                </div>\r\n                            </li>\r\n                            <li");
                BeginWriteAttribute("class", " class=\"", 3332, "\"", 3446, 2);
                WriteAttributeValue("", 3340, "appHeader_item", 3340, 14, true);
#nullable restore
#line 61 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
WriteAttributeValue(" ", 3354, Html.IsSelected(actions: "Index", controllers: "Home", cssClass: "appHeader_item--active"), 3355, 91, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""appHeader_text"">
                                    <a href=""/"" class =""appHeader_link"" >Trang Chủ</a>
                                </div>
                            </li>
                            <li");
                BeginWriteAttribute("class", " class=\"", 3706, "\"", 3823, 2);
                WriteAttributeValue("", 3714, "appHeader_item", 3714, 14, true);
#nullable restore
#line 66 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
WriteAttributeValue(" ", 3728, Html.IsSelected(actions: "Page", controllers: "Problems", cssClass: "appHeader_item--active"), 3729, 94, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""appHeader_text"">
                                    <a href=""/Problems"" class =""appHeader_link"" >Bài Tập</a>
                                </div>
                            </li>
                            <li");
                BeginWriteAttribute("class", " class=\"", 4089, "\"", 4209, 2);
                WriteAttributeValue("", 4097, "appHeader_item", 4097, 14, true);
#nullable restore
#line 71 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
WriteAttributeValue(" ", 4111, Html.IsSelected(actions: "Page", controllers: "Submissions", cssClass: "appHeader_item--active"), 4112, 97, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""appHeader_text"">
                                    <a href=""/Submissions"" class =""appHeader_link"" >Bài nộp</a>
                                </div>
                            </li>
                            <li class=""appHeader_item"">
                                <div class=""appHeader_text"">
                                    <a href=""/"" class =""appHeader_link"" >Bài viết</a>
                                </div>
                            </li>
                        </ul>
                        <ul class=""appHeader_list"">
");
#nullable restore
#line 83 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                             if(string.IsNullOrEmpty(Context.Session.GetString("AccountName")) == false)
                            {
                                accountName = Context.Session.GetString("AccountName");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <li class=""appHeader_item"">
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
                                    ");
                WriteLiteral(@"        <ul class=""appHeader_dropdown_list"">
                                                <a class=""appHeader_dropdown_link"" href=""/"">
                                                    <li class=""appHeader_dropdown_item"">
                                                        <i class=""appHeader_dropdown_icon fas fa-user""></i>
                                                        ");
#nullable restore
#line 104 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                                                   Write(Context.Session.GetString("AccountName"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                    </li>
                                                </a>
                                                <a class=""appHeader_dropdown_link"" href=""/Admin"">
                                                    <li class=""appHeader_dropdown_item"">
                                                        <i class=""appHeader_dropdown_icon fas fa-cogs""></i>
                                                        Admin
                                                    </li>
                                                </a>
                                                <a class=""appHeader_dropdown_link"" href=""/Logout"">
                                                    <li class=""appHeader_dropdown_item"">
                                                        <i class=""appHeader_dropdown_icon fas fa-sign-out-alt""></i>
                                                        Đăng xuất
                                                    </li>
  ");
                WriteLiteral("                                              </a>\r\n                                            </ul>\r\n                                        </div>\r\n                                    </div>\r\n                                </li>\r\n");
#nullable restore
#line 123 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <li class=""appHeader_item"">
                                    <a href=""/Home/Login"" class = ""login_link"">Đăng nhập</a>
                                </li>
                                <li class=""appHeader_item"">
                                    <a href=""/Account/SignUp"" class = ""register_link"">Đăng ký</a>
                                </li>
");
#nullable restore
#line 132 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </header>\r\n        <div class=\"appBody\">\r\n            ");
#nullable restore
#line 139 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
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
                        <div class=""appFooter"">
                            <p><a href=""/"" class=""appFooter_link"">CodeTop1</a></p>
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
                        block.classList.add(""plaintext"");
              ");
                WriteLiteral(@"      hljs.highlightBlock(block);
                });
            });
    </script>
    <script>
        function showNotifications()
        {
            $('.appHeader_notifications_dropdown').toggle();
        }

        function showUserTool()
        {
            $('.appHeader_dropdown').toggle();
        }

        fetch(""https://localhost:5001/Notification/ListNotifications?accountName="" + '");
#nullable restore
#line 178 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                                                                                 Write(accountName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"')
        .then(res => res.text())
        .then(data => {
            if(data == """")
            {
                $('#notification-list').html('<p style = ""text-align: center;margin: 0;font-size: 16rem; padding: 10px 0;"">Không có thông báo mới !</p>')
                $("".number_notifi"").html(0);
            }
            else
            {
                $('#notification-list').html(data);
            }
        })

        function getNotificationData(accountName)
        {   
            fetch(""https://localhost:5001/Notification/GetNumberUnSeenNotification?accountName="" + accountName)
            .then(res => res.text())
            .then(numberOfNotifications => {
                if(numberOfNotifications >= 0)
                {
                    fetch(""https://localhost:5001/Notification/ListNotifications?accountName="" + accountName)
                    .then(res => res.text())
                    .then(data => {
                        if(data == """")
                        ");
                WriteLiteral(@"{
                            $('#notification-list').html('<p style = ""text-align: center;margin: 0;font-size: 16rem; padding: 10px 0;"">Không có thông báo mới !</p>')
                        }
                        else
                        {
                            $('#notification-list').html(data);
                        }
                    })
                    
                    if(numberOfNotifications > 0)
                    {
                        $("".number_notifi"").html(numberOfNotifications);
                        $("".number_notifi"").css(""opacity"", ""1"");
                    }
                    else
                    {
                        $("".number_notifi"").css(""opacity"", ""0"");
                        $("".number_notifi"").html(0);
                    }
                }

                setTimeout(function()
                {
                    getNotificationData('");
#nullable restore
#line 226 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                                    Write(accountName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\')\r\n                }, 4000);\r\n            })\r\n        }\r\n        getNotificationData(\'");
#nullable restore
#line 230 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
                        Write(accountName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
    </script>
    <script>
        window.addEventListener('click', function(e){

            var bellIcon = document.querySelector("".appHeader_bellIcon"");
            var avarIcon = document.querySelector("".appHeader_avarIcon"");

            if(bellIcon != null)
            {
                let top = bellIcon.offsetTop, left = bellIcon.offsetLeft;
                let height = bellIcon.offsetHeight, width = bellIcon.offsetWidth;
                if(e.clientX < left || e.clientX > left + width || e.clientY < top || e.clientY > top + height)
                    $('.appHeader_notifications_dropdown').css(""display"", ""none"");
            }
            if(avarIcon != null)
            {
                let top = avarIcon.offsetTop, left = avarIcon.offsetLeft;
                let height = avarIcon.offsetHeight, width = avarIcon.offsetWidth;
                if(e.clientX < left || e.clientX > left + width || e.clientY < top || e.clientY > top + height)
                    $('.appHeader_dropdown");
                WriteLiteral("\').css(\"display\", \"none\");\r\n            }\r\n        })\r\n    </script>\r\n    ");
#nullable restore
#line 254 "D:\Web\PBL3\Views\Shared\_Layout.cshtml"
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
