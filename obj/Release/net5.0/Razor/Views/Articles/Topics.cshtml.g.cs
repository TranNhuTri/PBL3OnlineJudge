#pragma checksum "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d1788975b8d7d42cabf51598df941ca97705e6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Articles_Topics), @"mvc.1.0.view", @"/Views/Articles/Topics.cshtml")]
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
#line 4 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d1788975b8d7d42cabf51598df941ca97705e6d", @"/Views/Articles/Topics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Articles_Topics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Topic>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("topic-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
  
    ViewData["Title"] = "Ch??? ????? b??i vi???t";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"topic-list\">\r\n    <div class=\"grid\">\r\n");
#nullable restore
#line 8 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
         for(int i = 0; i < Model.Count; i++)
        {
            if(i % 4 == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"grid_row topic_row\">\r\n                    <div class=\"grid_column-3\"> \r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d1788975b8d7d42cabf51598df941ca97705e6d4903", async() => {
                WriteLiteral("\r\n                            <div class=\"topic-item__img\">\r\n                                <img");
                BeginWriteAttribute("src", " src=\"", 538, "\"", 567, 1);
#nullable restore
#line 16 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
WriteAttributeValue("", 544, Model[i].describeImage, 544, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 568, "\"", 574, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"topic-item__dicription\">\r\n                                <h3 class=\"topic-item__title\">");
#nullable restore
#line 19 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
                                                         Write(Model[i].name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-topic", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
                                                   WriteLiteral(Model[i].name);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["topic"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-topic", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["topic"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("    \r\n                    </div>\r\n");
#nullable restore
#line 23 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
                      
                        i ++;
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
                     while(i < Model.Count && i % 4 != 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"grid_column-3\"> \r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d1788975b8d7d42cabf51598df941ca97705e6d8796", async() => {
                WriteLiteral("\r\n                                <div class=\"topic-item__img\">\r\n                                    <img");
                BeginWriteAttribute("src", " src=\"", 1283, "\"", 1312, 1);
#nullable restore
#line 31 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
WriteAttributeValue("", 1289, Model[i].describeImage, 1289, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 1313, "\"", 1319, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                </div>\r\n                                <div class=\"topic-item__dicription\">\r\n                                    <h3 class=\"topic-item__title\">");
#nullable restore
#line 34 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
                                                             Write(Model[i].name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-topic", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
                                                       WriteLiteral(Model[i].name);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["topic"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-topic", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["topic"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("    \r\n                        </div>\r\n");
#nullable restore
#line 38 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
                        i ++;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 41 "D:\Web\PBL3\PBL3OnlineJudge\Views\Articles\Topics.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Topic>> Html { get; private set; }
    }
}
#pragma warning restore 1591
