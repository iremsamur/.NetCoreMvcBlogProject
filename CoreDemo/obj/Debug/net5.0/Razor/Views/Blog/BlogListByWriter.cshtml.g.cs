#pragma checksum "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3069e548d622b9e812550c669fea3701b2bc9975"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_BlogListByWriter), @"mvc.1.0.view", @"/Views/Blog/BlogListByWriter.cshtml")]
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
#nullable restore
#line 1 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3069e548d622b9e812550c669fea3701b2bc9975", @"/Views/Blog/BlogListByWriter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0e2cbebe4b7cca4b09168dd159f601192fafdf0", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_BlogListByWriter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Blog>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
  
    ViewData["Title"] = "BlogListByWriter";
    Layout = "~/Views/Shared/WriterLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Yazarın Blogları</h1>
<table class=""table table-bordered"">
    <tr>
        <th>#</th>
        <th>Blog Başlığı</th>
        <th>Oluşturma Tarihi</th>
        <th>Kategori</th>
        <th>Durum</th>
        <th>Sil</th>
        <th>Düzenle</th>

    </tr>
");
#nullable restore
#line 20 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
     foreach(var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 24 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
               Write(item.BlogID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 27 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
               Write(item.BlogTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 30 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
               Write(item.BlogCreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 33 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
               Write(item.CategoryID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 36 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
               Write(item.BlogStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </td>
                <td>
                    <a href=""#"" class=""btn btn-danger"">Sil</a>
                </td>
                <td>
                    <a href=""#"" class=""btn btn-warning"">Düzenle</a>
                </td>
            </tr>
");
#nullable restore
#line 45 "C:\Users\User\Desktop\C# Projects\CoreDemo\CoreDemo\Views\Blog\BlogListByWriter.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<a href=\"#\" class=\"btn btn-primary\">Yeni Blog Oluştur</a>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Blog>> Html { get; private set; }
    }
}
#pragma warning restore 1591