#pragma checksum "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "556037939c58732dff55862a0eb07dd5caa37bb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ActInfo), @"mvc.1.0.view", @"/Views/Home/ActInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ActInfo.cshtml", typeof(AspNetCore.Views_Home_ActInfo))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/_ViewImports.cshtml"
using Belt_exam;

#line default
#line hidden
#line 2 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/_ViewImports.cshtml"
using Belt_exam.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"556037939c58732dff55862a0eb07dd5caa37bb8", @"/Views/Home/ActInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc0a8365b1e6a5378c1e1b864448770e27b13e09", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ActInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Belt_exam.Models.Wrapper>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
  
    bool Leave(List<Attending> myusers){
        foreach(var user in myusers){
            if(ViewBag.curruser.FirstName == user.ThisUser.FirstName){
                return true;
            }else{
                return false;
            }
            }
            return false;
        }

#line default
#line hidden
            BeginContext(330, 55, true);
            WriteLiteral("<a href=\"/home\">Home</a>\n<a href=\"/logout\">Logout</a>\n\n");
            EndContext();
#line 17 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
 if(@ViewBag.curract.Coordinator.FirstName == ViewBag.curruser.FirstName){

#line default
#line hidden
            BeginContext(460, 10, true);
            WriteLiteral("    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 470, "\"", 503, 2);
            WriteAttributeValue("", 477, "/remove/", 477, 8, true);
#line 18 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
WriteAttributeValue("", 485, ViewBag.curractid, 485, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(504, 26, true);
            WriteLiteral(">Delete Activity</a></td>\n");
            EndContext();
#line 19 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
}else{
    if(Leave(@ViewBag.curract.UsersAttending) == true){

#line default
#line hidden
            BeginContext(593, 10, true);
            WriteLiteral("    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 603, "\"", 635, 2);
            WriteAttributeValue("", 610, "/leave/", 610, 7, true);
#line 21 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
WriteAttributeValue("", 617, ViewBag.curractid, 617, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(636, 16, true);
            WriteLiteral(">Leave</a></td>\n");
            EndContext();
#line 22 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
}else{

#line default
#line hidden
            BeginContext(659, 10, true);
            WriteLiteral("    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 669, "\"", 700, 2);
            WriteAttributeValue("", 676, "/join/", 676, 6, true);
#line 23 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
WriteAttributeValue("", 682, ViewBag.curractid, 682, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(701, 15, true);
            WriteLiteral(">Join</a></td>\n");
            EndContext();
#line 24 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
}
}

#line default
#line hidden
            BeginContext(720, 20, true);
            WriteLiteral("\n\n\n<h1>Event Title: ");
            EndContext();
            BeginContext(741, 18, false);
#line 29 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
            Write(Model.OneAct.Title);

#line default
#line hidden
            EndContext();
            BeginContext(759, 23, true);
            WriteLiteral("</h1>\n<h4>Description: ");
            EndContext();
            BeginContext(783, 24, false);
#line 30 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
            Write(Model.OneAct.Description);

#line default
#line hidden
            EndContext();
            BeginContext(807, 23, true);
            WriteLiteral("</h4>\n<h5>Coordinator: ");
            EndContext();
            BeginContext(831, 34, false);
#line 31 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
            Write(Model.OneAct.Coordinator.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(865, 39, true);
            WriteLiteral("</h5>\n\n<h3>User\'s Attending:</h3>\n<ul>\n");
            EndContext();
#line 35 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
     foreach(var x in Model.OneAct.UsersAttending){

#line default
#line hidden
            BeginContext(956, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(969, 20, false);
#line 36 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
       Write(x.ThisUser.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(989, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 37 "/Users/AaronClare/Desktop/coding_dojo/C#/asp/Belt_exam/Views/Home/ActInfo.cshtml"
    }

#line default
#line hidden
            BeginContext(1001, 5, true);
            WriteLiteral("</ul>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Belt_exam.Models.Wrapper> Html { get; private set; }
    }
}
#pragma warning restore 1591
