#pragma checksum "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "032f2ada4ada2b5ab6cc30715164f0d6e819d7cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Comment), @"mvc.1.0.view", @"/Views/Shared/_Comment.cshtml")]
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
#line 1 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"032f2ada4ada2b5ab6cc30715164f0d6e819d7cd", @"/Views/Shared/_Comment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f33869ee829845d5f268fe80b750ffa3addb3d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Comment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Comment>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Comments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: #fff; text-decoration: none;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"comment_item\"");
            BeginWriteAttribute("id", " id = \"", 61, "\"", 86, 2);
            WriteAttributeValue("", 68, "comment", 68, 7, true);
#nullable restore
#line 3 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 75, Model.ID, 75, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div style=\"display: flex;\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 134, "\"", 141, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 6 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
             if(!String.IsNullOrEmpty(Model.account.avar))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class = \"comment_avar\"");
            BeginWriteAttribute("style", " style=\"", 263, "\"", 314, 4);
            WriteAttributeValue("", 271, "background-image:", 271, 17, true);
            WriteAttributeValue(" ", 288, "url(", 289, 5, true);
#nullable restore
#line 8 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 293, Model.account.avar, 293, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 312, ");", 312, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n");
#nullable restore
#line 9 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class = \"comment_avar\"></div>\r\n");
#nullable restore
#line 13 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </a>\r\n        <div class=\"comment_container\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 508, "\"", 515, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"comment_author\">\r\n                ");
#nullable restore
#line 17 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
           Write(Model.account.accountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </a>\r\n            <div class=\"comment_content\">\r\n                ");
#nullable restore
#line 20 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
           Write(Html.Raw(@Model.content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"comment_dot\">\r\n        <i class=\"fas fa-ellipsis-h\"></i>\r\n        <div");
            BeginWriteAttribute("id", " id=\"", 824, "\"", 859, 2);
            WriteAttributeValue("", 829, "comment_extern-tool", 829, 19, true);
#nullable restore
#line 26 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 848, Model.ID, 848, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"comment_extern-tool\">\r\n            <span class = \"delete_comment\"");
            BeginWriteAttribute("onclick", " onclick=\"", 933, "\"", 969, 3);
            WriteAttributeValue("", 943, "deleteComment(\'", 943, 15, true);
#nullable restore
#line 27 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 958, Model.ID, 958, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 967, "\')", 967, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Xóa</span>\r\n");
#nullable restore
#line 28 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
             if(Context.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "Admin")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "032f2ada4ada2b5ab6cc30715164f0d6e819d7cd9001", async() => {
                WriteLiteral("\r\n                    <span class = \"edit_comment\">Sửa</span>\r\n                ");
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
#line 30 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
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
            WriteLiteral("\r\n");
#nullable restore
#line 33 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n");
#nullable restore
#line 36 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
     if(Model.likes.Where(p => p.status == true).ToList().Count == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"comment_likes\"");
            BeginWriteAttribute("id", " id = \"", 1470, "\"", 1501, 2);
            WriteAttributeValue("", 1477, "comment_likes", 1477, 13, true);
#nullable restore
#line 38 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 1490, Model.ID, 1490, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"opacity: 0;\">\r\n            <i class=\"fas fa-thumbs-up\"></i>\r\n            <span");
            BeginWriteAttribute("id", " id = \"", 1588, "\"", 1622, 2);
            WriteAttributeValue("", 1595, "comment_numlikes", 1595, 16, true);
#nullable restore
#line 40 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 1611, Model.ID, 1611, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 40 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
                                                Write(Model.likes.Where(p => p.status == true).ToList().Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n");
#nullable restore
#line 42 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"comment_likes\"");
            BeginWriteAttribute("id", " id = \"", 1763, "\"", 1794, 2);
            WriteAttributeValue("", 1770, "comment_likes", 1770, 13, true);
#nullable restore
#line 45 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 1783, Model.ID, 1783, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"opacity: 1;\">\r\n            <i class=\"fas fa-thumbs-up\"></i>\r\n            <span");
            BeginWriteAttribute("id", " id = \"", 1881, "\"", 1915, 2);
            WriteAttributeValue("", 1888, "comment_numlikes", 1888, 16, true);
#nullable restore
#line 47 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 1904, Model.ID, 1904, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 47 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
                                                Write(Model.likes.Where(p => p.status == true).ToList().Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n");
#nullable restore
#line 49 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div class=\"comment_tool\"");
            BeginWriteAttribute("id", " id = \"", 2038, "\"", 2068, 2);
            WriteAttributeValue("", 2045, "comment_tool", 2045, 12, true);
#nullable restore
#line 51 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 2057, Model.ID, 2057, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 52 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
      
        var accountID = 0;
        if(Context.User.Identity.IsAuthenticated)
        {
            accountID = Convert.ToInt32(Context.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
        }
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
     if(Model.likes.FirstOrDefault(p => p.accountID == accountID && p.status == true) == null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"comment_tool_like\"");
            BeginWriteAttribute("id", " id = \"", 2439, "\"", 2474, 2);
            WriteAttributeValue("", 2446, "comment_tool_like", 2446, 17, true);
#nullable restore
#line 61 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 2463, Model.ID, 2463, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 2475, "\"", 2509, 3);
            WriteAttributeValue("", 2485, "LikeComment(\'", 2485, 13, true);
#nullable restore
#line 61 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 2498, Model.ID, 2498, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2507, "\')", 2507, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Thích</span>\r\n");
#nullable restore
#line 62 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"comment_tool_like comment_tool_like--active\"");
            BeginWriteAttribute("id", " id = \"", 2614, "\"", 2649, 2);
            WriteAttributeValue("", 2621, "comment_tool_like", 2621, 17, true);
#nullable restore
#line 65 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 2638, Model.ID, 2638, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 2650, "\"", 2684, 3);
            WriteAttributeValue("", 2660, "LikeComment(\'", 2660, 13, true);
#nullable restore
#line 65 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 2673, Model.ID, 2673, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2682, "\')", 2682, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Thích</span>\r\n");
#nullable restore
#line 66 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
     if(Model.level < 3)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"comment_tool_reply\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2780, "\"", 2817, 3);
            WriteAttributeValue("", 2790, "LoadCommentBox(\'", 2790, 16, true);
#nullable restore
#line 69 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 2806, Model.ID, 2806, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2815, "\')", 2815, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Trả lời</span>\r\n");
#nullable restore
#line 70 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"comment_tool_reply\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2899, "\"", 2947, 3);
            WriteAttributeValue("", 2909, "LoadCommentBox(\'", 2909, 16, true);
#nullable restore
#line 73 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 2925, Model.rootCommentID, 2925, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2945, "\')", 2945, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Trả lời</span>\r\n");
#nullable restore
#line 74 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
      
        var timeCreate = @DateTime.Now.Subtract(Model.timeCreate);
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
     if(timeCreate.Days/30 >= 9)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span>");
#nullable restore
#line 80 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
         Write(Model.timeCreate.ToString("dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 81 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
    }
    else
    {
        if(timeCreate.Days/30 > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span>");
#nullable restore
#line 86 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
              Write(timeCreate.Days/30);

#line default
#line hidden
#nullable disable
            WriteLiteral(" tháng trước</span>\r\n");
#nullable restore
#line 87 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
             if(timeCreate.Days > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>");
#nullable restore
#line 92 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
                 Write(timeCreate.Days);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ngày trước</span>\r\n");
#nullable restore
#line 93 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
                 if(timeCreate.Hours > 0){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>");
#nullable restore
#line 97 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
                     Write(timeCreate.Hours);

#line default
#line hidden
#nullable disable
            WriteLiteral(" giờ trước</span>\r\n");
#nullable restore
#line 98 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
                } 
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>");
#nullable restore
#line 101 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
                     Write(timeCreate.Minutes);

#line default
#line hidden
#nullable disable
            WriteLiteral(" phút trước</span>\r\n");
#nullable restore
#line 102 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
             
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 107 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
     if(Model.child.Count > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"comment-load-child\"");
            BeginWriteAttribute("id", " id = \"", 3852, "\"", 3888, 2);
            WriteAttributeValue("", 3859, "comment-load-child", 3859, 18, true);
#nullable restore
#line 109 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 3877, Model.ID, 3877, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 3889, "\"", 3928, 3);
            WriteAttributeValue("", 3899, "LoadCommentChild(\'", 3899, 18, true);
#nullable restore
#line 109 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 3917, Model.ID, 3917, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3926, "\')", 3926, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Xem phản hồi</span>\r\n");
#nullable restore
#line 110 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 111 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
     if(Model.level < 3)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"comment_child\"");
            BeginWriteAttribute("id", " id = \"", 4025, "\"", 4056, 2);
            WriteAttributeValue("", 4032, "comment_child", 4032, 13, true);
#nullable restore
#line 113 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 4045, Model.ID, 4045, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n");
#nullable restore
#line 115 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"comment_box\"");
            BeginWriteAttribute("id", " id = \"", 4111, "\"", 4140, 2);
            WriteAttributeValue("", 4118, "comment-box", 4118, 11, true);
#nullable restore
#line 116 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 4129, Model.ID, 4129, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <i class=\"fas fa-times comment_box_icon\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4192, "\"", 4230, 3);
            WriteAttributeValue("", 4202, "CloseCommentBox(\'", 4202, 17, true);
#nullable restore
#line 117 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 4219, Model.ID, 4219, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4228, "\')", 4228, 2, true);
            EndWriteAttribute();
            WriteLiteral("></i>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "032f2ada4ada2b5ab6cc30715164f0d6e819d7cd26572", async() => {
                WriteLiteral("\r\n            <textarea name=\"content\"");
                BeginWriteAttribute("id", " id=\"", 4354, "\"", 4376, 2);
                WriteAttributeValue("", 4359, "editor", 4359, 6, true);
#nullable restore
#line 119 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
WriteAttributeValue("", 4365, Model.ID, 4365, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" data-first = \"1\" cols=\"30\" rows=\"10\"");
                BeginWriteAttribute("value", " value = \"", 4414, "\"", 4424, 0);
                EndWriteAttribute();
                WriteLiteral("></textarea>\r\n            <button class=\"button comment_button\">Gửi</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onsubmit", 7, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4262, "return", 4262, 6, true);
            AddHtmlAttributeValue(" ", 4268, "PostCommentData(\'", 4269, 18, true);
#nullable restore
#line 118 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
AddHtmlAttributeValue("", 4286, Model.ID, 4286, 9, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 4295, "\',", 4295, 2, true);
            AddHtmlAttributeValue(" ", 4297, "\'", 4298, 2, true);
#nullable restore
#line 118 "D:\Web\PBL3\PBL3OnlineJudge\Views\Shared\_Comment.cshtml"
AddHtmlAttributeValue("", 4299, Model.postID, 4299, 13, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 4312, "\')", 4312, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Comment> Html { get; private set; }
    }
}
#pragma warning restore 1591