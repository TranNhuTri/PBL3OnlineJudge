#pragma checksum "D:\Web\PBL3\Views\Notification\ListNotifications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5b294c385734b3ef248c56d7cde53d2f3687b5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification_ListNotifications), @"mvc.1.0.view", @"/Views/Notification/ListNotifications.cshtml")]
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
#line 3 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using PBL3.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Web\PBL3\Views\_ViewImports.cshtml"
using PBL3.General;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Web\PBL3\Views\Notification\ListNotifications.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5b294c385734b3ef248c56d7cde53d2f3687b5d", @"/Views/Notification/ListNotifications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88ef4445784557569207a2fe6f7175411bc82564", @"/Views/_ViewImports.cshtml")]
    public class Views_Notification_ListNotifications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Notification>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Web\PBL3\Views\Notification\ListNotifications.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Web\PBL3\Views\Notification\ListNotifications.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"appHeader_dropdown_item\">\r\n        <a class=\"appHeader_dropdown_link\"");
            BeginWriteAttribute("href", " href=\"", 191, "\"", 198, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <p class=\"appHeader_notiText\">");
#nullable restore
#line 10 "D:\Web\PBL3\Views\Notification\ListNotifications.cshtml"
                                     Write(Html.Raw(@item.content));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </a>\r\n");
#nullable restore
#line 12 "D:\Web\PBL3\Views\Notification\ListNotifications.cshtml"
         if(item.seen == false)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"appHeader_dropdown_item-dot\"></span>\r\n");
#nullable restore
#line 15 "D:\Web\PBL3\Views\Notification\ListNotifications.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </li>\r\n");
#nullable restore
#line 17 "D:\Web\PBL3\Views\Notification\ListNotifications.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Notification>> Html { get; private set; }
    }
}
#pragma warning restore 1591
