#pragma checksum "D:\Web\PBL3\Views\Shared\_ListComments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e64f2ba353253229b8b0a3dd092ad456c06e237d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ListComments), @"mvc.1.0.view", @"/Views/Shared/_ListComments.cshtml")]
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
#line 1 "D:\Web\PBL3\Views\Shared\_ListComments.cshtml"
using PBL3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e64f2ba353253229b8b0a3dd092ad456c06e237d", @"/Views/Shared/_ListComments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88ef4445784557569207a2fe6f7175411bc82564", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ListComments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Comment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Web\PBL3\Views\Shared\_ListComments.cshtml"
 if(Model != null)
{
    for(int i = 0; i < Model.Count; i++)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Web\PBL3\Views\Shared\_ListComments.cshtml"
   Write(await Html.PartialAsync("_Comment", Model[i]));

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Web\PBL3\Views\Shared\_ListComments.cshtml"
                                                      ;
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"">

    function LoadCommentChild(commentId)
    {
        $.ajax({url: ""https://localhost:5001/Comment/CommentChild/"" + commentId, success: function(result){
            $('#comment_child' + commentId).html(result);
        }});
        $(""#comment-load-child"" + commentId).css(""display"", ""none"");
    }

    function LoadCommentBox(commentId)
    {
        if($(""#editor"" + commentId).attr('data-first') == ""1"")
        {
            CKEDITOR.replace('editor' + commentId, {
                height: '200px',
            });
            $(""#editor"" + commentId).attr('data-first', ""0"");
        }
        $(""#comment-box"" + commentId).css(""display"", ""block"");
        document.querySelector(""#comment-box"" + commentId).scrollIntoView({ behavior: 'smooth', block: 'center' });
    }

    function CloseCommentBox(commentId)
    {
        $(""#comment-box"" + commentId).css(""display"", ""none"");
    }

    function PostCommentData(commentId, postId)
    {
        for ");
            WriteLiteral(@"( instance in CKEDITOR.instances)
            CKEDITOR.instances[instance].updateElement();

        var content = document.getElementById(""editor"" + commentId).value;

        let data = new URLSearchParams();
        data.append(""rootCommentID"", commentId);
        data.append(""postID"", postId);
        data.append(""content"", content);

        CKEDITOR.instances[""editor"" + commentId].setData('');

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
            if(document.querySelector('#comment_child' + commentId) != null)
            {
                $('#comment_child' + commentId).append(data);
            }
            else
            {
                $('#comment' + commentId).parent().append(data);
            }
            $(""#comment-box"" + commentId).c");
            WriteLiteral(@"ss(""display"", ""none"");
        })
        .catch(err => console.log(err));

        return false;
    }
    function deleteComment(commentId)
    {
        let data = new URLSearchParams();
        data.append(""id"", commentId);
        fetch(""https://localhost:5001/Comment/DeleteComment"", {
            method :'post',
            body : data
        })
        .then(res => res.text())
        .then(data =>{;
            if(data == ""true"")
            {
                $(""#comment"" + commentId).css(""display"", ""none"");
                $(""#comment_tool"" + commentId).css(""display"", ""none"");
            }
        })
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Comment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
